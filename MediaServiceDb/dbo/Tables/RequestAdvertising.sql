CREATE TABLE [dbo].[RequestAdvertising] (
    [reqId]         INT           NOT NULL,
    [tradeMark]     VARCHAR (254) NULL,
    [durationAll]   TIME (7)      NULL,
    [durationShort] TIME (7)      NULL,
    CONSTRAINT [PK_REQUESTADVERTISING] PRIMARY KEY CLUSTERED ([reqId] ASC),
    CONSTRAINT [FK_REQUESTA_REF_REQUESTADV] FOREIGN KEY ([reqId]) REFERENCES [dbo].[Request] ([reqId])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Торговая Марка ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RequestAdvertising', @level2type = N'COLUMN', @level2name = N'tradeMark';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор заявки', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RequestAdvertising', @level2type = N'COLUMN', @level2name = N'reqId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Информция для заявки на синхронизаяцию для рекламы', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RequestAdvertising';

