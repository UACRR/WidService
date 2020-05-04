CREATE TABLE [dbo].[CustomerTypeTr] (
    [codeI] INT           NOT NULL,
    [lang]  CHAR (2)      NOT NULL,
    [name]  VARCHAR (100) NULL,
    CONSTRAINT [PK_CUSTOMERTYPETR] PRIMARY KEY CLUSTERED ([codeI] ASC, [lang] ASC),
    CONSTRAINT [FK_CUSTOMER_REFERENCE_CUSTTR] FOREIGN KEY ([codeI]) REFERENCES [dbo].[CustomerType] ([codeI])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Справочник типа клиента (правообладателя или покупателя)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CustomerTypeTr';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Код типа Клиента (правообладателя или покупателя)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CustomerTypeTr', @level2type = N'COLUMN', @level2name = N'codeI';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Наименование кода типа клиента', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CustomerTypeTr', @level2type = N'COLUMN', @level2name = N'name';

