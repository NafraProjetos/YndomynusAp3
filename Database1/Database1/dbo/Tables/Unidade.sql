CREATE TABLE [dbo].[Unidade] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [Siu]       VARCHAR (1000) NOT NULL,
    [Parametro] VARCHAR (1000) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

