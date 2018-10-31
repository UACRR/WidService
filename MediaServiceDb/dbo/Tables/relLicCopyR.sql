CREATE TABLE [dbo].[relLicCopyR] (
    [agrLlicCode] INT NOT NULL,
    [cRKindCode]  INT NOT NULL,
    CONSTRAINT [PK_RELLICCOPYR] PRIMARY KEY CLUSTERED ([agrLlicCode] ASC, [cRKindCode] ASC),
    CONSTRAINT [FK_RELLICCO_REFERENCE_AGRLICEN] FOREIGN KEY ([agrLlicCode]) REFERENCES [dbo].[AgrLicenseType] ([codeI]),
    CONSTRAINT [FK_RELLICCO_REFERENCE_COPYRIGH] FOREIGN KEY ([cRKindCode]) REFERENCES [dbo].[CopyrightKind] ([codeI])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Код вида правообладателя', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'relLicCopyR', @level2type = N'COLUMN', @level2name = N'cRKindCode';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Ліцензійна угода', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'relLicCopyR';

