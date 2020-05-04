CREATE TABLE [dbo].[DistribType] (
    [codeI] INT           NOT NULL,
    [name]  VARCHAR (100) NULL,
    CONSTRAINT [PK_COURTTYPE] PRIMARY KEY CLUSTERED ([codeI] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Тип судебного распределения', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DistribType';

