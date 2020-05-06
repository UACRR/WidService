CREATE TABLE [dbo].[RepMSIPI] (
    [custId]     INT          NOT NULL,
    [IP_BASE_NR] VARCHAR (13) NOT NULL,
    [IPInr]      VARCHAR (11) NULL,
    [dateCreate] DATETIME     NULL,
    CONSTRAINT [PK_REPMSIPI] PRIMARY KEY CLUSTERED ([custId] ASC, [IP_BASE_NR] ASC)
);

