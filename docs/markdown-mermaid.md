# Domínio Identity

## Objetivo

Responsável por autenticação, autorização e controle de acesso dos usuários do sistema.

## Entidades principais

- AppUser
- Departamento
- Permissao

## Regra de negócio

Cada pessoa pode ganhar acessos de dois jeitos: direto nela (usuário) ou por fazer parte de um grupo (departamento).
Ou seja: se a permissão IsNegado estiver como true, a pessoa não tem acesso, mesmo que o departamento dela dê essa permissão.

## Diagrama ER

```mermaid
erDiagram
    USUARIO {
        int Id
        string Name
        string Email
        string PasswordHash
        string Status
        datetime CreateDate
        int ManagerId
    }

    PERMISSAO {
        int Id
        string Name
        string Codigo
        string Descricao
    }

    DEPARTAMENTO {
        int Id
        string Name
        string Descricao
    }

    USUARIO_PERMISSAO {
        int UsuarioId
        int PermissaoId
        bool IsNegado
    }

    DEPARTAMENTO_PERMISSAO {
        int DepartmentId
        int PermissaoId
    }

    USUARIO_DEPARTAMENTO {
        int UsuarioId
        int DepartmentId
    }

    USUARIO ||--o{ USUARIO
    USUARIO ||--o{ USUARIO_PERMISSAO
    PERMISSAO ||--o{ USUARIO_PERMISSAO

    DEPARTAMENTO ||--o{ DEPARTAMENTO_PERMISSAO
    PERMISSAO ||--o{ DEPARTAMENTO_PERMISSAO

    USUARIO ||--o{ USUARIO_DEPARTAMENTO
    DEPARTAMENTO ||--o{ USUARIO_DEPARTAMENTO
```
