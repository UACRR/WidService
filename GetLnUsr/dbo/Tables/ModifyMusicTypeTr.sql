CREATE TABLE [dbo].[ModifyMusicTypeTr] (
    [codeI] INT           NOT NULL,
    [lang]  CHAR (2)      NOT NULL,
    [name]  VARCHAR (200) NULL,
    CONSTRAINT [PK_MODIFYMUSICTYPETR] PRIMARY KEY CLUSTERED ([codeI] ASC, [lang] ASC),
    CONSTRAINT [FK_MODIFYMU_REFERENCE_MODIFYMU] FOREIGN KEY ([codeI]) REFERENCES [dbo].[ModifyMusicType] ([codeI])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Код вида деятельности', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ModifyMusicTypeTr', @level2type = N'COLUMN', @level2name = N'codeI';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Наименование вида деятельности', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ModifyMusicTypeTr', @level2type = N'COLUMN', @level2name = N'name';

