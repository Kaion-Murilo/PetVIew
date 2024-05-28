create database dbPetView
GO

use dbPetView
GO

-- TABELAS

create table tbEndereco(
cep char(8) not null,
numero int not null,
rua varchar(50) not null,
bairro varchar(50) not null,
complemento varchar(20),
cidade varchar(50) not null,
uf char(2) not null,
constraint PK_tbEndereco primary key clustered (cep, numero)
);
GO

create table tbFuncionario(
cod_funcionario int identity(1,1) constraint PK_tbFuncionario primary key,
nome_func varchar(70) not null,
cpf_func char(11) not null,
rg_func char(9) not null,
status_func varchar(8) not null constraint DF_tbFuncionario_status default 'Ativo', -- ativo ou demitido
tel_func char(10),
cel_func char(11) not null,
email_func varchar(100),
cargo_func varchar(30) not null,
salario_func money not null,
cep_func char(8) not null,
numcasa_func int not null,
constraint FK_tbFuncionario_tbEndereco foreign key(cep_func, numcasa_func) references tbEndereco(cep,numero),
constraint CK_tbFuncionario_salario check(salario_func >= 0.00)
);
GO

create table tbMedico(
cod_medico int identity(1,1) constraint PK_tbMedico primary key,
crmv int not null,
nome_med varchar(70) not null,
funcao_med varchar(30) not null,
cpf_med char(11) not null,
rg_med char(9) not null,
cel_med char(11) not null,
tel_med char(10),
email_med varchar(100) not null,
salario_med money not null,
status_med varchar(8) not null constraint DF_tbMedico_status default 'Ativo', -- ativo ou demitido
cep_med char(8) not null,
numcasa_med int not null,
constraint FK_tbMedico_tbEndereco foreign key(cep_med, numcasa_med) references tbEndereco(cep,numero),
constraint CK_tbMedico_salario check(salario_med >= 0.00)
);
GO

create table tbUsuario (
cod_usuario int identity(1,1) constraint PK_tbUsuario primary key,
nome_usuario varchar(25) not null,
ativacao_usuario bit not null constraint DF_tbUsuario_ativo default 0,
data_cadastro datetime not null constraint DF_tbUsuario_data default getdate(),
senha_usuario varchar(20) not null,
cod_funcionario int,
cod_medico int,
constraint FK_tbUsuario_tbFuncionario foreign key(cod_funcionario) references tbFuncionario(cod_funcionario),
constraint FK_tbUsuario_tbMedico foreign key(cod_medico) references tbMedico(cod_medico)
);
GO

create table tbDono(
cod_dono int identity(1,1) constraint PK_tbDono primary key,
nome_dono varchar(70) not null,
cpf_dono char(11) not null,
rg_dono char(9) not null,
cel_dono char(11) not null,
tel_dono char(10),
email_dono varchar(100),
cep_dono char(8) not null,
numcasa_dono int not null,
constraint FK_tbDono_tbEndereco foreign key(cep_dono, numcasa_dono) references tbEndereco(cep,numero)
);
GO

create table tbAnimal(
cod_animal int identity(1,1) constraint PK_tbAnimal primary key,
rga int,
cod_dono int not null,
nome_animal varchar(30) not null,
idade int not null,
tipo_idade char(5) not null,
raca_animal varchar(30) not null,
especie varchar(30) not null,
descricao varchar(100) not null,
constraint FK_tbAnimal_tbDono foreign key(cod_dono) references tbDono(cod_dono)
);
GO

create table tbConsulta(
cod_consulta int identity(1,1) constraint PK_tbConsulta primary key,
cod_animal int not null,
cod_medico int not null,
sintomas varchar(1000),
diagnostico varchar(1000),
custo_consulta money not null,
tipo_consulta varchar(30) not null,
data_consulta datetime not null,
observacao_consulta varchar(300),
status_consulta bit not null constraint DF_tbConsulta_status default 0,
constraint FK_tbConsulta_tbAnimal foreign key(cod_animal) references tbAnimal(cod_animal),
constraint FK_tbConsulta_tbMedico foreign key(cod_medico) references tbMedico(cod_medico)
);
GO

create table tbTratamento(
cod_tratamento int identity(1,1) constraint PK_tbTratamento primary key,
cod_animal int not null,
cod_medico int not null,
cod_consulta int not null,
tipo_tratamento varchar(30) not null,
observacao_tratamento varchar(300),
custo_tratamento money not null,
data_tratamento datetime not null,
status_tratamento bit not null constraint DF_tbTratamento_status default 0,
constraint FK_tbTratamento_tbAnimal foreign key(cod_animal) references tbAnimal(cod_animal),
constraint FK_tbTratamento_tbMedico foreign key(cod_medico) references tbMedico(cod_medico),
constraint FK_tbTratamento_tbConsulta foreign key(cod_consulta) references tbConsulta(cod_consulta)
);
GO

create table tbExame(
cod_exame int identity(1,1) constraint PK_tbExame primary key,
cod_animal int not null,
cod_medico int not null,
cod_consulta int not null,
tipo_exame varchar(30) not null,
observacao_exame varchar(300),
custo_exame money not null,
data_exame datetime not null,
status_exame bit not null constraint DF_tbExame_status default 0,
constraint FK_tbExame_tbAnimal foreign key(cod_animal) references tbAnimal(cod_animal),
constraint FK_tbExame_tbMedico foreign key(cod_medico) references tbMedico(cod_medico),
constraint FK_tbExame_tbConsulta foreign key(cod_consulta) references tbConsulta(cod_consulta)
);
GO

-- PROCEDURES

-- MÉDICO

create proc sp_insert_medico(
@cep char(8),
@numero int,
@rua varchar(50),
@bairro varchar(50),
@complemento varchar(20),
@cidade varchar(50),	
@uf char(2),
@crmv int,
@nome_med char(70),
@funcao_med varchar(30),
@cpf_med char(11),
@rg_med char(9),
@cel_med char(11),
@tel_med char(10),
@email_med varchar(100),
@salario_med money
) 
as 
	begin
		if(@complemento = null) set @complemento = 'Sem complemento';

		insert into tbEndereco (cep, numero, rua, bairro, complemento, cidade, uf)
				values (@cep, @numero, @rua, @bairro, @complemento, @cidade, @uf);
		insert into tbMedico(crmv, nome_med, funcao_med, cpf_med, rg_med, cel_med, tel_med, email_med, salario_med, cep_med, numcasa_med)
				values(@crmv, @nome_med, @funcao_med, @cpf_med, @rg_med, @cel_med, @tel_med, @email_med, @salario_med, @cep, @numero);
	end
GO

create proc sp_delete_medico(
@cod_medico int
)as
begin
    update tbMedico set status_med = 'Demitido' where cod_medico = @cod_medico;
	delete from tbUsuario where cod_medico = @cod_medico;
end
GO

create proc sp_update_medico(
@cod_medico int,
@cep char(8),
@numero int,
@rua varchar(50),
@bairro varchar(50),
@complemento varchar(20),
@cidade varchar(50),	
@uf char(2),
@crmv int,
@nome_med char(70),
@funcao_med varchar(30),
@cpf_med char(11),
@rg_med char(9),
@cel_med char(10),
@tel_med char(10),
@email_med varchar(100),
@salario_med money
)as
begin
	update tbEndereco
	set cep = @cep, numero = @numero, rua = @rua, bairro = @bairro, complemento = @complemento, cidade = @cidade, uf = @uf
	where cep = (select cep from tbEndereco inner join tbMedico on tbMedico.cep_med = tbEndereco.cep where tbMedico.cod_medico = @cod_medico) and numero = (select numero from tbEndereco inner join tbMedico on tbMedico.numcasa_med = tbEndereco.numero where tbMedico.cod_medico = @cod_medico);
	update tbMedico
	set crmv = @crmv, nome_med = @nome_med, funcao_med = @funcao_med, cpf_med = @cpf_med, rg_med = @rg_med, cel_med = @cel_med, tel_med = @tel_med, email_med = @email_med, salario_med = @salario_med, cep_med = @cep, numcasa_med = @numero
	where cod_medico = @cod_medico;
end
GO

