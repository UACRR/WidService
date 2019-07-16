CREATE TABLE [dbo].[AnketaExternal] (
    [custId]      INT           NOT NULL,
    [name]        VARCHAR (200) NOT NULL,
    [countryCode] CHAR (3)      NULL,
    [innOkpo]     VARCHAR (12)  NULL,
    CONSTRAINT [PK_ANKETAEXTERNAL] PRIMARY KEY CLUSTERED ([custId] ASC),
    CONSTRAINT [FK_ANKETAEX_REFERENCE_COUNTRY] FOREIGN KEY ([countryCode]) REFERENCES [dbo].[Country] ([countryCode]),
    CONSTRAINT [FK_ANKETAEX_REFERENCE_CUSTOMER] FOREIGN KEY ([custId]) REFERENCES [dbo].[Customer] ([custId])
);




GO



GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор клиента (правообладателя или покупателя)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AnketaExternal', @level2type = N'COLUMN', @level2name = N'custId';

