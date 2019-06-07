CREATE TABLE [dbo].[PermitType] (
    [codeB] BIT           NOT NULL,
    [name]  VARCHAR (100) NULL,
    CONSTRAINT [PK_PERMITTYPE] PRIMARY KEY CLUSTERED ([codeB] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Признак разрешения или запрета на выставление своих прав на использование', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'PermitType', @level2type = N'COLUMN', @level2name = N'codeB';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Справочник типов разрешения
   insert into PermitType 
   select 0, ''Дозволити'', ''Разрешить'', ''Allow''
   insert into PermitType 
   select 1, ''Заборонити'', ''Запретить'', ''Disable''
   ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'PermitType';

