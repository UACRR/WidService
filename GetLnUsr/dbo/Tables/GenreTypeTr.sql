CREATE TABLE [dbo].[GenreTypeTr] (
    [codeI] INT           NOT NULL,
    [lang]  CHAR (2)      NOT NULL,
    [name]  VARCHAR (200) NULL,
    CONSTRAINT [PK_GENRETYPETR] PRIMARY KEY CLUSTERED ([codeI] ASC, [lang] ASC),
    CONSTRAINT [FK_GENRETYP_REFERENCE_GENRETYP] FOREIGN KEY ([codeI]) REFERENCES [dbo].[GenreType] ([codeI])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Справочник типов объектов права( например, песня, инструм. пьеса, спектакль, постановка, стихотворениие, танец, другое и т.д.)
   
   Для Проекта ВАКАРЧУК не исп-ся', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'GenreTypeTr';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'код типа объекта права', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'GenreTypeTr', @level2type = N'COLUMN', @level2name = N'codeI';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Название тапа объекта права', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'GenreTypeTr', @level2type = N'COLUMN', @level2name = N'name';

