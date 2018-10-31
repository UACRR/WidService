CREATE TABLE [dbo].[Invoice] (
    [docId]       INT            NOT NULL,
    [payCustId]   INT            NULL,
    [recCustId]   INT            NULL,
    [payAnk]      INT            NULL,
    [recAnk]      INT            NULL,
    [r030]        CHAR (3)       NULL,
    [Amount]      MONEY          NULL,
    [recMFO]      VARCHAR (64)   NULL,
    [recBankName] VARCHAR (254)  NULL,
    [purpose]     VARCHAR (3000) NULL,
    [status]      INT            NULL,
    PRIMARY KEY CLUSTERED ([docId] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'назнаяение платежа', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Invoice', @level2type = N'COLUMN', @level2name = N'purpose';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Банк получателя', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Invoice', @level2type = N'COLUMN', @level2name = N'recBankName';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Мфо получателя', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Invoice', @level2type = N'COLUMN', @level2name = N'recMFO';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'сумма платежа', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Invoice', @level2type = N'COLUMN', @level2name = N'Amount';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'валюта', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Invoice', @level2type = N'COLUMN', @level2name = N'r030';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'версия анкеты получателя', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Invoice', @level2type = N'COLUMN', @level2name = N'recAnk';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'версия анкеты плательщика', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Invoice', @level2type = N'COLUMN', @level2name = N'payAnk';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Получатель CustId', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Invoice', @level2type = N'COLUMN', @level2name = N'recCustId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Плательщик CustId', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Invoice', @level2type = N'COLUMN', @level2name = N'payCustId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Идентификатор документа', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Invoice', @level2type = N'COLUMN', @level2name = N'docId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Таблица выставленных счетов
   ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Invoice';

