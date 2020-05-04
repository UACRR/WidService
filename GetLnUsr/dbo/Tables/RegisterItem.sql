CREATE TABLE [dbo].[RegisterItem] (
    [regId]         INT           NOT NULL,
    [regIItemId]    INT           NOT NULL,
    [objId]         INT           NULL,
    [codeItem]      INT           NOT NULL,
    [ItemName]      VARCHAR (100) NULL,
    [categoryCode]  INT           NULL,
    [performer]     VARCHAR (100) NULL,
    [authorMusic]   VARCHAR (100) NULL,
    [authorText]    VARCHAR (100) NULL,
    [durationUse]   TIME (7)      NULL,
    [countUse]      INT           NULL,
    [durationItem]  TIME (7)      NULL,
    [modifyDate]    DATETIME      NULL,
    [modifyLogin]   VARCHAR (48)  NULL,
    [durationticks] INT           NULL,
    [ticks]         INT           NOT NULL,
    [isAuto]        BIT           NOT NULL,
    [genreType]     INT           NULL,
    [WIC]           INT           NULL,
    CONSTRAINT [PK_REGISTERITEM] PRIMARY KEY CLUSTERED ([regId] ASC, [regIItemId] ASC),
    CONSTRAINT [FK_REGISTER_REF_REGITEM] FOREIGN KEY ([regId]) REFERENCES [dbo].[Register] ([regId]),
    CONSTRAINT [FK_REGISTER_REFERENCE_GENRETYP] FOREIGN KEY ([genreType]) REFERENCES [dbo].[GenreType] ([codeI]),
    CONSTRAINT [FK_REGITEM_REF_OBJRIGHT] FOREIGN KEY ([objId]) REFERENCES [dbo].[ObjectRight] ([objId]),
    CONSTRAINT [FK_REGITEM_REF_REGITEMTYPE] FOREIGN KEY ([codeItem]) REFERENCES [dbo].[RegisterItemType] ([codeI])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Отчетная ведомость использования объектов права Детализация по объектам', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RegisterItem';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор ведомости', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RegisterItem', @level2type = N'COLUMN', @level2name = N'regId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор записи в ведомости', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RegisterItem', @level2type = N'COLUMN', @level2name = N'regIItemId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор объекта права', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RegisterItem', @level2type = N'COLUMN', @level2name = N'objId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Наименование произведения', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RegisterItem', @level2type = N'COLUMN', @level2name = N'ItemName';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Код категории объекта автоского права', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RegisterItem', @level2type = N'COLUMN', @level2name = N'categoryCode';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Исполнитель произведения', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RegisterItem', @level2type = N'COLUMN', @level2name = N'performer';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Автор музыки произведения', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RegisterItem', @level2type = N'COLUMN', @level2name = N'authorMusic';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Автор текста', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RegisterItem', @level2type = N'COLUMN', @level2name = N'authorText';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Продолжительность использования ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RegisterItem', @level2type = N'COLUMN', @level2name = N'durationUse';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Количество использований композиции', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RegisterItem', @level2type = N'COLUMN', @level2name = N'countUse';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Общая длительность звучания произведения ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RegisterItem', @level2type = N'COLUMN', @level2name = N'durationItem';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Дата модификации записи', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RegisterItem', @level2type = N'COLUMN', @level2name = N'modifyDate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Пользователь, кто модифицировал запись', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RegisterItem', @level2type = N'COLUMN', @level2name = N'modifyLogin';

