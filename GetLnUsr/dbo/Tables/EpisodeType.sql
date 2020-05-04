CREATE TABLE [dbo].[EpisodeType] (
    [codeI] INT           NOT NULL,
    [name]  VARCHAR (100) NULL,
    CONSTRAINT [PK_EPISODETYPE] PRIMARY KEY CLUSTERED ([codeI] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Типы эпизодов (Титры начальные, Титры завершающие,  Кульминация/ Главная сцена фильма, ...)
   
   ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'EpisodeType';

