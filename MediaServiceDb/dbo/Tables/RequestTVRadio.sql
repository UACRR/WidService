CREATE TABLE [dbo].[RequestTVRadio] (
    [reqId]          INT           NOT NULL,
    [shortTitle]     VARCHAR (254) NULL,
    [nameTVChanel]   VARCHAR (254) NULL,
    [episodeComment] VARCHAR (254) NULL,
    CONSTRAINT [PK_REQUESTTVRADIO] PRIMARY KEY CLUSTERED ([reqId] ASC),
    CONSTRAINT [FK_REQUESTT_REF_TVREQUEST] FOREIGN KEY ([reqId]) REFERENCES [dbo].[Request] ([reqId])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Описание эпизодов ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RequestTVRadio', @level2type = N'COLUMN', @level2name = N'episodeComment';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Название телеканала ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RequestTVRadio', @level2type = N'COLUMN', @level2name = N'nameTVChanel';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Краткое описание передачи ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RequestTVRadio', @level2type = N'COLUMN', @level2name = N'shortTitle';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор заявки', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RequestTVRadio', @level2type = N'COLUMN', @level2name = N'reqId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Информция для заявки на синхронизаяцию для ТВ и радио', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RequestTVRadio';

