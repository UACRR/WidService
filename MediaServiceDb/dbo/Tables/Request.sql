CREATE TABLE [dbo].[Request] (
    [reqId]        INT           IDENTITY (1, 1) NOT NULL,
    [categoryCode] INT           NULL,
    [reqType]      INT           NOT NULL,
    [reqDate]      DATE          NULL,
    [countUse]     INT           NULL,
    [beginDate]    DATE          NULL,
    [endDate]      DATE          NULL,
    [reqstatus]    INT           NOT NULL,
    [custId]       INT           NULL,
    [userId]       NVARCHAR (48) NULL,
    [reqAimCode]   INT           NOT NULL,
    [objId]        INT           NULL,
    [kindCompCode] INT           NULL,
    [termUseCode]  INT           NULL,
    [createDate]   DATETIME      NULL,
    [modifyDate]   DATETIME      NULL,
    [modifyLogin]  VARCHAR (48)  NULL,
    [licCode]      INT           NULL,
    [reqCustId]    INT           NULL,
    [reqComment]   VARCHAR (254) NULL,
    [r030]         CHAR (3)      NULL,
    [reqAmount]    MONEY         NULL,
    [workName]     VARCHAR (254) NULL,
    [durationUse]  TIME (7)      NULL,
    CONSTRAINT [PK_REQUEST] PRIMARY KEY CLUSTERED ([reqId] ASC),
    CONSTRAINT [FK_REQUEST_REFERENCE_CATEGORY] FOREIGN KEY ([categoryCode]) REFERENCES [dbo].[Category] ([codeI]),
    CONSTRAINT [FK_REQUEST_REFERENCE_CUSTOMER] FOREIGN KEY ([custId]) REFERENCES [dbo].[Customer] ([custId]),
    CONSTRAINT [FK_REQUEST_REFERENCE_KINDCOMP] FOREIGN KEY ([kindCompCode]) REFERENCES [dbo].[KindComposition] ([codeI]),
    CONSTRAINT [FK_REQUEST_REFERENCE_LICENSET] FOREIGN KEY ([licCode]) REFERENCES [dbo].[LicenseType] ([codeI]),
    CONSTRAINT [FK_REQUEST_REFERENCE_OBJECTRI] FOREIGN KEY ([objId]) REFERENCES [dbo].[ObjectRight] ([objId]),
    CONSTRAINT [FK_REQUEST_REFERENCE_REQCUSTO] FOREIGN KEY ([reqCustId]) REFERENCES [dbo].[ReqCustomer] ([reqCustId]),
    CONSTRAINT [FK_REQUEST_REFERENCE_REQUESTA] FOREIGN KEY ([reqAimCode]) REFERENCES [dbo].[RequestAim] ([codeI]),
    CONSTRAINT [FK_REQUEST_REFERENCE_REQUESTS] FOREIGN KEY ([reqstatus]) REFERENCES [dbo].[RequestStatusType] ([codeI]),
    CONSTRAINT [FK_REQUEST_REFERENCE_REQUESTT] FOREIGN KEY ([reqType]) REFERENCES [dbo].[RequestType] ([codeI]),
    CONSTRAINT [FK_REQUEST_REFERENCE_TERMUSE] FOREIGN KEY ([termUseCode]) REFERENCES [dbo].[TermUse] ([codeI])
);




GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор объекта права', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Request', @level2type = N'COLUMN', @level2name = N'objId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Код цели использования ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Request', @level2type = N'COLUMN', @level2name = N'reqAimCode';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор клиента (правообладателя или покупателя)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Request', @level2type = N'COLUMN', @level2name = N'custId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Статус заявки', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Request', @level2type = N'COLUMN', @level2name = N'reqstatus';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Конец периода', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Request', @level2type = N'COLUMN', @level2name = N'endDate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Начало периода', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Request', @level2type = N'COLUMN', @level2name = N'beginDate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Количество использований композиции', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Request', @level2type = N'COLUMN', @level2name = N'countUse';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Дата заявки', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Request', @level2type = N'COLUMN', @level2name = N'reqDate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Код типа заявки', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Request', @level2type = N'COLUMN', @level2name = N'reqType';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Код категории объекта автоского права', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Request', @level2type = N'COLUMN', @level2name = N'categoryCode';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор заявки', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Request', @level2type = N'COLUMN', @level2name = N'reqId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Заявка', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Request';