create proc sp_select_medico(
@cod_medico int = null,
@crmv int = null,
@nome_med varchar(70) = null,
@funcao_med varchar(30) = null,
@cpf_med varchar(11) = null,
@rg_med varchar(9) = null,
@cel_med varchar(10) = null,
@tel_med varchar(10) = null,
@email_med  varchar(100) = null,
@status_med varchar(8) = null,
@salario_med money = null
)
as
begin

if (@cod_medico is not null) begin
	select M.cod_medico [ID], M.crmv [CRMV], M.nome_med [Nome], M.funcao_med [Função], M.cpf_med [CPF], M.rg_med [RG], M.cel_med [Celular], M.tel_med [Telefone], M.email_med [Email], M.status_med [Status], M.salario_med [Salário], E.cep [CEP], E.rua [Rua], E.numero [Número], E.complemento [Complemento], E.bairro [Bairro], E.cidade [Cidade], E.uf [UF]
	from tbMedico M
	inner join tbEndereco E on M.cep_med = E.cep and M.numcasa_med = E.numero
	where M.cod_medico like @cod_medico;
end

else if (@crmv is not null) begin
	select M.cod_medico [ID], M.crmv [CRMV], M.nome_med [Nome], M.funcao_med [Função], M.cpf_med [CPF], M.rg_med [RG], M.cel_med [Celular], M.tel_med [Telefone], M.email_med [Email], M.status_med [Status], M.salario_med [Salário], E.cep [CEP], E.rua [Rua], E.numero [Número], E.complemento [Complemento], E.bairro [Bairro], E.cidade [Cidade], E.uf [UF]
	from tbMedico M
	inner join tbEndereco E on M.cep_med = E.cep and M.numcasa_med = E.numero
	where M.crmv like @crmv;
end

else if (@nome_med is not null) begin
	select M.cod_medico [ID], M.crmv [CRMV], M.nome_med [Nome], M.funcao_med [Função], M.cpf_med [CPF], M.rg_med [RG], M.cel_med [Celular], M.tel_med [Telefone], M.email_med [Email], M.status_med [Status], M.salario_med [Salário], E.cep [CEP], E.rua [Rua], E.numero [Número], E.complemento [Complemento], E.bairro [Bairro], E.cidade [Cidade], E.uf [UF]
	from tbMedico M
	inner join tbEndereco E on M.cep_med = E.cep and M.numcasa_med = E.numero
	where M.nome_med like concat('%',@nome_med,'%');
end

else if (@funcao_med is not null) begin
	select M.cod_medico [ID], M.crmv [CRMV], M.nome_med [Nome], M.funcao_med [Função], M.cpf_med [CPF], M.rg_med [RG], M.cel_med [Celular], M.tel_med [Telefone], M.email_med [Email], M.status_med [Status], M.salario_med [Salário], E.cep [CEP], E.rua [Rua], E.numero [Número], E.complemento [Complemento], E.bairro [Bairro], E.cidade [Cidade], E.uf [UF]
	from tbMedico M
	inner join tbEndereco E on M.cep_med = E.cep and M.numcasa_med = E.numero
	where M.funcao_med like concat('%',@funcao_med,'%');
end

else if (@cpf_med is not null) begin
	select M.cod_medico [ID], M.crmv [CRMV], M.nome_med [Nome], M.funcao_med [Função], M.cpf_med [CPF], M.rg_med [RG], M.cel_med [Celular], M.tel_med [Telefone], M.email_med [Email], M.status_med [Status], M.salario_med [Salário], E.cep [CEP], E.rua [Rua], E.numero [Número], E.complemento [Complemento], E.bairro [Bairro], E.cidade [Cidade], E.uf [UF]
	from tbMedico M
	inner join tbEndereco E on M.cep_med = E.cep and M.numcasa_med = E.numero
	where M.cpf_med like concat('%',@cpf_med,'%');
end

else if (@rg_med is not null) begin
	select M.cod_medico [ID], M.crmv [CRMV], M.nome_med [Nome], M.funcao_med [Função], M.cpf_med [CPF], M.rg_med [RG], M.cel_med [Celular], M.tel_med [Telefone], M.email_med [Email], M.status_med [Status], M.salario_med [Salário], E.cep [CEP], E.rua [Rua], E.numero [Número], E.complemento [Complemento], E.bairro [Bairro], E.cidade [Cidade], E.uf [UF]
	from tbMedico M
	inner join tbEndereco E on M.cep_med = E.cep and M.numcasa_med = E.numero
	where M.rg_med like concat('%',@rg_med,'%');
end

else if (@cel_med is not null) begin
	select M.cod_medico [ID], M.crmv [CRMV], M.nome_med [Nome], M.funcao_med [Função], M.cpf_med [CPF], M.rg_med [RG], M.cel_med [Celular], M.tel_med [Telefone], M.email_med [Email], M.status_med [Status], M.salario_med [Salário], E.cep [CEP], E.rua [Rua], E.numero [Número], E.complemento [Complemento], E.bairro [Bairro], E.cidade [Cidade], E.uf [UF]
	from tbMedico M
	inner join tbEndereco E on M.cep_med = E.cep and M.numcasa_med = E.numero
	where M.cel_med like concat('%',@cel_med,'%');
end

else if (@tel_med is not null) begin
	select M.cod_medico [ID], M.crmv [CRMV], M.nome_med [Nome], M.funcao_med [Função], M.cpf_med [CPF], M.rg_med [RG], M.cel_med [Celular], M.tel_med [Telefone], M.email_med [Email], M.status_med [Status], M.salario_med [Salário], E.cep [CEP], E.rua [Rua], E.numero [Número], E.complemento [Complemento], E.bairro [Bairro], E.cidade [Cidade], E.uf [UF]
	from tbMedico M
	inner join tbEndereco E on M.cep_med = E.cep and M.numcasa_med = E.numero
	where M.tel_med like concat('%',@tel_med,'%');
end

else if (@email_med is not null) begin
	select M.cod_medico [ID], M.crmv [CRMV], M.nome_med [Nome], M.funcao_med [Função], M.cpf_med [CPF], M.rg_med [RG], M.cel_med [Celular], M.tel_med [Telefone], M.email_med [Email], M.status_med [Status], M.salario_med [Salário], E.cep [CEP], E.rua [Rua], E.numero [Número], E.complemento [Complemento], E.bairro [Bairro], E.cidade [Cidade], E.uf [UF]
	from tbMedico M
	inner join tbEndereco E on M.cep_med = E.cep and M.numcasa_med = E.numero
	where M.email_med like concat('%',@email_med,'%');
end

else if (@status_med is not null) begin
	select M.cod_medico [ID], M.crmv [CRMV], M.nome_med [Nome], M.funcao_med [Função], M.cpf_med [CPF], M.rg_med [RG], M.cel_med [Celular], M.tel_med [Telefone], M.email_med [Email], M.status_med [Status], M.salario_med [Salário], E.cep [CEP], E.rua [Rua], E.numero [Número], E.complemento [Complemento], E.bairro [Bairro], E.cidade [Cidade], E.uf [UF]
	from tbMedico M
	inner join tbEndereco E on M.cep_med = E.cep and M.numcasa_med = E.numero
	where M.status_med like concat('%',@status_med,'%');
end

else if (@salario_med is not null) begin
	select M.cod_medico [ID], M.crmv [CRMV], M.nome_med [Nome], M.funcao_med [Função], M.cpf_med [CPF], M.rg_med [RG], M.cel_med [Celular], M.tel_med [Telefone], M.email_med [Email], M.status_med [Status], M.salario_med [Salário], E.cep [CEP], E.rua [Rua], E.numero [Número], E.complemento [Complemento], E.bairro [Bairro], E.cidade [Cidade], E.uf [UF]
	from tbMedico M
	inner join tbEndereco E on M.cep_med = E.cep and M.numcasa_med = E.numero
	where M.salario_med like @salario_med;
end

else begin
	select M.cod_medico [ID], M.crmv [CRMV], M.nome_med [Nome], M.funcao_med [Função], M.cpf_med [CPF], M.rg_med [RG], M.cel_med [Celular], M.tel_med [Telefone], M.email_med [Email], M.status_med [Status], M.salario_med [Salário], E.cep [CEP], E.rua [Rua], E.numero [Número], E.complemento [Complemento], E.bairro [Bairro], E.cidade [Cidade], E.uf [UF]
	from tbMedico M
	inner join tbEndereco E on M.cep_med = E.cep and M.numcasa_med = E.numero;
