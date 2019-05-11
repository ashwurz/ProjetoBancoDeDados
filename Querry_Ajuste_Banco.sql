use ProjetoBanco
go

drop table Estoque_Materia_Prima
go

drop table Estoque_Produtos
go

drop table Produtos_Finalizados
go

drop table Produtos
go

drop table Materia_Prima
go

CREATE TABLE [dbo].[Materia_Prima](
	[Nome] [varchar](30) NOT NULL,
	[Custo] [varchar](20) NOT NULL,
	[Quantidade_Estoque] [int] NOT NULL,
 CONSTRAINT [PK_Materia_Prima] PRIMARY KEY CLUSTERED 
(
	[Nome] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Produtos](
	[Nome] [varchar](30) NOT NULL,
	[Tempo_Producao_Minutos] [int] NOT NULL,
	[Nome_Materia_Principal] [varchar](30) NOT NULL,
	[Lucro_Producao] [varchar](20) NOT NULL,
	[Quantidade_Estoque] [int] NOT NULL,
 CONSTRAINT [PK_Produtos] PRIMARY KEY CLUSTERED 
(
	[Nome] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Produtos]  WITH CHECK ADD  CONSTRAINT [FK_Produtos] FOREIGN KEY([Nome_Materia_Principal])
REFERENCES [dbo].[Materia_Prima] ([Nome])
GO

ALTER TABLE [dbo].[Produtos] CHECK CONSTRAINT [FK_Produtos]
GO

CREATE TABLE [dbo].[Produtos_Finalizados](
	[Sequencia_Producao] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](30) NOT NULL,
	[Data_Producao] [datetime] NOT NULL,
 CONSTRAINT [PK_Produtos_Finalizados] PRIMARY KEY CLUSTERED 
(
	[Sequencia_Producao] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Produtos_Finalizados]  WITH CHECK ADD  CONSTRAINT [FK_Produtos_Finalizados] FOREIGN KEY([Nome])
REFERENCES [dbo].[Produtos] ([Nome])
GO

ALTER TABLE [dbo].[Produtos_Finalizados] CHECK CONSTRAINT [FK_Produtos_Finalizados]
GO
