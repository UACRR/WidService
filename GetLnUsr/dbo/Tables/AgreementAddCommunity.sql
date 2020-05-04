CREATE TABLE [dbo].[AgreementAddCommunity] (
    [agrId]        INT             NOT NULL,
    [version]      INT             NOT NULL,
    [rateCourt]    DECIMAL (10, 5) NULL,
    [rateCommiss]  DECIMAL (10, 5) NULL,
    [custId]       INT             NULL,
    [agrNumber]    VARCHAR (100)   NULL,
    [agrDate]      DATE            NULL,
    [dateBegin]    DATE            NULL,
    [dateEnd]      DATE            NULL,
    [periodCode]   INT             NULL,
    [dayForPay]    INT             NULL,
    [ankVersion]   INT             NULL,
    [agrStatus]    INT             NULL,
    [modifyDate]   DATETIME        NULL,
    [modifyLogin]  VARCHAR (48)    NULL,
    [dateBeginMEC] DATE            NULL,
    [dateEndMEC]   DATE            NULL,
    [dateBeginPER] DATE            NULL,
    [dateEndPER]   DATE            NULL,
    [isMEC]        BIT             NULL,
    [isPER]        BIT             NULL,
    CONSTRAINT [PK_AGREEMENTADDCOMMUNITY] PRIMARY KEY CLUSTERED ([agrId] ASC, [version] ASC),
    CONSTRAINT [FK_AGRComm_REFERENCE_AGREEMEN] FOREIGN KEY ([agrId]) REFERENCES [dbo].[AgreementMaster] ([agrId]),
    CONSTRAINT [FK_AGRComm_REFERENCE_AGRSTAUS] FOREIGN KEY ([agrStatus]) REFERENCES [dbo].[AgreementStatus] ([codeI]),
    CONSTRAINT [FK_AGRComm_REFERENCE_COMMUNIT] FOREIGN KEY ([custId]) REFERENCES [dbo].[Community] ([custId]),
    CONSTRAINT [FK_AGREEMEN_REFERENCE_PERIOD] FOREIGN KEY ([periodCode]) REFERENCES [dbo].[Period] ([codeI])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Чужие ОКУ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AgreementAddCommunity';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор договора', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AgreementAddCommunity', @level2type = N'COLUMN', @level2name = N'agrId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Версия', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AgreementAddCommunity', @level2type = N'COLUMN', @level2name = N'version';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Ставка комиссии при судебном разбирательстве', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AgreementAddCommunity', @level2type = N'COLUMN', @level2name = N'rateCourt';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Ставка комиссии ОКУ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AgreementAddCommunity', @level2type = N'COLUMN', @level2name = N'rateCommiss';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор клиента (правообладателя)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AgreementAddCommunity', @level2type = N'COLUMN', @level2name = N'custId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Номер договора (додаткова угода)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AgreementAddCommunity', @level2type = N'COLUMN', @level2name = N'agrNumber';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Дата договора (додаткова угода)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AgreementAddCommunity', @level2type = N'COLUMN', @level2name = N'agrDate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'дата начала действия договора', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AgreementAddCommunity', @level2type = N'COLUMN', @level2name = N'dateBegin';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Дата закінчення дії договору', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AgreementAddCommunity', @level2type = N'COLUMN', @level2name = N'dateEnd';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Периодичность расчетов с правлообладателем
   ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AgreementAddCommunity', @level2type = N'COLUMN', @level2name = N'periodCode';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'День, до которого нужно рассчитаться с правообладателем
   ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AgreementAddCommunity', @level2type = N'COLUMN', @level2name = N'dayForPay';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Номер текущей версии анкеты', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AgreementAddCommunity', @level2type = N'COLUMN', @level2name = N'ankVersion';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Статус договора', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AgreementAddCommunity', @level2type = N'COLUMN', @level2name = N'agrStatus';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Дата/время модификации договора', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AgreementAddCommunity', @level2type = N'COLUMN', @level2name = N'modifyDate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Пользователь, кто модифицировал запись', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AgreementAddCommunity', @level2type = N'COLUMN', @level2name = N'modifyLogin';

