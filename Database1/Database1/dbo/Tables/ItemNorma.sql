CREATE TABLE [dbo].[ItemNorma] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [Norma_Id] INT            NOT NULL,
    [Item]     VARCHAR (1000) NOT NULL,
    [Obs]      VARCHAR (1000) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([Norma_Id]) REFERENCES [dbo].[Norma] ([Id]),
    FOREIGN KEY ([Norma_Id]) REFERENCES [dbo].[Norma] ([Id]),
    FOREIGN KEY ([Norma_Id]) REFERENCES [dbo].[Norma] ([Id]),
    FOREIGN KEY ([Norma_Id]) REFERENCES [dbo].[Norma] ([Id]),
    FOREIGN KEY ([Norma_Id]) REFERENCES [dbo].[Norma] ([Id]),
    FOREIGN KEY ([Norma_Id]) REFERENCES [dbo].[Norma] ([Id])
);

