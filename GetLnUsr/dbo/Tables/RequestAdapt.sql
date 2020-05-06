CREATE TABLE [dbo].[RequestAdapt] (
    [reqId]               INT           NOT NULL,
    [execNick]            VARCHAR (254) NULL,
    [modifyType]          INT           NULL,
    [modifyTextType]      INT           NULL,
    [modifyTextComment]   VARCHAR (512) NULL,
    [modifyMusicType]     INT           NULL,
    [modifyMusictComment] VARCHAR (512) NULL,
    [useAreaComment]      VARCHAR (256) NULL,
    CONSTRAINT [PK_REQUESTADAPT] PRIMARY KEY CLUSTERED ([reqId] ASC),
    CONSTRAINT [FK_REQUESTA_REF_REQUESTADA] FOREIGN KEY ([reqId]) REFERENCES [dbo].[Request] ([reqId]),
    CONSTRAINT [FK_REQUESTA_REFERENCE_MODIFYMU] FOREIGN KEY ([modifyMusicType]) REFERENCES [dbo].[ModifyMusicType] ([codeI]),
    CONSTRAINT [FK_REQUESTA_REFERENCE_MODIFYTE] FOREIGN KEY ([modifyTextType]) REFERENCES [dbo].[ModifyTextType] ([codeI]),
    CONSTRAINT [FK_REQUESTA_REFERENCE_MODIFYTY] FOREIGN KEY ([modifyType]) REFERENCES [dbo].[ModifyType] ([codeI])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Информация для заявки на адаптацию', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RequestAdapt';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор заявки', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RequestAdapt', @level2type = N'COLUMN', @level2name = N'reqId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Творческий псевдоним исполнителя ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RequestAdapt', @level2type = N'COLUMN', @level2name = N'execNick';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Тип изменений (текст, музыка, текст и музыка)
   ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RequestAdapt', @level2type = N'COLUMN', @level2name = N'modifyType';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Тип изменения текста (синхронный перевод, отклонение от содержания, полное изменение текста, отказ от текста (инструментальная версия) )
   ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RequestAdapt', @level2type = N'COLUMN', @level2name = N'modifyTextType';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Комментарий к изменению текста ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RequestAdapt', @level2type = N'COLUMN', @level2name = N'modifyTextComment';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Тип изменения музыки (без изменений, изменение стиля (аранжировка), отказ от музыки (только текст),  другое (с возможностью указать значение))
   ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RequestAdapt', @level2type = N'COLUMN', @level2name = N'modifyMusicType';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Комментарий к изменению текста ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RequestAdapt', @level2type = N'COLUMN', @level2name = N'modifyMusictComment';

