CREATE TABLE [dbo].[AgreementMaster] (
    [agrId]       INT          IDENTITY (1, 1) NOT NULL,
    [custId]      INT          NOT NULL,
    [agrStatus]   INT          NULL,
    [modifyDate]  DATETIME     NULL,
    [modifyLogin] VARCHAR (48) NULL,
    [agrType]     INT          NULL,
    [version]     INT          NULL,
    CONSTRAINT [PK_AGREEMENTMASTER] PRIMARY KEY CLUSTERED ([agrId] ASC),
    CONSTRAINT [FK_AGREEMEN_REF_AGRTYPE] FOREIGN KEY ([agrType]) REFERENCES [dbo].[AgreementType] ([codeI]),
    CONSTRAINT [FK_AGREEMEN_REFERENCE_CUSTOMER] FOREIGN KEY ([custId]) REFERENCES [dbo].[Customer] ([custId]),
    CONSTRAINT [FK_AGREEMEN_REFERENCE_STATUS] FOREIGN KEY ([agrStatus]) REFERENCES [dbo].[AgreementStatus] ([codeI])
);


GO
CREATE NONCLUSTERED INDEX [iAgreementMaster]
    ON [dbo].[AgreementMaster]([custId] ASC);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Генеральній договор с клиентами и правообладателями
   
   ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AgreementMaster';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор договора', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AgreementMaster', @level2type = N'COLUMN', @level2name = N'agrId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор клиента (правообладателя или покупателя)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AgreementMaster', @level2type = N'COLUMN', @level2name = N'custId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Дата/время модификации договора', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AgreementMaster', @level2type = N'COLUMN', @level2name = N'modifyDate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Пользователь, кто модифицировал запись', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AgreementMaster', @level2type = N'COLUMN', @level2name = N'modifyLogin';

