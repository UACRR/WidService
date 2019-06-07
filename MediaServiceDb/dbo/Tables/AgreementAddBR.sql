CREATE TABLE [dbo].[AgreementAddBR] (
    [agrId]       INT           NOT NULL,
    [version]     INT           NOT NULL,
    [agrNumber]   VARCHAR (100) NULL,
    [agrDate]     DATE          NULL,
    [dateBegin]   DATE          NULL,
    [dateEnd]     DATE          NULL,
    [periodCode]  INT           NULL,
    [agrStatus]   INT           NULL,
    [dayForPay]   INT           NULL,
    [ankVersion]  INT           NULL,
    [modifyDate]  DATETIME      NULL,
    [modifyLogin] VARCHAR (48)  NULL,
    [custId]      INT           NULL,
    CONSTRAINT [PK_AGREEMENTADDBR] PRIMARY KEY CLUSTERED ([agrId] ASC, [version] ASC),
    CONSTRAINT [FK_AGRBR_REFERENCE_AGRMASTER] FOREIGN KEY ([agrId]) REFERENCES [dbo].[AgreementMaster] ([agrId]),
    CONSTRAINT [FK_AGRBR_REFERENCE_AGRSTATUS] FOREIGN KEY ([agrStatus]) REFERENCES [dbo].[AgreementStatus] ([codeI]),
    CONSTRAINT [FK_AGRBR_REFERENCE_PERIOD] FOREIGN KEY ([periodCode]) REFERENCES [dbo].[Period] ([codeI]),
    CONSTRAINT [FK_AGREEMEN_REFERENCE_CLIENT] FOREIGN KEY ([custId]) REFERENCES [dbo].[Client] ([custId])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Пользователь, кто модифицировал запись', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AgreementAddBR', @level2type = N'COLUMN', @level2name = N'modifyLogin';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Дата/время модификации договора', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AgreementAddBR', @level2type = N'COLUMN', @level2name = N'modifyDate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Номер текущей версии анкеты', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AgreementAddBR', @level2type = N'COLUMN', @level2name = N'ankVersion';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'День, до которого нужно рассчитаться 
   Обязательно для Больших Прав', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AgreementAddBR', @level2type = N'COLUMN', @level2name = N'dayForPay';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Периодичность расчета
   Обязательно для Больших Прав', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AgreementAddBR', @level2type = N'COLUMN', @level2name = N'periodCode';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Дата окончания договора', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AgreementAddBR', @level2type = N'COLUMN', @level2name = N'dateEnd';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'дата начала договора', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AgreementAddBR', @level2type = N'COLUMN', @level2name = N'dateBegin';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Дата договора доп.соглашения', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AgreementAddBR', @level2type = N'COLUMN', @level2name = N'agrDate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Номер договорадопюсоглашения', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AgreementAddBR', @level2type = N'COLUMN', @level2name = N'agrNumber';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Версия', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AgreementAddBR', @level2type = N'COLUMN', @level2name = N'version';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор договора', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AgreementAddBR', @level2type = N'COLUMN', @level2name = N'agrId';

