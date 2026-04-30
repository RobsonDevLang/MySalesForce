# 🔄 Fluxo do Users Service

Este documento explica como o serviço de usuários foi estruturado e o motivo das decisões de design.

---

## Visão Geral da Arquitetura

```
┌─────────────────────────────────────────────────────────────────┐
│                        HTTP Request                              │
│                    (usuariosController)                          │
└─────────────────────────────────────────────────────────────────┘
                                │
                                ▼
┌─────────────────────────────────────────────────────────────────┐
│                      Controller Layer                            │
│                  (UsuariosController.cs)                         │
│  - Recebe as requisições HTTP                                    │
│  - Valida parâmetros básicos                                     │
│  - Delega para o Service                                         │
└─────────────────────────────────────────────────────────────────┘
                                │
                                ▼
┌─────────────────────────────────────────────────────────────────┐
│                      Service Layer                               │
│                    (UsuarioService.cs)                           │
│  - Lógica de negócio                                             │
│  - Validações de domínio                                         │
│  - Manipulação de dados                                          │
└─────────────────────────────────────────────────────────────────┘
                                │
                                ▼
┌─────────────────────────────────────────────────────────────────┐
│                      Model Layer                                 │
│                  (UsuarioModel.cs)                               │
│  - Entidade de domínio                                           │
│  - Validações de negócio (CPF, CNPJ, Email)                      │
└─────────────────────────────────────────────────────────────────┘
```

---

## Componentes e Suas Responsabilidades

### 1. Controller (`usuariosController.cs`)

**Responsabilidade:** Expor os endpoints da API e receber as requisições HTTP.

**Por que foi feito assim:**

- Segue o padrão RESTful com rotas claras (`/usuarios`)
- Utiliza `IActionResult` para retornar códigos HTTP apropriados
- Separação clara entre "o que" (endpoint) e "como" (lógica)

**Métodos implementados:**
| Método | Endpoint | Descrição |
|--------|----------|-----------|
| `GET /usuarios` | `ExibirTodosUsuarios()` | Lista todos os usuários |
| `GET /usuarios/{id}` | `SelecionarUsuario(id)` | Retorna um usuário específico |
| `POST /usuarios` | `AdicionarUsuario(dto)` | Cria um novo usuário |

---

### 2. DTO (`UsuarioDto.cs`)

**Responsabilidade:** Representar os dados que entram/saem da API.

**Por que foi feito assim:**

- Separa a estrutura de dados da API do modelo de domínio
- Permite evolução independente do modelo interno
- Evita expor propriedades internas desnecessárias

```csharp
public class UsuarioDto
{
    public string Nome { get; set; }
    public string Email { get; set; }
    public string TipoDocumento { get; set; }
    public string NumeroDocumento { get; set; }
    public string SenhaHash { get; set; }
    public int Status { get; set; }
    public int? GerenteId { get; set; }
}
```

---

### 3. Mapper (`UsuarioMapper.cs`)

**Responsabilidade:** Converter entre DTO e Model.

**Por que foi feito assim:**

- Mantém o código do Controller limpo
- Centraliza a lógica de transformação
- Facilita manutenção quando a estrutura muda

```csharp
public static UsuarioModel ParaModel(UsuarioDto dto)
{
    return new UsuarioModel
    {
        Nome = dto.Nome,
        Email = dto.Email,
        // ... outros campos
    };
}
```

---

### 4. Model (`UsuarioModel.cs`)

**Responsabilidade:** Representar a entidade de domínio com suas validações.

**Por que foi feito assim:**

- **Validação de Email:** Implementada como setter com validação
- **Validação de Documento:** CPF/CNPJ com validação de dígitos
- **Encapsulamento:** Propriedades privadas com validação no setter

**Validações implementadas:**

- ✅ Email válido (formato `user@domain.com`)
- ✅ CPF (11 dígitos com validação)
- ✅ CNPJ (14 dígitos com validação)
- ✅ Status padrão: `Ativo`

---

### 5. Service (`UsuarioService.cs`)

**Responsabilidade:** Lógica de negócio e manipulação de dados.

**Por que foi feito assim:**

- Centraliza toda a lógica de negócio
- Atualmente usa lista em memória (para desenvolvimento)
- Pode ser facilmente adaptado para banco de dados

**Métodos:**
| Método | Descrição |
|--------|-----------|
| `ObterTodos()` | Retorna lista de usuários |
| `ObterPorId(id)` | Retorna usuário por ID |
| `Adicionar(usuario)` | Adiciona novo usuário |

---

## Fluxo de uma Requisição POST

```
1. Cliente envia POST /usuarios com JSON
         │
         ▼
2. Controller recebe UsuarioDto
         │
         ▼
3. Mapper converte DTO → Model
   (Validações de domínio são executadas aqui)
         │
         ▼
4. Service processa e adiciona à lista
         │
         ▼
5. Controller retorna 201 Created
   com o usuário criado
```

---

## O que Poderia Melhorar

### 1. 🔴 Implementar Validação Real de CPF/CNPJ

Os métodos `EhCpf()` e `EhCnpj()` atualmente retornam `true` sempre:

```csharp
// TODO: Implementar validador de cpf
public static bool EhCpf(string cpf)
{
    return true; // ← Temporário
}
```

**Solução:** Implementar algoritmo de validação de dígitos verificadores.

---

### 2. 🔴 Adicionar Repository Pattern

Actualmente o `UsuarioService` gerencia diretamente a lista em memória:

```csharp
private static List<UsuarioModel> _usuarios = new List<UsuarioModel>();
```

**Melhoria:** Criar uma camada de Repository para abstrair a fonte de dados:

```
Service → Repository → (Banco de Dados / Cache / API)
```

Isso permite:

- Trocar a fonte de dados sem alterar o Service
- Facilitar testes unitários com mock
- Adicionar caching futuramente

---

### 3. 🔴 Injeção de Dependência

O Service está sendo instanciado diretamente no Controller:

```csharp
private readonly UsuarioService _service = new UsuarioService();
```

**Melhoria:** Usar injeção de dependência do .NET:

```csharp
public UsuariosController(UsuarioService service)
{
    _service = service;
}
```

E registrar no `Program.cs`:

```csharp
builder.Services.AddScoped<UsuarioService>();
```

---

### 4. 🔴 Adicionar Validação de Entrada (FluentValidation)

As validações estão no Model, mas seria melhor usar FluentValidation para:

- Mensagens de erro mais detalhadas
- Validações complexas mais legíveis
- Separação de concerns

---

### 5. 🔴 Documentação com Swagger

O Swagger já está configurado, mas pode ser melhorado com:

- Descrição dos endpoints
- Exemplos de request/response
- Anotações de resposta (códigos HTTP)

---

## Conclusão

Este padrão de arquitetura (Controller → Service → Model) é escalável e segue boas práticas de Clean Architecture. As melhorias sugeridas são para quando o projeto crescer em complexidade e necessidade de manutenção.
