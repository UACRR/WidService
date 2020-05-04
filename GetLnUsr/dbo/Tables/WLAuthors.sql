CREATE TABLE [dbo].[WLAuthors] (
    [id]          INT           IDENTITY (1, 1) NOT NULL,
    [createDate]  DATETIME      NULL,
    [IPInr]       VARCHAR (11)  NOT NULL,
    [IP_BASE_NR]  VARCHAR (13)  NULL,
    [lstName]     VARCHAR (254) NULL,
    [fstName]     VARCHAR (254) NULL,
    [authorName]  VARCHAR (254) NULL,
    [rhCustId]    INT           NULL,
    [custIdNew]   INT           NULL,
    [roleCode]    INT           NULL,
    [CmCodePER]   VARCHAR (10)  NULL,
    [CmCodeMEC]   VARCHAR (10)  NULL,
    [CmCustIdPER] INT           NULL,
    [CmCustIdMEC] INT           NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

