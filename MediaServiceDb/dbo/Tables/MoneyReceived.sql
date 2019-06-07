CREATE TABLE [dbo].[MoneyReceived] (
    [paidId]        INT           NOT NULL,
    [custId]        INT           NOT NULL,
    [moneyType]     INT           NOT NULL,
    [dateInvoice]   DATE          NOT NULL,
    [numberInvoice] VARCHAR (32)  NOT NULL,
    [goalInvoice]   VARCHAR (256) NOT NULL,
    [amount]        MONEY         NOT NULL,
    [destribAmount] MONEY         NOT NULL,
    [destribPrepay] MONEY         NULL,
    CONSTRAINT [PK_MONEYRECEIVED] PRIMARY KEY CLUSTERED ([paidId] ASC),
    CONSTRAINT [FK_MONEYREC_REFERENCE_CLIENT] FOREIGN KEY ([custId]) REFERENCES [dbo].[Client] ([custId]),
    CONSTRAINT [FK_MONEYREC_REFERENCE_MONEYTYP] FOREIGN KEY ([moneyType]) REFERENCES [dbo].[MoneyType] ([codeI])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор клиента (правообладателя или покупателя)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'MoneyReceived', @level2type = N'COLUMN', @level2name = N'custId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Отримані кошти від користувача', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'MoneyReceived';

