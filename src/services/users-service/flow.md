# 🔄 Fluxo do Users Service

Este documento explica como o serviço de usuários foi estruturado e o motivo das decisões de design.

---

## Visão Geral da Arquitetura

```
┌─────────────────────────────────────────────────────────────────┐
│                        HTTP Request                              │
│                    (UsuariosController)                          │
└─────────────────────────────────────────────────────────────────┘
                                │
                                ▼
┌─────────────────────────────────────────────────────────────────┐
│                      Controller Layer                            │
│                  (UsuariosController.cs)                         │
│  - Recebe as requisições HTTP                                    │
│  - Valida parâmetros básicos                                     │
│  - Delega para o Service                                         │
│  - Retorna respostas HTTP apropriadas                            │
└─────────────────────────────────────────────────────────────────┘
                                │
                                ▼
┌─────────────────────────────────────────────────────────────────┐
│                      Service Layer                               │
│                    (UsuarioService.cs)                           │
│  - Lógica de negócio                                             │
│  - Validações de domínio                                         │
│  - Orquestra chamadas ao Repository                              │
└─────────────────────────────────────────────────────────────────┘
                                │
                                ▼
┌─────────────────────────────────────────────────────────────────┐
│                    Repository Layer                              │
│                  (UsuarioRepository.cs)                          │
│  - Abstração do acesso a dados                                   │
│  - Operações CRUD via Entity Framework                           │
│  - Isolamento do DbContext                                       │
└─────────────────────────────────────────────────────────────────┘
                                │
                                ▼
┌─────────────────────────────────────────────────────────────────┐
│                      Data Layer                                  │
│                  (ApplicationDbContext.cs)                       │
│  - Mapeamento ORM com Entity Framework                           │
│  - Comunicação com o banco de dados                              │
└─────────────────────────────────────────────────────────────────┘
```

---

## Componentes e Suas Responsabilidades

### 1. Controller (`UsuariosController.cs`)

**Responsabilidade:** Expor os endpoints da API e receber as requisições HTTP.

**Por que foi feito assim:**

- Segue o padrão RESTful com rotas claras (`/usuarios`)
- Utiliza `IActionResult` para retornar códigos HTTP apropriados
- Não possui acesso direto ao `DbContext` — delega tudo ao Service
- Separação clara entre "o que" (endpoint) e "como" (lógica)

**Métodos implementados:**

| Método HTTP | Endpoint         | Método do Controller  | Descrição                        |
| ----------- | ---------------- | --------------------- | -------------------------------- |
| `GET`       | `/usuarios`      | `GetAll()`            | Lista todos os usuários          |
| `GET`       | `/usuarios/{id}` | `GetById(id)`         | Retorna um usuário específico    |
| `POST`      | `/usuarios`      | `Create(dto)`         | Cria um novo usuário             |
| `PUT`       | `/usuarios/{id}` | `Update(id, dto)`     | Atualiza um usuário completo     |
| `PATCH`     | `/usuarios/{id}` | `Patch(id, patchDoc)` | Atualiza parcialmente um usuário |

---

### 2. DTO (`UsuarioDto.cs`)

**Responsabilidade:** Representar os dados que entram e saem da API.

**Por que foi feito assim:**

- Separa a estrutura de dados da API do modelo de domínio
- Permite evolução independente do modelo interno
- Evita expor propriedades internas desnecessárias (ex: `DataCriacao`)

```csharp
public class UsuarioDto
{
    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public string Email { get; set; }
    public string SenhaHash { get; set; }
    public int Status { get; set; } = 1; // Ativo por padrão
    public int? GerenteId { get; set; }
    public int? CargoId { get; set; }
    public int? DepartamentoId { get; set; }
}
```

---

### 3. Mapper (`UsuarioMapper.cs`)

**Responsabilidade:** Converter entre DTO e Model nos dois sentidos.

**Por que foi feito assim:**

- Mantém o Controller e o Service limpos
- Centraliza a lógica de transformação de dados
- Facilita manutenção quando a estrutura muda

```csharp
// DTO → Model (entrada de dados)
public static UsuarioModel ParaModel(UsuarioDto dto) { ... }

// Model → DTO (saída de dados / PATCH)
public static UsuarioDto ParaDto(UsuarioModel model) { ... }
```

---

### 4. Model (`UsuarioModel.cs`)

**Responsabilidade:** Representar a entidade de domínio com suas validações internas.

**Por que foi feito assim:**

- **Validação de Email:** Implementada no setter com `UsuarioValidator.EhEmailValido()`
- **Encapsulamento:** Propriedades privadas com validação no setter garantem integridade dos dados
- **Status padrão:** `Ativo (1)` por convenção

**Campos:**

