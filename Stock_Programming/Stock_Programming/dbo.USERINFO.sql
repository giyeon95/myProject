CREATE TABLE [dbo].[USERINFO] (
    [Id]         VARCHAR (15) NOT NULL,
    [Passward]   VARCHAR (15) NOT NULL,
    [StartMoney] INT          NOT NULL,
    [EndMoney]   INT          NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

