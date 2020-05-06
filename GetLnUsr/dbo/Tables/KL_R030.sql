CREATE TABLE [dbo].[KL_R030] (
    [r030]        CHAR (3)      NOT NULL,
    [r031]        SMALLINT      NULL,
    [countryCode] CHAR (3)      NULL,
    [a3]          CHAR (3)      NULL,
    [r030Name]    VARCHAR (100) NULL,
    [nOMIN]       INT           NULL,
    [nAIM]        VARCHAR (100) NULL,
    [pr_work]     SMALLINT      NULL,
    CONSTRAINT [PK_KL_R030] PRIMARY KEY CLUSTERED ([r030] ASC),
    CONSTRAINT [FK_KL_R030_REFERENCE_COUNTRY] FOREIGN KEY ([countryCode]) REFERENCES [dbo].[Country] ([countryCode]),
    CONSTRAINT [FK_KL_R030_REFERENCE_KL_R031] FOREIGN KEY ([r031]) REFERENCES [dbo].[KL_R031] ([r031])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Справочник кодов валют', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KL_R030';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Код валюты', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KL_R030', @level2type = N'COLUMN', @level2name = N'r030';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Код типа валют', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KL_R030', @level2type = N'COLUMN', @level2name = N'r031';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Код страны (K040)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KL_R030', @level2type = N'COLUMN', @level2name = N'countryCode';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Буквенное обозначение валюты', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KL_R030', @level2type = N'COLUMN', @level2name = N'a3';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Название с большой буквы', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KL_R030', @level2type = N'COLUMN', @level2name = N'r030Name';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'коеффициент номинала', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KL_R030', @level2type = N'COLUMN', @level2name = N'nOMIN';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'наименование валюты с маленькой буквы', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KL_R030', @level2type = N'COLUMN', @level2name = N'nAIM';

