CREATE TABLE [dbo].[KindComposition] (
    [codeI]        INT           NOT NULL,
    [name]         VARCHAR (100) NULL,
    [categoryCode] INT           NOT NULL,
    CONSTRAINT [PK_KINDCOMPOSITION] PRIMARY KEY CLUSTERED ([codeI] ASC),
    CONSTRAINT [FK_KINDCOMP_REFERENCE_CATEGORY] FOREIGN KEY ([categoryCode]) REFERENCES [dbo].[Category] ([codeI])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Вид использования композиции (Оригинальная композиция, Кавер-версия)
   
    ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KindComposition';

