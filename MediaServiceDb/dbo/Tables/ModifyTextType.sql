CREATE TABLE [dbo].[ModifyTextType] (
    [codeI]        INT           NOT NULL,
    [name]         VARCHAR (100) NULL,
    [kindCompCode] INT           NULL,
    [categoryCode] INT           NOT NULL,
    CONSTRAINT [PK_MODIFYTEXTTYPE] PRIMARY KEY CLUSTERED ([codeI] ASC),
    CONSTRAINT [FK_MODIFYTE_REFERENCE_CATEGORY] FOREIGN KEY ([categoryCode]) REFERENCES [dbo].[Category] ([codeI]),
    CONSTRAINT [FK_MODIFYTE_REFERENCE_KINDCOMP] FOREIGN KEY ([kindCompCode]) REFERENCES [dbo].[KindComposition] ([codeI])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Тип изменения текста (синхронный перевод,  отклонение от содержания, полное изменение текста, отказ от текста (инструментальная версия))
   
   
    ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ModifyTextType';

