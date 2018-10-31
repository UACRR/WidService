CREATE TABLE [dbo].[CopyRTranslate] (
    [cRightId] INT      NOT NULL,
    [roleCode] INT      NULL,
    [langFrom] CHAR (2) NULL,
    [langTo]   CHAR (2) NULL,
    CONSTRAINT [PK_COPYRTRANSLATE] PRIMARY KEY CLUSTERED ([cRightId] ASC),
    CONSTRAINT [FK_COPYRTRA_REFERENCE_COPYRIGH] FOREIGN KEY ([cRightId]) REFERENCES [dbo].[CopyRight] ([cRightId]),
    CONSTRAINT [FK_COPYRTRA_REFERENCE_CREATIVE] FOREIGN KEY ([roleCode]) REFERENCES [dbo].[CreativeTranslate] ([codeI]),
    CONSTRAINT [FK_CPTRATO_REFERENCE_LANGUAGE] FOREIGN KEY ([langTo]) REFERENCES [dbo].[Language] ([codeS]),
    CONSTRAINT [FK_CRTRAFROM_REFERENCE_LANGUAGE] FOREIGN KEY ([langFrom]) REFERENCES [dbo].[Language] ([codeS])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор в таблице правообладания авторским правом', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CopyRTranslate', @level2type = N'COLUMN', @level2name = N'cRightId';

