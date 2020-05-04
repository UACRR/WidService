CREATE TABLE [dbo].[PopGenre] (
    [categoryCode] INT           NOT NULL,
    [name]         VARCHAR (100) NULL,
    [id]           INT           IDENTITY (1, 1) NOT NULL,
    CONSTRAINT [PK_GENRE] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_GENRE_REFERENCE_CATEGORY] FOREIGN KEY ([categoryCode]) REFERENCES [dbo].[Category] ([codeI])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Жанр произведения', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'PopGenre';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Код категории объекта автоского права', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'PopGenre', @level2type = N'COLUMN', @level2name = N'categoryCode';

