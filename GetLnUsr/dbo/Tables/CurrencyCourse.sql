CREATE TABLE [dbo].[CurrencyCourse] (
    [r030]       CHAR (3)        NOT NULL,
    [cDate]      DATE            NOT NULL,
    [cUnit]      INT             NULL,
    [cAmount]    NUMERIC (18, 5) NULL,
    [cAmountNBU] NUMERIC (18, 5) NULL,
    CONSTRAINT [PK_CURRENCYCOURSE] PRIMARY KEY CLUSTERED ([r030] ASC, [cDate] ASC),
    CONSTRAINT [FK_CURRENCY_REFERENCE_KL_R030] FOREIGN KEY ([r030]) REFERENCES [dbo].[KL_R030] ([r030])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Курс валют', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CurrencyCourse';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Код валюты', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CurrencyCourse', @level2type = N'COLUMN', @level2name = N'r030';