end
end
GO

-- FUNCIONÁRIO

create proc sp_insert_func(
@cep char(8),
@numero int,
@rua varchar(50),
@bairro varchar(50),
@complemento varchar(20),
@cidade varchar(50),	
@uf char(2),
@nome_func varchar(70),
@cpf_func char(11),
@rg_func char(9),
@tel_func char(10),
@cel_func char(11),
@email_func varchar(100),
@cargo_func varchar(30),
@salario_func money
) 
as 
	begin
		if(@complemento = null) set @complemento = 'Sem complemento';

		insert into tbEndereco (cep, numero, rua, bairro, complemento, cidade, uf)
				values (@cep, @numero, @rua, @bairro, @complemento, @cidade, @uf);
		insert into tbFuncionario(nome_func, cpf_func, rg_func, tel_func, cel_func, email_func, cargo_func, salario_func, cep_func, numcasa_func)
			values(@nome_func, @cpf_func, @rg_func, @tel_func, @cel_func, @email_func, @cargo_func, @salario_func, @cep, @numero)
	end
GO

create proc sp_delete_func(
@cod_func int
)as
begin
    update tbFuncionario set status_func = 'Demitido' where cod_funcionario = @cod_func;
	delete from tbUsuario where cod_funcionario = @cod_func;
end
GO

create proc sp_update_func(
@cod_funcionario int,
@cep char(8),
@numero int,
@rua varchar(50),
@bairro varchar(50),
@complemento varchar(20),
@cidade varchar(50),	
@uf char(2),
@nome_func varchar(70),
@cpf_func char(11),
@rg_func char(9),
@tel_func char(10),
@cel_func char(11),
@email_func varchar(100),
@cargo_func varchar(30),
@salario_func money
)as
begin
	update tbEndereco
	set cep = @cep, numero = @numero, rua = @rua, bairro = @bairro, complemento = @complemento, cidade = @cidade, uf = @uf
	where cep = (select cep from tbEndereco inner join tbFuncionario on tbFuncionario.cep_func = tbEndereco.cep where tbFuncionario.cod_funcionario = @cod_funcionario) and numero = (select numero from tbEndereco inner join tbFuncionario on tbFuncionario.numcasa_func = tbEndereco.numero where tbFuncionario.cod_funcionario = @cod_funcionario);
	update tbFuncionario
	set nome_func = @nome_func, cpf_func = @cpf_func, rg_func = @rg_func, tel_func = @tel_func, cel_func = @cel_func, email_func = @email_func, cargo_func = @cargo_func, salario_func = @salario_func, cep_func = @cep, numcasa_func = @numero
	where cod_funcionario = @cod_funcionario;
end
GO

create proc sp_select_func(
@cod_funcionario int = null,
@nome_func varchar(70) = null,
@cpf_func varchar(11) = null,
@rg_func varchar(9) = null,
@status_func varchar(8) = null,
@tel_func varchar(10) = null,
@cel_func varchar(11) = null,
@email_func varchar(100) = null,
@cargo_func varchar(30) = null,
@salario_func money = null
)
as
begin
if (@cod_funcionario is not null) begin
	select F.cod_funcionario [ID], F.nome_func [Nome], F.cargo_func [Cargo], F.cpf_func [CPF], F.rg_func [RG], F.cel_func [Celular], F.tel_func [Telefone], F.salario_func [Salário], E.cep [CEP], E.rua [Rua], E.numero [Número], E.complemento [Complemento], E.bairro [Bairro], E.cidade [Cidade], E.uf [UF] from tbFuncionario F
	inner join tbEndereco E on F.cep_func = E.cep and F.numcasa_func = E.numero
	where cod_funcionario like @cod_funcionario;
end

else if (@nome_func is not null) begin
	select F.cod_funcionario [ID], F.nome_func [Nome], F.cargo_func [Cargo], F.cpf_func [CPF], F.rg_func [RG], F.cel_func [Celular], F.tel_func [Telefone], F.salario_func [Salário], E.cep [CEP], E.rua [Rua], E.numero [Número], E.complemento [Complemento], E.bairro [Bairro], E.cidade [Cidade], E.uf [UF] from tbFuncionario F
	inner join tbEndereco E on F.cep_func = E.cep and F.numcasa_func = E.numero
	where F.nome_func like CONCAT('%',@nome_func,'%');
end

else if (@cpf_func is not null) begin
	select F.cod_funcionario [ID], F.nome_func [Nome], F.cargo_func [Cargo], F.cpf_func [CPF], F.rg_func [RG], F.cel_func [Celular], F.tel_func [Telefone], F.salario_func [Salário], E.cep [CEP], E.rua [Rua], E.numero [Número], E.complemento [Complemento], E.bairro [Bairro], E.cidade [Cidade], E.uf [UF] from tbFuncionario F
	inner join tbEndereco E on F.cep_func = E.cep and F.numcasa_func = E.numero
	where F.cpf_func like CONCAT('%',@cpf_func,'%');
end

else if (@rg_func is not null) begin
	select F.cod_funcionario [ID], F.nome_func [Nome], F.cargo_func [Cargo], F.cpf_func [CPF], F.rg_func [RG], F.cel_func [Celular], F.tel_func [Telefone], F.salario_func [Salário], E.cep [CEP], E.rua [Rua], E.numero [Número], E.complemento [Complemento], E.bairro [Bairro], E.cidade [Cidade], E.uf [UF] from tbFuncionario F
	inner join tbEndereco E on F.cep_func = E.cep and F.numcasa_func = E.numero
	where F.rg_func like CONCAT('%',@rg_func,'%');
end

else if (@status_func is not null) begin
	select F.cod_funcionario [ID], F.nome_func [Nome], F.cargo_func [Cargo], F.cpf_func [CPF], F.rg_func [RG], F.cel_func [Celular], F.tel_func [Telefone], F.salario_func [Salário], E.cep [CEP], E.rua [Rua], E.numero [Número], E.complemento [Complemento], E.bairro [Bairro], E.cidade [Cidade], E.uf [UF] from tbFuncionario F
	inner join tbEndereco E on F.cep_func = E.cep and F.numcasa_func = E.numero
	where F.status_func like CONCAT('%',@status_func,'%');
end

else if (@tel_func is not null) begin
	select F.cod_funcionario [ID], F.nome_func [Nome], F.cargo_func [Cargo], F.cpf_func [CPF], F.rg_func [RG], F.cel_func [Celular], F.tel_func [Telefone], F.salario_func [Salário], E.cep [CEP], E.rua [Rua], E.numero [Número], E.complemento [Complemento], E.bairro [Bairro], E.cidade [Cidade], E.uf [UF] from tbFuncionario F
	inner join tbEndereco E on F.cep_func = E.cep and F.numcasa_func = E.numero
	where F.tel_func like CONCAT('%',@tel_func,'%');
end

else if (@cel_func is not null) begin
	select F.cod_funcionario [ID], F.nome_func [Nome], F.cargo_func [Cargo], F.cpf_func [CPF], F.rg_func [RG], F.cel_func [Celular], F.tel_func [Telefone], F.salario_func [Salário], E.cep [CEP], E.rua [Rua], E.numero [Número], E.complemento [Complemento], E.bairro [Bairro], E.cidade [Cidade], E.uf [UF] from tbFuncionario F
	inner join tbEndereco E on F.cep_func = E.cep and F.numcasa_func = E.numero
	where F.cel_func like CONCAT('%',@cel_func,'%');
end

else if (@email_func is not null) begin
	select F.cod_funcionario [ID], F.nome_func [Nome], F.cargo_func [Cargo], F.cpf_func [CPF], F.rg_func [RG], F.cel_func [Celular], F.tel_func [Telefone], F.salario_func [Salário], E.cep [CEP], E.rua [Rua], E.numero [Número], E.complemento [Complemento], E.bairro [Bairro], E.cidade [Cidade], E.uf [UF] from tbFuncionario F
	inner join tbEndereco E on F.cep_func = E.cep and F.numcasa_func = E.numero
	where F.email_func like CONCAT('%',@email_func,'%');
