# Convenções de Modelagem e Estrutura do Banco de Dados

## Nomes de Tabelas

- Em português
- Em minúsculo
- snake_case
- Nome no singular
- Sem acentos
- Sem espaços
- Sem caracter especial

## Chave Primária

- id ou quando necessário: `id_`[nome do campo]
- utilizar sempre chaves primarias nomeadas
- utilizar o "INT GENERATED ALWAYS AS IDENTITY" em vez do "SERIAL"

## Chaves Estrangeiras

- Nome igual ao da PK referenciada
- Relacionamento N:N as chaves devem ser NOT NULL nas FKs da tabela de relacionamento

## Datas

- `data_`[nome da data]

## Status

- utilizar o nome padrão: status

## Índices

- `idx_`[nome do campo]

## Padrão de Constraints

| Tipo        | Prefixo |
| ----------- | ------- |
| Primary Key | `pk_`   |
| Foreign Key | `fk_`   |
| Unique      | `uk_`   |
| Index       | `idx_`  |
| Check       | `ck_`   |

## Tipos de Dados

- INT para identificadores
- VARCHAR para textos curtos
- TEXT para textos longos
- DECIMAL para valores monetários
- DATE ou DATETIME para datas
- BIT para valores booleanos

## Valores Monetários

- Utilizar DECIMAL(10,2)
- Nomear colunas com prefixo valor\_ ou nome descritivo, exemplos: valor_desconto e preco

## Boas Práticas

- NOT NULL quando possível
- Utilizar UNIQUE para campos que não podem repetir
- Constraints nomeadas
- Índices em FKs
- Campos de auditoria (data_criacao)
- Normalização (1FN, 2FN e 3FN)

## Evite

- Nomes abreviados
- Dados duplicados
- Colunas com nomes genéricos (campo1, valor2, descricao3)

## Exclusão Lógica

- Utilizar data_exclusao quando necessário
- Evitar DELETE físico em registros importantes

## Tabelas de Relacionamento

- Utilizar nome composto pelas tabelas relacionadas
- Exemplo:
  usuario_permissao
  produto_categoria
