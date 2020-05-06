CREATE TABLE [dbo].[Country] (
    [continentCode]    INT           NULL,
    [countryCode]      CHAR (3)      NOT NULL,
    [countryName]      VARCHAR (100) NULL,
    [a2]               CHAR (2)      NULL,
    [kOD_LIT]          CHAR (3)      NULL,
    [countryNameShort] VARCHAR (100) NULL,
    [shortChoise]      SMALLINT      NULL,
    [orderBy]          INT           NULL,
    CONSTRAINT [PK_COUNTRY] PRIMARY KEY CLUSTERED ([countryCode] ASC),
    CONSTRAINT [FK_COUNTRY_REFERENCE_CONTINEN] FOREIGN KEY ([continentCode]) REFERENCES [dbo].[Continent] ([codeI])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Справочник стран
   ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Country';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Код континента/части света', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Country', @level2type = N'COLUMN', @level2name = N'continentCode';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Код страны (K040)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Country', @level2type = N'COLUMN', @level2name = N'countryCode';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Название страны (TXT)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Country', @level2type = N'COLUMN', @level2name = N'countryName';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Код страны в 2-х символах (UK, UA,...)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Country', @level2type = N'COLUMN', @level2name = N'a2';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Код страны в 3-х символах (UKR)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Country', @level2type = N'COLUMN', @level2name = N'kOD_LIT';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Название страны краткое', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Country', @level2type = N'COLUMN', @level2name = N'countryNameShort';