end

else if (@cargo_func is not null) begin
	select F.cod_funcionario [ID], F.nome_func [Nome], F.cargo_func [Cargo], F.cpf_func [CPF], F.rg_func [RG], F.cel_func [Celular], F.tel_func [Telefone], F.salario_func [Salário], E.cep [CEP], E.rua [Rua], E.numero [Número], E.complemento [Complemento], E.bairro [Bairro], E.cidade [Cidade], E.uf [UF] from tbFuncionario F
	inner join tbEndereco E on F.cep_func = E.cep and F.numcasa_func = E.numero
	where F.cargo_func like CONCAT('%',@cargo_func,'%');
end

else if (@salario_func is not null) begin
	select F.cod_funcionario [ID], F.nome_func [Nome], F.cargo_func [Cargo], F.cpf_func [CPF], F.rg_func [RG], F.cel_func [Celular], F.tel_func [Telefone], F.salario_func [Salário], E.cep [CEP], E.rua [Rua], E.numero [Número], E.complemento [Complemento], E.bairro [Bairro], E.cidade [Cidade], E.uf [UF] from tbFuncionario F
	inner join tbEndereco E on F.cep_func = E.cep and F.numcasa_func = E.numero
	where F.salario_func like @salario_func;
end

else begin
	select F.cod_funcionario [ID], F.nome_func [Nome], F.cargo_func [Cargo], F.cpf_func [CPF], F.rg_func [RG], F.cel_func [Celular], F.tel_func [Telefone], F.salario_func [Salário], E.cep [CEP], E.rua [Rua], E.numero [Número], E.complemento [Complemento], E.bairro [Bairro], E.cidade [Cidade], E.uf [UF] from tbFuncionario F
	inner join tbEndereco E on F.cep_func = E.cep and F.numcasa_func = E.numero;
end
end
GO

-- DONO

create proc sp_insert_dono(
@cep char(8),
@numero int,
@rua varchar(50),
@bairro varchar(50),
@complemento varchar(20) = null,
@cidade varchar(50),	
@uf char(2),
@nome_dono varchar(70),
@cpf_dono char(11),
@rg_dono char(9),
@tel_dono char(10) = null,
@cel_dono char(11),
@email_dono varchar(100)
) 
as 
	begin
		if(@complemento = null)set @complemento = 'Sem complemento';

		insert into tbEndereco (cep, numero, rua, bairro, complemento, cidade, uf)
				values (@cep, @numero, @rua, @bairro, @complemento, @cidade, @uf);
		insert into tbDono (nome_dono, cpf_dono, rg_dono, tel_dono, cel_dono, email_dono, cep_dono, numcasa_dono)
			values(@nome_dono, @cpf_dono, @rg_dono, @tel_dono, @cel_dono, @email_dono, @cep, @numero)
	end
 
GO

create proc sp_update_dono(
@cod_dono int,
@cep char(8),
@numero int,
@rua varchar(50),
@bairro varchar(50),
@complemento varchar(20),
@cidade varchar(50),	
@uf char(2),
@nome_dono varchar(70),
@cpf_dono char(11),
@rg_dono char(9),
@tel_dono char(10),
@cel_dono char(11),
@email_dono varchar(100)
)as
begin
	update tbEndereco
	set cep = @cep, numero = @numero, rua = @rua, bairro = @bairro, complemento = @complemento, cidade = @cidade, uf = @uf
	where cep = (select cep from tbEndereco inner join tbDono on tbDono.cep_dono = tbEndereco.cep where tbDono.cod_dono = @cod_dono) and numero = (select numero from tbEndereco inner join tbDono on tbDono.numcasa_dono = tbEndereco.numero where tbDono.cod_dono = @cod_dono);
	update tbDono
	set nome_dono = @nome_dono, cpf_dono = @cpf_dono, rg_dono = @rg_dono, tel_dono = @tel_dono, cel_dono = @cel_dono, email_dono = @email_dono, cep_dono = @cep, numcasa_dono = @numero
	where cod_dono = @cod_dono;
end
GO

create proc sp_select_dono(
@cod_dono int = null,
@nome_dono varchar(70) = null,
@cpf_dono varchar(11) = null,
@rg_dono varchar(9) = null,
@tel_dono varchar(10) = null,
@cel_dono varchar(11) = null,
@email_dono varchar(100) = null
)
as
begin
if (@cod_dono is not null) begin
	select D.cod_dono [ID], D.nome_dono [Nome], D.cpf_dono [CPF], D.rg_dono [RG], D.cel_dono [Celular], D.tel_dono [Telefone], E.cep [CEP], E.rua [Rua], E.numero [Número], E.complemento [Complemento], E.bairro [Bairro], E.cidade [Cidade], E.uf [UF] from tbDono D
	inner join tbEndereco E on D.cep_dono = E.cep and D.numcasa_dono = E.numero
	where D.cod_dono like @cod_dono;
end

else if (@nome_dono is not null) begin
	select D.cod_dono [ID], D.nome_dono [Nome], D.cpf_dono [CPF], D.rg_dono [RG], D.cel_dono [Celular], D.tel_dono [Telefone], E.cep [CEP], E.rua [Rua], E.numero [Número], E.complemento [Complemento], E.bairro [Bairro], E.cidade [Cidade], E.uf [UF] from tbDono D
	inner join tbEndereco E on D.cep_dono = E.cep and D.numcasa_dono = E.numero
	where D.nome_dono like concat('%',@nome_dono,'%');
end

else if (@cpf_dono is not null) begin
	select D.cod_dono [ID], D.nome_dono [Nome], D.cpf_dono [CPF], D.rg_dono [RG], D.cel_dono [Celular], D.tel_dono [Telefone], E.cep [CEP], E.rua [Rua], E.numero [Número], E.complemento [Complemento], E.bairro [Bairro], E.cidade [Cidade], E.uf [UF] from tbDono D
	inner join tbEndereco E on D.cep_dono = E.cep and D.numcasa_dono = E.numero
	where D.cpf_dono like concat('%',@cpf_dono,'%');
end

else if (@rg_dono is not null) begin
	select D.cod_dono [ID], D.nome_dono [Nome], D.cpf_dono [CPF], D.rg_dono [RG], D.cel_dono [Celular], D.tel_dono [Telefone], E.cep [CEP], E.rua [Rua], E.numero [Número], E.complemento [Complemento], E.bairro [Bairro], E.cidade [Cidade], E.uf [UF] from tbDono D
	inner join tbEndereco E on D.cep_dono = E.cep and D.numcasa_dono = E.numero
	where D.rg_dono like concat('%',@rg_dono,'%');
end

else if (@tel_dono is not null) begin
	select D.cod_dono [ID], D.nome_dono [Nome], D.cpf_dono [CPF], D.rg_dono [RG], D.cel_dono [Celular], D.tel_dono [Telefone], E.cep [CEP], E.rua [Rua], E.numero [Número], E.complemento [Complemento], E.bairro [Bairro], E.cidade [Cidade], E.uf [UF] from tbDono D
	inner join tbEndereco E on D.cep_dono = E.cep and D.numcasa_dono = E.numero
	where D.tel_dono like concat('%',@tel_dono,'%');
end

else if (@cel_dono is not null) begin
	select D.cod_dono [ID], D.nome_dono [Nome], D.cpf_dono [CPF], D.rg_dono [RG], D.cel_dono [Celular], D.tel_dono [Telefone], E.cep [CEP], E.rua [Rua], E.numero [Número], E.complemento [Complemento], E.bairro [Bairro], E.cidade [Cidade], E.uf [UF] from tbDono D
	inner join tbEndereco E on D.cep_dono = E.cep and D.numcasa_dono = E.numero
	where D.cel_dono like concat('%',@cel_dono,'%');
end

else if (@email_dono is not null) begin
	select D.cod_dono [ID], D.nome_dono [Nome], D.cpf_dono [CPF], D.rg_dono [RG], D.cel_dono [Celular], D.tel_dono [Telefone], E.cep [CEP], E.rua [Rua], E.numero [Número], E.complemento [Complemento], E.bairro [Bairro], E.cidade [Cidade], E.uf [UF] from tbDono D
	inner join tbEndereco E on D.cep_dono = E.cep and D.numcasa_dono = E.numero
	where D.email_dono like concat('%',@email_dono,'%');
