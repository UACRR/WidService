CREATE TABLE [dbo].[TermsOfService] (
    [custId]     INT NOT NULL,
    [CRKindCode] INT NOT NULL,
    [ourService] BIT NOT NULL,
    CONSTRAINT [PK_TERMSOFSERVICE] PRIMARY KEY CLUSTERED ([custId] ASC, [CRKindCode] ASC),
    CONSTRAINT [FK_TERMSOFS_REFERENCE_COPYRIGH] FOREIGN KEY ([CRKindCode]) REFERENCES [dbo].[CopyrightKind] ([codeI]),
    CONSTRAINT [FK_TERMSOFS_REFERENCE_RIGHTHOL] FOREIGN KEY ([custId]) REFERENCES [dbo].[RightHolder] ([custId])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Код вида правообладателя', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'TermsOfService', @level2type = N'COLUMN', @level2name = N'CRKindCode';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор клиента (правообладателя или покупателя)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'TermsOfService', @level2type = N'COLUMN', @level2name = N'custId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Виды права переданные в управление', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'TermsOfService';

