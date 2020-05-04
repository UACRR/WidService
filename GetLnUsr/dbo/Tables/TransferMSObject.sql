CREATE TABLE [dbo].[TransferMSObject] (
    [transferId]   INT           IDENTITY (1, 1) NOT NULL,
    [WIC]          INT           NOT NULL,
    [objId]        INT           NULL,
    [createDate]   DATETIME      DEFAULT (getdate()) NULL,
    [transferDate] DATETIME      NULL,
    [status]       INT           NULL,
    [comment]      VARCHAR (200) NULL,
    CONSTRAINT [PK_TRANSFEMSOBJECT] PRIMARY KEY CLUSTERED ([transferId] ASC)
);

