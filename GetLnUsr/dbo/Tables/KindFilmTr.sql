CREATE TABLE [dbo].[KindFilmTr] (
    [codeI] INT           NOT NULL,
    [lang]  CHAR (2)      NOT NULL,
    [name]  VARCHAR (200) NULL,
    CONSTRAINT [PK_KINDFILMTR] PRIMARY KEY CLUSTERED ([codeI] ASC, [lang] ASC),
    CONSTRAINT [FK_KINDFILM_REFERENCE_KINDFILM] FOREIGN KEY ([codeI]) REFERENCES [dbo].[KindFilm] ([codeI])
);

