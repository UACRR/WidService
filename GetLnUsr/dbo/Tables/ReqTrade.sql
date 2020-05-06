CREATE TABLE [dbo].[ReqTrade] (
    [tradeId]      INT           IDENTITY (1, 1) NOT NULL,
    [reqId]        INT           NOT NULL,
    [r030]         CHAR (3)      NOT NULL,
    [costRHolder]  MONEY         NULL,
    [createDate]   DATETIME      NULL,
    [rAgrId]       INT           NOT NULL,
    [status]       INT           NOT NULL,
    [statusDate]   DATETIME      NULL,
    [modifyDate]   DATETIME      NULL,
    [costClient]   MONEY         NULL,
    [tradeComment] VARCHAR (254) NULL,
    [causeCode]    INT           NULL,
    CONSTRAINT [PK_REQTRADE] PRIMARY KEY CLUSTERED ([tradeId] ASC),
    CONSTRAINT [FK_REQTRADE_REFERENCE_COMMENTC] FOREIGN KEY ([causeCode]) REFERENCES [dbo].[CommentCause] ([causeCode]),
    CONSTRAINT [FK_REQTRADE_REFERENCE_REQAGREE] FOREIGN KEY ([rAgrId]) REFERENCES [dbo].[ReqAgreement] ([rAgrId]),
    CONSTRAINT [FK_REQTRADE_REFERENCE_REQUEST] FOREIGN KEY ([reqId]) REFERENCES [dbo].[Request] ([reqId]),
    CONSTRAINT [FK_REQTRADE_REFERENCE_TRADESTA] FOREIGN KEY ([status]) REFERENCES [dbo].[TradeStatus] ([statusCode])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Таблица торгов', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ReqTrade';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор торгов', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ReqTrade', @level2type = N'COLUMN', @level2name = N'tradeId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор заявки', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ReqTrade', @level2type = N'COLUMN', @level2name = N'reqId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Валюта цены предложения', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ReqTrade', @level2type = N'COLUMN', @level2name = N'r030';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Сумма предложения', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ReqTrade', @level2type = N'COLUMN', @level2name = N'costRHolder';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Дата создания торгов ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ReqTrade', @level2type = N'COLUMN', @level2name = N'createDate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'ID Идентификатор записи таблицы договоров по заявке', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ReqTrade', @level2type = N'COLUMN', @level2name = N'rAgrId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Статус  записи торгов :
   0	Підготовка
   1	На погодженні
   2	Погоджено
   3	Зустрічна пропозиція
   8	Відмовлено правовласником
   9	Відмовлено клієнтом
   ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ReqTrade', @level2type = N'COLUMN', @level2name = N'status';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Дата время изменения статуса', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ReqTrade', @level2type = N'COLUMN', @level2name = N'statusDate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Дата модификации записи', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ReqTrade', @level2type = N'COLUMN', @level2name = N'modifyDate';

