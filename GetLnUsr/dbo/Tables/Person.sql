CREATE TABLE [dbo].[Person] (
    [custId]  INT NOT NULL,
    [version] INT NOT NULL,
    CONSTRAINT [PK_PERSON] PRIMARY KEY CLUSTERED ([custId] ASC),
    CONSTRAINT [FK_PERSON_ASSOCIATI_CUSTOMER] FOREIGN KEY ([custId]) REFERENCES [dbo].[Customer] ([custId])
);


GO
CREATE NONCLUSTERED INDEX [Association21_FK]
    ON [dbo].[Person]([custId] ASC);


GO
CREATE NONCLUSTERED INDEX [Association24_FK]
    ON [dbo].[Person]([custId] ASC, [version] ASC);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Клиенты физические лица', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Person';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор клиента (правообладателя или покупателя)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Person', @level2type = N'COLUMN', @level2name = N'custId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Версия', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Person', @level2type = N'COLUMN', @level2name = N'version';

