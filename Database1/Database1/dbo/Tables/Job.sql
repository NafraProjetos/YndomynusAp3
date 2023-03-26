CREATE TABLE [dbo].[Job] (
    [Id]             INT             IDENTITY (1, 1) NOT NULL,
    [Usuario_Id]     INT             NOT NULL,
    [Estado_Id]      INT             NOT NULL,
    [ObjetivoJob_Id] INT             NOT NULL,
    [IT14_Id]        INT             NOT NULL,
    [NomeJob]        VARCHAR (1000)  NOT NULL,
    [DataInicio]     DATE            NOT NULL,
    [DataEdificacao] DATE            NOT NULL,
    [Area]           DECIMAL (18, 2) NOT NULL,
    [Altura]         DECIMAL (18, 2) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([Estado_Id]) REFERENCES [dbo].[Estado] ([Id]),
    FOREIGN KEY ([IT14_Id]) REFERENCES [dbo].[IT14] ([Id]),
    FOREIGN KEY ([ObjetivoJob_Id]) REFERENCES [dbo].[ObjetivoJob] ([Id]),
    FOREIGN KEY ([Usuario_Id]) REFERENCES [dbo].[Usuario] ([Id])
);

