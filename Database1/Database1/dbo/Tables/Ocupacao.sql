CREATE TABLE [dbo].[Ocupacao] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Grupo]       VARCHAR (1000) NOT NULL,
    [OcupacaoUso] VARCHAR (1000) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

