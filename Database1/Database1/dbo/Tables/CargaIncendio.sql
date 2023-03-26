CREATE TABLE [dbo].[CargaIncendio] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [Risco]           VARCHAR (1000) NOT NULL,
    [DescricaoLimite] VARCHAR (1000) NOT NULL,
    [Minimo]          DECIMAL (18)   NOT NULL,
    [Maximo]          DECIMAL (18)   NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

