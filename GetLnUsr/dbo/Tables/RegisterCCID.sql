CREATE TABLE [dbo].[RegisterCCID] (
    [regId]        INT              NOT NULL,
    [DdexReportId] INT              NOT NULL,
    [CcidClFileId] INT              NOT NULL,
    [amountCur]    NUMERIC (30, 10) NULL,
    [ExchangeRate] NUMERIC (30, 10) NULL,
    [r030]         CHAR (3)         NULL,
    CONSTRAINT [PK_REGISTERCCID] PRIMARY KEY CLUSTERED ([regId] ASC),
    CONSTRAINT [FK_REGISTER_REF_REGCCID] FOREIGN KEY ([regId]) REFERENCES [dbo].[Register] ([regId]),
    CONSTRAINT [FK_RegisterCCIDR030] FOREIGN KEY ([r030]) REFERENCES [dbo].[KL_R030] ([r030])
);

