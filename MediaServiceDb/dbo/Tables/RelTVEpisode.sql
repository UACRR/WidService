CREATE TABLE [dbo].[RelTVEpisode] (
    [reqId]           INT        NOT NULL,
    [episodeTypeCode] INT        NOT NULL,
    [epDuration]      FLOAT (53) NULL,
    CONSTRAINT [PK_RELTVEPISODE] PRIMARY KEY CLUSTERED ([reqId] ASC, [episodeTypeCode] ASC),
    CONSTRAINT [FK_RELTVEPI_REFERENCE_EPISODET] FOREIGN KEY ([episodeTypeCode]) REFERENCES [dbo].[EpisodeType] ([codeI]),
    CONSTRAINT [FK_RELTVEPI_REFERENCE_REQUESTT] FOREIGN KEY ([reqId]) REFERENCES [dbo].[RequestTVRadio] ([reqId])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Длительность эпизода', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RelTVEpisode', @level2type = N'COLUMN', @level2name = N'epDuration';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор заявки', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RelTVEpisode', @level2type = N'COLUMN', @level2name = N'reqId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Набор эписодов для использования синхронизации в ТВ/Радио передаче', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RelTVEpisode';

