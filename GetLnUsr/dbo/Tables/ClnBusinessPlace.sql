CREATE TABLE [dbo].[ClnBusinessPlace] (
    [placeId]      INT           IDENTITY (1, 1) NOT NULL,
    [custId]       INT           NULL,
    [plCode]       INT           NULL,
    [placeName]    VARCHAR (100) NULL,
    [placeCountry] CHAR (3)      NULL,
    [placeRegion]  INT           NULL,
    [placeCity]    VARCHAR (100) NULL,
    [placeAddress] VARCHAR (256) NULL,
    [placePhone]   VARCHAR (25)  NULL,
    [freeEntry]    BIT           NULL,
    CONSTRAINT [PK_CLNBUSINESSPLACE] PRIMARY KEY CLUSTERED ([placeId] ASC),
    CONSTRAINT [FK_CLNBUSIN_REFERENCE_CLIENT] FOREIGN KEY ([custId]) REFERENCES [dbo].[Client] ([custId]),
    CONSTRAINT [FK_CLNBUSIN_REFERENCE_TYPEPLAC] FOREIGN KEY ([plCode]) REFERENCES [dbo].[TypePlace] ([codeI])
);


GO
CREATE NONCLUSTERED INDEX [iClnBusinessPlace_plName]
    ON [dbo].[ClnBusinessPlace]([placeName] ASC);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Майданчики Клиента
   ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ClnBusinessPlace';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор клиента (правообладателя или покупателя)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ClnBusinessPlace', @level2type = N'COLUMN', @level2name = N'custId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Фактический адрес - город', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ClnBusinessPlace', @level2type = N'COLUMN', @level2name = N'placeRegion';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Фактический адрес - город', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ClnBusinessPlace', @level2type = N'COLUMN', @level2name = N'placeCity';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Бесплдатыій вход', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ClnBusinessPlace', @level2type = N'COLUMN', @level2name = N'freeEntry';

