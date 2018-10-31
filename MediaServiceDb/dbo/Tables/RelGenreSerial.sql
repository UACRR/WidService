CREATE TABLE [dbo].[RelGenreSerial] (
    [reqId]   INT NOT NULL,
    [genreId] INT NOT NULL,
    CONSTRAINT [PK_RELGENRESERIAL] PRIMARY KEY CLUSTERED ([reqId] ASC, [genreId] ASC),
    CONSTRAINT [FK_RELGENRE_REF_GENRESERI] FOREIGN KEY ([genreId]) REFERENCES [dbo].[PopGenre] ([id]),
    CONSTRAINT [FK_RELGENRE_REF_REQUESTSERI] FOREIGN KEY ([reqId]) REFERENCES [dbo].[RequestSerial] ([reqId])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор заявки', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RelGenreSerial', @level2type = N'COLUMN', @level2name = N'reqId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Перечень жанров для сериала, в котором используется объект права', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RelGenreSerial';

