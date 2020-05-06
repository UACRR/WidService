CREATE TABLE [dbo].[RegisterCCIDMW] (
    [regId]         INT              NOT NULL,
    [regIItemId]    INT              NOT NULL,
    [ccIdClFileId]  INT              NOT NULL,
    [ddexReportid]  INT              NULL,
    [workcode]      VARCHAR (39)     NULL,
    [amountMech]    NUMERIC (30, 10) NOT NULL,
    [amountPerf]    NUMERIC (30, 10) NOT NULL,
    [amountMechCur] NUMERIC (30, 10) NULL,
    [amountPerfCur] NUMERIC (30, 10) NULL,
    CONSTRAINT [PK_REGISTERCCIDMW] PRIMARY KEY CLUSTERED ([regId] ASC, [regIItemId] ASC),
    CONSTRAINT [FK_REGISTER_REF_REGISTERCCIDMW] FOREIGN KEY ([regId], [regIItemId]) REFERENCES [dbo].[RegisterItem] ([regId], [regIItemId])
);

