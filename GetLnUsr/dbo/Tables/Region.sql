CREATE TABLE [dbo].[Region] (
    [codeI] INT           NOT NULL,
    [name]  VARCHAR (100) NULL,
    CONSTRAINT [PK_REGION] PRIMARY KEY CLUSTERED ([codeI] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Справочник регионов/областей', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Region';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Код региона/области', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Region', @level2type = N'COLUMN', @level2name = N'codeI';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Название региона/области', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Region', @level2type = N'COLUMN', @level2name = N'name';

