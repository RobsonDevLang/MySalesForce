%
# Domínio CRM

## Objetivo
Responsável pelo relacionamento com leads, clientes, contatos, oportunidades e atividades comerciais.

## Entidades principais
- Lead/Cliente
- Contato
- Endereco
- Oportunidade
- Atividade
- Usuario

## Diagrama ER
%
```mermaid
erDiagram
    LEAD/CLIENTE {
        int Id PK
        string Nome
        string Email
        sring TipoDocumento
        string Documento
        string TipoPessoa
        string Status
        datetime DataCriacao
    }

    CONTATO {
        int Id PK
        string Nome
        string Email
        string Telefone
        string Cargo
        int ClienteId FK
    }

    ENDERECO {
        int Id PK
        string Logradouro
        string Numero
        string Bairro
        string Cidade
        string Estado
        string Cep
        string Complemento
        int ClienteId FK
    }

    OPORTUNIDADE {
        int Id PK
        string Titulo
        string Descricao
        decimal ValorEstimado
        string Etapa
        string Status
        datetime DataCriacao
        int ClienteId FK
        int ResponsavelId FK
    }

    ATIVIDADE {
        int Id PK
        string Tipo
        string Titulo
        string Descricao
        datetime DataExecucao
        string Status
        int ClienteId FK
        int OportunidadeId FK
        int ResponsavelId FK
    }

    USUARIO {
        int Id PK
        string Nome
        string Email
    }

    LEAD o|--o| CLIENTE : pode_converter_em
    CLIENTE ||--o{ CONTATO : possui
    CLIENTE ||--o{ ENDERECO : possui
    CLIENTE ||--o{ OPORTUNIDADE : possui
    CLIENTE ||--o{ ATIVIDADE : possui
    USUARIO ||--o{ OPORTUNIDADE : responsavel_por
    USUARIO ||--o{ ATIVIDADE : responsavel_por
    OPORTUNIDADE o|--o{ ATIVIDADE : gera