## Estrutura de Pastas

```
MySalesForce/
├─ src/ # código-fonte da aplicação
│ ├─ web/ # front-end (React + Vite)
│ └─ services/ # microsserviços (APIs .NET)
│ ├─ [name]-service/
│ └─ run-all.ps1 # script para iniciar todos os serviços
├─ docs/ # documentação do projeto
├─ infra/ # configurações de infraestrutura (Docker, K8s, pipelines)
└─ shared/ # código, contratos e utilitários compartilhados entre serviços
```

## Propósito de Cada Pasta

### `src/`

Código-fonte principal da aplicação. Contém todo o código de negócio.

### `src/web/`

Aplicação front-end React. Inclui:

- Código fonte em `src/`
- Configurações (Vite, TypeScript, ESLint)
- Arquivos públicos em `public/`

### `src/services/`

Microsserviços da aplicação. Cada serviço é uma API independente.

Cada microsserviço segue o padrão:

```
[name]-service/
├── Controllers/      # endpoints da API (recebe requisições HTTP)
├── DTO/              # Data Transfer Objects (representa dados de entrada/saída)
├── Mappers/          # conversões entre DTO e Model
├── Models/           # entidades de domínio com validações
├── Services/         # lógica de negócio
└── [Name].Api.csproj # projeto .NET
```

### `docs/`

Documentação do projeto. Inclui:

- Arquitetura e padrões
- Convenções de Git
- Diagramas (Mermaid)
- Documentação de domínio

### `infra/`

Configurações de infraestrutura:

- Dockerfiles
- Kubernetes manifests
- Pipelines CI/CD
- Scripts de deploy

### `shared/`

Código compartilhado entre serviços:

- Bibliotecas comuns
- Contratos (interfaces, DTOs compartilhados)
- Utilitários
- Helpers

## Regras Gerais

- Cada pasta deve ter um propósito claro
- Não misturar front-end com back-end fora de suas pastas
- Não misturar infraestrutura com código de negócio
- Tudo que for compartilhado entre projetos deve ir para `shared/`
- Novos microsserviços devem seguir o mesmo padrão de nomenclatura (`[name]-service/`)
- Cada microsserviço deve seguir a estrutura interna (Controllers, DTOs, Mappers, Models, Services)
