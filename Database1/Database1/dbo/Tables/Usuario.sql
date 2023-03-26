CREATE TABLE [dbo].[Usuario] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [Nome]       VARCHAR (1000) NOT NULL,
    [Sobrenome]  VARCHAR (1000) NOT NULL,
    [Telefone]   VARCHAR (1000) NOT NULL,
    [Email]      VARCHAR (1000) NOT NULL,
    [Senha]      VARCHAR (1000) NOT NULL,
    [DataInicio] DATE           NOT NULL,
    [DataFim]    DATE           NOT NULL,
    [Ativo]      BINARY (1)     NOT NULL,
    [Logado]     BINARY (1)     NOT NULL,
    [QtdAcesso]  INT            NOT NULL,
    [Msg]        VARCHAR (1000) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

