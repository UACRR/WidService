CREATE TABLE [dbo].[Fixation] (
    [fixId]           INT            IDENTITY (1, 1) NOT NULL,
    [partnerCustId]   INT            NULL,
    [stageStatus]     INT            NOT NULL,
    [clientCustId]    INT            NULL,
    [licId]           INT            NULL,
    [usesType]        INT            NULL,
    [eventName]       NVARCHAR (255) NULL,
    [eventDates]      NVARCHAR (255) NULL,
    [city]            NVARCHAR (255) NULL,
    [address]         NVARCHAR (255) NULL,
    [placement]       NVARCHAR (255) NULL,
    [countPlace]      INT            NULL,
    [ticketPriceMin]  MONEY          NULL,
    [ticketPriceMax]  MONEY          NULL,
    [fixationDtBegin] DATETIME       NULL,
    [fixationDtEnd]   DATETIME       NULL,
    [rewardAmount]    MONEY          NULL,
    [courtFeeAmount]  MONEY          NULL,
    [userId]          NVARCHAR (48)  NULL,
    CONSTRAINT [PK_FIXATION] PRIMARY KEY CLUSTERED ([fixId] ASC),
    CONSTRAINT [FK_FIXATION_REFERENCE_CLIENT] FOREIGN KEY ([clientCustId]) REFERENCES [dbo].[Client] ([custId]),
    CONSTRAINT [FK_FIXATION_REFERENCE_FIXSTAGE] FOREIGN KEY ([stageStatus]) REFERENCES [dbo].[FixStageStatus] ([codeI]),
    CONSTRAINT [FK_FIXATION_REFERENCE_LICENSEA] FOREIGN KEY ([licId]) REFERENCES [dbo].[LicenseAgreement] ([licId]),
    CONSTRAINT [FK_FIXATION_REFERENCE_PARTNER] FOREIGN KEY ([partnerCustId]) REFERENCES [dbo].[Partner] ([custId]),
    CONSTRAINT [FK_FIXATION_REFERENCE_USESTYPE] FOREIGN KEY ([usesType]) REFERENCES [dbo].[UsesType] ([codeI])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Подання про порушення авторських прав', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Fixation';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Ідентифікатор подання', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Fixation', @level2type = N'COLUMN', @level2name = N'fixId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор Партнера', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Fixation', @level2type = N'COLUMN', @level2name = N'partnerCustId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Етап подання і статус етапу подання', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Fixation', @level2type = N'COLUMN', @level2name = N'stageStatus';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор клиента (правообладателя или покупателя)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Fixation', @level2type = N'COLUMN', @level2name = N'clientCustId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Тип подання (малі права, виликі права, ...)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Fixation', @level2type = N'COLUMN', @level2name = N'usesType';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Назва події', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Fixation', @level2type = N'COLUMN', @level2name = N'eventName';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Дати заходу', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Fixation', @level2type = N'COLUMN', @level2name = N'eventDates';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Місто проведення заходу', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Fixation', @level2type = N'COLUMN', @level2name = N'city';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Адреса проведення заходу', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Fixation', @level2type = N'COLUMN', @level2name = N'address';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Приміщення в якому проводиться захід', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Fixation', @level2type = N'COLUMN', @level2name = N'placement';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Кількість місць', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Fixation', @level2type = N'COLUMN', @level2name = N'countPlace';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Мінімальна ціна квитка', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Fixation', @level2type = N'COLUMN', @level2name = N'ticketPriceMin';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Максимальна ціна квитка', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Fixation', @level2type = N'COLUMN', @level2name = N'ticketPriceMax';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Дата та час початку фіксації порушення прав', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Fixation', @level2type = N'COLUMN', @level2name = N'fixationDtBegin';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Дата та час завершення фіксації порушення прав', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Fixation', @level2type = N'COLUMN', @level2name = N'fixationDtEnd';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Сума винагороди', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Fixation', @level2type = N'COLUMN', @level2name = N'rewardAmount';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Сума судового збору', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Fixation', @level2type = N'COLUMN', @level2name = N'courtFeeAmount';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Відповідальний за фіксацію', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Fixation', @level2type = N'COLUMN', @level2name = N'userId';