end

else begin 
	select D.cod_dono [ID], D.nome_dono [Nome], D.cpf_dono [CPF], D.rg_dono [RG], D.cel_dono [Celular], D.tel_dono [Telefone], E.cep [CEP], E.rua [Rua], E.numero [Número], E.complemento [Complemento], E.bairro [Bairro], E.cidade [Cidade], E.uf [UF] from tbDono D
	inner join tbEndereco E on D.cep_dono = E.cep and D.numcasa_dono = E.numero;
end
end
GO

-- ANIMAL

create proc sp_insert_animal(
@rga int,
@cod_dono int,
@nome_animal varchar(70),
@idade int,
@tipo_idade char(5),
@raca_animal varchar(30),
@especie varchar(30),
@descricao varchar(100)
) 
as 
	begin
		insert into tbAnimal (rga, cod_dono, nome_animal, idade, tipo_idade, raca_animal, especie, descricao)
			values(@rga, @cod_dono, @nome_animal, @idade, @tipo_idade, @raca_animal, @especie, @descricao)
	end
GO

create proc sp_update_animal(
@cod_animal int,
@rga int,
@nome_animal varchar(70),
@idade int,
@tipo_idade char(5),
@raca_animal varchar(30),
@especie varchar(30),
@descricao varchar(100)
)as
begin
	update tbAnimal
	set rga = @rga, nome_animal = @nome_animal, idade = @idade, raca_animal = @raca_animal, tipo_idade = @tipo_idade, especie = @especie, descricao = @descricao
	where cod_animal = @cod_animal;
end
GO

create proc sp_select_animal(
@cod_animal int = null,
@rga int = null,
@nome_dono varchar(70) = null,
@nome_animal varchar(70) = null,
@idade int = null,
@raca_animal varchar(30) = null,
@especie varchar(30) = null,
@descricao varchar(100) = null
)
as
begin
if (@cod_animal is not null) begin
	select A.cod_animal [ID], A.rga [RGA], A.nome_animal [Nome], concat(A.idade, ' ', A.tipo_idade) [Idade], A.raca_animal [Raça], A.especie [Espécie], A.descricao [Descrição], D.nome_dono [Dono], D.cel_dono [Celular], D.tel_dono [Telefone] from tbAnimal A
	inner join tbDono D on A.cod_dono = D.cod_dono
	where A.cod_animal like @cod_animal;
end

else if (@rga is not null) begin
	select A.cod_animal [ID], A.rga [RGA], A.nome_animal [Nome], concat(A.idade, ' ', A.tipo_idade) [Idade], A.raca_animal [Raça], A.especie [Espécie], A.descricao [Descrição], D.nome_dono [Dono], D.cel_dono [Celular], D.tel_dono [Telefone] from tbAnimal A
	inner join tbDono D on A.cod_dono = D.cod_dono
	where A.rga like @rga;
end

else if (@nome_dono is not null) begin
	select A.cod_animal [ID], A.rga [RGA], A.nome_animal [Nome], concat(A.idade, ' ', A.tipo_idade) [Idade], A.raca_animal [Raça], A.especie [Espécie], A.descricao [Descrição], D.nome_dono [Dono], D.cel_dono [Celular], D.tel_dono [Telefone] from tbAnimal A
	inner join tbDono D on A.cod_dono = D.cod_dono
	where D.nome_dono like CONCAT('%',@nome_dono,'%');
end

else if (@nome_animal is not null) begin
	select A.cod_animal [ID], A.rga [RGA], A.nome_animal [Nome], concat(A.idade, ' ', A.tipo_idade) [Idade], A.raca_animal [Raça], A.especie [Espécie], A.descricao [Descrição], D.nome_dono [Dono], D.cel_dono [Celular], D.tel_dono [Telefone] from tbAnimal A
	inner join tbDono D on A.cod_dono = D.cod_dono
	where A.nome_animal like CONCAT('%',@nome_animal,'%');
end

else if (@idade is not null) begin
	select A.cod_animal [ID], A.rga [RGA], A.nome_animal [Nome], concat(A.idade, ' ', A.tipo_idade) [Idade], A.raca_animal [Raça], A.especie [Espécie], A.descricao [Descrição], D.nome_dono [Dono], D.cel_dono [Celular], D.tel_dono [Telefone] from tbAnimal A
	inner join tbDono D on A.cod_dono = D.cod_dono
	where A.idade like @idade;
end

else if (@raca_animal is not null) begin
	select A.cod_animal [ID], A.rga [RGA], A.nome_animal [Nome], concat(A.idade, ' ', A.tipo_idade) [Idade], A.raca_animal [Raça], A.especie [Espécie], A.descricao [Descrição], D.nome_dono [Dono], D.cel_dono [Celular], D.tel_dono [Telefone] from tbAnimal A
	inner join tbDono D on A.cod_dono = D.cod_dono
	where A.raca_animal like CONCAT('%',@raca_animal,'%');
end

else if (@especie is not null) begin
	select A.cod_animal [ID], A.rga [RGA], A.nome_animal [Nome], concat(A.idade, ' ', A.tipo_idade) [Idade], A.raca_animal [Raça], A.especie [Espécie], A.descricao [Descrição], D.nome_dono [Dono], D.cel_dono [Celular], D.tel_dono [Telefone] from tbAnimal A
	inner join tbDono D on A.cod_dono = D.cod_dono
	where A.especie like CONCAT('%',@especie,'%');
end

else if (@descricao is not null) begin
	select A.cod_animal [ID], A.rga [RGA], A.nome_animal [Nome], concat(A.idade, ' ', A.tipo_idade) [Idade], A.raca_animal [Raça], A.especie [Espécie], A.descricao [Descrição], D.nome_dono [Dono], D.cel_dono [Celular], D.tel_dono [Telefone] from tbAnimal A
	inner join tbDono D on A.cod_dono = D.cod_dono
	where A.descricao like CONCAT('%',@descricao,'%');
end

else begin
	select A.cod_animal [ID], A.rga [RGA], A.nome_animal [Nome], concat(A.idade, ' ', A.tipo_idade) [Idade], A.raca_animal [Raça], A.especie [Espécie], A.descricao [Descrição], D.nome_dono [Dono], D.cel_dono [Celular], D.tel_dono [Telefone] from tbAnimal A
	inner join tbDono D on A.cod_dono = D.cod_dono;
end
end
GO

-- CONSULTA

create proc sp_update_consulta(
@cod_consulta int,
@observacao_consulta varchar(300) = null,
@sintomas varchar(1000),
@diagnostico varchar(1000)
) 
as
	begin
		update tbConsulta
		set observacao_consulta = @observacao_consulta, sintomas = @sintomas, diagnostico = @diagnostico, status_consulta = 1
		where cod_consulta = @cod_consulta
	end
GO

create proc sp_insert_consulta(
@cod_animal int,
@cod_medico int,
@custo_consulta money,
@observacao_consulta varchar(300) = null,
@tipo_consulta varchar(15),
@data_consulta datetime
) 
as 
	begin
		insert into tbConsulta (cod_animal, cod_medico, observacao_consulta, custo_consulta, tipo_consulta, data_consulta)
			values(@cod_animal, @cod_medico, @observacao_consulta, @custo_consulta, @tipo_consulta, @data_consulta)
	end
GO

create proc sp_select_consulta(
@cod_consulta int = null,
@nome_animal varchar(70) = null,
@nome_medico varchar(70) = null,
@nome_dono varchar(70) = null,
@custo_consulta money = null,
@tipo_consulta varchar(15) = null
)
as
begin
if (@cod_consulta is not null) begin
	select C.cod_consulta [ID], RTRIM(M.nome_med) [Médico], A.nome_animal [Animal], D.nome_dono [Dono], C.data_consulta [Data], C.tipo_consulta [Tipo], C.sintomas [Sintomas], C.diagnostico [Diagnóstico], C.custo_consulta [Custo] from tbConsulta C
	inner join tbAnimal A on A.cod_animal = C.cod_animal
	inner join tbMedico M on M.cod_medico = C.cod_medico
	inner join tbDono D on D.cod_dono = A.cod_dono
	where C.cod_consulta like @cod_consulta;
