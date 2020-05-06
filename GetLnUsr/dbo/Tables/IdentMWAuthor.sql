CREATE TABLE [dbo].[IdentMWAuthor] (
    [id]                  INT            IDENTITY (1, 1) NOT NULL,
    [mwId]                INT            NOT NULL,
    [DdexReportId]        INT            NOT NULL,
    [BlockId]             INT            NOT NULL,
    [SalesTransactionId]  VARCHAR (100)  NOT NULL,
    [WIC]                 INT            NULL,
    [objId]               INT            NULL,
    [IP_BASE_NR]          VARCHAR (13)   NULL,
    [custId]              INT            NULL,
    [IPInr]               VARCHAR (13)   NULL,
    [ratePER]             DECIMAL (5, 2) NULL,
    [rateMEC]             DECIMAL (5, 2) NULL,
    [cmCodePER]           VARCHAR (3)    NULL,
    [cmCodeMEC]           VARCHAR (3)    NULL,
    [rateCmPER]           DECIMAL (5, 2) NULL,
    [rateCmMEC]           DECIMAL (5, 2) NULL,
    [excId]               INT            NULL,
    [excStatus]           INT            NULL,
    [ValidityPeriodEnd]   DATE           NULL,
    [ValidityPeriodStart] DATE           NULL,
    CONSTRAINT [PK_IDENTMWAUTHOR] PRIMARY KEY CLUSTERED ([id] ASC)
);


GO
CREATE NONCLUSTERED INDEX [iIdentMWAuthor_excStatus]
    ON [dbo].[IdentMWAuthor]([excStatus] ASC);

