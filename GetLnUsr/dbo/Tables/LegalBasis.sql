CREATE TABLE [dbo].[LegalBasis] (
    [codeI] INT           NOT NULL,
    [name]  VARCHAR (254) NULL,
    CONSTRAINT [PK_LEGALBASIS] PRIMARY KEY CLUSTERED ([codeI] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Правовое основание владением авторским правом (автор, покупка, наследование)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'LegalBasis';

