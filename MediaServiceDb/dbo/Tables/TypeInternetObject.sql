CREATE TABLE [dbo].[TypeInternetObject] (
    [codeI]          INT           NOT NULL,
    [name]           VARCHAR (100) NULL,
    [typeInetNameEn] VARCHAR (100) NULL,
    [typeInetNameRu] VARCHAR (100) NULL,
    CONSTRAINT [PK_TYPEINTERNETOBJECT] PRIMARY KEY CLUSTERED ([codeI] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Типы интернет-объектов', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'TypeInternetObject';

