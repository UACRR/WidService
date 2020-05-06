CREATE TABLE [dbo].[HandDocPay] (
    [Id]          INT             IDENTITY (1, 1) NOT NULL,
    [turnId]      INT             NULL,
    [dateWork]    DATE            NOT NULL,
    [nD]          VARCHAR (25)    NULL,
    [nDDate]      DATE            NULL,
    [accIdDebet]  INT             NULL,
    [accIdCredit] INT             NULL,
    [accDebet]    VARCHAR (25)    NULL,
    [accCredit]   VARCHAR (25)    NULL,
    [amount]      NUMERIC (20, 2) NULL,
    [amountCur]   NUMERIC (20, 2) NULL,
    [payNote]     VARCHAR (160)   NULL,
    [r030]        CHAR (3)        NULL,
    [dateOper]    DATETIME        NULL,
    [payStatus]   INT             NULL,
    [regId]       INT             NULL,
    [distId]      INT             NULL,
    [custIdRh]    INT             NULL,
    [regIItemId]  INT             NULL,
    [PayTurnType] INT             NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

