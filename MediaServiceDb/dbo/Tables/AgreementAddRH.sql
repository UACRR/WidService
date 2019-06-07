CREATE TABLE [dbo].[AgreementAddRH] (
    [agrId]       INT             NOT NULL,
    [rateCourt]   DECIMAL (10, 5) NULL,
    [rateCommiss] DECIMAL (10, 5) NULL,
    [responsUser] NVARCHAR (48)   NULL,
    [custId]      INT             NULL,
    [version]     INT             NOT NULL,
    [agrNumber]   VARCHAR (100)   NULL,
    [agrDate]     DATE            NULL,
    [dateBegin]   DATE            NULL,
    [dateEnd]     DATE            NULL,
    [periodCode]  INT             NULL,
    [dayForPay]   INT             NULL,
    [ankVersion]  INT             NULL,
    [agrStatus]   INT             NULL,
    [getCode]     INT             NULL,
    [modifyDate]  DATETIME        NULL,
    [modifyLogin] VARCHAR (48)    NULL,
    CONSTRAINT [PK_AGREEMENTADDRH] PRIMARY KEY CLUSTERED ([agrId] ASC, [version] ASC),
    CONSTRAINT [FK_AGREEMEN_REF_AGREEMEN] FOREIGN KEY ([agrStatus]) REFERENCES [dbo].[AgreementStatus] ([codeI]),
    CONSTRAINT [FK_AGREEMEN_REF_PERIOD] FOREIGN KEY ([periodCode]) REFERENCES [dbo].[Period] ([codeI]),
    CONSTRAINT [FK_AGREEMEN_REFERENCE_AGREEM] FOREIGN KEY ([agrId]) REFERENCES [dbo].[AgreementMaster] ([agrId]),
    CONSTRAINT [FK_AGREEMEN_REFERENCE_ASPNETUS] FOREIGN KEY ([responsUser]) REFERENCES [dbo].[AspNetUsers] ([id]),
    CONSTRAINT [FK_AGREEMEN_REFERENCE_RIGHTHOL] FOREIGN KEY ([custId]) REFERENCES [dbo].[RightHolder] ([custId]),
    CONSTRAINT [FK_AGREEMEN_REFERENCE_TYPEMETH] FOREIGN KEY ([getCode]) REFERENCES [dbo].[TypeMethodGet] ([codeI])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор клиента (правообладателя или покупателя)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AgreementAddRH', @level2type = N'COLUMN', @level2name = N'custId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Ответственный исполнитель', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AgreementAddRH', @level2type = N'COLUMN', @level2name = N'responsUser';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Ставка комиссии ОКУ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AgreementAddRH', @level2type = N'COLUMN', @level2name = N'rateCommiss';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Ставка комиссии при судебном разбирательстве', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AgreementAddRH', @level2type = N'COLUMN', @level2name = N'rateCourt';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор договора', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AgreementAddRH', @level2type = N'COLUMN', @level2name = N'agrId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Комиссиооные от Правообладаелей', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AgreementAddRH';

