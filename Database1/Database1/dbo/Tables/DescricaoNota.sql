CREATE TABLE [dbo].[DescricaoNota] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [Nota_Id]   INT            NOT NULL,
    [Descricao] VARCHAR (1000) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([Nota_Id]) REFERENCES [dbo].[Nota] ([Id]),
    FOREIGN KEY ([Nota_Id]) REFERENCES [dbo].[Nota] ([Id]),
    FOREIGN KEY ([Nota_Id]) REFERENCES [dbo].[Nota] ([Id]),
    FOREIGN KEY ([Nota_Id]) REFERENCES [dbo].[Nota] ([Id]),
    FOREIGN KEY ([Nota_Id]) REFERENCES [dbo].[Nota] ([Id]),
    FOREIGN KEY ([Nota_Id]) REFERENCES [dbo].[Nota] ([Id]),
    FOREIGN KEY ([Nota_Id]) REFERENCES [dbo].[Nota] ([Id]),
    FOREIGN KEY ([Nota_Id]) REFERENCES [dbo].[Nota] ([Id]),
    FOREIGN KEY ([Nota_Id]) REFERENCES [dbo].[Nota] ([Id])
);

