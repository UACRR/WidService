CREATE TABLE [dbo].[Client] (
    [custId]      INT           NOT NULL,
    [clientBrand] VARCHAR (100) NULL,
    [clientGroup] VARCHAR (100) NULL,
    CONSTRAINT [PK_CLIENT] PRIMARY KEY CLUSTERED ([custId] ASC),
    CONSTRAINT [FK_CLIENT_REFERENCE_CUSTOMER] FOREIGN KEY ([custId]) REFERENCES [dbo].[Customer] ([custId])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Клиенты-Покупатели', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Client';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор клиента (правообладателя или покупателя)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Client', @level2type = N'COLUMN', @level2name = N'custId';

