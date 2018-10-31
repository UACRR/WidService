CREATE TABLE [dbo].[CustCmRight] (
    [custId]     INT  NOT NULL,
    [cRKindCode] INT  NOT NULL,
    [cmCustId]   INT  NOT NULL,
    [dateBegin]  DATE NOT NULL,
    [dateEnd]    DATE NOT NULL,
    CONSTRAINT [PK_CUSTCMRIGHT] PRIMARY KEY CLUSTERED ([custId] ASC, [cRKindCode] ASC, [dateBegin] ASC, [cmCustId] ASC),
    CONSTRAINT [FK_CUSTCMRI_REFERENCE_COMMUNIT] FOREIGN KEY ([cmCustId]) REFERENCES [dbo].[Community] ([custId]),
    CONSTRAINT [FK_CUSTCMRI_REFERENCE_TERMSOFS] FOREIGN KEY ([custId], [cRKindCode]) REFERENCES [dbo].[TermsOfService] ([custId], [CRKindCode])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Дата окончания периода', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CustCmRight', @level2type = N'COLUMN', @level2name = N'dateEnd';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Дата начала периода', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CustCmRight', @level2type = N'COLUMN', @level2name = N'dateBegin';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор сообщества', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CustCmRight', @level2type = N'COLUMN', @level2name = N'cmCustId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Код вида правообладателя', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CustCmRight', @level2type = N'COLUMN', @level2name = N'cRKindCode';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор клиента (правообладателя или покупателя)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CustCmRight', @level2type = N'COLUMN', @level2name = N'custId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Права, переданній в другие сообщества', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CustCmRight';

