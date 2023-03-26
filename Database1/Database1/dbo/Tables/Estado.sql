CREATE TABLE [dbo].[Estado] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [NomeEstado] VARCHAR (1000) NOT NULL,
    [Ativo]      BINARY (1)     NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

