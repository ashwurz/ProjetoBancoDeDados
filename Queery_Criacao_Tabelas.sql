use ProjetoBanco
GO

create table Materia_Prima(Nome VarChar(30) not null, Custo varchar(20) not null, Quantidade_Estoque int not null);
go

alter table Materia_Prima add constraint PK_Materia_Prima PRIMARY KEY(Nome);

go

create table Produtos(Nome varchar(30) not null, Tempo_Producao_Minutos int not null,Nome_Materia_Principal varchar(30) not null, Lucro_Producao varchar(20) not null, Quantidade_Estoque int not null);
go

alter table Produtos add constraint PK_Produtos primary key(Nome);
go

alter table Produtos add constraint FK_Produtos FOREIGN KEY(Nome_Materia_Principal) references Materia_Prima(Nome);
go

create table Produtos_Finalizados(Sequencia_Producao int Identity(1,1) not null,Nome varchar(30) not null,Data_Producao datetime not null);
go

alter table Produtos_Finalizados add constraint PK_Produtos_Finalizados primary key(Sequencia_Producao);
go

alter table Produtos_Finalizados add constraint FK_Produtos_Finalizados FOREIGN KEY(Nome) references Produtos(Nome);
go