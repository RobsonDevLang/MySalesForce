## Estrutura de Pastas

```
MySalesForce/
├─ src/                         # código-fonte principal
│
├─ web/                         # front-end React + Vite
│
│  ├─ public/                  # arquivos públicos estáticos
│  │
│  ├─ src/                     # código-fonte React
│  │  ├─ app/                  # núcleo da aplicação
│  │  │
│  │  │  ├─ routes/            # gerenciamento de rotas
│  │  │  ├─ providers/         # providers globais
│  │  │  └─ layouts/           # layouts reutilizáveis
│  │  │
│  │  │  assets/               # imagens
│  │  │  ├── images/
│  │  │  ├── icons/
│  │  │  ├── fonts/
│  │  │  ├── illustrations/
│  │  │  ├── videos/
│  │  │  └── animations/
│  │  │
│  │  ├─ modules/              # módulos/domínios do sistema
│  │  │
│  │  │  ├─ auth/              # módulo de autenticação
│  │  │  │
│  │  │  │  ├─ pages/          # páginas do módulo
│  │  │  │  ├─ components/     # componentes exclusivos
│  │  │  │  ├─ services/       # chamadas HTTP/API
│  │  │  │  ├─ hooks/          # hooks do módulo
│  │  │  │  ├─ types/          # DTOs/tipos/interfaces
│  │  │  │  └─ utils/          # helpers internos
│  │  │  │
│  │  │  │
│  │  │  ├─ user/             # módulo do user-service
│  │  │  │
│  │  │  │  ├─ pages/
│  │  │  │  │
│  │  │  │  │  ├─ UserListPage.tsx
│  │  │  │  │  ├─ UserDetailsPage.tsx
│  │  │  │  │  └─ CreateUserPage.tsx
│  │  │  │  │
│  │  │  │  │  # telas relacionadas aos usuários
│  │  │  │
│  │  │  │  ├─ components/
│  │  │  │  │
│  │  │  │  │  ├─ UserTable/
│  │  │  │  │  ├─ UserCard/
│  │  │  │  │  └─ UserForm/
│  │  │  │  │
│  │  │  │  │  # componentes exclusivos do domínio users
│  │  │  │
│  │  │  │  ├─ services/
│  │  │  │  │
│  │  │  │  │  └─ users.service.ts
│  │  │  │  │
│  │  │  │  │  # integração com o user-service backend
│  │  │  │
│  │  │  │  ├─ hooks/
│  │  │  │  │
│  │  │  │  │  └─ useUsers.ts
│  │  │  │  │
│  │  │  │  │  # lógica reutilizável de usuários
│  │  │  │
│  │  │  │  ├─ types/
│  │  │  │  │
│  │  │  │  │  └─ user.type.ts
│  │  │  │  │
│  │  │  │  │  # contratos/tipos/interfaces
│  │  │  │
│  │  │  │  └─ utils/
│  │  │  │
│  │  │  │     # helpers específicos do módulo
│  │  │  │
│  │  │  │
│  │  │  └─ product/
│  │  │
│  │  │     # mesmo padrão dos outros módulos
│  │  │
│  │  │
│  │  ├─ shared/               # compartilhado entre módulos
│  │  │
│  │  │  ├─ components/        # componentes globais
│  │  │  ├─ hooks/             # hooks reutilizáveis
│  │  │  ├─ services/          # axios/api base
│  │  │  ├─ utils/             # helpers globais
│  │  │  ├─ types/             # tipagens globais
│  │  │  ├─ constants/         # constantes do sistema
│  │  │  └─ styles/            # estilos globais
│  │  │
│  │  │
│  │  ├─ assets/               # imagens, fontes e ícones
│  │  │
│  │  ├─ main.tsx              # ponto de entrada React
│  │  │
│  │  └─ vite-env.d.ts
│  │
│  ├─ package.json
│  ├─ vite.config.ts
│  └─ tsconfig.json
│
│
│
├─ services/                   # microsserviços .NET
│  │
│  ├─ ...
│
│
├─ docs/                       # documentação do projeto
│
├─ infra/                      # infraestrutura
│
└─ shared/                     # compartilhado entre backend/services

```
