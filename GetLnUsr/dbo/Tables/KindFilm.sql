CREATE TABLE [dbo].[KindFilm] (
    [codeI] INT           NOT NULL,
    [name]  VARCHAR (100) NULL,
    CONSTRAINT [PK_KINDFILM] PRIMARY KEY CLUSTERED ([codeI] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Вид кинофильма', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KindFilm';

