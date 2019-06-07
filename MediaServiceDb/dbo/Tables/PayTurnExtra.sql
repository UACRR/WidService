CREATE TABLE [dbo].[PayTurnExtra] (
    [turnid]      INT  NOT NULL,
    [datework]    DATE NOT NULL,
    [custid]      INT  NULL,
    [payturntype] INT  NULL,
    PRIMARY KEY CLUSTERED ([datework] ASC, [turnid] ASC)
);