end

else if (@nome_animal is not null) begin
	select C.cod_consulta [ID], RTRIM(M.nome_med) [Médico], A.nome_animal [Animal], D.nome_dono [Dono], C.data_consulta [Data], C.tipo_consulta [Tipo], C.sintomas [Sintomas], C.diagnostico [Diagnóstico], C.custo_consulta [Custo] from tbConsulta C
	inner join tbAnimal A on A.cod_animal = C.cod_animal
	inner join tbMedico M on M.cod_medico = C.cod_medico
	inner join tbDono D on D.cod_dono = A.cod_dono
	where A.nome_animal like concat('%',@nome_animal,'%');
end

else if (@nome_medico is not null) begin
	select C.cod_consulta [ID], RTRIM(M.nome_med) [Médico], A.nome_animal [Animal], D.nome_dono [Dono], C.data_consulta [Data], C.tipo_consulta [Tipo], C.sintomas [Sintomas], C.diagnostico [Diagnóstico], C.custo_consulta [Custo] from tbConsulta C
	inner join tbAnimal A on A.cod_animal = C.cod_animal
	inner join tbMedico M on M.cod_medico = C.cod_medico
	inner join tbDono D on D.cod_dono = A.cod_dono
	where M.nome_med like concat('%',@nome_medico,'%');
end

else if (@nome_dono is not null) begin
	select C.cod_consulta [ID], RTRIM(M.nome_med) [Médico], A.nome_animal [Animal], D.nome_dono [Dono], C.data_consulta [Data], C.tipo_consulta [Tipo], C.sintomas [Sintomas], C.diagnostico [Diagnóstico], C.custo_consulta [Custo] from tbConsulta C
	inner join tbAnimal A on A.cod_animal = C.cod_animal
	inner join tbMedico M on M.cod_medico = C.cod_medico
	inner join tbDono D on D.cod_dono = A.cod_dono
	where D.nome_dono like concat('%',@nome_dono,'%');
end

else if (@custo_consulta is not null) begin
	select C.cod_consulta [ID], RTRIM(M.nome_med) [Médico], A.nome_animal [Animal], D.nome_dono [Dono], C.data_consulta [Data], C.tipo_consulta [Tipo], C.sintomas [Sintomas], C.diagnostico [Diagnóstico], C.custo_consulta [Custo] from tbConsulta C
	inner join tbAnimal A on A.cod_animal = C.cod_animal
	inner join tbMedico M on M.cod_medico = C.cod_medico
	inner join tbDono D on D.cod_dono = A.cod_dono
	where C.custo_consulta like @custo_consulta;
end

else if (@tipo_consulta is not null) begin
	select C.cod_consulta [ID], RTRIM(M.nome_med) [Médico], A.nome_animal [Animal], D.nome_dono [Dono], C.data_consulta [Data], C.tipo_consulta [Tipo], C.sintomas [Sintomas], C.diagnostico [Diagnóstico], C.custo_consulta [Custo] from tbConsulta C
	inner join tbAnimal A on A.cod_animal = C.cod_animal
	inner join tbMedico M on M.cod_medico = C.cod_medico
	inner join tbDono D on D.cod_dono = A.cod_dono
	where C.tipo_consulta like concat('%',@tipo_consulta,'%');
end

else begin
	select C.cod_consulta [ID], RTRIM(M.nome_med) [Médico], A.nome_animal [Animal], D.nome_dono [Dono], C.data_consulta [Data], C.tipo_consulta [Tipo], C.sintomas [Sintomas], C.diagnostico [Diagnóstico], C.custo_consulta [Custo] from tbConsulta C
	inner join tbAnimal A on A.cod_animal = C.cod_animal
	inner join tbMedico M on M.cod_medico = C.cod_medico
	inner join tbDono D on D.cod_dono = A.cod_dono;
end
end
GO

-- TRATAMENTO

create proc sp_update_tratamento(
@cod_tratamento int,
@observacao varchar(300)
) 
as
	begin
		update tbTratamento
		set observacao_tratamento = @observacao, status_tratamento = 1
		where cod_tratamento = @cod_tratamento
	end
GO

create proc sp_insert_tratamento(
@cod_animal int,
@cod_medico int,
@cod_consulta int,
@tipo_tratamento varchar(30),
@observacao_tratamento varchar(300) = null,
@custo_tratamento money,
@data_tratamento datetime
) 
as 
	begin
		insert into tbTratamento(cod_animal, cod_medico, cod_consulta, tipo_tratamento, observacao_tratamento, custo_tratamento, data_tratamento)
			values (@cod_animal, @cod_medico, @cod_consulta, @tipo_tratamento, @observacao_tratamento, @custo_tratamento, @data_tratamento);
	end
GO

create proc sp_select_tratamento(
@cod_tratamento int = null,
@nome_animal varchar(70) = null,
@nome_medico varchar(70) = null,
@nome_dono varchar(70) = null,
@custo_tratamento money = null,
@tipo_tratamento varchar(30) = null
)
as
begin
if (@cod_tratamento is not null) begin
	select T.cod_tratamento [ID], RTRIM(M.nome_med) [Médico], A.nome_animal [Animal], D.nome_dono [Dono], T.tipo_tratamento [Tipo], T.custo_tratamento [Custo], T.observacao_tratamento [Observações], T.data_tratamento [Data] from tbTratamento T
	inner join tbAnimal A on A.cod_animal = T.cod_animal
	inner join tbMedico M on M.cod_medico = T.cod_medico
	inner join tbDono D on D.cod_dono = A.cod_dono
	where T.cod_tratamento like @cod_tratamento;
end

else if (@nome_animal is not null) begin
	select T.cod_tratamento [ID], RTRIM(M.nome_med) [Médico], A.nome_animal [Animal], D.nome_dono [Dono], T.tipo_tratamento [Tipo], T.custo_tratamento [Custo], T.observacao_tratamento [Observações], T.data_tratamento [Data] from tbTratamento T
	inner join tbAnimal A on A.cod_animal = T.cod_animal
	inner join tbMedico M on M.cod_medico = T.cod_medico
	inner join tbDono D on D.cod_dono = A.cod_dono
	where A.nome_animal like concat('%',@nome_animal,'%');
end

else if (@nome_medico is not null) begin
	select T.cod_tratamento [ID], RTRIM(M.nome_med) [Médico], A.nome_animal [Animal], D.nome_dono [Dono], T.tipo_tratamento [Tipo], T.custo_tratamento [Custo], T.observacao_tratamento [Observações], T.data_tratamento [Data] from tbTratamento T
	inner join tbAnimal A on A.cod_animal = T.cod_animal
	inner join tbMedico M on M.cod_medico = T.cod_medico
	inner join tbDono D on D.cod_dono = A.cod_dono
	where M.nome_med like concat('%',@nome_medico,'%');
end

else if (@nome_dono is not null) begin
	select T.cod_tratamento [ID], RTRIM(M.nome_med) [Médico], A.nome_animal [Animal], D.nome_dono [Dono], T.tipo_tratamento [Tipo], T.custo_tratamento [Custo], T.observacao_tratamento [Observações], T.data_tratamento [Data] from tbTratamento T
	inner join tbAnimal A on A.cod_animal = T.cod_animal
	inner join tbMedico M on M.cod_medico = T.cod_medico
	inner join tbDono D on D.cod_dono = A.cod_dono
	where D.nome_dono like concat('%',@nome_dono,'%');
end

else if (@custo_tratamento is not null) begin
	select T.cod_tratamento [ID], RTRIM(M.nome_med) [Médico], A.nome_animal [Animal], D.nome_dono [Dono], T.tipo_tratamento [Tipo], T.custo_tratamento [Custo], T.observacao_tratamento [Observações], T.data_tratamento [Data] from tbTratamento T
	inner join tbAnimal A on A.cod_animal = T.cod_animal
	inner join tbMedico M on M.cod_medico = T.cod_medico
	inner join tbDono D on D.cod_dono = A.cod_dono
	where T.custo_tratamento like @custo_tratamento;
end

