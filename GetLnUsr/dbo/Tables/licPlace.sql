CREATE TABLE [dbo].[licPlace] (
    [licId]   INT NOT NULL,
    [placeId] INT NOT NULL,
    CONSTRAINT [PK_LICPLACE] PRIMARY KEY CLUSTERED ([licId] ASC, [placeId] ASC),
    CONSTRAINT [FK_LICPLACE_REFERENCE_CLNBUSIN] FOREIGN KEY ([placeId]) REFERENCES [dbo].[ClnBusinessPlace] ([placeId]),
    CONSTRAINT [FK_LICPLACE_REFERENCE_LICENSEA] FOREIGN KEY ([licId]) REFERENCES [dbo].[LicenseAgreement] ([licId])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Майданчики ліцензійного договору', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'licPlace';

