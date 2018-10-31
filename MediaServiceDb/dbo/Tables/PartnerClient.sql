CREATE TABLE [dbo].[PartnerClient] (
    [custId]   INT NOT NULL,
    [clCustId] INT NOT NULL,
    CONSTRAINT [PK_PARTNERCLIENT] PRIMARY KEY CLUSTERED ([custId] ASC, [clCustId] ASC),
    CONSTRAINT [FK_PARTNERC_REFERENCE_CLIENT] FOREIGN KEY ([clCustId]) REFERENCES [dbo].[Client] ([custId]),
    CONSTRAINT [FK_PARTNERC_REFERENCE_PARTNER] FOREIGN KEY ([custId]) REFERENCES [dbo].[Partner] ([custId])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор клиента (правообладателя или покупателя)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'PartnerClient', @level2type = N'COLUMN', @level2name = N'clCustId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор Партнера', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'PartnerClient', @level2type = N'COLUMN', @level2name = N'custId';