else if (@tipo_tratamento is not null) begin
	select T.cod_tratamento [ID], RTRIM(M.nome_med) [Médico], A.nome_animal [Animal], D.nome_dono [Dono], T.tipo_tratamento [Tipo], T.custo_tratamento [Custo], T.observacao_tratamento [Observações], T.data_tratamento [Data] from tbTratamento T
	inner join tbAnimal A on A.cod_animal = T.cod_animal
	inner join tbMedico M on M.cod_medico = T.cod_medico
	inner join tbDono D on D.cod_dono = A.cod_dono
	where T.tipo_tratamento like concat('%',@tipo_tratamento,'%');
end

else begin
	select T.cod_tratamento [ID], RTRIM(M.nome_med) [Médico], A.nome_animal [Animal], D.nome_dono [Dono], T.tipo_tratamento [Tipo], T.custo_tratamento [Custo], T.observacao_tratamento [Observações], T.data_tratamento [Data] from tbTratamento T
	inner join tbAnimal A on A.cod_animal = T.cod_animal
	inner join tbMedico M on M.cod_medico = T.cod_medico
	inner join tbDono D on D.cod_dono = A.cod_dono;
end
end
GO

-- EXAME

create proc sp_update_exame(
@cod_exame int,
@observacao varchar(300)
) 
as
	begin
		update tbExame
		set observacao_exame = observacao_exame, status_exame = 1
		where cod_exame = @cod_exame
	end
GO

create proc sp_insert_exame(
@cod_animal int,
@cod_medico int,
@cod_consulta int,
@tipo_exame varchar(30),
@observacao_exame varchar(150),
@custo_exame money,
@data_exame datetime
) 
as 
	begin
		insert into tbExame(cod_animal, cod_medico, cod_consulta, tipo_exame, observacao_exame, custo_exame, data_exame)
			values (@cod_animal, @cod_medico, @cod_consulta, @tipo_exame, @observacao_exame, @custo_exame, @data_exame);
	end
 
GO

create proc sp_select_exame(
@cod_exame int = null,
@nome_animal varchar(70) = null,
@nome_medico varchar(70) = null,
@nome_dono varchar(70) = null,
@custo_exame money = null,
@tipo_exame varchar(30) = null
)
as
begin
if (@cod_exame is not null) begin
	select E.cod_exame [ID], RTRIM(M.nome_med) [Médico], A.nome_animal [Animal], D.nome_dono [Dono], E.tipo_exame [Tipo], E.custo_exame [Custo], E.data_exame [Data] from tbExame E
	inner join tbAnimal A on A.cod_animal = E.cod_animal
	inner join tbMedico M on M.cod_medico = E.cod_medico
	inner join tbDono D on D.cod_dono = A.cod_dono
	where E.cod_exame like @cod_exame;
end

else if (@nome_animal is not null) begin
	select E.cod_exame [ID], RTRIM(M.nome_med) [Médico], A.nome_animal [Animal], D.nome_dono [Dono], E.tipo_exame [Tipo], E.custo_exame [Custo], E.data_exame [Data] from tbExame E
	inner join tbAnimal A on A.cod_animal = E.cod_animal
	inner join tbMedico M on M.cod_medico = E.cod_medico
	inner join tbDono D on D.cod_dono = A.cod_dono
	where A.nome_animal like concat('%',@nome_animal,'%');
end

else if (@nome_medico is not null) begin
	select E.cod_exame [ID], RTRIM(M.nome_med) [Médico], A.nome_animal [Animal], D.nome_dono [Dono], E.tipo_exame [Tipo], E.custo_exame [Custo], E.data_exame [Data] from tbExame E
	inner join tbAnimal A on A.cod_animal = E.cod_animal
	inner join tbMedico M on M.cod_medico = E.cod_medico
	inner join tbDono D on D.cod_dono = A.cod_dono
	where M.nome_med like concat('%',@nome_medico,'%');
end

else if (@nome_dono is not null) begin
	select E.cod_exame [ID], RTRIM(M.nome_med) [Médico], A.nome_animal [Animal], D.nome_dono [Dono], E.tipo_exame [Tipo], E.custo_exame [Custo], E.data_exame [Data] from tbExame E
	inner join tbAnimal A on A.cod_animal = E.cod_animal
	inner join tbMedico M on M.cod_medico = E.cod_medico
	inner join tbDono D on D.cod_dono = A.cod_dono
	where D.nome_dono like concat('%',@nome_dono,'%');
end

else if (@custo_exame is not null) begin
	select E.cod_exame [ID], RTRIM(M.nome_med) [Médico], A.nome_animal [Animal], D.nome_dono [Dono], E.tipo_exame [Tipo], E.custo_exame [Custo], E.data_exame [Data] from tbExame E
	inner join tbAnimal A on A.cod_animal = E.cod_animal
	inner join tbMedico M on M.cod_medico = E.cod_medico
	inner join tbDono D on D.cod_dono = A.cod_dono
	where E.custo_exame like @custo_exame;
end

else if (@tipo_exame is not null) begin
	select E.cod_exame [ID], RTRIM(M.nome_med) [Médico], A.nome_animal [Animal], D.nome_dono [Dono], E.tipo_exame [Tipo], E.custo_exame [Custo], E.data_exame [Data] from tbExame E
	inner join tbAnimal A on A.cod_animal = E.cod_animal
	inner join tbMedico M on M.cod_medico = E.cod_medico
	inner join tbDono D on D.cod_dono = A.cod_dono
	where E.tipo_exame like concat('%',@tipo_exame,'%');
end

else if (@custo_exame is not null) begin
	select E.cod_exame [ID], RTRIM(M.nome_med) [Médico], A.nome_animal [Animal], D.nome_dono [Dono], E.tipo_exame [Tipo], E.custo_exame [Custo], E.data_exame [Data] from tbExame E
	inner join tbAnimal A on A.cod_animal = E.cod_animal
	inner join tbMedico M on M.cod_medico = E.cod_medico
	inner join tbDono D on D.cod_dono = A.cod_dono
	where E.custo_exame like @custo_exame;
end

else begin
	select E.cod_exame [ID], RTRIM(M.nome_med) [Médico], A.nome_animal [Animal], D.nome_dono [Dono], E.tipo_exame [Tipo], E.custo_exame [Custo], E.data_exame [Data] from tbExame E
	inner join tbAnimal A on A.cod_animal = E.cod_animal
	inner join tbMedico M on M.cod_medico = E.cod_medico
	inner join tbDono D on D.cod_dono = A.cod_dono;
end
end
GO

create proc sp_select_servicos(
@data_inicial datetime = null,
@data_final datetime = null,
@cod_medico int = null
)
as
begin

if (@data_inicial is not null and @data_final is not null) begin
select C.cod_consulta [ID], RTRIM(M.nome_med) [Médico], A.nome_animal [Animal], D.nome_dono [Dono], C.data_consulta [Data], 'Consulta' [Descrição], C.tipo_consulta [Tipo], C.custo_consulta [Custo], C.observacao_consulta [Observações] 
	from tbConsulta C

	inner join tbAnimal A on A.cod_animal = C.cod_animal
	inner join tbMedico M on M.cod_medico = C.cod_medico
	inner join tbDono D on D.cod_dono = A.cod_dono

	where C.data_consulta between @data_inicial and @data_final

	union

	select E.cod_exame [ID], RTRIM(M.nome_med) [Médico], A.nome_animal [Animal], D.nome_dono [Dono], E.data_exame [Data], 'Exame' [Descrição], E.tipo_exame [Tipo], E.custo_exame [Custo], E.observacao_exame [Observações] from tbExame E
	inner join tbAnimal A on A.cod_animal = E.cod_animal
	inner join tbMedico M on M.cod_medico = E.cod_medico
	inner join tbDono D on D.cod_dono = A.cod_dono
	
	where E.data_exame between @data_inicial and @data_final

	union

	select T.cod_tratamento [ID], RTRIM(M.nome_med) [Médico], A.nome_animal [Animal], D.nome_dono [Dono], T.data_tratamento [Data], 'Tratamento' [Descrição], T.tipo_tratamento [Tipo], T.custo_tratamento [Custo], T.observacao_tratamento [Observações] from tbTratamento T
	inner join tbAnimal A on A.cod_animal = T.cod_animal
	inner join tbMedico M on M.cod_medico = T.cod_medico
	inner join tbDono D on D.cod_dono = A.cod_dono

	where T.data_tratamento between @data_inicial and @data_final

