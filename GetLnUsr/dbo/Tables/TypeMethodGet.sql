CREATE TABLE [dbo].[TypeMethodGet] (
    [codeI] INT           NOT NULL,
    [name]  VARCHAR (100) NULL,
    CONSTRAINT [PK_TYPEMETHODGET] PRIMARY KEY CLUSTERED ([codeI] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Метод получения роялти', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'TypeMethodGet';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Код методу отримання  авторської винагороди', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'TypeMethodGet', @level2type = N'COLUMN', @level2name = N'codeI';

