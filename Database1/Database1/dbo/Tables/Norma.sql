CREATE TABLE [dbo].[Norma] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [NumeroNorma] VARCHAR (1000) NOT NULL,
    [Obs]         VARCHAR (1000) NOT NULL,
    [Data]        DATE           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

