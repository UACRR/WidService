CREATE TABLE [dbo].[RegionTr] (
    [codeI] INT           NOT NULL,
    [lang]  CHAR (2)      NOT NULL,
    [name]  VARCHAR (100) NULL,
    CONSTRAINT [PK_REGIONTR] PRIMARY KEY CLUSTERED ([codeI] ASC, [lang] ASC),
    CONSTRAINT [FK_REGIONTR_REFERENCE_REGION] FOREIGN KEY ([codeI]) REFERENCES [dbo].[Region] ([codeI])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Справочник регионов/областей
   
   ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RegionTr';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Код региона/области', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RegionTr', @level2type = N'COLUMN', @level2name = N'codeI';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Название региона/области', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RegionTr', @level2type = N'COLUMN', @level2name = N'name';

