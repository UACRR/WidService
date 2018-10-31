CREATE TABLE [dbo].[UseAreaType] (
    [codeI]        INT           NOT NULL,
    [categoryCode] INT           NOT NULL,
    [reqType]      INT           NOT NULL,
    [name]         VARCHAR (100) NULL,
    CONSTRAINT [PK_USEAREATYPE] PRIMARY KEY CLUSTERED ([codeI] ASC),
    CONSTRAINT [FK_USEAREAT_REFERENCE_CATEGORY] FOREIGN KEY ([categoryCode]) REFERENCES [dbo].[Category] ([codeI]),
    CONSTRAINT [FK_USEAREAT_REFERENCE_REQUESTT] FOREIGN KEY ([reqType]) REFERENCES [dbo].[RequestType] ([codeI])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Код типа заявки', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'UseAreaType', @level2type = N'COLUMN', @level2name = N'reqType';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Код категории объекта автоского права', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'UseAreaType', @level2type = N'COLUMN', @level2name = N'categoryCode';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Область применения:  Публичное исполнение, Включение Композиции в состав Клипа, Создание фонограммы, Механическое воспроизведение в составе альбома, Осуществление синхронизации произведения в части смежных прав, Иное использование (с возможностью ввести значение комментарий))
   ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'UseAreaType';

