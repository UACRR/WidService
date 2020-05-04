CREATE TABLE [dbo].[PortalSupportRights] (
    [cRKindCode] INT NOT NULL,
    CONSTRAINT [pk] PRIMARY KEY CLUSTERED ([cRKindCode] ASC),
    CONSTRAINT [FK_PORTALOB_REFERENCE_COPYRIGH] FOREIGN KEY ([cRKindCode]) REFERENCES [dbo].[CopyrightKind] ([codeI])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Код вида правообладателя', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'PortalSupportRights', @level2type = N'COLUMN', @level2name = N'cRKindCode';

