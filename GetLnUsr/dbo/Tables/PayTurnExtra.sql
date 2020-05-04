CREATE TABLE [dbo].[PayTurnExtra] (
    [turnid]      INT         NOT NULL,
    [datework]    DATE        NOT NULL,
    [custid]      INT         NULL,
    [payturntype] INT         NULL,
    [cmCustId]    INT         NULL,
    [balsDebet]   VARCHAR (2) NULL,
    [balsCredit]  VARCHAR (2) NULL,
    PRIMARY KEY CLUSTERED ([datework] ASC, [turnid] ASC)
);


GO
CREATE NONCLUSTERED INDEX [i_PayTurnExtra_cmCustId]
    ON [dbo].[PayTurnExtra]([cmCustId] ASC);


GO
CREATE NONCLUSTERED INDEX [PayTurnExtra_Bals]
    ON [dbo].[PayTurnExtra]([balsDebet] ASC, [balsCredit] ASC);

