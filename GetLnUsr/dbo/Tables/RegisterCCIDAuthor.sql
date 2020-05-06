CREATE TABLE [dbo].[RegisterCCIDAuthor] (
    [regId]      INT            NOT NULL,
    [regIItemId] INT            NOT NULL,
    [regAuthId]  INT            NOT NULL,
    [IP_BASE_NR] VARCHAR (13)   NULL,
    [ratePER]    DECIMAL (5, 2) NULL,
    [rateMEC]    DECIMAL (5, 2) NULL,
    [custId]     INT            NULL,
    [cmCodePER]  CHAR (3)       NULL,
    [cmCodeMEC]  CHAR (3)       NULL,
    CONSTRAINT [PK_REGISTERCCIDAUTHOR] PRIMARY KEY CLUSTERED ([regId] ASC, [regIItemId] ASC, [regAuthId] ASC),
    CONSTRAINT [FK_REGISTER_REFERENCE_REGISTERCCIDAuth] FOREIGN KEY ([regId], [regIItemId]) REFERENCES [dbo].[RegisterCCIDMW] ([regId], [regIItemId])
);