end

else if (@data_inicial is not null and @data_final is not null and @cod_medico is not null) begin
select C.cod_consulta [ID], RTRIM(M.nome_med) [Médico], A.nome_animal [Animal], D.nome_dono [Dono], C.data_consulta [Data], 'Consulta' [Descrição], C.tipo_consulta [Tipo], C.custo_consulta [Custo], C.observacao_consulta [Observações] 
	from tbConsulta C

	inner join tbAnimal A on A.cod_animal = C.cod_animal
	inner join tbMedico M on M.cod_medico = C.cod_medico
	inner join tbDono D on D.cod_dono = A.cod_dono

	where M.cod_medico = @cod_medico and C.data_consulta between @data_inicial and @data_final

	union

	select E.cod_exame [ID], RTRIM(M.nome_med) [Médico], A.nome_animal [Animal], D.nome_dono [Dono], E.data_exame [Data], 'Exame' [Descrição], E.tipo_exame [Tipo], E.custo_exame [Custo], E.observacao_exame [Observações] from tbExame E
	inner join tbAnimal A on A.cod_animal = E.cod_animal
	inner join tbMedico M on M.cod_medico = E.cod_medico
	inner join tbDono D on D.cod_dono = A.cod_dono
	
	where M.cod_medico = @cod_medico and E.data_exame between @data_inicial and @data_final

	union

	select T.cod_tratamento [ID], RTRIM(M.nome_med) [Médico], A.nome_animal [Animal], D.nome_dono [Dono], T.data_tratamento [Data], 'Tratamento' [Descrição], T.tipo_tratamento [Tipo], T.custo_tratamento [Custo], T.observacao_tratamento [Observações] from tbTratamento T
	inner join tbAnimal A on A.cod_animal = T.cod_animal
	inner join tbMedico M on M.cod_medico = T.cod_medico
	inner join tbDono D on D.cod_dono = A.cod_dono

	where M.cod_medico = @cod_medico and T.data_tratamento between @data_inicial and @data_final
end

else if (@data_inicial is null and @data_final is null and @cod_medico is not null) begin
select C.cod_consulta [ID], RTRIM(M.nome_med) [Médico], A.nome_animal [Animal], D.nome_dono [Dono], C.data_consulta [Data], 'Consulta' [Descrição], C.tipo_consulta [Tipo], C.custo_consulta [Custo], C.observacao_consulta [Observações] 
	from tbConsulta C

	inner join tbAnimal A on A.cod_animal = C.cod_animal
	inner join tbMedico M on M.cod_medico = C.cod_medico
	inner join tbDono D on D.cod_dono = A.cod_dono

	where M.cod_medico = @cod_medico

	union

	select E.cod_exame [ID], RTRIM(M.nome_med) [Médico], A.nome_animal [Animal], D.nome_dono [Dono], E.data_exame [Data], 'Exame' [Descrição], E.tipo_exame [Tipo], E.custo_exame [Custo], E.observacao_exame [Observações] from tbExame E
	inner join tbAnimal A on A.cod_animal = E.cod_animal
	inner join tbMedico M on M.cod_medico = E.cod_medico
	inner join tbDono D on D.cod_dono = A.cod_dono
	
	where M.cod_medico = @cod_medico

	union

	select T.cod_tratamento [ID], RTRIM(M.nome_med) [Médico], A.nome_animal [Animal], D.nome_dono [Dono], T.data_tratamento [Data], 'Tratamento' [Descrição], T.tipo_tratamento [Tipo], T.custo_tratamento [Custo], T.observacao_tratamento [Observações] from tbTratamento T
	inner join tbAnimal A on A.cod_animal = T.cod_animal
	inner join tbMedico M on M.cod_medico = T.cod_medico
	inner join tbDono D on D.cod_dono = A.cod_dono

	where M.cod_medico = @cod_medico
end

else begin
	select C.cod_consulta [ID], RTRIM(M.nome_med) [Médico], A.nome_animal [Animal], D.nome_dono [Dono], C.data_consulta [Data], 'Consulta' [Descrição], C.tipo_consulta [Tipo], C.custo_consulta [Custo], C.observacao_consulta [Observações] 
	from tbConsulta C

	inner join tbAnimal A on A.cod_animal = C.cod_animal
	inner join tbMedico M on M.cod_medico = C.cod_medico
	inner join tbDono D on D.cod_dono = A.cod_dono

	union

	select E.cod_exame [ID], RTRIM(M.nome_med) [Médico], A.nome_animal [Animal], D.nome_dono [Dono], E.data_exame [Data], 'Exame' [Descrição], E.tipo_exame [Tipo], E.custo_exame [Custo], E.observacao_exame [Observações] from tbExame E
	inner join tbAnimal A on A.cod_animal = E.cod_animal
	inner join tbMedico M on M.cod_medico = E.cod_medico
	inner join tbDono D on D.cod_dono = A.cod_dono

	union

	select T.cod_tratamento [ID], RTRIM(M.nome_med) [Médico], A.nome_animal [Animal], D.nome_dono [Dono], T.data_tratamento [Data], 'Tratamento' [Descrição], T.tipo_tratamento [Tipo], T.custo_tratamento [Custo], T.observacao_tratamento [Observações] from tbTratamento T
	inner join tbAnimal A on A.cod_animal = T.cod_animal
	inner join tbMedico M on M.cod_medico = T.cod_medico
	inner join tbDono D on D.cod_dono = A.cod_dono
end

end
GO

-- USUÁRIO

create proc sp_insert_usuario(
@nome_usuario varchar(25),
@senha_usuario varchar(20),
@cod_funcionario int = null,
@cod_medico int = null
) 
as 
	begin
	if (select count (*) as cnt from tbUsuario where nome_usuario = @nome_usuario and senha_usuario = @senha_usuario) = 0
		begin
			insert into tbUsuario(nome_usuario, senha_usuario, cod_funcionario, cod_medico)
				values (@nome_usuario, @senha_usuario, @cod_funcionario, @cod_medico);
		end
	else
		print 'Já existe um usuário com esse nome!'
	end
GO

create proc sp_delete_usuario(
@cod_usuario int
)as
begin
    delete from tbUsuario where cod_usuario = @cod_usuario;
end
GO

create proc sp_select_usuario_ativo(
@cod_funcionario int = null,
@cod_medico int = null
)
as
begin
	select RTRIM(M.nome_med) [nome_med], F.nome_func from tbUsuario U
	left join tbMedico M on M.cod_medico = U.cod_medico
	left join tbFuncionario F on F.cod_funcionario = U.cod_funcionario
	where ativacao_usuario = 1;
end
GO

create proc sp_logar_usuario(
@nome_usuario varchar (25),
@senha_usuario varchar (20)
)
as
begin
	if (select count (*) as CNT from tbUsuario where nome_usuario = @nome_usuario and senha_usuario = @senha_usuario) = 1
		update tbUsuario set ativacao_usuario = 1 where nome_usuario = @nome_usuario and senha_usuario = @senha_usuario;
end
GO

-- INSERTS DE TESTE

exec sp_insert_func '12345678', 22, 'Rua rua', 'Bairro bairro', null, 'Cidade cidade', 'UF', 'Jorge', '12345678901', '123456789', '11986376726', '27362651', 'aaa', 'func', 1111
GO

exec sp_insert_usuario 'nome', 'senha', 1
GO

update tbUsuario set ativacao_usuario = 0 where cod_usuario = 1
GO

exec sp_insert_medico '34647384', 12, 'a', 'b', null, 'a', 'ff', 33333, 'Roberta', 'a', '733774584', '33333333', '3333333', '44444', 'aa', 34344
GO

exec sp_insert_usuario 'med', '123', null, 1
GO

update tbUsuario set ativacao_usuario = 0 where cod_usuario = 2
GO

exec sp_insert_dono 07856999, 23, 'a', 's', 'a', 'a', 'aa', 'Patrício', '73466377722', '564738372', '222222', '32222', 'sssssssssss'
GO