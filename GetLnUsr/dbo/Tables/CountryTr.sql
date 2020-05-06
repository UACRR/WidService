CREATE TABLE [dbo].[CountryTr] (
    [countryCode]      CHAR (3)      NOT NULL,
    [lang]             CHAR (2)      NOT NULL,
    [countryName]      VARCHAR (100) NULL,
    [countryNameShort] VARCHAR (100) NULL,
    CONSTRAINT [PK_COUNTRYTR] PRIMARY KEY NONCLUSTERED ([countryCode] ASC, [lang] ASC),
    CONSTRAINT [FK_COUNTRYT_REFERENCE_COUNTRY] FOREIGN KEY ([countryCode]) REFERENCES [dbo].[Country] ([countryCode])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Справочник стран
   ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CountryTr';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Код страны (K040)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CountryTr', @level2type = N'COLUMN', @level2name = N'countryCode';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Название страны (TXT)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CountryTr', @level2type = N'COLUMN', @level2name = N'countryName';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Название страны краткое', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CountryTr', @level2type = N'COLUMN', @level2name = N'countryNameShort';

