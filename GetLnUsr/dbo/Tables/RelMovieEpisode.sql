CREATE TABLE [dbo].[RelMovieEpisode] (
    [episodeTypeCode] INT        NOT NULL,
    [reqId]           INT        NOT NULL,
    [epDuration]      FLOAT (53) NULL,
    CONSTRAINT [PK_RELMOVIEEPISODE] PRIMARY KEY CLUSTERED ([episodeTypeCode] ASC, [reqId] ASC),
    CONSTRAINT [FK_RELMOVIE_REFERENCE_EPISODET] FOREIGN KEY ([episodeTypeCode]) REFERENCES [dbo].[EpisodeType] ([codeI]),
    CONSTRAINT [FK_RELMOVIE_REFERENCE_REQUESTM] FOREIGN KEY ([reqId]) REFERENCES [dbo].[RequestMovie] ([reqId])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Набор эписодов для использования синхронизации в фильме', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RelMovieEpisode';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор заявки', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RelMovieEpisode', @level2type = N'COLUMN', @level2name = N'reqId';

