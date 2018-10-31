CREATE TABLE [dbo].[ReqAgreement] (
    [rAgrId]      INT           IDENTITY (1, 1) NOT NULL,
    [custId]      INT           NOT NULL,
    [custIdRh]    INT           NULL,
    [reqId]       INT           NULL,
    [r030]        CHAR (3)      NOT NULL,
    [amount]      MONEY         NULL,
    [costOffer]   MONEY         NULL,
    [status]      INT           NOT NULL,
    [agrDate]     DATETIME      NULL,
    [userId]      NVARCHAR (48) NULL,
    [modifyDate]  DATETIME      NULL,
    [tradeId]     INT           NULL,
    [r030Offer]   CHAR (3)      NULL,
    [statusDate]  DATETIME      NULL,
    [rAgrComment] VARCHAR (254) NULL,
    CONSTRAINT [PK_REQAGREEMENT] PRIMARY KEY CLUSTERED ([rAgrId] ASC),
    CONSTRAINT [FK_REQAGREE_REFERENCE_CUSTOMER] FOREIGN KEY ([custId]) REFERENCES [dbo].[Customer] ([custId]),
    CONSTRAINT [FK_REQAGREE_REFERENCE_REQAGREE] FOREIGN KEY ([status]) REFERENCES [dbo].[ReqAgreementStatus] ([statusCode]),
    CONSTRAINT [FK_REQAGREE_REFERENCE_REQUEST] FOREIGN KEY ([reqId]) REFERENCES [dbo].[Request] ([reqId]),
    CONSTRAINT [FK_REQAGREE_REFERENCE_RIGHTHOL] FOREIGN KEY ([custIdRh]) REFERENCES [dbo].[RightHolder] ([custId])
);


GO
CREATE NONCLUSTERED INDEX [Association16_FK]
    ON [dbo].[ReqAgreement]([custId] ASC);


GO
CREATE NONCLUSTERED INDEX [Association15_FK]
    ON [dbo].[ReqAgreement]([custIdRh] ASC);


GO
Create TRIGGER dbo.reqAgreementIns 
   ON  dbo.reqAgreement
      AFTER INSERT , UPDATE
	  AS 
BEGIN
	SET NOCOUNT ON;

   update reqAgreement set modifyDate = getdate() 
      from inserted t1 where reqAgreement.rAgrId = t1.rAgrId

END
GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Пользователь. который ввел предложение', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ReqAgreement', @level2type = N'COLUMN', @level2name = N'userId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Дата время предложения', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ReqAgreement', @level2type = N'COLUMN', @level2name = N'agrDate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = '', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ReqAgreement', @level2type = N'COLUMN', @level2name = N'status';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Предполагаемая цена', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ReqAgreement', @level2type = N'COLUMN', @level2name = N'costOffer';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Цена от правообладателя ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ReqAgreement', @level2type = N'COLUMN', @level2name = N'amount';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор заявки', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ReqAgreement', @level2type = N'COLUMN', @level2name = N'reqId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'ID Клиента - Правообладателя', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ReqAgreement', @level2type = N'COLUMN', @level2name = N'custIdRh';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор клиента (правообладателя или покупателя)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ReqAgreement', @level2type = N'COLUMN', @level2name = N'custId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'ID Идентификатор записи таблицы договоров по заявке', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ReqAgreement', @level2type = N'COLUMN', @level2name = N'rAgrId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Договора между клиентами по заявке', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ReqAgreement';

