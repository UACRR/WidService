CREATE TABLE [dbo].[DicList] (
    [dicId]   INT           IDENTITY (1, 1) NOT NULL,
    [dKind]   VARCHAR (50)  NOT NULL,
    [dCode]   INT           NOT NULL,
    [dNameUk] VARCHAR (100) NULL,
    [dNameRu] VARCHAR (100) NULL,
    [dNameEn] VARCHAR (100) NULL,
    CONSTRAINT [PK_DICLIST] PRIMARY KEY CLUSTERED ([dicId] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Список справочников коротких', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DicList';

