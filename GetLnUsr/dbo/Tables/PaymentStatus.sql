CREATE TABLE [dbo].[PaymentStatus] (
    [codeI] INT           NOT NULL,
    [name]  VARCHAR (100) NULL,
    CONSTRAINT [PK_PAYMENTSTATUS] PRIMARY KEY CLUSTERED ([codeI] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Справочник статуса оплаты', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'PaymentStatus';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Код статуса оплаты', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'PaymentStatus', @level2type = N'COLUMN', @level2name = N'codeI';

