CREATE TABLE [dbo].[ReqCustomer] (
    [reqCustId]    INT           IDENTITY (1, 1) NOT NULL,
    [custId]       INT           NULL,
    [name]         VARCHAR (254) NULL,
    [countryCode]  CHAR (3)      NULL,
    [okpo]         VARCHAR (254) NULL,
    [nickName]     VARCHAR (254) NULL,
    [activityCode] INT           NULL,
    [comment]      VARCHAR (254) NULL,
    CONSTRAINT [PK_REQCUSTOMER] PRIMARY KEY CLUSTERED ([reqCustId] ASC),
    CONSTRAINT [FK_REQCUSTO_REFERENCE_ACTIVITY] FOREIGN KEY ([activityCode]) REFERENCES [dbo].[ActivityType] ([codeI]),
    CONSTRAINT [FK_REQCUSTO_REFERENCE_COUNTRY] FOREIGN KEY ([countryCode]) REFERENCES [dbo].[Country] ([countryCode]),
    CONSTRAINT [FK_REQCUSTO_REFERENCE_CUSTOMER] FOREIGN KEY ([custId]) REFERENCES [dbo].[Customer] ([custId])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Сценическое имя', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ReqCustomer', @level2type = N'COLUMN', @level2name = N'nickName';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Код юр.лица - заказчика', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ReqCustomer', @level2type = N'COLUMN', @level2name = N'okpo';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Страна заказчика', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ReqCustomer', @level2type = N'COLUMN', @level2name = N'countryCode';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'ФИО Клиента-Покупателя (заполняется для внешнего клиента. Если клиент зарегистрирован - записывается автоматически)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ReqCustomer', @level2type = N'COLUMN', @level2name = N'name';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор клиента (правообладателя или покупателя)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ReqCustomer', @level2type = N'COLUMN', @level2name = N'custId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'ID Идентификатор клиента  сервиса адаптации', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ReqCustomer', @level2type = N'COLUMN', @level2name = N'reqCustId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Заказчик', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ReqCustomer';

