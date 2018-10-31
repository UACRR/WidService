CREATE TABLE [dbo].[AgreementAddPartner] (
    [agrId]         INT             NOT NULL,
    [custId]        INT             NULL,
    [srFirstRate]   NUMERIC (10, 5) NULL,
    [srMonthRate]   NUMERIC (10, 5) NULL,
    [pfFirstRate]   NUMERIC (10, 5) NULL,
    [pfMonthRate]   NUMERIC (10, 5) NULL,
    [courtRate]     NUMERIC (10, 5) NULL,
    [noCourtRate]   NUMERIC (10, 5) NULL,
    [courtCompRate] NUMERIC (10, 5) NULL,
    [version]       INT             NOT NULL,
    [agrNumber]     VARCHAR (100)   NULL,
    [agrDate]       DATE            NULL,
    [dateBegin]     DATE            NULL,
    [dateEnd]       DATE            NULL,
    [periodCode]    INT             NULL,
    [agrStatus]     INT             NULL,
    [dayForPay]     INT             NULL,
    [ankVersion]    INT             NULL,
    [modifyDate]    DATETIME        NULL,
    [modifyLogin]   VARCHAR (48)    NULL,
    CONSTRAINT [PK_AGREEMENTADDPARTNER] PRIMARY KEY CLUSTERED ([agrId] ASC, [version] ASC),
    CONSTRAINT [FK_AGREEMEN_REFER_AGREEMEN] FOREIGN KEY ([agrStatus]) REFERENCES [dbo].[AgreementStatus] ([codeI]),
    CONSTRAINT [FK_AGREEMEN_REFER_PERIOD] FOREIGN KEY ([periodCode]) REFERENCES [dbo].[Period] ([codeI]),
    CONSTRAINT [FK_AGREEMEN_REFERENCE_AGREEMEN] FOREIGN KEY ([agrId]) REFERENCES [dbo].[AgreementMaster] ([agrId]),
    CONSTRAINT [FK_AGREEMEN_REFERENCE_PARTNER] FOREIGN KEY ([custId]) REFERENCES [dbo].[Partner] ([custId])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'винагорода за стягнення компенсації за порушення майнових авторських прав у судовому порядку', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AgreementAddPartner', @level2type = N'COLUMN', @level2name = N'courtCompRate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'винагорода за послуги із погашення заборгованості у позасудовому порядку', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AgreementAddPartner', @level2type = N'COLUMN', @level2name = N'noCourtRate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'винагорода за послуги із погашення заборгованості у судовому порядку', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AgreementAddPartner', @level2type = N'COLUMN', @level2name = N'courtRate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'концертно-видовищні заходи, гастрольні, театральні - щомісячний платіж', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AgreementAddPartner', @level2type = N'COLUMN', @level2name = N'pfMonthRate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'концертно-видовищні заходи, гастрольні, театральні - одноразова сума', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AgreementAddPartner', @level2type = N'COLUMN', @level2name = N'pfFirstRate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'ежемесячный процент', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AgreementAddPartner', @level2type = N'COLUMN', @level2name = N'srMonthRate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'відсоток від першого місячного платежу', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AgreementAddPartner', @level2type = N'COLUMN', @level2name = N'srFirstRate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор Партнера', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AgreementAddPartner', @level2type = N'COLUMN', @level2name = N'custId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор договора', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AgreementAddPartner', @level2type = N'COLUMN', @level2name = N'agrId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Данные по договору с партнером', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AgreementAddPartner';

