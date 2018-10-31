CREATE TABLE [dbo].[ModifyType] (
    [codeI]        INT           NOT NULL,
    [name]         VARCHAR (100) NULL,
    [kindCompCode] INT           NULL,
    [categoryCode] INT           NOT NULL,
    CONSTRAINT [PK_MODIFYTYPE] PRIMARY KEY CLUSTERED ([codeI] ASC),
    CONSTRAINT [FK_MODIFYTY_REFERENCE_CATEGORY] FOREIGN KEY ([categoryCode]) REFERENCES [dbo].[Category] ([codeI]),
    CONSTRAINT [FK_MODIFYTY_REFERENCE_KINDCOMP] FOREIGN KEY ([kindCompCode]) REFERENCES [dbo].[KindComposition] ([codeI])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Тип изменений (текст, музыка, текст и музыка)
   
    ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ModifyType';

