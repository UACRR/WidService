CREATE TABLE [dbo].[TaxRate] (
    [codeI]     INT            NOT NULL,
    [dateBegin] DATE           NOT NULL,
    [dateEnd]   DATE           NULL,
    [name]      VARCHAR (100)  NULL,
    [rate]      DECIMAL (5, 2) NULL,
    CONSTRAINT [PK_TAXRATE] PRIMARY KEY CLUSTERED ([codeI] ASC, [dateBegin] ASC)
);

