CREATE TABLE [dbo].[MSIPInr] (
    [custId]     INT          NOT NULL,
    [IP_BASE_NR] VARCHAR (13) NOT NULL,
    [IPInr]      VARCHAR (11) NULL,
    [dateCreate] DATETIME     NULL,
    CONSTRAINT [PK_MSIPINR] PRIMARY KEY CLUSTERED ([custId] ASC)
);

