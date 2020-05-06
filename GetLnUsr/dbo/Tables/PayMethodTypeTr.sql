CREATE TABLE [dbo].[PayMethodTypeTr] (
    [codeI] INT           NOT NULL,
    [lang]  CHAR (2)      NOT NULL,
    [name]  VARCHAR (100) NULL,
    CONSTRAINT [PK_PAYMETHODTYPETR] PRIMARY KEY CLUSTERED ([codeI] ASC, [lang] ASC),
    CONSTRAINT [FK_PAYMETHO_REFERENCE_PAYMETHO] FOREIGN KEY ([codeI]) REFERENCES [dbo].[PayMethodType] ([codeI])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'в т.ч. - оплата картой, оплата через банк, оплата со счета портала', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'PayMethodTypeTr';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Метод оплаты - карточкой, банковский перевод или наличные', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'PayMethodTypeTr', @level2type = N'COLUMN', @level2name = N'codeI';

