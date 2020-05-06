CREATE TABLE [dbo].[RequestMovie] (
    [reqId]          INT           NOT NULL,
    [kindFilm]       INT           NULL,
    [episodeComment] VARCHAR (254) NULL,
    [UseHire]        BIT           NULL,
    [UseFestival]    BIT           NULL,
    CONSTRAINT [PK_REQUESTMOVIE] PRIMARY KEY CLUSTERED ([reqId] ASC),
    CONSTRAINT [FK_REQUESTM_REFERENCE_KINDFILM] FOREIGN KEY ([kindFilm]) REFERENCES [dbo].[KindFilm] ([codeI]),
    CONSTRAINT [FK_REQUESTM_REFERENCE_REQUEST] FOREIGN KEY ([reqId]) REFERENCES [dbo].[Request] ([reqId])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Информция для заявки на синхронизаяцию для фильма', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RequestMovie';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор заявки', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RequestMovie', @level2type = N'COLUMN', @level2name = N'reqId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Вид фильма  ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RequestMovie', @level2type = N'COLUMN', @level2name = N'kindFilm';

