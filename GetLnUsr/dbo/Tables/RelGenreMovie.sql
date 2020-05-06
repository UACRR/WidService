CREATE TABLE [dbo].[RelGenreMovie] (
    [reqId]   INT NOT NULL,
    [genreId] INT NOT NULL,
    CONSTRAINT [PK_RELGENREMOVIE] PRIMARY KEY CLUSTERED ([reqId] ASC, [genreId] ASC),
    CONSTRAINT [FK_RELGENRE_REFERENCE_GENRE] FOREIGN KEY ([genreId]) REFERENCES [dbo].[PopGenre] ([id]),
    CONSTRAINT [FK_RELGENRE_REFERENCE_REQUESTM] FOREIGN KEY ([reqId]) REFERENCES [dbo].[RequestMovie] ([reqId])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Перечень жанров фильма, в котором будет использоваться объект права', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RelGenreMovie';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор заявки', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RelGenreMovie', @level2type = N'COLUMN', @level2name = N'reqId';

