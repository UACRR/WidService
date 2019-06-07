CREATE TABLE [dbo].[RequestAim] (
    [codeI]        INT           NOT NULL,
    [reqType]      INT           NOT NULL,
    [name]         VARCHAR (200) NULL,
    [categoryCode] INT           NOT NULL,
    CONSTRAINT [PK_REQUESTAIM] PRIMARY KEY CLUSTERED ([codeI] ASC),
    CONSTRAINT [FK_REQUESTA_REFERENCE_CATEGORY] FOREIGN KEY ([categoryCode]) REFERENCES [dbo].[Category] ([codeI])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Код категории объекта автоского права', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RequestAim', @level2type = N'COLUMN', @level2name = N'categoryCode';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Наименование цели использования', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RequestAim', @level2type = N'COLUMN', @level2name = N'name';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Код типа заявки', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RequestAim', @level2type = N'COLUMN', @level2name = N'reqType';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Код цели использования ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RequestAim', @level2type = N'COLUMN', @level2name = N'codeI';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Справочник цели заявки
   в т.ч. цель заявки на синхронизацию:	
   ?	реклама; 
   ?	ТВ/радио программа; 
   ?	фильм; 
   ?	сериал; 
   ?	интернет-объект;
   ?	другое
   ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RequestAim';

