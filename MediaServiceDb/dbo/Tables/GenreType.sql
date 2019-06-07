CREATE TABLE [dbo].[GenreType] (
    [codeI]        INT           NOT NULL,
    [categoryCode] INT           NOT NULL,
    [name]         VARCHAR (200) NULL,
    CONSTRAINT [PK_OBJECTTYPE] PRIMARY KEY CLUSTERED ([codeI] ASC),
    CONSTRAINT [FK_OBJECTTY_REFERENCE_CATEGORY] FOREIGN KEY ([categoryCode]) REFERENCES [dbo].[Category] ([codeI])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Название тапа объекта права', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'GenreType', @level2type = N'COLUMN', @level2name = N'name';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Код категории объекта автоского права', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'GenreType', @level2type = N'COLUMN', @level2name = N'categoryCode';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'код типа объекта права', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'GenreType', @level2type = N'COLUMN', @level2name = N'codeI';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Справочник типов объектов права( например, песня, инструм. пьеса, спектакль, постановка, стихотворениие, танец, другое и т.д.)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'GenreType';

