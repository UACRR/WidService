CREATE TABLE [dbo].[ReqLocationUse] (
    [locUsId]       INT      IDENTITY (1, 1) NOT NULL,
    [reqId]         INT      NULL,
    [countryCode]   CHAR (3) NULL,
    [continentCode] INT      NULL,
    CONSTRAINT [PK_REQLOCATIONUSE] PRIMARY KEY CLUSTERED ([locUsId] ASC),
    CONSTRAINT [FK_REQLOCAT_REFERENCE_CONTINEN] FOREIGN KEY ([continentCode]) REFERENCES [dbo].[Continent] ([codeI]),
    CONSTRAINT [FK_REQLOCAT_REFERENCE_COUNTRY] FOREIGN KEY ([countryCode]) REFERENCES [dbo].[Country] ([countryCode]),
    CONSTRAINT [FK_REQLOCAT_REFERENCE_REQUEST] FOREIGN KEY ([reqId]) REFERENCES [dbo].[Request] ([reqId])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Код континента/части света', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ReqLocationUse', @level2type = N'COLUMN', @level2name = N'continentCode';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Код страны (K040)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ReqLocationUse', @level2type = N'COLUMN', @level2name = N'countryCode';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор заявки', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ReqLocationUse', @level2type = N'COLUMN', @level2name = N'reqId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Территория, где будет использоваться объект права
   ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ReqLocationUse';

