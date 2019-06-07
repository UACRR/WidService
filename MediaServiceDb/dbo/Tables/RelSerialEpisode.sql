CREATE TABLE [dbo].[RelSerialEpisode] (
    [reqId]           INT        NOT NULL,
    [episodeTypeCode] INT        NOT NULL,
    [epDuration]      FLOAT (53) NULL,
    CONSTRAINT [PK_RELSERIALEPISODE] PRIMARY KEY CLUSTERED ([reqId] ASC, [episodeTypeCode] ASC),
    CONSTRAINT [FK_RELSERIAEP_REF_EPISODET] FOREIGN KEY ([episodeTypeCode]) REFERENCES [dbo].[EpisodeType] ([codeI]),
    CONSTRAINT [FK_RELSERIAEP_REF_REQSERIAL] FOREIGN KEY ([reqId]) REFERENCES [dbo].[RequestSerial] ([reqId])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор заявки', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RelSerialEpisode', @level2type = N'COLUMN', @level2name = N'reqId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Набор эписодов для использования синхронизации в сериале', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RelSerialEpisode';

