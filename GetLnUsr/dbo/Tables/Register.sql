CREATE TABLE [dbo].[Register] (
    [regId]         INT             IDENTITY (1, 1) NOT NULL,
    [rmId]          INT             NULL,
    [number]        VARCHAR (10)    NULL,
    [countRows]     INT             NOT NULL,
    [custId]        INT             NOT NULL,
    [createDate]    DATETIME        NULL,
    [durationticks] INT             NOT NULL,
    [rgStatus]      INT             NULL,
    [fileName]      VARCHAR (512)   NULL,
    [userId]        NVARCHAR (48)   NULL,
    [periodId]      INT             NULL,
    [regAmount]     MONEY           NULL,
    [regRate]       DECIMAL (5, 2)  NULL,
    [regRoyalty]    MONEY           NULL,
    [musicAmount]   MONEY           NULL,
    [musicRate]     DECIMAL (10, 5) NULL,
    [authAmount]    MONEY           NULL,
    [authRate]      DECIMAL (10, 5) NULL,
    [paidAmount]    MONEY           NULL,
    [licId]         INT             NULL,
    [schemaId]      INT             NULL,
    [algorithmId]   INT             NULL,
    CONSTRAINT [PK_REGISTER] PRIMARY KEY CLUSTERED ([regId] ASC),
    CONSTRAINT [FK_REG_REF_CLIENT] FOREIGN KEY ([custId]) REFERENCES [dbo].[Client] ([custId]),
    CONSTRAINT [FK_REG_REF_REGRATELIST] FOREIGN KEY ([rmId]) REFERENCES [dbo].[RegisterRatedList] ([rmId]),
    CONSTRAINT [FK_REGISTER_REFERENCE_ALGORITH] FOREIGN KEY ([algorithmId]) REFERENCES [dbo].[AlgorithmType] ([codeI]),
    CONSTRAINT [FK_REGISTER_REFERENCE_REGISTER2] FOREIGN KEY ([rgStatus]) REFERENCES [dbo].[RegisterStatus] ([codeI])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Отчетная ведомость использования объектов права 
   Общие данные (Расчетная)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Register';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор ведомости', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Register', @level2type = N'COLUMN', @level2name = N'regId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Количество записей в ведомости', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Register', @level2type = N'COLUMN', @level2name = N'countRows';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор клиента ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Register', @level2type = N'COLUMN', @level2name = N'custId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Дата/время создания договора', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Register', @level2type = N'COLUMN', @level2name = N'createDate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Статус ведомости', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Register', @level2type = N'COLUMN', @level2name = N'rgStatus';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'путь и имя файла', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Register', @level2type = N'COLUMN', @level2name = N'fileName';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Пользователь, кто вводил реестр', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Register', @level2type = N'COLUMN', @level2name = N'userId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'сумма за музюсупровід', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Register', @level2type = N'COLUMN', @level2name = N'musicAmount';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'процент за муз.супровід', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Register', @level2type = N'COLUMN', @level2name = N'musicRate';

