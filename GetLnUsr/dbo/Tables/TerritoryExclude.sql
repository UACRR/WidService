CREATE TABLE [dbo].[TerritoryExclude] (
    [custId]      INT      NOT NULL,
    [countryCode] CHAR (3) NOT NULL,
    CONSTRAINT [PK_TERRITORYEXCLUDE] PRIMARY KEY CLUSTERED ([custId] ASC, [countryCode] ASC),
    CONSTRAINT [FK_TERRITOR_REFERENCE_COUNTRY] FOREIGN KEY ([countryCode]) REFERENCES [dbo].[Country] ([countryCode]),
    CONSTRAINT [FK_TERRITOR_REFERENCE_RIGHTHOL] FOREIGN KEY ([custId]) REFERENCES [dbo].[RightHolder] ([custId])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Територия обслуживания', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'TerritoryExclude';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор клиента (правообладателя или покупателя)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'TerritoryExclude', @level2type = N'COLUMN', @level2name = N'custId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Код страны (K040)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'TerritoryExclude', @level2type = N'COLUMN', @level2name = N'countryCode';

