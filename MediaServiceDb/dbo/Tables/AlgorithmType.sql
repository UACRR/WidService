CREATE TABLE [dbo].[AlgorithmType] (
    [codeI] INT           NOT NULL,
    [name]  VARCHAR (100) NOT NULL,
    CONSTRAINT [PK_ALGORITHMTYPE] PRIMARY KEY CLUSTERED ([codeI] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Код роли пользователя', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AlgorithmType', @level2type = N'COLUMN', @level2name = N'codeI';

