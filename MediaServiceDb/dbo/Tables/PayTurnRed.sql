CREATE TABLE [dbo].[PayTurnRed] (
    [redId]       INT   IDENTITY (1, 1) NOT NULL,
    [dateWork]    DATE  NOT NULL,
    [turnId]      INT   NOT NULL,
    [turnIdRed]   INT   NULL,
    [dateWorkRed] DATE  NULL,
    [amount]      MONEY NOT NULL,
    [AmountRest]  MONEY NULL,
    [accId]       INT   NULL,
    [redType]     INT   NULL,
    PRIMARY KEY CLUSTERED ([redId] ASC)
);

