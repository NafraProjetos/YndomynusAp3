CREATE TABLE [dbo].[Capacidade] (
    [Id]         INT             IDENTITY (1, 1) NOT NULL,
    [Unidade_Id] INT             NOT NULL,
    [Minimo]     DECIMAL (18, 2) NOT NULL,
    [Maximo]     DECIMAL (18, 2) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([Unidade_Id]) REFERENCES [dbo].[Unidade] ([Id]),
    FOREIGN KEY ([Unidade_Id]) REFERENCES [dbo].[Unidade] ([Id]),
    FOREIGN KEY ([Unidade_Id]) REFERENCES [dbo].[Unidade] ([Id]),
    FOREIGN KEY ([Unidade_Id]) REFERENCES [dbo].[Unidade] ([Id]),
    FOREIGN KEY ([Unidade_Id]) REFERENCES [dbo].[Unidade] ([Id]),
    FOREIGN KEY ([Unidade_Id]) REFERENCES [dbo].[Unidade] ([Id]),
    FOREIGN KEY ([Unidade_Id]) REFERENCES [dbo].[Unidade] ([Id]),
    FOREIGN KEY ([Unidade_Id]) REFERENCES [dbo].[Unidade] ([Id]),
    FOREIGN KEY ([Unidade_Id]) REFERENCES [dbo].[Unidade] ([Id])
);

