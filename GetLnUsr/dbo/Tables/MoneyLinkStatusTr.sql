CREATE TABLE [dbo].[MoneyLinkStatusTr] (
    [codeI] INT           NOT NULL,
    [lang]  CHAR (2)      NOT NULL,
    [name]  VARCHAR (100) NULL,
    CONSTRAINT [PK_MONEYLINKSTATUSTR] PRIMARY KEY CLUSTERED ([codeI] ASC, [lang] ASC),
    CONSTRAINT [FK_MONEYLIN_REFERENCE_MONEYLIN] FOREIGN KEY ([codeI]) REFERENCES [dbo].[MoneyLinkStatus] ([codeI])
);

