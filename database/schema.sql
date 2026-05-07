
drop table if EXISTS user_permissoes cascade;
drop table if EXISTS permissoes cascade;
drop table if EXISTS usuarios cascade;
drop table if EXISTS departamentos cascade;
drop table if EXISTS cargos cascade;


create table cargos (
	id SERIAL primary key,
	nome VARCHAR(100)
);

create table departamentos (
	id SERIAL primary key,
	nome VARCHAR(100)
);

create table usuarios (
	id SERIAL primary key,
	nome VARCHAR(100) not NULL,
	email VARCHAR(100)not NULL,
	senha_hash VARCHAR(100) not NULL,
	gerente_id INT,
	cargo_id INT,
	departamento_id INT,
	
	constraint uq_usuario_email unique (email),
	
	constraint fk_usuario_gerente
	FOREIGN key (gerente_id) references usuarios(id),
	
	constraint fk_usuario_cargo
	FOREIGN key (cargo_id) references cargos(id),
	
	constraint fk_usuario_departamento
	FOREIGN key (departamento_id) references departamentos(id)
	

);

create table permissoes (
	id SERIAL primary key,
	nome VARCHAR(100)

);

create table user_permissoes (
	permissao_id INT,
	user_id INT,
	primary KEY(permissao_id, user_id),
	
	constraint fk_permissao
	FOREIGN KEY(permissao_id) references permissoes(id),
	
	constraint fk_user
	FOREIGN KEY(user_id) references usuarios(id)
);
