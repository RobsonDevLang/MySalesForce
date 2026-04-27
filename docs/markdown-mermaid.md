# Domínio Identity

## Objetivo

Responsável por autenticação, autorização e controle de acesso dos usuários do sistema.

## Entidades principais

- Usuario
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
        string Nome
        string Email
        string SenhaHash
        string Status
        datetime DataCriacao
        int GerenteId
    }

    PERMISSAO {
        int Id
        string Nome
        string Codigo
        string Descricao
    }

    DEPARTAMENTO {
        int Id
        string Nome
        string Descricao
    }

    USUARIO_PERMISSAO {
        int UsuarioId
        int PermissaoId
        bool IsNegado
    }

    DEPARTAMENTO_PERMISSAO {
        int DepartamentoId
        int PermissaoId
    }

    USUARIO_DEPARTAMENTO {
        int UsuarioId
        int DepartamentoId
    }

    USUARIO ||--o{ USUARIO
    USUARIO ||--o{ USUARIO_PERMISSAO
    PERMISSAO ||--o{ USUARIO_PERMISSAO

    DEPARTAMENTO ||--o{ DEPARTAMENTO_PERMISSAO
    PERMISSAO ||--o{ DEPARTAMENTO_PERMISSAO

    USUARIO ||--o{ USUARIO_DEPARTAMENTO
    DEPARTAMENTO ||--o{ USUARIO_DEPARTAMENTO