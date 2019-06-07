CREATE TABLE [dbo].[Currency] (
    [r030]        CHAR (3)      NOT NULL,
    [a3]          CHAR (3)      NULL,
    [countryCode] CHAR (3)      NULL,
    [r030NameEn]  VARCHAR (100) NULL,
    [r030NameRu]  VARCHAR (100) NULL,
    [r030NameUk]  VARCHAR (100) NULL,
    [nOMIN]       INT           NULL,
    [nAIM]        VARCHAR (100) NULL,
    [prWork]      SMALLINT      NULL,
    [prNC]        SMALLINT      NULL,
    [orderBy]     INT           NULL,
    CONSTRAINT [PK_CURRENCY] PRIMARY KEY CLUSTERED ([r030] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'наименование валюты с маленькой буквы', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Currency', @level2type = N'COLUMN', @level2name = N'nAIM';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'коеффициент номинала', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Currency', @level2type = N'COLUMN', @level2name = N'nOMIN';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Название с большой буквы', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Currency', @level2type = N'COLUMN', @level2name = N'r030NameUk';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Название с большой буквы', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Currency', @level2type = N'COLUMN', @level2name = N'r030NameRu';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Название с большой буквы', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Currency', @level2type = N'COLUMN', @level2name = N'r030NameEn';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Код страны (K040)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Currency', @level2type = N'COLUMN', @level2name = N'countryCode';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Буквенное обозначение валюты', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Currency', @level2type = N'COLUMN', @level2name = N'a3';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Код валюты', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Currency', @level2type = N'COLUMN', @level2name = N'r030';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Подмножество валют, с которыми работаем
   ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Currency';

