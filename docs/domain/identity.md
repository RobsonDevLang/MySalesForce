%
# Domínio Identity

## Objetivo
Responsável por autenticação, autorização e controle de acesso dos usuários do sistema.

## Entidades principais
- Usuario
- Perfil
- Permissao

## Diagrama ER
%


```mermaid
erDiagram

    GERENTE {
        int Id PK
        string Nome
        string Descricao
    }

    USUARIO {
        int Id PK
        string Nome
        string Email
        string SenhaHash
        string Status
        datetime DataCriacao
        int GerenteId FK
    }

    PERMISSAO {
        int Id PK
        string Nome
        string Codigo
        string Descricao
    }

    GERENTE o|--|{ USUARIO : gerencia
    USUARIO }o--|{ PERMISSAO : possui