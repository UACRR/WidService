CREATE TABLE [dbo].[CategoryStatusType] (
    [codeI] INT           NOT NULL,
    [name]  VARCHAR (200) NULL,
    CONSTRAINT [PK_CATEGORYSTATUSTYPE] PRIMARY KEY CLUSTERED ([codeI] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Название статуса категории права', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CategoryStatusType', @level2type = N'COLUMN', @level2name = N'name';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Код статуса категории права', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CategoryStatusType', @level2type = N'COLUMN', @level2name = N'codeI';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Справочник статусов категорий объектов права (1-отмечена для работы, 8-заблокирована, 9-удалена)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CategoryStatusType';

