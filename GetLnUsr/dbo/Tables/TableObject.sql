CREATE TABLE [dbo].[TableObject] (
    [id]    NUMERIC (18)   IDENTITY (1, 1) NOT NULL,
    [lang]  CHAR (2)       NULL,
    [cName] VARCHAR (100)  NOT NULL,
    [dText] VARCHAR (2048) NULL,
    [hText] VARCHAR (100)  NULL,
    CONSTRAINT [PK_TABLEOBJECT] PRIMARY KEY NONCLUSTERED ([id] ASC),
    CONSTRAINT [uni_01] UNIQUE NONCLUSTERED ([lang] ASC, [cName] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Таблица описания объектов  на 3 языках. Используетя в проекте для представления.
   Кнопки, названия и т.д.', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'TableObject';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Код объекта', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'TableObject', @level2type = N'COLUMN', @level2name = N'cName';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Описание для отображения', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'TableObject', @level2type = N'COLUMN', @level2name = N'dText';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Полное описание поля, которое м.б. как подсказка (hint/help)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'TableObject', @level2type = N'COLUMN', @level2name = N'hText';

