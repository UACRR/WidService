CREATE TABLE [dbo].[CategoryStatusTypeTr] (
    [codeI] INT           NOT NULL,
    [lang]  CHAR (2)      NOT NULL,
    [name]  VARCHAR (200) NULL,
    CONSTRAINT [PK_CATEGORYSTATUSTYPETR] PRIMARY KEY CLUSTERED ([codeI] ASC, [lang] ASC),
    CONSTRAINT [FK_CATEGORY_REFERENCE_CATSTTR] FOREIGN KEY ([codeI]) REFERENCES [dbo].[CategoryStatusType] ([codeI]) ON DELETE CASCADE ON UPDATE CASCADE
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Название статуса категории права', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CategoryStatusTypeTr', @level2type = N'COLUMN', @level2name = N'name';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Код статуса категории права', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CategoryStatusTypeTr', @level2type = N'COLUMN', @level2name = N'codeI';

