CREATE TABLE [dbo].[RequestSerial] (
    [reqId]          INT           NOT NULL,
    [kindSerial]     INT           NULL,
    [episodeComment] VARCHAR (254) NULL,
    [cntSeries]      SMALLINT      NULL,
    [UseHire]        BIT           NULL,
    [UseFestival]    BIT           NULL,
    CONSTRAINT [PK_REQUESTSERIAL] PRIMARY KEY CLUSTERED ([reqId] ASC),
    CONSTRAINT [FK_REQUESTS_REF_REQUESTS] FOREIGN KEY ([reqId]) REFERENCES [dbo].[Request] ([reqId]),
    CONSTRAINT [FK_REQUESTS_REFERENCE_KINDSERI] FOREIGN KEY ([kindSerial]) REFERENCES [dbo].[KindSerial] ([codeI])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Вид Сериала', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RequestSerial', @level2type = N'COLUMN', @level2name = N'kindSerial';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор заявки', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RequestSerial', @level2type = N'COLUMN', @level2name = N'reqId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Информция для заявки на синхронизаяцию для сериалов', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RequestSerial';

