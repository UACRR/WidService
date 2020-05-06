CREATE TABLE [dbo].[BankAccount] (
    [banAccID]      INT           IDENTITY (1, 1) NOT NULL,
    [custId]        INT           NULL,
    [accountNumber] VARCHAR (32)  NULL,
    [currency]      CHAR (3)      NULL,
    [transitNumber] VARCHAR (254) NULL,
    [mfo]           INT           NULL,
    [mfoName]       VARCHAR (254) NULL,
    [mfoOkpo]       CHAR (10)     NULL,
    [pIndex]        VARCHAR (15)  NULL,
    [pAddress]      VARCHAR (254) NULL,
    [pCity]         VARCHAR (100) NULL,
    [pCountry]      CHAR (3)      NULL,
    [pRegion]       INT           NULL,
    CONSTRAINT [PK_BANKACCOUNT] PRIMARY KEY CLUSTERED ([banAccID] ASC),
    CONSTRAINT [FK_BANKACCO_REFERENCE_CUSTOMER] FOREIGN KEY ([custId]) REFERENCES [dbo].[Customer] ([custId]),
    CONSTRAINT [FK_BANKACCO_REFERENCE_KL_R030] FOREIGN KEY ([currency]) REFERENCES [dbo].[KL_R030] ([r030])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Счета клиента', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'BankAccount';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор записи ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'BankAccount', @level2type = N'COLUMN', @level2name = N'banAccID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор клиента (правообладателя или покупателя)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'BankAccount', @level2type = N'COLUMN', @level2name = N'custId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Номер счета', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'BankAccount', @level2type = N'COLUMN', @level2name = N'accountNumber';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Валюта счета', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'BankAccount', @level2type = N'COLUMN', @level2name = N'currency';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Номер транзитного счета', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'BankAccount', @level2type = N'COLUMN', @level2name = N'transitNumber';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Код банка МФО', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'BankAccount', @level2type = N'COLUMN', @level2name = N'mfo';

