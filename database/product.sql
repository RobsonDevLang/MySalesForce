DROP TABLE IF EXISTS preco_historico;
DROP TABLE IF EXISTS produto_estoque;
DROP TABLE IF EXISTS produto_imagem;

DROP TABLE IF EXISTS produto;

DROP TABLE IF EXISTS movimentacao;
DROP TABLE IF EXISTS marca;
DROP TABLE IF EXISTS categoria;
DROP TABLE IF EXISTS condicao;


CREATE TABLE condicao(
	id INT GENERATED ALWAYS AS IDENTITY,
	constraint pk_condicao primary key (id),
	name VARCHAR(255) not NULL
);

CREATE TABLE category(
	id INT GENERATED ALWAYS AS IDENTITY,
	constraint pk_categoria primary key (id),
	name VARCHAR(255) not NULL
);

CREATE TABLE size (
    id INT GENERATED ALWAYS AS IDENTITY,
    size VARCHAR(255) NOT NULL,
    CONSTRAINT pk_size PRIMARY KEY (id)
);

CREATE TABLE product_size (
    product_id INT NOT NULL,
    size_id INT NOT NULL,

    CONSTRAINT pk_product_size
        PRIMARY KEY (product_id, size_id),

    CONSTRAINT fk_product_size_product
        FOREIGN KEY (product_id)
        REFERENCES product(id),

    CONSTRAINT fk_product_size_size
        FOREIGN KEY (size_id)
        REFERENCES size(id)
);

CREATE TABLE marca(
	id INT GENERATED ALWAYS AS IDENTITY,
	constraint pk_marca primary key (id),
	name VARCHAR(255) not NULL
);

CREATE TABLE produto (
	id INT GENERATED ALWAYS AS IDENTITY,
	constraint pk_produto primary key (id),
	codigo VARCHAR(255) not NULL,
	name VARCHAR(255) not NULL,
	descricao TEXT not NULL,
	status INT not null default 0,
	peso DECIMAL(10, 2) not null default 0.00,
	altura DECIMAL(10, 2) not null default 0.00,
	largura DECIMAL(10, 2) not null default 0.00,
	observacao TEXT not NULL,


	condicao_id INT,
	constraint fk_produto_condicao
	FOREIGN key (condicao_id) references condicao(id),
	
	categoria_id INT,
	constraint fk_produto_categoria
	FOREIGN key (categoria_id) references categoria(id),
	
	marca_id INT,
	constraint fk_produto_marca
	FOREIGN key (marca_id) references marca(id)
);

CREATE INDEX idx_produto_condicao_id ON produto(condicao_id);
CREATE INDEX idx_produto_categoria_id ON produto(categoria_id);
CREATE INDEX idx_produto_marca_id ON produto(marca_id);

CREATE TABLE produto_imagem(
	id INT GENERATED ALWAYS AS IDENTITY,
	CONSTRAINT pk_produto_imagem PRIMARY KEY (id),
	url TEXT not null,
	ordem INT not null default 1,
	imagem_principal BIT not null default '1',
	alt_text TEXT,

	produto_id INT,
	CONSTRAINT fk_produto_imagem_produto FOREIGN KEY (produto_id) REFERENCES produto(id)
);

CREATE TABLE movimentacao(
	id INT GENERATED ALWAYS AS IDENTITY,
	constraint pk_movimentacao primary key (id),
	name VARCHAR(255) not NULL
);

CREATE INDEX idx_produto_imagem_produto_id ON produto_imagem(produto_id);

CREATE TABLE produto_estoque(
	id INT GENERATED ALWAYS AS IDENTITY,
	CONSTRAINT pk_produto_estoque PRIMARY KEY (id),

	produto_id INT,
	constraint fk_produto_estoque_produto
	FOREIGN key (produto_id) references produto(id),

	movimentacao_id INT,
	constraint fk_produto_estoque_movimentacao
	FOREIGN key (movimentacao_id) references movimentacao(id),

	quantidade INT not null default 0,
	data_movimentacao TIMESTAMP not null default CURRENT_TIMESTAMP,
	origem VARCHAR(255) not null,
	observacao TEXT not NULL
);

CREATE INDEX idx_produto_estoque_produto_id ON produto_estoque(produto_id);
CREATE INDEX idx_produto_estoque_movimentacao_id ON produto_estoque(movimentacao_id);

CREATE TABLE preco_historico(
	id INT GENERATED ALWAYS AS IDENTITY,
	CONSTRAINT pk_preco_historico PRIMARY KEY (id),
	produto_id INT,
	constraint fk_preco_historico_produto
	FOREIGN key (produto_id) references produto(id),
	
	preco DECIMAL(10, 2) not null default 0.00,
	data_inicio TIMESTAMP not null default CURRENT_TIMESTAMP,
	data_fim TIMESTAMP
);


CREATE UNIQUE INDEX uq_preco_historico_ativo
ON preco_historico(produto_id)
WHERE data_fim IS NULL;
