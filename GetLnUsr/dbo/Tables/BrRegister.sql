CREATE TABLE [dbo].[BrRegister] (
    [regId]      INT           IDENTITY (1, 1) NOT NULL,
    [periodId]   INT           NULL,
    [custId]     INT           NULL,
    [createDate] DATE          NULL,
    [fullAmount] MONEY         NULL,
    [rAmount]    MONEY         NULL,
    [status]     INT           NULL,
    [fileName]   VARCHAR (512) NULL,
    [userId]     NVARCHAR (48) NULL,
    CONSTRAINT [PK_BRREGISTER] PRIMARY KEY CLUSTERED ([regId] ASC),
    CONSTRAINT [FK_BRREGIST_REFERENCE_CLIENT] FOREIGN KEY ([custId]) REFERENCES [dbo].[Client] ([custId]),
    CONSTRAINT [FK_BRREGIST_REFERENCE_PAIDPERI] FOREIGN KEY ([periodId]) REFERENCES [dbo].[PaidPeriod] ([periodId]),
    CONSTRAINT [FK_BRREGIST_REFERENCE_REGISTER] FOREIGN KEY ([status]) REFERENCES [dbo].[RegisterStatus] ([codeI])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Расчетній лист больших прав', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'BrRegister';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор клиента (правообладателя или покупателя)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'BrRegister', @level2type = N'COLUMN', @level2name = N'custId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Сума зборів - Для Великих прав', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'BrRegister', @level2type = N'COLUMN', @level2name = N'fullAmount';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Статус ведомости', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'BrRegister', @level2type = N'COLUMN', @level2name = N'status';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'путь и имя файла', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'BrRegister', @level2type = N'COLUMN', @level2name = N'fileName';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Пользователь, кто вводил реестр', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'BrRegister', @level2type = N'COLUMN', @level2name = N'userId';

