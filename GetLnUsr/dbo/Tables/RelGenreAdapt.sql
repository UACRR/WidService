CREATE TABLE [dbo].[RelGenreAdapt] (
    [reqId]   INT NOT NULL,
    [genreId] INT NOT NULL,
    CONSTRAINT [PK_RELGENREADAPT] PRIMARY KEY CLUSTERED ([reqId] ASC, [genreId] ASC),
    CONSTRAINT [FK_RELGENRE_REFERENCE_REQUESTA] FOREIGN KEY ([reqId]) REFERENCES [dbo].[RequestAdapt] ([reqId]),
    CONSTRAINT [FK_RELGENREAD_REF_GENRE] FOREIGN KEY ([genreId]) REFERENCES [dbo].[PopGenre] ([id])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор заявки', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RelGenreAdapt', @level2type = N'COLUMN', @level2name = N'reqId';

