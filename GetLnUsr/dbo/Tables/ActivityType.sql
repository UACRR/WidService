CREATE TABLE [dbo].[ActivityType] (
    [codeI] INT           NOT NULL,
    [name]  VARCHAR (200) NULL,
    CONSTRAINT [PK_ACTIVITYTYPE] PRIMARY KEY CLUSTERED ([codeI] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Справочник видов деятельности клиента портала юридического лица  ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ActivityType';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Код вида деятельности', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ActivityType', @level2type = N'COLUMN', @level2name = N'codeI';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Наименование вида деятельности', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ActivityType', @level2type = N'COLUMN', @level2name = N'name';

