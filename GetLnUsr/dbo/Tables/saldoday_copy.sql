CREATE TABLE [dbo].[saldoday_copy] (
    [accId]          INT             NOT NULL,
    [dateBegin]      DATE            NOT NULL,
    [dateEnd]        DATE            NULL,
    [r030]           CHAR (3)        NULL,
    [rest]           NUMERIC (20, 2) NULL,
    [restCourt]      NUMERIC (20, 2) NULL,
    [deboborot]      NUMERIC (20, 2) NULL,
    [krdOborot]      NUMERIC (20, 2) NULL,
    [deboborotCourt] NUMERIC (20, 2) NULL,
    [krdOborotCourt] NUMERIC (20, 2) NULL,
    [restBegin]      NUMERIC (20, 2) NULL,
    [restBeginCourt] NUMERIC (20, 2) NULL
);

