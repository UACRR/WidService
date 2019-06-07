CREATE TABLE [dbo].[RelPopGenre] (
    [genreId] INT NOT NULL,
    [objId]   INT NOT NULL,
    CONSTRAINT [PK_RELOBJGENRE] PRIMARY KEY CLUSTERED ([objId] ASC, [genreId] ASC),
    CONSTRAINT [FK_RELOBJGE_REFERENCE_GENRE] FOREIGN KEY ([genreId]) REFERENCES [dbo].[PopGenre] ([id]),
    CONSTRAINT [FK_RELOBJGE_REFERENCE_OBJECTRI] FOREIGN KEY ([objId]) REFERENCES [dbo].[ObjectRight] ([objId])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор объекта права', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RelPopGenre', @level2type = N'COLUMN', @level2name = N'objId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Жанры объекта права', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RelPopGenre';

