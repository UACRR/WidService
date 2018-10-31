CREATE TABLE [dbo].[Company] (
    [custId]  INT NOT NULL,
    [version] INT NOT NULL,
    CONSTRAINT [PK_COMPANY] PRIMARY KEY CLUSTERED ([custId] ASC),
    CONSTRAINT [FK_COMPANY_ASSOCIATI_CUSTOMER] FOREIGN KEY ([custId]) REFERENCES [dbo].[Customer] ([custId])
);


GO
CREATE NONCLUSTERED INDEX [Association25_FK]
    ON [dbo].[Company]([custId] ASC, [version] ASC);


GO
CREATE NONCLUSTERED INDEX [Association20_FK]
    ON [dbo].[Company]([custId] ASC);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Версия', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Company', @level2type = N'COLUMN', @level2name = N'version';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор клиента (правообладателя или покупателя)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Company', @level2type = N'COLUMN', @level2name = N'custId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Клиенты-Юридические лица', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Company';

