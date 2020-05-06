CREATE TABLE [dbo].[TMPWIC] (
    [dateCreate]     DATETIME   NULL,
    [WIC]            INT        NULL,
    [objid]          INT        NULL,
    [sumAllTogether] FLOAT (53) NULL,
    [id]             INT        IDENTITY (1, 1) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

