CREATE TABLE [dbo].[LicenseBigR] (
    [licId]          INT             NOT NULL,
    [datePremiere]   DATE            NULL,
    [objId]          INT             NULL,
    [fillingRate]    NUMERIC (10, 5) NULL,
    [performNumb]    INT             NULL,
    [ticketPriceNC]  MONEY           NULL,
    [ticketPriceUSD] MONEY           NULL,
    [isTour]         BIT             NULL,
    [whereTour]      VARCHAR (512)   NULL,
    [rate]           DECIMAL (5, 2)  NULL,
    [prepayRest]     MONEY           NULL,
    [langCode]       CHAR (2)        NULL,
    [performType]    INT             NULL,
    [licTerm]        SMALLINT        NULL,
    [rateMusic]      DECIMAL (5, 2)  NULL,
    CONSTRAINT [PK_LICENSEBIGR] PRIMARY KEY CLUSTERED ([licId] ASC),
    CONSTRAINT [FK_LICENSEB_REFERENCE_LANGUAGE] FOREIGN KEY ([langCode]) REFERENCES [dbo].[Language] ([codeS]),
    CONSTRAINT [FK_LICENSEB_REFERENCE_LICENSEA] FOREIGN KEY ([licId]) REFERENCES [dbo].[LicenseAgreement] ([licId]),
    CONSTRAINT [FK_LICENSEB_REFERENCE_OBJECTRI] FOREIGN KEY ([objId]) REFERENCES [dbo].[ObjectRight] ([objId]),
    CONSTRAINT [FK_LICENSEB_REFERENCE_PERFORMT] FOREIGN KEY ([performType]) REFERENCES [dbo].[PerformType] ([codeI])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = '% за исполнение спектакля в договор', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'LicenseBigR', @level2type = N'COLUMN', @level2name = N'rate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Де плануються гастролі (текст)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'LicenseBigR', @level2type = N'COLUMN', @level2name = N'whereTour';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Гастролі (так, ні)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'LicenseBigR', @level2type = N'COLUMN', @level2name = N'isTour';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Середня вартість квитка у дол США', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'LicenseBigR', @level2type = N'COLUMN', @level2name = N'ticketPriceUSD';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Середня вартість квитка у гривні', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'LicenseBigR', @level2type = N'COLUMN', @level2name = N'ticketPriceNC';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Приблизна кількість постановок на місяць', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'LicenseBigR', @level2type = N'COLUMN', @level2name = N'performNumb';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Заповнюваність залу у %', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'LicenseBigR', @level2type = N'COLUMN', @level2name = N'fillingRate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Лицензия для театров
   Это все для Заявки', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'LicenseBigR';

