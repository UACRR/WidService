CREATE TABLE [dbo].[PaymentCase] (
    [reqId]       INT           NOT NULL,
    [payKind]     INT           NULL,
    [payMethod]   INT           NULL,
    [ptId]        INT           NULL,
    [dateForPay]  DATE          NULL,
    [dateInvoce]  DATE          NULL,
    [datePay]     DATE          NULL,
    [payStatus]   INT           NULL,
    [datePayFact] DATE          NULL,
    [otherCase]   VARCHAR (254) NULL,
    CONSTRAINT [PK_PAYMENTCASE] PRIMARY KEY CLUSTERED ([reqId] ASC),
    CONSTRAINT [FK_PAYMENTC_REFERENCE_PAYMENTK] FOREIGN KEY ([payKind]) REFERENCES [dbo].[PaymentKind] ([codeI]),
    CONSTRAINT [FK_PAYMENTC_REFERENCE_PAYMETHO] FOREIGN KEY ([payMethod]) REFERENCES [dbo].[PayMethodType] ([codeI]),
    CONSTRAINT [FK_PAYMENTC_REFERENCE_REQUEST] FOREIGN KEY ([reqId]) REFERENCES [dbo].[Request] ([reqId])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Дата фактической оплаты', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'PaymentCase', @level2type = N'COLUMN', @level2name = N'datePayFact';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Признак наличия оплаты 
   Признак: 
   •	продукт оплачен 
   •	в ожидании подтверждения оплаты (для случаев оплаты чрез банк); 
   •	в ожидании оплаты (в случае долгосрочной покупки с помесячной оплатой) 
   •	просрочена оплата (если продукт не был оплачен до установленной или ожидаемой даты). 
   ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'PaymentCase', @level2type = N'COLUMN', @level2name = N'payStatus';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Дата оплаты по договору', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'PaymentCase', @level2type = N'COLUMN', @level2name = N'datePay';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Дата формирования счета фактуры. Платеж должен придти через 3 дня', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'PaymentCase', @level2type = N'COLUMN', @level2name = N'dateInvoce';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Дата, до которой продукт должен быть оплачен', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'PaymentCase', @level2type = N'COLUMN', @level2name = N'dateForPay';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Тип партнера', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'PaymentCase', @level2type = N'COLUMN', @level2name = N'ptId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Метод оплаты - карточкой, банковский перевод или наличные', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'PaymentCase', @level2type = N'COLUMN', @level2name = N'payMethod';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Код вида способа оплаты', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'PaymentCase', @level2type = N'COLUMN', @level2name = N'payKind';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор заявки', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'PaymentCase', @level2type = N'COLUMN', @level2name = N'reqId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Условия оплаты', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'PaymentCase';

