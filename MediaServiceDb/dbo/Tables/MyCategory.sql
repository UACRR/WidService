CREATE TABLE [dbo].[MyCategory] (
    [custId] INT NOT NULL,
    [codeI]  INT NOT NULL,
    CONSTRAINT [PK_MYCATEGORY] PRIMARY KEY CLUSTERED ([custId] ASC, [codeI] ASC),
    CONSTRAINT [FK_MYCATEGO_REFERENCE_CATEGORY] FOREIGN KEY ([codeI]) REFERENCES [dbo].[Category] ([codeI]),
    CONSTRAINT [FK_MYCATEGO_REFERENCE_MYANKETA] FOREIGN KEY ([custId]) REFERENCES [dbo].[MyAnketa] ([custId])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Код категории объекта автоского права', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'MyCategory', @level2type = N'COLUMN', @level2name = N'codeI';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор клиента (правообладателя или покупателя)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'MyCategory', @level2type = N'COLUMN', @level2name = N'custId';