| Campo            | Tipo       | Descrição                             |
| ---------------- | ---------- | ------------------------------------- |
| `Id`             | `int`      | Identificador único                   |
| `Nome`           | `string`   | Primeiro nome                         |
| `Sobrenome`      | `string`   | Sobrenome                             |
| `Email`          | `string`   | E-mail com validação no setter        |
| `SenhaHash`      | `string`   | Hash da senha                         |
| `Status`         | `int`      | `0 = Inativo`, `1 = Ativo`            |
| `DataCriacao`    | `DateTime` | Gerado automaticamente no Mapper      |
| `GerenteId`      | `int?`     | Referência ao gestor (nullable)       |
| `CargoId`        | `int?`     | Referência ao cargo (nullable)        |
| `DepartamentoId` | `int?`     | Referência ao departamento (nullable) |

---

### 5. Service (`UsuarioService.cs`)

**Responsabilidade:** Lógica de negócio — orquestra as operações delegando ao Repository.

**Por que foi feito assim:**

- Não acessa o banco diretamente — depende de `IUsuarioRepository`
- Facilita testes unitários (basta mockar o repository)
- Respeita o princípio da inversão de dependência (DIP — SOLID)

**Métodos:**

| Método               | Descrição                           |
| -------------------- | ----------------------------------- |
| `ObterTodos()`       | Retorna todos os usuários do banco  |
| `ObterPorId(id)`     | Retorna um usuário por ID ou `null` |
| `Adicionar(usuario)` | Persiste um novo usuário            |
| `Atualizar(usuario)` | Atualiza um usuário existente       |

---

### 6. Repository (`UsuarioRepository.cs`)

**Responsabilidade:** Abstração do acesso ao banco de dados via Entity Framework.

**Por que foi feito assim:**

- Isola o `DbContext` do restante da aplicação
- Usa `AsNoTracking()` em queries de leitura para melhor performance
- Chama `SaveChanges()` internamente — o Service não precisa saber disso
- Facilita trocar a fonte de dados futuramente sem alterar Service ou Controller

```csharp
public IReadOnlyList<UsuarioModel> ObterTodos()
{
    return _context.Usuarios
        .AsNoTracking()
        .ToList()
        .AsReadOnly();
}
```

---

### 7. DbContext (`ApplicationDbContext.cs`)

**Responsabilidade:** Mapeamento ORM e comunicação com o banco de dados.

```csharp
public DbSet<UsuarioModel> Usuarios { get; set; }
```

---

## Injeção de Dependência (`Program.cs`)

Todos os componentes são registrados com ciclo de vida `Scoped` — uma instância por requisição HTTP:

```csharp
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
```

## Fluxo de uma Requisição POST `/usuarios`

```
1. Cliente envia POST /usuarios com JSON
         │
         ▼
2. Controller recebe UsuarioDto
         │
         ▼
3. Mapper converte DTO → Model
   (Validações de domínio executadas aqui,
    ex: Email inválido lança ArgumentException)
         │
         ▼
4. Controller chama _service.Adicionar(model)
         │
         ▼
5. Service delega para _repository.Adicionar(model)
         │
         ▼
6. Repository persiste via EF e chama SaveChanges()
         │
         ▼
7. Controller retorna 201 Created
   com Location header apontando para GET /usuarios/{id}
```

---

## Fluxo de uma Requisição PATCH `/usuarios/{id}`

```
1. Cliente envia PATCH /usuarios/{id} com JsonPatchDocument
         │
         ▼
2. Controller verifica se o usuário existe via _service.ObterPorId(id)
         │
         ▼
3. Model é convertido para DTO via Mapper.ParaDto()
         │
         ▼
4. patchDoc.ApplyTo(dto) aplica apenas os campos enviados
         │
         ▼
5. DTO é reconvertido para Model via Mapper.ParaModel()
         │
         ▼
6. Service chama _repository.Atualizar(model)
         │
         ▼
7. Controller retorna 204 No Content
```

## O que Ainda Pode Melhorar

### 1. 🟡 FluentValidation no DTO

Atualmente as validações estão no setter do Model. O ideal é validar na entrada (DTO) antes do mapeamento:

```csharp
public class UsuarioDtoValidator : AbstractValidator<UsuarioDto>
{
    public UsuarioDtoValidator()
    {
        RuleFor(x => x.Email).EmailAddress();
        RuleFor(x => x.Nome).NotEmpty().MaximumLength(100);
    }
}
```

### 2. 🟡 Respostas Assíncronas (async/await)

Os métodos do Repository e Service podem ser migrados para `async/await` para não bloquear threads em I/O:

```csharp
public async Task<IReadOnlyList<UsuarioModel>> ObterTodosAsync()
{
    return await _context.Usuarios
        .AsNoTracking()
        .ToListAsync();
}
```

### 3. 🟡 Retornar DTO no lugar de Model

Os endpoints atualmente retornam `UsuarioModel` diretamente. O correto é retornar um DTO de resposta para não expor detalhes internos como `SenhaHash`.

### 4. 🟡 Tratamento Global de Exceções

Adicionar um middleware para capturar `ArgumentException` (lançada pelo setter de Email) e retornar `400 Bad Request` de forma padronizada, em vez de deixar o erro estourar.
