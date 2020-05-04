CREATE TABLE [dbo].[PopGenreTr] (
    [Id]   INT           NOT NULL,
    [lang] CHAR (2)      NOT NULL,
    [name] VARCHAR (100) NULL,
    CONSTRAINT [PK_GENRETR] PRIMARY KEY CLUSTERED ([Id] ASC, [lang] ASC),
    CONSTRAINT [FK_GENRETR_REFERENCE_GENRE] FOREIGN KEY ([Id]) REFERENCES [dbo].[PopGenre] ([id])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Жанр произведения', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'PopGenreTr';

