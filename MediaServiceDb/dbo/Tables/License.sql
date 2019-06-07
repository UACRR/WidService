CREATE TABLE [dbo].[License] (
    [lId]        INT          IDENTITY (1, 1) NOT NULL,
    [placeId]    INT          NULL,
    [licId]      INT          NULL,
    [licVersion] INT          NULL,
    [lNum]       VARCHAR (50) NULL,
    [lDate]      DATE         NULL,
    [status]     INT          NULL,
    CONSTRAINT [PK_LICENSE] PRIMARY KEY CLUSTERED ([lId] ASC),
    CONSTRAINT [FK_LICENSE_REFERENCE_CLNBUSIN] FOREIGN KEY ([placeId]) REFERENCES [dbo].[ClnBusinessPlace] ([placeId]),
    CONSTRAINT [FK_LICENSE_REFERENCE_LICENSEA] FOREIGN KEY ([licId], [licVersion]) REFERENCES [dbo].[LicenseAgrParam] ([licId], [licVersion])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Статус лицензии - нова, на акцепті, активна, призупинена, закрита', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'License', @level2type = N'COLUMN', @level2name = N'status';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Дата видачі ліцензії', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'License', @level2type = N'COLUMN', @level2name = N'lDate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Номер ліцензії', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'License', @level2type = N'COLUMN', @level2name = N'lNum';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор лицензии', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'License', @level2type = N'COLUMN', @level2name = N'lId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Лицензии', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'License';

