# 🔄 Fluxo do Users Service

Este documento explica como o serviço de usuários foi estruturado e o motivo das decisões de design.

---

## Visão Geral da Arquitetura

```
┌─────────────────────────────────────────────────────────────────┐
│                        HTTP Request                              │
│                    (UserController)                          │
└─────────────────────────────────────────────────────────────────┘
                                │
                                ▼
┌─────────────────────────────────────────────────────────────────┐
│                      Controller Layer                            │
│                  (UserController.cs)                         │
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
│                  (UserRepository.cs)                          │
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

### 1. Controller (`UserController.cs`)

**Responsabilidade:** Expor os endpoints da API e receber as requisições HTTP.

**Por que foi feito assim:**

- Segue o padrão RESTful com rotas claras (`/user`)
- Utiliza `IActionResult` para retornar códigos HTTP apropriados
- Não possui acesso direto ao `DbContext` — delega tudo ao Service
- Separação clara entre "o que" (endpoint) e "como" (lógica)

**Métodos implementados:**

| Método HTTP | Endpoint     | Método do Controller  | Descrição                        |
| ----------- | ------------ | --------------------- | -------------------------------- |
| `GET`       | `/user`      | `GetAll()`            | Lista todos os usuários          |
| `GET`       | `/user/{id}` | `GetById(id)`         | Retorna um usuário específico    |
| `POST`      | `/user`      | `Create(dto)`         | Cria um novo usuário             |
| `PUT`       | `/user/{id}` | `Update(id, dto)`     | Atualiza um usuário completo     |
| `PATCH`     | `/user/{id}` | `Patch(id, patchDoc)` | Atualiza parcialmente um usuário |

---

### 2. DTO (`UserDto.cs`)

**Responsabilidade:** Representar os dados que entram e saem da API.

**Por que foi feito assim:**

- Separa a estrutura de dados da API do modelo de domínio
- Permite evolução independente do modelo interno
- Evita expor propriedades internas desnecessárias (ex: `CreateDate`)

```csharp
public class UserDto
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public int Status { get; set; } = 1; // Ativo por padrão
    public int? ManagerId { get; set; }
    public int? PositionId { get; set; }
    public int? DepartmentId { get; set; }
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
public static UserModel ParaModel(UserDto dto) { ... }

// Model → DTO (saída de dados / PATCH)
public static UserDto ForDto(UserModel model) { ... }
```

---

### 4. Model (`UserModel.cs`)

**Responsabilidade:** Representar a entidade de domínio com suas validações internas.

**Por que foi feito assim:**

- **Validação de Email:** Implementada no setter com `UserValidator.IsEmailValid()`
- **Encapsulamento:** Propriedades privadas com validação no setter garantem integridade dos dados
- **Status padrão:** `Ativo (1)` por convenção

**Campos:**

| Campo          | Tipo       | Descrição                             |
| -------------- | ---------- | ------------------------------------- |
| `Id`           | `int`      | Identificador único                   |
| `Name`         | `string`   | Primeiro name                         |
| `Surname`      | `string`   | Surname                               |
| `Email`        | `string`   | E-mail com validação no setter        |
| `PasswordHash` | `string`   | Hash da senha                         |
| `Status`       | `int`      | `0 = Inativo`, `1 = Ativo`            |
| `CreateDate`   | `DateTime` | Gerado automaticamente no Mapper      |
| `ManagerId`    | `int?`     | Referência ao gestor (nullable)       |
| `PositionId`   | `int?`     | Referência ao cargo (nullable)        |
| `DepartmentId` | `int?`     | Referência ao departamento (nullable) |

---

### 5. Service (`UsuarioService.cs`)

**Responsabilidade:** Lógica de negócio — orquestra as operações delegando ao Repository.

**Por que foi feito assim:**

- Não acessa o banco diretamente — depende de `IUserRepository`
- Facilita testes unitários (basta mockar o repository)
- Respeita o princípio da inversão de dependência (DIP — SOLID)

**Métodos:**

| Método         | Descrição                           |
| -------------- | ----------------------------------- |
| `GetAll()`     | Retorna todos os usuários do banco  |
| `GetById(id)`  | Retorna um usuário por ID ou `null` |
| `Add(user)`    | Persiste um novo usuário            |
| `Update(user)` | Atualiza um usuário existing        |

---

### 6. Repository (`UserRepository.cs`)

**Responsabilidade:** Abstração do acesso ao banco de dados via Entity Framework.

**Por que foi feito assim:**

- Isola o `DbContext` do restante da aplicação
- Usa `AsNoTracking()` em queries de leitura para melhor performance
- Chama `SaveChanges()` internamente — o Service não precisa saber disso
- Facilita trocar a fonte de dados futuramente sem alterar Service ou Controller

```csharp
public IReadOnlyList<UserModel> GetAll()
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
public DbSet<UserModel> Usuarios { get; set; }
```

---

## Injeção de Dependência (`Program.cs`)

Todos os componentes são registrados com ciclo de vida `Scoped` — uma instância por requisição HTTP:

```csharp
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UsuarioService>();
```

## Fluxo de uma Requisição POST `/user`

```
1. Cliente envia POST /user com JSON
         │
         ▼
2. Controller recebe UserDto
         │
         ▼
3. Mapper converte DTO → Model
   (Validações de domínio executadas aqui,
    ex: Email inválido lança ArgumentException)
         │
         ▼
4. Controller chama _service.Add(model)
         │
         ▼
5. Service delega para _repository.Add(model)
         │
         ▼
6. Repository persiste via EF e chama SaveChanges()
         │
         ▼
7. Controller retorna 201 Created
   com Location header apontando para GET /user/{id}
```

---

## Fluxo de uma Requisição PATCH `/user/{id}`

```
1. Cliente envia PATCH /user/{id} com JsonPatchDocument
         │
         ▼
2. Controller verifica se o usuário existe via _service.GetById(id)
         │
         ▼
3. Model é convertido para DTO via Mapper.ForDto()
         │
         ▼
4. patchDoc.ApplyTo(dto) aplica apenas os campos enviados
         │
         ▼
5. DTO é reconvertido para Model via Mapper.ParaModel()
         │
         ▼
6. Service chama _repository.Update(model)
         │
         ▼
7. Controller retorna 204 No Content
```

## O que Ainda Pode Melhorar

### 1. 🟡 FluentValidation no DTO

Atualmente as validações estão no setter do Model. O ideal é validar na entrada (DTO) antes do mapeamento:

```csharp
public class UsuarioDtoValidator : AbstractValidator<UserDto>
{
    public UsuarioDtoValidator()
    {
        RuleFor(x => x.Email).EmailAddress();
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
    }
}
```

### 2. 🟡 Respostas Assíncronas (async/await)

Os métodos do Repository e Service podem ser migrados para `async/await` para não bloquear threads em I/O:

```csharp
public async Task<IReadOnlyList<UserModel>> GetAllAsync()
{
    return await _context.Usuarios
        .AsNoTracking()
        .ToListAsync();
}
```

### 3. 🟡 Retornar DTO no lugar de Model

Os endpoints atualmente retornam `UserModel` diretamente. O correto é retornar um DTO de resposta para não expor detalhes internos como `PasswordHash`.

### 4. 🟡 Tratamento Global de Exceções

Add um middleware para capturar `ArgumentException` (lançada pelo setter de Email) e retornar `400 Bad Request` de forma padronizada, em vez de deixar o erro estourar.
