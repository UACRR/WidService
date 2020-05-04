CREATE TABLE [dbo].[TradeStatus] (
    [statusCode]   INT           NOT NULL,
    [statusNameUk] VARCHAR (100) NULL,
    [statusNameRu] VARCHAR (100) NULL,
    [statusNameEn] VARCHAR (100) NULL,
    CONSTRAINT [PK_TRADESTATUS] PRIMARY KEY CLUSTERED ([statusCode] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Статусы торговой записи', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'TradeStatus';

