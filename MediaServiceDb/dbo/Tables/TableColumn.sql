CREATE TABLE [dbo].[TableColumn] (
    [id]    NUMERIC (18)  IDENTITY (1, 1) NOT NULL,
    [lang]  CHAR (2)      NULL,
    [cName] VARCHAR (100) NULL,
    [tName] VARCHAR (100) NULL,
    [dText] VARCHAR (100) NULL,
    [hText] VARCHAR (100) NULL,
    CONSTRAINT [PK_TABLECOLUMN] PRIMARY KEY NONCLUSTERED ([id] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [TableColumn_UI]
    ON [dbo].[TableColumn]([tName] ASC, [cName] ASC, [lang] ASC);


GO
CREATE CLUSTERED INDEX [Index_Unique]
    ON [dbo].[TableColumn]([lang] ASC, [tName] ASC, [cName] ASC);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Полное описание поля, которое м.б. как подсказка (title)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'TableColumn', @level2type = N'COLUMN', @level2name = N'hText';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Краткое описание Lable для ввода', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'TableColumn', @level2type = N'COLUMN', @level2name = N'dText';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Таблица описания колонок на 3 языках. Используетя в проекте.', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'TableColumn';

