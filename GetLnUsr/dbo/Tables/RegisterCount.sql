CREATE TABLE [dbo].[RegisterCount] (
    [regCntId]    NUMERIC (18)    IDENTITY (1, 1) NOT NULL,
    [regId]       INT             NULL,
    [regIItemId]  INT             NULL,
    [objId]       INT             NULL,
    [custId]      INT             NULL,
    [cRType]      INT             NULL,
    [cRKindCode]  INT             NULL,
    [rate]        DECIMAL (10, 5) NULL,
    [rateCommiss] DECIMAL (10, 5) NULL,
    [cmCustId]    INT             NULL,
    [regIdBr]     INT             NULL,
    [regItemIdBr] INT             NULL,
    [prepaySum]   MONEY           NULL,
    [distItemId]  INT             NULL,
    [distId]      INT             NULL,
    CONSTRAINT [PK_REGISTERCOUNT] PRIMARY KEY CLUSTERED ([regCntId] ASC),
    CONSTRAINT [FK_REGISTER_REFEREN_REGISTER] FOREIGN KEY ([regId], [regIItemId]) REFERENCES [dbo].[RegisterItem] ([regId], [regIItemId]) ON DELETE CASCADE,
    CONSTRAINT [FK_REGISTER_REFERENCE_BRREGITE] FOREIGN KEY ([regItemIdBr], [regIdBr]) REFERENCES [dbo].[BrRegItem] ([regItemId], [regId]),
    CONSTRAINT [FK_REGISTER_REFERENCE_COMMUNIT] FOREIGN KEY ([cmCustId]) REFERENCES [dbo].[Community] ([custId]),
    CONSTRAINT [FK_REGISTER_REFERENCE_COPYRIGH] FOREIGN KEY ([cRKindCode]) REFERENCES [dbo].[CopyrightKind] ([codeI]),
    CONSTRAINT [FK_REGISTER_REFERENCE_DISTRIBU] FOREIGN KEY ([distItemId], [distId]) REFERENCES [dbo].[DistributionItem] ([distItemId], [distId]),
    CONSTRAINT [FK_REGISTER_REFERENCE_RIGHTHOL] FOREIGN KEY ([custId]) REFERENCES [dbo].[RightHolder] ([custId])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Расчетная таблица', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RegisterCount';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор ведомости', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RegisterCount', @level2type = N'COLUMN', @level2name = N'regId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор записи в ведомости', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RegisterCount', @level2type = N'COLUMN', @level2name = N'regIItemId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор объекта права', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RegisterCount', @level2type = N'COLUMN', @level2name = N'objId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор правообладателя', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RegisterCount', @level2type = N'COLUMN', @level2name = N'custId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Тип авторского права', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RegisterCount', @level2type = N'COLUMN', @level2name = N'cRType';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Код вида правообладателя', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RegisterCount', @level2type = N'COLUMN', @level2name = N'cRKindCode';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = '% правообладания объектов права
   Нужно удалить в следующей версии портала - берется из MainCopyright', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RegisterCount', @level2type = N'COLUMN', @level2name = N'rate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Ставка комиссии ОКУ для Правообладателя (или Community)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RegisterCount', @level2type = N'COLUMN', @level2name = N'rateCommiss';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор Community', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RegisterCount', @level2type = N'COLUMN', @level2name = N'cmCustId';

