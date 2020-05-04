CREATE TABLE [dbo].[PubCatalogItem] (
    [itemId]      INT             IDENTITY (1, 1) NOT NULL,
    [fileId]      INT             NULL,
    [cRightId]    INT             NULL,
    [custId]      INT             NULL,
    [itemCode]    VARCHAR (50)    NULL,
    [iswc]        VARCHAR (100)   NULL,
    [objName]     VARCHAR (254)   NULL,
    [genreName]   VARCHAR (100)   NULL,
    [roleName]    VARCHAR (100)   NULL,
    [rate]        NUMERIC (10, 5) NULL,
    [authorMusic] VARCHAR (254)   NULL,
    [authorText]  VARCHAR (254)   NULL,
    [performer]   VARCHAR (254)   NULL,
    [comment]     VARCHAR (1024)  NULL,
    [objId]       INT             NULL,
    [genreCode]   INT             NULL,
    [roleCode]    INT             NULL,
    [status]      INT             NULL,
    [errComment]  VARCHAR (200)   NULL,
    [rhName]      VARCHAR (254)   NULL,
    [dateBegin]   DATE            NULL,
    [dateEnd]     DATE            NULL,
    CONSTRAINT [PK_PUBCATALOGITEM] PRIMARY KEY CLUSTERED ([itemId] ASC),
    CONSTRAINT [FK_PUBCATAL_REFERENCE_CATALOGF] FOREIGN KEY ([fileId]) REFERENCES [dbo].[CatalogFile] ([fileId]),
    CONSTRAINT [FK_PUBCATAL_REFERENCE_CATALOGS] FOREIGN KEY ([status]) REFERENCES [dbo].[CatalogStatus] ([codeI]),
    CONSTRAINT [FK_PUBCATAL_REFERENCE_RIGHTHOL] FOREIGN KEY ([custId]) REFERENCES [dbo].[RightHolder] ([custId])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Каталоги Видавництво - список', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'PubCatalogItem';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор в таблице правообладания авторским правом', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'PubCatalogItem', @level2type = N'COLUMN', @level2name = N'cRightId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор клиента (правообладателя или покупателя)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'PubCatalogItem', @level2type = N'COLUMN', @level2name = N'custId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Номер/код запису у файлі (унікальний) /шифр твору', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'PubCatalogItem', @level2type = N'COLUMN', @level2name = N'itemCode';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'комментарий к ошибке', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'PubCatalogItem', @level2type = N'COLUMN', @level2name = N'errComment';

