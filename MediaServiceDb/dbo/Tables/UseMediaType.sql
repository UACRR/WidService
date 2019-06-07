CREATE TABLE [dbo].[UseMediaType] (
    [codeI]        INT           NOT NULL,
    [reqType]      INT           NOT NULL,
    [name]         VARCHAR (100) NULL,
    [categoryCode] INT           NOT NULL,
    CONSTRAINT [PK_USEMEDIATYPE] PRIMARY KEY CLUSTERED ([codeI] ASC),
    CONSTRAINT [FK_USEMEDIA_REFERENCE_CATEGORY] FOREIGN KEY ([categoryCode]) REFERENCES [dbo].[Category] ([codeI]),
    CONSTRAINT [FK_USEMEDIA_REFERENCE_REQUESTT] FOREIGN KEY ([reqType]) REFERENCES [dbo].[RequestType] ([codeI])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Код типа заявки', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'UseMediaType', @level2type = N'COLUMN', @level2name = N'reqType';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Использование композиции - Медиа ресурсы (ДЛЯ ВСЕХ, Телевидение, Радио, Интернет, )Другое (с возможностью ввести значение комментарий)
   ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'UseMediaType';

