CREATE TABLE [dbo].[AnketaAddParam] (
    [paramCode]  INT           NOT NULL,
    [langCode]   VARCHAR (3)   NOT NULL,
    [paramName]  VARCHAR (25)  NOT NULL,
    [custId]     INT           NULL,
    [paramValue] VARCHAR (500) NULL,
    CONSTRAINT [PK_ANKETAADDPARAM] PRIMARY KEY CLUSTERED ([paramCode] ASC, [langCode] ASC),
    CONSTRAINT [FK_ANKETAAD_REFERENCE_CUSTOMER] FOREIGN KEY ([custId]) REFERENCES [dbo].[Customer] ([custId])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Дополнительные параметры для анкеты. 
   Сделали прежде всего для для нашей анкеты', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AnketaAddParam';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Цифровой код параметра. Не д.б. идентити!', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AnketaAddParam', @level2type = N'COLUMN', @level2name = N'paramCode';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Язык -Uk/Ru/En', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AnketaAddParam', @level2type = N'COLUMN', @level2name = N'langCode';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Название параметра', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AnketaAddParam', @level2type = N'COLUMN', @level2name = N'paramName';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор клиента (правообладателя или покупателя)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AnketaAddParam', @level2type = N'COLUMN', @level2name = N'custId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Значение параметра', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AnketaAddParam', @level2type = N'COLUMN', @level2name = N'paramValue';

