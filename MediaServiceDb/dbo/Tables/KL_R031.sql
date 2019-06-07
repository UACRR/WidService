CREATE TABLE [dbo].[KL_R031] (
    [r031]       SMALLINT      NOT NULL,
    [r031NameUk] VARCHAR (100) NULL,
    [r031NameRu] VARCHAR (100) NULL,
    [r031NameEn] VARCHAR (100) NULL,
    CONSTRAINT [PK_KL_R031] PRIMARY KEY CLUSTERED ([r031] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Наименование типа валют
   ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KL_R031', @level2type = N'COLUMN', @level2name = N'r031NameEn';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Наименование типа валют
   ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KL_R031', @level2type = N'COLUMN', @level2name = N'r031NameRu';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Наименование типа валют
   ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KL_R031', @level2type = N'COLUMN', @level2name = N'r031NameUk';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Код типа валют', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KL_R031', @level2type = N'COLUMN', @level2name = N'r031';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Справочник типов валют
   (НВ, СКВ, НКВ)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KL_R031';

