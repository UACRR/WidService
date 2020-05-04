CREATE TABLE [dbo].[MoneyPrepayLink] (
    [paidId]   INT   NOT NULL,
    [cRightId] INT   NOT NULL,
    [amount]   MONEY NULL,
    CONSTRAINT [PK_MONEYPREPAYLINK] PRIMARY KEY CLUSTERED ([paidId] ASC, [cRightId] ASC),
    CONSTRAINT [FK_MONEYPRE_REFERENCE_MONEYREC] FOREIGN KEY ([paidId]) REFERENCES [dbo].[MoneyReceived] ([paidId])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Таблица оплат авансов', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'MoneyPrepayLink';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор в таблице правообладания авторским правом', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'MoneyPrepayLink', @level2type = N'COLUMN', @level2name = N'cRightId';

