CREATE TABLE [dbo].[TableType] (
    [tName] VARCHAR (100) NOT NULL,
    [tType] SMALLINT      NULL,
    CONSTRAINT [PK_TABLETYPE] PRIMARY KEY NONCLUSTERED ([tName] ASC)
);


GO
CREATE CLUSTERED INDEX [Index_Unique]
    ON [dbo].[TableType]([tName] ASC);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Код типа таблицы. Если 3 - не нужно записывать в TableColumn', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'TableType', @level2type = N'COLUMN', @level2name = N'tType';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Наименование таблицы', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'TableType', @level2type = N'COLUMN', @level2name = N'tName';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Таблица с именами таблиц и тапми таблиц
   1- таблица с данными
   2 - справочник
   3-техническая таблица, не заливается в TableColumn
   ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'TableType';

