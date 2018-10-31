CREATE TABLE [dbo].[MediaFile] (
    [mediaFileId] INT           IDENTITY (1, 1) NOT NULL,
    [fileType]    VARCHAR (254) NULL,
    [path]        VARCHAR (254) NULL,
    [compress]    FLOAT (53)    NULL,
    [playTime]    FLOAT (53)    NULL,
    [objId]       INT           NULL,
    CONSTRAINT [PK_MEDIAFILE] PRIMARY KEY CLUSTERED ([mediaFileId] ASC),
    CONSTRAINT [FK_MEDIAFIL_ASSOCIATI_MEDIATRA] FOREIGN KEY ([objId]) REFERENCES [dbo].[MediaTrack] ([objId])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Время звучания', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'MediaFile', @level2type = N'COLUMN', @level2name = N'playTime';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Качество сжатия', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'MediaFile', @level2type = N'COLUMN', @level2name = N'compress';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Путь к файлу', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'MediaFile', @level2type = N'COLUMN', @level2name = N'path';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Тип файла', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'MediaFile', @level2type = N'COLUMN', @level2name = N'fileType';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'ID Идентификатор медиафайла', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'MediaFile', @level2type = N'COLUMN', @level2name = N'mediaFileId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Информация о файле размещения объекта права Медиа', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'MediaFile';

