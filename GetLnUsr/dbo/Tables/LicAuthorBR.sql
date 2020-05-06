CREATE TABLE [dbo].[LicAuthorBR] (
    [cRightId]        INT             NOT NULL,
    [prepayType]      INT             NULL,
    [dateCreate]      DATE            NULL,
    [dateClose]       DATE            NULL,
    [dateModify]      DATE            NULL,
    [dateAccept]      DATE            NULL,
    [rate]            NUMERIC (10, 5) NULL,
    [prepaySum]       MONEY           NULL,
    [prepaySumAuthor] MONEY           NULL,
    [r030]            CHAR (3)        NULL,
    [prepayDateDo]    DATE            NULL,
    [prepayRest]      MONEY           NULL,
    [prepayUsed]      MONEY           NULL,
    CONSTRAINT [PK_LICAUTHORBR] PRIMARY KEY CLUSTERED ([cRightId] ASC),
    CONSTRAINT [FK_LICAUTHO_REFERENCE_COPYRIGH] FOREIGN KEY ([cRightId]) REFERENCES [dbo].[CopyRight] ([cRightId]) ON DELETE CASCADE,
    CONSTRAINT [FK_LICAUTHO_REFERENCE_PREPAYTY] FOREIGN KEY ([prepayType]) REFERENCES [dbo].[PrePayType] ([codeI])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Авторы лицензии для Больших прав
   Это для ввода заявки и довыдки. После согласования довидки авторы вносятся в Copyright. ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'LicAuthorBR';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор в таблице правообладания авторским правом', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'LicAuthorBR', @level2type = N'COLUMN', @level2name = N'cRightId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Дата включення Автора в Заявку', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'LicAuthorBR', @level2type = N'COLUMN', @level2name = N'dateCreate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Дата виключення Автора із Заявки', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'LicAuthorBR', @level2type = N'COLUMN', @level2name = N'dateClose';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Дата акцепта. ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'LicAuthorBR', @level2type = N'COLUMN', @level2name = N'dateAccept';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'процент володіння', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'LicAuthorBR', @level2type = N'COLUMN', @level2name = N'rate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'сумма аванса', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'LicAuthorBR', @level2type = N'COLUMN', @level2name = N'prepaySum';

