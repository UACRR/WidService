CREATE TABLE [dbo].[DocPreparePay] (
    [docPayId]    INT             IDENTITY (1, 1) NOT NULL,
    [dateWork]    DATE            NOT NULL,
    [regId]       INT             NULL,
    [distId]      INT             NULL,
    [nD]          VARCHAR (25)    NULL,
    [nDDate]      DATE            NULL,
    [accIdDebet]  INT             NULL,
    [accIdCredit] INT             NULL,
    [accDebet]    VARCHAR (25)    NULL,
    [accCredit]   VARCHAR (25)    NULL,
    [amount]      NUMERIC (20, 2) NULL,
    [amountCur]   NUMERIC (20, 2) NULL,
    [payNote]     VARCHAR (256)   NULL,
    [r030]        CHAR (3)        NULL,
    [dateOper]    DATETIME        NOT NULL,
    [payStatus]   INT             NULL,
    [paidid]      INT             NULL,
    [flCourt]     TINYINT         NULL,
    [custIdRh]    INT             NULL,
    CONSTRAINT [PK_DOCPREPAREPAY] PRIMARY KEY CLUSTERED ([docPayId] ASC, [dateWork] ASC),
    CONSTRAINT [FK_DOCPREPA_REFERENCE_PAYMENTS] FOREIGN KEY ([payStatus]) REFERENCES [dbo].[PaymentStatus] ([codeI])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Подготовленные документы для оплаты', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DocPreparePay';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Идентификатор документа', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DocPreparePay', @level2type = N'COLUMN', @level2name = N'docPayId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Текущая дата/время изменений', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DocPreparePay', @level2type = N'COLUMN', @level2name = N'dateWork';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Номер документа', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DocPreparePay', @level2type = N'COLUMN', @level2name = N'nD';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Дата документа', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DocPreparePay', @level2type = N'COLUMN', @level2name = N'nDDate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'идентификатор счета дебета', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DocPreparePay', @level2type = N'COLUMN', @level2name = N'accIdDebet';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Идентификатор счета кредита', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DocPreparePay', @level2type = N'COLUMN', @level2name = N'accIdCredit';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Счет по дебету', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DocPreparePay', @level2type = N'COLUMN', @level2name = N'accDebet';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Счет по кредиту
   ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DocPreparePay', @level2type = N'COLUMN', @level2name = N'accCredit';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Сумма платежа в нац.валюте', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DocPreparePay', @level2type = N'COLUMN', @level2name = N'amount';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Сумма платежа в номинале валюты', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DocPreparePay', @level2type = N'COLUMN', @level2name = N'amountCur';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Назначение платежа', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DocPreparePay', @level2type = N'COLUMN', @level2name = N'payNote';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Код валюты
   ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DocPreparePay', @level2type = N'COLUMN', @level2name = N'r030';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Дата операции', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DocPreparePay', @level2type = N'COLUMN', @level2name = N'dateOper';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Статус платежа', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DocPreparePay', @level2type = N'COLUMN', @level2name = N'payStatus';

