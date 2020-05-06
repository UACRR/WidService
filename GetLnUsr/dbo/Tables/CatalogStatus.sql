CREATE TABLE [dbo].[CatalogStatus] (
    [codeI] INT           NOT NULL,
    [name]  VARCHAR (100) NULL,
    CONSTRAINT [PK_CATALOGSTATUS] PRIMARY KEY CLUSTERED ([codeI] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = '0 - новий запис
   1 - готовий для завантаження (контроль пройдено)
   2 - помилка (знайдено помилки)
   3 - оброблений
   4 - вилучений', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CatalogStatus';

