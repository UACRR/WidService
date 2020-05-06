CREATE TABLE [dbo].[RelGenrePercent] (
    [actCode]   INT            NOT NULL,
    [genreType] INT            NOT NULL,
    [rate]      DECIMAL (5, 2) NULL,
    CONSTRAINT [PK_RELGENREPERCENT] PRIMARY KEY CLUSTERED ([actCode] ASC, [genreType] ASC),
    CONSTRAINT [FK_RELGENRE_REFERENCE_OBJACT] FOREIGN KEY ([actCode]) REFERENCES [dbo].[ObjAct] ([codeI]),
    CONSTRAINT [FK_RELGPerc_REFERENCE_GENRETYP] FOREIGN KEY ([genreType]) REFERENCES [dbo].[GenreType] ([codeI])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Проценті по жанрам в зависимости от актов по 72-й постанове', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RelGenrePercent';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'код типа объекта права', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RelGenrePercent', @level2type = N'COLUMN', @level2name = N'genreType';

