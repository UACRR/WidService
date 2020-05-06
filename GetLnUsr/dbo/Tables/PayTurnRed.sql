CREATE TABLE [dbo].[PayTurnRed] (
    [redId]       INT      IDENTITY (1, 1) NOT NULL,
    [dateWork]    DATE     NOT NULL,
    [turnId]      INT      NOT NULL,
    [turnIdRed]   INT      NULL,
    [dateWorkRed] DATE     NULL,
    [amount]      MONEY    NOT NULL,
    [AmountRest]  MONEY    NULL,
    [accId]       INT      NULL,
    [redType]     INT      NULL,
    [dateCreate]  DATETIME NULL,
    PRIMARY KEY CLUSTERED ([redId] ASC)
);


GO
CREATE NONCLUSTERED INDEX [i_PayTurnRed_TurnIdDateWork]
    ON [dbo].[PayTurnRed]([turnId] ASC, [dateWork] ASC);


GO
CREATE NONCLUSTERED INDEX [i_PayTurnRed_TurnIdRedDateWorkRed]
    ON [dbo].[PayTurnRed]([turnIdRed] ASC, [dateWorkRed] ASC);

