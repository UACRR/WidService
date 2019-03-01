CREATE TABLE [dbo].[ReportList] (
    [id]          INT            IDENTITY (1, 1) NOT NULL,
    [repCode]     VARCHAR (20)   NULL,
    [repType]     INT            NULL,
    [repName]     VARCHAR (200)  NULL,
    [repDesc]     VARCHAR (4000) NULL,
    [repDescFile] VARCHAR (200)  NULL,
    [repExec]     VARCHAR (200)  NULL,
    CONSTRAINT [PK_REPORTLIST] PRIMARY KEY CLUSTERED ([id] ASC)
);

