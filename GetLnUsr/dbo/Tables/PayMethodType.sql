CREATE TABLE [dbo].[PayMethodType] (
    [codeI] INT           NOT NULL,
    [name]  VARCHAR (100) NULL,
    CONSTRAINT [PK_PAYMETHODTYPE] PRIMARY KEY CLUSTERED ([codeI] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'в т.ч. - оплата картой, оплата через банк, оплата со счета портала', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'PayMethodType';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Метод оплаты - карточкой, банковский перевод или наличные', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'PayMethodType', @level2type = N'COLUMN', @level2name = N'codeI';

