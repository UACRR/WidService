CREATE TABLE [dbo].[CreativeTranslate] (
    [codeI] INT NOT NULL,
    CONSTRAINT [PK_CREATIVETRANSLATE] PRIMARY KEY CLUSTERED ([codeI] ASC),
    CONSTRAINT [FK_CTRANSLATE_REFERENCE_CREATIVE] FOREIGN KEY ([codeI]) REFERENCES [dbo].[CreativeRoleType] ([codeI])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Переводчики', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CreativeTranslate';

