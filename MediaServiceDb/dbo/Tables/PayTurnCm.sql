CREATE TABLE [dbo].[PayTurnCm] (
    [accId]           INT             NOT NULL,
    [dateWork]        DATE            NOT NULL,
    [kindCode]        INT             NOT NULL,
    [amount_sum]      MONEY           NULL,
    [amountCourt_sum] MONEY           NULL,
    [rateCommiss]     DECIMAL (10, 5) NULL,
    [rateCourt]       DECIMAL (10, 5) NULL,
    [amount]          MONEY           NULL,
    [amountCourt]     MONEY           NULL,
    [amountCommiss]   MONEY           NULL,
    [custid]          INT             NULL,
    [custIdRh]        INT             NULL,
    [custIdCm]        INT             NULL,
    [accNls]          VARCHAR (25)    NULL,
    CONSTRAINT [PK_PAYTURNCM] PRIMARY KEY CLUSTERED ([accId] ASC, [dateWork] ASC, [kindCode] ASC)
);

