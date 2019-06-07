CREATE TABLE [dbo].[MyAnketa] (
    [custId]          INT          NOT NULL,
    [accCompany]      VARCHAR (25) NULL,
    [accCommission]   VARCHAR (25) NULL,
    [accInCommission] VARCHAR (25) NULL,
    [accCourt]        VARCHAR (25) NULL,
    CONSTRAINT [PK_MYANKETA] PRIMARY KEY CLUSTERED ([custId] ASC),
    CONSTRAINT [FK_MYANKETA_REFERENCE_CUSTOMER] FOREIGN KEY ([custId]) REFERENCES [dbo].[Customer] ([custId])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор клиента (правообладателя или покупателя)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'MyAnketa', @level2type = N'COLUMN', @level2name = N'custId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Моя анкета', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'MyAnketa';

