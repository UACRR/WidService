CREATE TABLE [dbo].[PayTurn] (
    [turnId]      INT             NOT NULL,
    [dateWork]    DATETIME        NOT NULL,
    [nD]          VARCHAR (25)    NULL,
    [nDDate]      DATE            NULL,
    [accIdDebet]  INT             NULL,
    [accIdCredit] INT             NULL,
    [accDebet]    VARCHAR (25)    NULL,
    [accCredit]   VARCHAR (25)    NULL,
    [amount]      NUMERIC (20, 2) NULL,
    [amountCur]   NUMERIC (20, 2) NULL,
    [payNote]     VARCHAR (160)   NULL,
    [r030]        CHAR (3)        NULL,
    [dateOper]    DATE            NOT NULL,
    [payStatus]   INT             NULL,
    [regId]       INT             NULL,
    [distId]      INT             NULL,
    [custIdRh]    INT             NULL,
    [regIItemId]  INT             NULL,
    CONSTRAINT [PK_PAYTURN] PRIMARY KEY CLUSTERED ([turnId] ASC, [dateWork] ASC),
    CONSTRAINT [FK_PAYTURN_REFERENCE_ACCOUNT] FOREIGN KEY ([accIdDebet]) REFERENCES [dbo].[Account] ([accId]),
    CONSTRAINT [FK_PAYTURN_REFERENCE_PAYMENTS] FOREIGN KEY ([payStatus]) REFERENCES [dbo].[PaymentStatus] ([codeI])
);


GO
CREATE NONCLUSTERED INDEX [date_idx]
    ON [dbo].[PayTurn]([dateOper] ASC);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Статус платежа', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'PayTurn', @level2type = N'COLUMN', @level2name = N'payStatus';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Дата операции', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'PayTurn', @level2type = N'COLUMN', @level2name = N'dateOper';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Код валюты
   ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'PayTurn', @level2type = N'COLUMN', @level2name = N'r030';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Назначение платежа', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'PayTurn', @level2type = N'COLUMN', @level2name = N'payNote';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Сумма платежа в номинале валюты', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'PayTurn', @level2type = N'COLUMN', @level2name = N'amountCur';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Сумма платежа в нац.валюте', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'PayTurn', @level2type = N'COLUMN', @level2name = N'amount';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Счет по кредиту
   ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'PayTurn', @level2type = N'COLUMN', @level2name = N'accCredit';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Счет по дебету', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'PayTurn', @level2type = N'COLUMN', @level2name = N'accDebet';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор счета кредита', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'PayTurn', @level2type = N'COLUMN', @level2name = N'accIdCredit';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'идентификатор счета дебета', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'PayTurn', @level2type = N'COLUMN', @level2name = N'accIdDebet';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Дата документа', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'PayTurn', @level2type = N'COLUMN', @level2name = N'nDDate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Номер документа', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'PayTurn', @level2type = N'COLUMN', @level2name = N'nD';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Текущая дата/время изменений', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'PayTurn', @level2type = N'COLUMN', @level2name = N'dateWork';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор записи', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'PayTurn', @level2type = N'COLUMN', @level2name = N'turnId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Таблица Платежей', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'PayTurn';

