## Padrão de pastas e organização iniciais 

MySalesForce/
├─ apps/          # aplicações cliente
│  └─ web/        # front-end React
├─ services/      # APIs e microsserviços
│  ├─ identity-service/
│  ├─ crm-service/
│  ├─ catalog-service/
│  └─ sales-service/
├─ docs/          # documentação do projeto
├─ infra/         # Docker, Kubernetes, pipelines e configs de infraestrutura
└─ shared/        # código, contratos e utilitários compartilhados


## Regras gerais

- Cada pasta deve ter um propósito claro
- Não misturar front-end com back-end fora de suas pastas
- Não misturar infraestrutura com código de negócio
- Tudo que for compartilhado entre projetos deve ir para `shared/`
- Novos módulos devem seguir o mesmo padrão de nomenclatura