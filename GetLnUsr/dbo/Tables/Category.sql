CREATE TABLE [dbo].[Category] (
    [codeI]    INT           NOT NULL,
    [name]     VARCHAR (256) NULL,
    [status]   INT           NULL,
    [TableObj] VARCHAR (50)  NULL,
    [utype]    INT           NULL,
    [comment]  VARCHAR (200) NULL,
    CONSTRAINT [PK_CATEGORY] PRIMARY KEY CLUSTERED ([codeI] ASC),
    CONSTRAINT [FK_CATEGORY_REFERENCE_CATEGORY] FOREIGN KEY ([status]) REFERENCES [dbo].[CategoryStatusType] ([codeI])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Справочник категорий объектов права (в т.ч. - музыкальные произведения, аудиовизуальные произведения, книги  и т.д.)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Category';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Код категории объекта автоского права', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Category', @level2type = N'COLUMN', @level2name = N'codeI';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Название категории права', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Category', @level2type = N'COLUMN', @level2name = N'name';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Статус категории права на портале ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Category', @level2type = N'COLUMN', @level2name = N'status';

