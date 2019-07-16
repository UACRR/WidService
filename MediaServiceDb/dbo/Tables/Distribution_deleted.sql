CREATE TABLE [dbo].[Distribution_deleted] (
    [distId]         INT   NOT NULL,
    [regId]          INT   NULL,
    [rmId]           INT   NULL,
    [cRKindCode]     INT   NOT NULL,
    [status]         INT   NOT NULL,
    [distribDate]    DATE  NOT NULL,
    [amount]         MONEY NOT NULL,
    [partnerCommiss] MONEY NOT NULL,
    [courtFee]       MONEY NOT NULL,
    [partnerId]      INT   NULL,
    [isCourt]        BIT   NULL,
    [regIdBr]        INT   NULL,
    [distType]       INT   NULL,
    [custId]         INT   NULL,
    [cRightId]       INT   NULL,
    PRIMARY KEY CLUSTERED ([distId] ASC)
);

