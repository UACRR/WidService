CREATE TABLE [dbo].[relGenreRole] (
    [roleCode]  INT            NOT NULL,
    [genreType] INT            NOT NULL,
    [rate]      DECIMAL (5, 2) NULL,
    [actCode]   INT            NOT NULL,
    CONSTRAINT [PK_RELGENREROLE] PRIMARY KEY CLUSTERED ([roleCode] ASC, [genreType] ASC, [actCode] ASC),
    CONSTRAINT [FK_RELGENRE_REFERENCE_CREATIVE] FOREIGN KEY ([roleCode]) REFERENCES [dbo].[CreativeRoleType] ([codeI]),
    CONSTRAINT [FK_RELGENRE_REFERENCE_GENRETYP] FOREIGN KEY ([genreType]) REFERENCES [dbo].[GenreType] ([codeI])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'код типа объекта права', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'relGenreRole', @level2type = N'COLUMN', @level2name = N'genreType';

