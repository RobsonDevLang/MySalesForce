%

# Domínio Identity

## Objetivo

Responsável por autenticação, autorização e controle de acesso dos usuários do sistema.

## Entidades principais

- AppUser
- Perfil
- Permissao

## Diagrama ER

%

```mermaid
erDiagram

    GERENTE {
        int Id PK
        string Name
        string Descricao
    }

    USUARIO {
        int Id PK
        string Name
        string Email
        string PasswordHash
        string Status
        datetime CreateDate
        int ManagerId FK
    }

    PERMISSAO {
        int Id PK
        string Name
        string Codigo
        string Descricao
    }

    GERENTE o|--|{ USUARIO : gerencia
    USUARIO }o--|{ PERMISSAO : possui
```
