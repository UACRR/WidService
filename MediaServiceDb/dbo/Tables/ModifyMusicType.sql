CREATE TABLE [dbo].[ModifyMusicType] (
    [codeI]        INT           NOT NULL,
    [name]         VARCHAR (100) NULL,
    [kindCompCode] INT           NULL,
    [categoryCode] INT           NOT NULL,
    CONSTRAINT [PK_MODIFYMUSICTYPE] PRIMARY KEY CLUSTERED ([codeI] ASC),
    CONSTRAINT [FK_MODIFYMU_REFERENCE_CATEGORY] FOREIGN KEY ([categoryCode]) REFERENCES [dbo].[Category] ([codeI]),
    CONSTRAINT [FK_MODIFYMU_REFERENCE_KINDCOMP] FOREIGN KEY ([kindCompCode]) REFERENCES [dbo].[KindComposition] ([codeI])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Тип изменения музыки	(без изменений, изменение стиля (аранжировка), отказ от музыки (только текст), другое)
   
    ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ModifyMusicType';

