DROP TABLE IF EXISTS usuario_permissao CASCADE;
DROP TABLE IF EXISTS permissao CASCADE;
DROP TABLE IF EXISTS usuario CASCADE;
DROP TABLE IF EXISTS departamento CASCADE;
DROP TABLE IF EXISTS cargo CASCADE;


create table cargo (
	id INT GENERATED ALWAYS AS IDENTITY,
	nome VARCHAR(255) not NULL,
	constraint pk_cargo primary key (id)
);

create table departamento (
	id INT GENERATED ALWAYS AS IDENTITY,
	nome VARCHAR(255) not NULL,
	constraint pk_departamento primary key (id)
);

create table usuario (
	id INT GENERATED ALWAYS AS IDENTITY,
	nome VARCHAR(255) not NULL,
	sobrenome VARCHAR(255) not NULL,
	email VARCHAR(255) not NULL,
	senha_hash VARCHAR(255) not NULL,
	gerente_id INT,
	cargo_id INT,
	departamento_id INT,
	status INT not null default 1,
	
	data_criacao TIMESTAMP not null default CURRENT_TIMESTAMP,
	
	constraint pk_usuario primary key (id),
	
	constraint uq_usuario_email unique (email),
	
	constraint fk_usuario_gerente
	FOREIGN key (gerente_id) references usuario(id),
	
	constraint fk_usuario_cargo
	FOREIGN key (cargo_id) references cargo(id),
	
	constraint fk_usuario_departamento
	FOREIGN key (departamento_id) references departamento(id)
	
);

create table permissao (
	id INT GENERATED ALWAYS AS IDENTITY,
	nome VARCHAR(255) not NULL,
	constraint pk_permissao primary key (id)
);

create table usuario_permissao (
	permissao_id INT not null,
	usuario_id INT not null,
	constraint pk_usuario_permissao
	primary key (permissao_id, usuario_id),
	
	constraint fk_permissao
	FOREIGN KEY(permissao_id) references permissao(id),
	
	constraint fk_usuario
	FOREIGN KEY(usuario_id) references usuario(id)
);

create index idx_usuario_gerente_id
	on usuario(gerente_id);

create index idx_usuario_cargo_id
	on usuario(cargo_id);

create index idx_usuario_departamento_id
	on usuario(departamento_id);

create index idx_usuario_permissao_permissao_id
	on usuario_permissao(permissao_id);

create index idx_usuario_permissao_usuario_id
	on usuario_permissao(usuario_id);
