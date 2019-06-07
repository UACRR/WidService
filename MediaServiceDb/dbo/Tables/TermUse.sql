CREATE TABLE [dbo].[TermUse] (
    [codeI] INT           NOT NULL,
    [name]  VARCHAR (100) NULL,
    CONSTRAINT [PK_TERMUSE] PRIMARY KEY CLUSTERED ([codeI] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Срок использования:  На весь срок охраны произведения, другие сроки использования (указывается «Срок использования» в месяцах, а также заполняются поля «С» и «По»)
   ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'TermUse';

