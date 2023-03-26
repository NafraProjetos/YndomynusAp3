CREATE TABLE [dbo].[ObjetivoJob] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [Objetivo] VARCHAR (1000) NOT NULL,
    [Ativo]    BINARY (1)     NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

