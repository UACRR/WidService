CREATE TABLE [dbo].[myCopyRightType] (
    [custId] INT NOT NULL,
    [cRType] INT NOT NULL,
    CONSTRAINT [PK_MYCOPYRIGHTTYPE] PRIMARY KEY CLUSTERED ([custId] ASC, [cRType] ASC),
    CONSTRAINT [FK_MYCOPYRI_REFERENCE_COPYRIGH] FOREIGN KEY ([cRType]) REFERENCES [dbo].[CopyrightType] ([codeI]),
    CONSTRAINT [FK_MYCOPYRI_REFERENCE_MYANKETA] FOREIGN KEY ([custId]) REFERENCES [dbo].[MyAnketa] ([custId])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Тип авторского права', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'myCopyRightType', @level2type = N'COLUMN', @level2name = N'cRType';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор клиента (правообладателя или покупателя)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'myCopyRightType', @level2type = N'COLUMN', @level2name = N'custId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Типы прав на обслуживании у МЕНЯ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'myCopyRightType';

