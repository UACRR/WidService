CREATE TABLE [dbo].[MoneyTypeTr] (
    [codeI] INT           NOT NULL,
    [lang]  CHAR (2)      NOT NULL,
    [name]  VARCHAR (200) NOT NULL,
    CONSTRAINT [PK_MONEYTYPETR] PRIMARY KEY CLUSTERED ([codeI] ASC, [lang] ASC),
    CONSTRAINT [FK_MONEYTYP_REFERENCE_MONEYTYP] FOREIGN KEY ([codeI]) REFERENCES [dbo].[MoneyType] ([codeI])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Язык ФИО оригинал', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'MoneyTypeTr', @level2type = N'COLUMN', @level2name = N'lang';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Тип платежа Трансляція', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'MoneyTypeTr';

