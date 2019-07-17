CREATE TABLE [dbo].[CatalogFile] (
    [fileId]     INT            IDENTITY (1, 1) NOT NULL,
    [custId]     INT            NULL,
    [custName]   VARCHAR (254)  NULL,
    [fileName]   VARCHAR (100)  NULL,
    [createDate] DATETIME       NULL,
    [modifyDate] DATETIME       NULL,
    [userId]     NVARCHAR (48)  NOT NULL,
    [status]     INT            NULL,
    [rhType]     INT            NULL,
    [comment]    VARCHAR (1024) NULL,
    [countZap]   INT            NULL,
    [countOk]    INT            NULL,
    [countErr]   INT            NULL,
    CONSTRAINT [PK_CATALOGFILE] PRIMARY KEY CLUSTERED ([fileId] ASC),
    CONSTRAINT [FK_CATALOGF_REFERENCE_CATALOGS] FOREIGN KEY ([status]) REFERENCES [dbo].[CatalogStatus] ([codeI]),
    CONSTRAINT [FK_CATALOGF_REFERENCE_RHOLDERT] FOREIGN KEY ([rhType]) REFERENCES [dbo].[RHolderType] ([codeI]),
    CONSTRAINT [FK_CATALOGF_REFERENCE_RIGHTHOL] FOREIGN KEY ([custId]) REFERENCES [dbo].[RightHolder] ([custId])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Статус файла ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CatalogFile', @level2type = N'COLUMN', @level2name = N'status';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'пользователь, кто выполнил загрузку файла', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CatalogFile', @level2type = N'COLUMN', @level2name = N'userId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Дата изменений - проставления последнего статуса', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CatalogFile', @level2type = N'COLUMN', @level2name = N'modifyDate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Дата загрузки', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CatalogFile', @level2type = N'COLUMN', @level2name = N'createDate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор клиента (правообладателя или покупателя)
   Издательство', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CatalogFile', @level2type = N'COLUMN', @level2name = N'custId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Каталоги издателей - файлы загрузки
   0 - новий запис
   1 - готовий для завантаження
   2 - помилка
   3 - вилучений
   ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CatalogFile';

