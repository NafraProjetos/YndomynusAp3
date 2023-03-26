CREATE TABLE [dbo].[DivisaoOcupacao] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Ocupacao_Id] INT            NOT NULL,
    [Divisao]     VARCHAR (1000) NOT NULL,
    [Descricao]   VARCHAR (1000) NOT NULL,
    [Exemplo]     VARCHAR (1000) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([Ocupacao_Id]) REFERENCES [dbo].[Ocupacao] ([Id]),
    FOREIGN KEY ([Ocupacao_Id]) REFERENCES [dbo].[Ocupacao] ([Id]),
    FOREIGN KEY ([Ocupacao_Id]) REFERENCES [dbo].[Ocupacao] ([Id]),
    FOREIGN KEY ([Ocupacao_Id]) REFERENCES [dbo].[Ocupacao] ([Id]),
    FOREIGN KEY ([Ocupacao_Id]) REFERENCES [dbo].[Ocupacao] ([Id]),
    FOREIGN KEY ([Ocupacao_Id]) REFERENCES [dbo].[Ocupacao] ([Id]),
    FOREIGN KEY ([Ocupacao_Id]) REFERENCES [dbo].[Ocupacao] ([Id]),
    FOREIGN KEY ([Ocupacao_Id]) REFERENCES [dbo].[Ocupacao] ([Id])
);

