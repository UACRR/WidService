CREATE TABLE [dbo].[RegisterStatusTr] (
    [codeI] INT           NOT NULL,
    [lang]  CHAR (2)      NOT NULL,
    [name]  VARCHAR (100) NULL,
    CONSTRAINT [PK_REGISTERSTATUSTR] PRIMARY KEY CLUSTERED ([codeI] ASC, [lang] ASC),
    CONSTRAINT [FK_REGISTER_REFERENCE_REGISTER] FOREIGN KEY ([codeI]) REFERENCES [dbo].[RegisterStatus] ([codeI])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Справочник Статус Ведомости использования объектов права 
   ?	"корректировка"
   ?	"на согласовании" 
   ?	"согласован" - "согласован админом контента", "согласован админом прав", "согласован админом продаж"
   ?	"средства распределены"
   
   ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RegisterStatusTr';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Статус ведомости', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RegisterStatusTr', @level2type = N'COLUMN', @level2name = N'codeI';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Статус ведомости название', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RegisterStatusTr', @level2type = N'COLUMN', @level2name = N'name';

