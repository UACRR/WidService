CREATE TABLE [dbo].[RepMSWIC] (
    [WIC]        INT      NOT NULL,
    [objId]      INT      NOT NULL,
    [dateCreate] DATETIME NULL,
    CONSTRAINT [PK_REPMSWIC] PRIMARY KEY CLUSTERED ([WIC] ASC, [objId] ASC)
);

