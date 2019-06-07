CREATE TABLE [dbo].[relEtGenre] (
    [genreCode]   INT NOT NULL,
    [etGenreCode] INT NOT NULL,
    CONSTRAINT [PK_RELETGENRE] PRIMARY KEY CLUSTERED ([genreCode] ASC, [etGenreCode] ASC),
    CONSTRAINT [FK_RELETGEN_REFERENCE_ETGENRE] FOREIGN KEY ([etGenreCode]) REFERENCES [dbo].[EtGenre] ([codeI]),
    CONSTRAINT [FK_RELETGEN_REFERENCE_GENRETYP] FOREIGN KEY ([genreCode]) REFERENCES [dbo].[GenreType] ([codeI])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'код типа объекта права', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'relEtGenre', @level2type = N'COLUMN', @level2name = N'genreCode';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Соответсвие наших жанров постанове 72 (эталону)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'relEtGenre';

