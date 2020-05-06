CREATE TABLE [dbo].[RegisterStatus] (
    [codeI] INT           NOT NULL,
    [name]  VARCHAR (100) NULL,
    CONSTRAINT [PK_REGISTERSTATUS] PRIMARY KEY CLUSTERED ([codeI] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Справочник Статус Ведомости использования объектов права 
   ?	"корректировка"
   ?	"на согласовании" 
   ?	"согласован" - "согласован админом контента", "согласован админом прав", "согласован админом продаж"
   ?	"средства распределены"
   
   ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RegisterStatus';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Статус ведомости', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RegisterStatus', @level2type = N'COLUMN', @level2name = N'codeI';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Статус ведомости название', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RegisterStatus', @level2type = N'COLUMN', @level2name = N'name';

