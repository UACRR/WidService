CREATE TABLE [dbo].[RHCatalogItem] (
    [itemId]     INT             IDENTITY (1, 1) NOT NULL,
    [fileId]     INT             NULL,
    [itemCode]   VARCHAR (50)    NULL,
    [iswc]       VARCHAR (100)   NULL,
    [objName]    VARCHAR (254)   NULL,
    [genreName]  VARCHAR (100)   NULL,
    [roleName]   VARCHAR (100)   NULL,
    [authorName] VARCHAR (200)   NULL,
    [rate]       NUMERIC (10, 5) NULL,
    [cmName]     VARCHAR (100)   NULL,
    [comment]    VARCHAR (1024)  NULL,
    [objId]      INT             NULL,
    [custId]     INT             NULL,
    [genreCode]  INT             NULL,
    [roleCode]   INT             NULL,
    [cmCustId]   INT             NULL,
    [status]     INT             NULL,
    [cRightId]   INT             NULL,
    [errComment] VARCHAR (200)   NULL,
    [duration]   TIME (7)        NULL,
    [rhCustId]   INT             NULL,
    CONSTRAINT [PK_RHСATALOGITEM] PRIMARY KEY CLUSTERED ([itemId] ASC),
    CONSTRAINT [FK_RHСATALO_REFERENCE_CATALOGF] FOREIGN KEY ([fileId]) REFERENCES [dbo].[CatalogFile] ([fileId]),
    CONSTRAINT [FK_RHСATALO_REFERENCE_CATALOGS] FOREIGN KEY ([status]) REFERENCES [dbo].[CatalogStatus] ([codeI]),
    CONSTRAINT [FK_RHСATALO_REFERENCE_COPYRIGH] FOREIGN KEY ([cRightId]) REFERENCES [dbo].[CopyRight] ([cRightId]),
    CONSTRAINT [FK_RHСATALO_REFERENCE_RIGHTHOL] FOREIGN KEY ([custId]) REFERENCES [dbo].[RightHolder] ([custId])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'комментарий к ошибке', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RHCatalogItem', @level2type = N'COLUMN', @level2name = N'errComment';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор в таблице правообладания авторским правом', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RHCatalogItem', @level2type = N'COLUMN', @level2name = N'cRightId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор клиента (правообладателя или покупателя)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RHCatalogItem', @level2type = N'COLUMN', @level2name = N'custId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Назва ОКУ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RHCatalogItem', @level2type = N'COLUMN', @level2name = N'cmName';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Номер/код запису у файлі (унікальний) /шифр твору', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RHCatalogItem', @level2type = N'COLUMN', @level2name = N'itemCode';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Каталоги авторів- список', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RHCatalogItem';

