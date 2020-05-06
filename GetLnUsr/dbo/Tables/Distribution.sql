CREATE TABLE [dbo].[Distribution] (
    [distId]         INT   IDENTITY (1, 1) NOT NULL,
    [regId]          INT   NULL,
    [rmId]           INT   NULL,
    [cRKindCode]     INT   NOT NULL,
    [status]         INT   NOT NULL,
    [distribDate]    DATE  NOT NULL,
    [amount]         MONEY NOT NULL,
    [partnerCommiss] MONEY NOT NULL,
    [courtFee]       MONEY NOT NULL,
    [partnerId]      INT   NULL,
    [isCourt]        BIT   NULL,
    [regIdBr]        INT   NULL,
    [distType]       INT   NULL,
    [custId]         INT   NULL,
    [cRightId]       INT   NULL,
    CONSTRAINT [PK_DISTRIBUTION] PRIMARY KEY CLUSTERED ([distId] ASC),
    CONSTRAINT [CKC_CRKINDCODE_DISTRIBU] CHECK ([cRKindCode]>=(1)),
    CONSTRAINT [FK_DISTRIB_REF_REGISTER] FOREIGN KEY ([regId]) REFERENCES [dbo].[Register] ([regId]),
    CONSTRAINT [FK_DISTRIBU_REFERENCE_BRREGIST] FOREIGN KEY ([regIdBr]) REFERENCES [dbo].[BrRegister] ([regId]),
    CONSTRAINT [FK_DISTRIBU_REFERENCE_CLIENT] FOREIGN KEY ([custId]) REFERENCES [dbo].[Client] ([custId]),
    CONSTRAINT [FK_DISTRIBU_REFERENCE_COPYRIGH] FOREIGN KEY ([cRKindCode]) REFERENCES [dbo].[CopyrightKind] ([codeI]),
    CONSTRAINT [FK_DISTRIBU_REFERENCE_DISTRIBS] FOREIGN KEY ([status]) REFERENCES [dbo].[DistribStatus] ([codeI]),
    CONSTRAINT [FK_DISTRIBU_REFERENCE_PARTNER] FOREIGN KEY ([partnerId]) REFERENCES [dbo].[Partner] ([custId]),
    CONSTRAINT [FK_DISTRIBU_REFERENCE_REGISTER] FOREIGN KEY ([rmId]) REFERENCES [dbo].[RegisterRatedList] ([rmId]),
    CONSTRAINT [FK_DISTRIBUT_REF_COPYRIGHT] FOREIGN KEY ([cRightId]) REFERENCES [dbo].[CopyRight] ([cRightId])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'РозподілСуми', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Distribution';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор ведомости', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Distribution', @level2type = N'COLUMN', @level2name = N'regId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Код вида правообладателя', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Distribution', @level2type = N'COLUMN', @level2name = N'cRKindCode';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Код категории объекта автоского права', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Distribution', @level2type = N'COLUMN', @level2name = N'status';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'судебній сбор', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Distribution', @level2type = N'COLUMN', @level2name = N'courtFee';

