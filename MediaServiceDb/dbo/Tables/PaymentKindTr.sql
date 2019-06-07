CREATE TABLE [dbo].[PaymentKindTr] (
    [codeI] INT           NOT NULL,
    [lang]  CHAR (2)      NOT NULL,
    [name]  VARCHAR (100) NULL,
    CONSTRAINT [PK_PAYMENTKINDTR] PRIMARY KEY CLUSTERED ([codeI] ASC, [lang] ASC),
    CONSTRAINT [FK_PAYMENTK_REFERENCE_PAYMENTK] FOREIGN KEY ([codeI]) REFERENCES [dbo].[PaymentKind] ([codeI])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Справочник вида оплаты
   в т.ч. - предварительная, рассрочка, по факту', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'PaymentKindTr';

