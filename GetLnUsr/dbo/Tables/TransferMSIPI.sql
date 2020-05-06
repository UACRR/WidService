CREATE TABLE [dbo].[TransferMSIPI] (
    [transferId]   INT           IDENTITY (1, 1) NOT NULL,
    [IP_BASE_NR]   CHAR (13)     NOT NULL,
    [createDate]   DATETIME      DEFAULT (getdate()) NULL,
    [transferDate] DATETIME      NULL,
    [WIC]          INT           NULL,
    [custId]       INT           NULL,
    [status]       INT           NULL,
    [comment]      VARCHAR (200) NULL,
    CONSTRAINT [PK_TRANSFERMSIPI] PRIMARY KEY CLUSTERED ([transferId] ASC)
);

