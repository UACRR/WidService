CREATE TABLE [dbo].[AccountBals] (
    [codeI]    INT           NOT NULL,
    [balsType] SMALLINT      NULL,
    [name]     VARCHAR (100) NULL,
    CONSTRAINT [PK_ACCOUNTBALS] PRIMARY KEY CLUSTERED ([codeI] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Справочник типов счетов (балансовые характеристики)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AccountBals';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Код характеристики (балансовый счет)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AccountBals', @level2type = N'COLUMN', @level2name = N'codeI';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Признак балансового - активный/пассивный', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AccountBals', @level2type = N'COLUMN', @level2name = N'balsType';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Наименование балансового счета', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AccountBals', @level2type = N'COLUMN', @level2name = N'name';

