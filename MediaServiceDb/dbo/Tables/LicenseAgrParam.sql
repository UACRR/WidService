CREATE TABLE [dbo].[LicenseAgrParam] (
    [licId]        INT             NOT NULL,
    [licVersion]   INT             NOT NULL,
    [licNum]       VARCHAR (25)    NULL,
    [licDate]      DATE            NULL,
    [dateBegin]    DATE            NULL,
    [dateEnd]      DATE            NULL,
    [minAmount]    MONEY           NULL,
    [rateAmount]   NUMERIC (10, 5) NULL,
    [isAutoprolog] BIT             NULL,
    [addRate]      NUMERIC (10, 5) NULL,
    [indxInfl]     NUMERIC (10, 5) NULL,
    [periodCode]   INT             NULL,
    [dayForPay]    INT             NULL,
    [licStatus]    INT             NULL,
    [modifyDate]   DATETIME        NULL,
    [modifyLogin]  VARCHAR (48)    NULL,
    [ankVersion]   INT             NULL,
    [comment]      VARCHAR (2048)  NULL,
    CONSTRAINT [PK_LICENSEAGRPARAM] PRIMARY KEY CLUSTERED ([licId] ASC, [licVersion] ASC),
    CONSTRAINT [FK_LICENSEA_REF_PERIOD] FOREIGN KEY ([periodCode]) REFERENCES [dbo].[Period] ([codeI]),
    CONSTRAINT [FK_LICENSEA_REFERENCE_AGREEMEN] FOREIGN KEY ([licStatus]) REFERENCES [dbo].[AgreementStatus] ([codeI]),
    CONSTRAINT [FK_LICENSEA_REFERENCE_LICENSEA] FOREIGN KEY ([licId]) REFERENCES [dbo].[LicenseAgreement] ([licId])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Пользователь, кто модифицировал запись', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'LicenseAgrParam', @level2type = N'COLUMN', @level2name = N'modifyLogin';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Дата модификации записи', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'LicenseAgrParam', @level2type = N'COLUMN', @level2name = N'modifyDate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'День, до которого нужно рассчитаться', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'LicenseAgrParam', @level2type = N'COLUMN', @level2name = N'dayForPay';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Підпищення на індекс інфляції', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'LicenseAgrParam', @level2type = N'COLUMN', @level2name = N'indxInfl';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'З підвищення авторської винагороди за попередній рік', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'LicenseAgrParam', @level2type = N'COLUMN', @level2name = N'addRate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Автопролонгация', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'LicenseAgrParam', @level2type = N'COLUMN', @level2name = N'isAutoprolog';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Параметры лицензионного договора, доп.соглашения', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'LicenseAgrParam';

