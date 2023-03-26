CREATE TABLE [dbo].[ParametroOcupacao] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [Capacidade_Id] INT            NOT NULL,
    [Tipo]          VARCHAR (1000) NOT NULL,
    [Denominacao]   VARCHAR (1000) NOT NULL,
    [Obs]           VARCHAR (1000) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([Capacidade_Id]) REFERENCES [dbo].[Capacidade] ([Id]),
    FOREIGN KEY ([Capacidade_Id]) REFERENCES [dbo].[Capacidade] ([Id]),
    FOREIGN KEY ([Capacidade_Id]) REFERENCES [dbo].[Capacidade] ([Id]),
    FOREIGN KEY ([Capacidade_Id]) REFERENCES [dbo].[Capacidade] ([Id]),
    FOREIGN KEY ([Capacidade_Id]) REFERENCES [dbo].[Capacidade] ([Id]),
    FOREIGN KEY ([Capacidade_Id]) REFERENCES [dbo].[Capacidade] ([Id]),
    FOREIGN KEY ([Capacidade_Id]) REFERENCES [dbo].[Capacidade] ([Id]),
    FOREIGN KEY ([Capacidade_Id]) REFERENCES [dbo].[Capacidade] ([Id]),
    FOREIGN KEY ([Capacidade_Id]) REFERENCES [dbo].[Capacidade] ([Id])
);

