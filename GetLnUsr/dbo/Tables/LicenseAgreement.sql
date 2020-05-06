CREATE TABLE [dbo].[LicenseAgreement] (
    [licId]          INT IDENTITY (1, 1) NOT NULL,
    [licCode]        INT NOT NULL,
    [licType]        INT NULL,
    [custId]         INT NULL,
    [licStatus]      INT NULL,
    [licClass]       INT NOT NULL,
    [agrId]          INT NOT NULL,
    [licSize]        INT NULL,
    [licVersion]     INT NULL,
    [prolongVersion] INT NULL,
    CONSTRAINT [PK_LICENSEAGREEMENT] PRIMARY KEY CLUSTERED ([licId] ASC),
    CONSTRAINT [FK_LICENSEA_REF_AGREEMEN] FOREIGN KEY ([agrId]) REFERENCES [dbo].[AgreementMaster] ([agrId]),
    CONSTRAINT [FK_LICENSEA_REFERENCE_ARGLICEN] FOREIGN KEY ([licCode]) REFERENCES [dbo].[AgrLicenseType] ([codeI]),
    CONSTRAINT [FK_LICENSEA_REFERENCE_CLIENT] FOREIGN KEY ([custId]) REFERENCES [dbo].[Client] ([custId]),
    CONSTRAINT [FK_LICENSEA_REFERENCE_LICENSET] FOREIGN KEY ([licType]) REFERENCES [dbo].[LicenseType] ([codeI]),
    CONSTRAINT [FK_LICENSEA_REFERENCE_MASTER] FOREIGN KEY ([licStatus]) REFERENCES [dbo].[AgreementStatus] ([codeI])
);


GO
CREATE NONCLUSTERED INDEX [iLicenseAgreementCustid]
    ON [dbo].[LicenseAgreement]([custId] ASC);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Ліцензійний договір', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'LicenseAgreement';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Код ліцензії - трансляцію, сповіщення,...', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'LicenseAgreement', @level2type = N'COLUMN', @level2name = N'licCode';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Тип ліцензії - виключна/невиключна', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'LicenseAgreement', @level2type = N'COLUMN', @level2name = N'licType';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор клиента (правообладателя или покупателя)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'LicenseAgreement', @level2type = N'COLUMN', @level2name = N'custId';

