CREATE TABLE [dbo].[BrRegItem] (
    [regItemId]    INT             NOT NULL,
    [regId]        INT             NOT NULL,
    [objId]        INT             NULL,
    [licId]        INT             NULL,
    [ItemName]     VARCHAR (100)   NULL,
    [countUse]     INT             NULL,
    [numTicket]    INT             NULL,
    [fullAmount]   MONEY           NULL,
    [fullRate]     DECIMAL (10, 5) NULL,
    [rAmount]      MONEY           NULL,
    [modifyDate]   DATETIME        NULL,
    [modifyLogin]  VARCHAR (48)    NULL,
    [status]       INT             NULL,
    [regIdSr]      INT             NULL,
    [musicRate]    DECIMAL (10, 5) NULL,
    [musicAmount]  MONEY           NULL,
    [categoryCode] INT             NULL,
    CONSTRAINT [PK_BRREGITEM] PRIMARY KEY CLUSTERED ([regItemId] ASC, [regId] ASC),
    CONSTRAINT [FK_BRREGITE_REFERENCE_BRREGIST] FOREIGN KEY ([regId]) REFERENCES [dbo].[BrRegister] ([regId]),
    CONSTRAINT [FK_BRREGITE_REFERENCE_ITEMSTAT] FOREIGN KEY ([status]) REFERENCES [dbo].[ItemStatus] ([codeI]),
    CONSTRAINT [FK_BRREGITE_REFERENCE_LICENSEA] FOREIGN KEY ([licId]) REFERENCES [dbo].[LicenseAgreement] ([licId]),
    CONSTRAINT [FK_BRREGITE_REFERENCE_OBJECTRI] FOREIGN KEY ([objId]) REFERENCES [dbo].[ObjectRight] ([objId]),
    CONSTRAINT [FK_BRREGITE_REFERENCE_REGISTER] FOREIGN KEY ([regIdSr]) REFERENCES [dbo].[Register] ([regId])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Детализация расчетного листа для Больших Прав ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'BrRegItem';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор объекта права', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'BrRegItem', @level2type = N'COLUMN', @level2name = N'objId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Наименование произведения', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'BrRegItem', @level2type = N'COLUMN', @level2name = N'ItemName';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Количество использований композиции', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'BrRegItem', @level2type = N'COLUMN', @level2name = N'countUse';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Сума зборів - Для Великих прав', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'BrRegItem', @level2type = N'COLUMN', @level2name = N'fullAmount';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Дата модификации записи', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'BrRegItem', @level2type = N'COLUMN', @level2name = N'modifyDate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Пользователь, кто модифицировал запись', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'BrRegItem', @level2type = N'COLUMN', @level2name = N'modifyLogin';

