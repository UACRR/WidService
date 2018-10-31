CREATE TABLE [dbo].[MediaTrack] (
    [objId]         INT           NOT NULL,
    [iswc]          VARCHAR (254) NULL,
    [name]          VARCHAR (254) NULL,
    [lyrics]        VARCHAR (254) NULL,
    [composers]     VARCHAR (256) NULL,
    [performers]    VARCHAR (254) NULL,
    [Album]         VARCHAR (254) NULL,
    [genre]         VARCHAR (254) NULL,
    [numberInAlbum] INT           NULL,
    [year]          INT           NULL,
    [label]         VARCHAR (254) NULL,
    [modifyDate]    DATETIME      NULL,
    [modifyLogin]   VARCHAR (48)  NULL,
    [duration]      TIME (7)      NULL,
    CONSTRAINT [PK_MEDIATRACK] PRIMARY KEY CLUSTERED ([objId] ASC),
    CONSTRAINT [FK_MEDIATRA_ASSOCIATI_OBJECTRI] FOREIGN KEY ([objId]) REFERENCES [dbo].[ObjectRight] ([objId])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Пользователь, кто модифицировал запись', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'MediaTrack', @level2type = N'COLUMN', @level2name = N'modifyLogin';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Дата модификации записи', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'MediaTrack', @level2type = N'COLUMN', @level2name = N'modifyDate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Лейбл', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'MediaTrack', @level2type = N'COLUMN', @level2name = N'label';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Год', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'MediaTrack', @level2type = N'COLUMN', @level2name = N'year';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Номер трека в Альбоме', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'MediaTrack', @level2type = N'COLUMN', @level2name = N'numberInAlbum';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Альбом', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'MediaTrack', @level2type = N'COLUMN', @level2name = N'Album';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Исполнители', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'MediaTrack', @level2type = N'COLUMN', @level2name = N'performers';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Автора музыки', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'MediaTrack', @level2type = N'COLUMN', @level2name = N'composers';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Авторы текста', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'MediaTrack', @level2type = N'COLUMN', @level2name = N'lyrics';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Название трека', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'MediaTrack', @level2type = N'COLUMN', @level2name = N'name';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Международный ИД', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'MediaTrack', @level2type = N'COLUMN', @level2name = N'iswc';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор объекта права', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'MediaTrack', @level2type = N'COLUMN', @level2name = N'objId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Информация о треке объкта права. Записывается с тегов.', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'MediaTrack';

