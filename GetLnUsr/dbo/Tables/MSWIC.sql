CREATE TABLE [dbo].[MSWIC] (
    [WIC]        INT      NOT NULL,
    [objId]      INT      NOT NULL,
    [dateCreate] DATETIME NULL,
    CONSTRAINT [PK_MSWIC] PRIMARY KEY CLUSTERED ([WIC] ASC, [objId] ASC)
);

