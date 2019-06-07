CREATE TABLE [dbo].[TableColumnTech] (
    [id]      NUMERIC (18)  IDENTITY (1, 1) NOT NULL,
    [cname]   VARCHAR (100) NULL,
    [tname]   VARCHAR (100) NULL,
    [dnameUk] VARCHAR (100) NULL,
    [dnameRu] VARCHAR (100) NULL,
    [dnameEn] VARCHAR (100) NULL,
    [typeTab] SMALLINT      NULL,
    CONSTRAINT [PK_TABLECOLUMN_PRE] PRIMARY KEY CLUSTERED ([id] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [ITableColumn]
    ON [dbo].[TableColumnTech]([tname] ASC, [cname] ASC);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Таблица описания колонок на 3 языках', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'TableColumnTech';

