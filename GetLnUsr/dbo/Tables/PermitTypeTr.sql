CREATE TABLE [dbo].[PermitTypeTr] (
    [codeB] BIT           NOT NULL,
    [lang]  CHAR (2)      NOT NULL,
    [name]  VARCHAR (100) NOT NULL,
    CONSTRAINT [PK_PERMITTYPETR] PRIMARY KEY CLUSTERED ([codeB] ASC, [lang] ASC),
    CONSTRAINT [FK_PERMITTY_REFERENCE_PERMITTY] FOREIGN KEY ([codeB]) REFERENCES [dbo].[PermitType] ([codeB])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Справочник типов разрешения
   insert into PermitType 
   select 0, ''Дозволити'', ''Разрешить'', ''Allow''
   insert into PermitType 
   select 1, ''Заборонити'', ''Запретить'', ''Disable''
   ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'PermitTypeTr';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Признак разрешения или запрета на выставление своих прав на использование', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'PermitTypeTr', @level2type = N'COLUMN', @level2name = N'codeB';

