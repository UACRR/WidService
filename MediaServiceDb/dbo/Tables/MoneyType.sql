CREATE TABLE [dbo].[MoneyType] (
    [codeI] INT           NOT NULL,
    [name]  VARCHAR (200) NOT NULL,
    CONSTRAINT [PK_MONEYTYPE] PRIMARY KEY CLUSTERED ([codeI] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Тип платежа ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'MoneyType';

