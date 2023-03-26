CREATE TABLE [dbo].[NotaGeral] (
    [Id]               INT IDENTITY (1, 1) NOT NULL,
    [ItemNorma_Id]     INT NOT NULL,
    [DescricaoNota_Id] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([DescricaoNota_Id]) REFERENCES [dbo].[DescricaoNota] ([Id]),
    FOREIGN KEY ([ItemNorma_Id]) REFERENCES [dbo].[ItemNorma] ([Id])
);

