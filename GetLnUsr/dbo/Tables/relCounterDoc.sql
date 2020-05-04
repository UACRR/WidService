CREATE TABLE [dbo].[relCounterDoc] (
    [cDocId]    INT IDENTITY (1, 1) NOT NULL,
    [counterId] INT NOT NULL,
    [docType]   INT NOT NULL,
    [licType]   INT NULL,
    CONSTRAINT [PK_RELCOUNTERDOC] PRIMARY KEY CLUSTERED ([cDocId] ASC),
    CONSTRAINT [FK_RELCOUNT_REFERENCE_AGRLICEN] FOREIGN KEY ([licType]) REFERENCES [dbo].[AgrLicenseType] ([codeI]),
    CONSTRAINT [FK_RELCOUNT_REFERENCE_COUNTERN] FOREIGN KEY ([counterId]) REFERENCES [dbo].[CounterNumber] ([counterId]),
    CONSTRAINT [FK_RELCOUNT_REFERENCE_DOCUMENT] FOREIGN KEY ([docType]) REFERENCES [dbo].[DocumentType] ([codeI])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор - код', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'relCounterDoc', @level2type = N'COLUMN', @level2name = N'counterId';

