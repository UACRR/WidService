CREATE TABLE [dbo].[CopyrightKindTr] (
    [codeI]        INT           NOT NULL,
    [lang]         CHAR (2)      NOT NULL,
    [name]         VARCHAR (600) NULL,
    [nameDescript] VARCHAR (700) NULL,
    CONSTRAINT [PK_CRIGHTKINDT] PRIMARY KEY CLUSTERED ([codeI] ASC, [lang] ASC),
    CONSTRAINT [FK_COPYRIGH_REFERENCE_COPYR] FOREIGN KEY ([codeI]) REFERENCES [dbo].[CopyrightKind] ([codeI])
);




GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Наименование кода вида правообладателя', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CopyrightKindTr', @level2type = N'COLUMN', @level2name = N'name';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Код вида правообладателя', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CopyrightKindTr', @level2type = N'COLUMN', @level2name = N'codeI';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Справочник видов прав собственности (авторские права, смежные права, аудиовизуальные права)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CopyrightKindTr';

