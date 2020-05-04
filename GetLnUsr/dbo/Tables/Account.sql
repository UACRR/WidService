CREATE TABLE [dbo].[Account] (
    [accId]      INT           IDENTITY (1, 1) NOT NULL,
    [balsCode]   INT           NULL,
    [custId]     INT           NULL,
    [objId]      INT           NULL,
    [r030]       CHAR (3)      NULL,
    [accNls]     VARCHAR (25)  NULL,
    [dateOpen]   DATE          NULL,
    [dateClose]  DATE          NULL,
    [accStatus]  INT           NOT NULL,
    [accName]    VARCHAR (100) NULL,
    [accDK]      SMALLINT      NULL,
    [dateModify] DATETIME      NULL,
    CONSTRAINT [PK_ACCOUNT] PRIMARY KEY CLUSTERED ([accId] ASC),
    CONSTRAINT [FK_ACCOUNT_REFERENCE_ACCOUNTB] FOREIGN KEY ([balsCode]) REFERENCES [dbo].[AccountBals] ([codeI]),
    CONSTRAINT [FK_ACCOUNT_REFERENCE_ACCOUNTS] FOREIGN KEY ([accStatus]) REFERENCES [dbo].[AccountStatus] ([codeI]),
    CONSTRAINT [FK_ACCOUNT_REFERENCE_CURRENCY] FOREIGN KEY ([r030]) REFERENCES [dbo].[Currency] ([r030]),
    CONSTRAINT [FK_ACCOUNT_REFERENCE_CUSTOMER] FOREIGN KEY ([custId]) REFERENCES [dbo].[Customer] ([custId]),
    CONSTRAINT [FK_ACCOUNT_REFERENCE_OBJECTRI] FOREIGN KEY ([objId]) REFERENCES [dbo].[ObjectRight] ([objId])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [AccountUI]
    ON [dbo].[Account]([r030] ASC, [accNls] ASC, [accStatus] ASC);


GO
CREATE NONCLUSTERED INDEX [idx_custId]
    ON [dbo].[Account]([accId] ASC, [custId] ASC);


GO
CREATE TRIGGER AccountInsert 
   ON  [dbo].[Account]
      AFTER INSERT 
AS 
BEGIN
   SET NOCOUNT ON;

   update Account set dateModify = getdate() 
      from inserted t1 where Account.AccId = t1.AccId
END

GO
GRANT SELECT
    ON OBJECT::[dbo].[Account] TO [ReportUser]
    AS [dbo];


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Таблица счетов учетной системы портала', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Account';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор счета', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Account', @level2type = N'COLUMN', @level2name = N'accId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Код характеристики (балансовый счет)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Account', @level2type = N'COLUMN', @level2name = N'balsCode';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор клиента (правообладателя или покупателя)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Account', @level2type = N'COLUMN', @level2name = N'custId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор объекта права', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Account', @level2type = N'COLUMN', @level2name = N'objId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Код валюты', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Account', @level2type = N'COLUMN', @level2name = N'r030';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Номер счета', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Account', @level2type = N'COLUMN', @level2name = N'accNls';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Дата открытия счета', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Account', @level2type = N'COLUMN', @level2name = N'dateOpen';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Дата закрытия счета', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Account', @level2type = N'COLUMN', @level2name = N'dateClose';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Статус счета', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Account', @level2type = N'COLUMN', @level2name = N'accStatus';

