CREATE TABLE [dbo].[CopyrightTypeTr] (
    [codeI] INT           NOT NULL,
    [lang]  CHAR (2)      NOT NULL,
    [name]  VARCHAR (100) NULL,
    CONSTRAINT [PK_COPYRIGHTTYPET] PRIMARY KEY CLUSTERED ([codeI] ASC, [lang] ASC),
    CONSTRAINT [FK_COPYRIGH_REFERENCE_COPYRIGH] FOREIGN KEY ([codeI]) REFERENCES [dbo].[CopyrightType] ([codeI])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Справочник типов прав на объекты права', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CopyrightTypeTr';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Тип авторского права', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CopyrightTypeTr', @level2type = N'COLUMN', @level2name = N'codeI';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Наименование Типа авторского права', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CopyrightTypeTr', @level2type = N'COLUMN', @level2name = N'name';

