use ProjetoBanco
GO

create table Materia_Prima(ID_Materia_Prima int not null, Nome VarChar(30) not null, Custo varchar(20) not null);
go
alter table Materia_Prima add constraint PK_Materia_Prima PRIMARY KEY(ID_Materia_Prima, Nome);
go
create table Estoque_Materia_Prima(Sequencia_Estoque int identity(1,1) not null, ID_Materia_Prima int not null, Nome varchar(30) not null, Quantidade int not null);
go
alter table Estoque_Materia_Prima add constraint PK_Estoque_Materia_Prima PRIMARY KEY(Sequencia_Estoque);
go
alter table Estoque_Materia_Prima add constraint FK_Estoque_Materia_Prima FOREIGN KEY(ID_Materia_Prima,Nome) references Materia_Prima(ID_Materia_Prima,Nome);
go

create table Produtos(ID_Produtos int not null, Nome varchar(30) not null, Tempo_Producao_Minutos int not null, ID_Materia_Principal int not null, Nome_Materia_Principal varchar(30) not null, Lucro_Producao varchar(20) not null);
go

alter table Produtos add constraint PK_Produtos primary key(ID_Produtos,Nome);
go

alter table Produtos add constraint FK_Produtos FOREIGN KEY(ID_Materia_Principal,Nome_Materia_Principal) references Materia_Prima(ID_Materia_Prima, Nome);
go

create table Produtos_Finalizados(Sequencia_Producao int Identity(1,1) not null, ID_Produto int not null, Nome varchar(30) not null, Data_Producao datetime not null);
go

alter table Produtos_Finalizados add constraint PK_Produtos_Finalizados primary key(Sequencia_Producao);
go

alter table Produtos_Finalizados add constraint FK_Produtos_Finalizados FOREIGN KEY(ID_Produto, Nome) references Produtos(ID_Produtos, Nome);
go

create table Estoque_Produtos(Sequencia_Estoque int identity(1,1) not null, ID_Produto int not null, Nome VARCHAR(30) not null, Quantidade int not null);
go
alter table Estoque_Produtos add constraint PK_Estoque_Produtos PRIMARY KEY(Sequencia_Estoque);
go
alter table Estoque_Produtos add constraint FK_Estoque_Produtos FOREIGN KEY(ID_Produto, Nome) references Produtos(ID_Produtos, Nome);
go

