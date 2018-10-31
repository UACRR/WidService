CREATE TABLE [dbo].[AnketaAddName] (
    [custId]    INT           NOT NULL,
    [lang]      CHAR (2)      NOT NULL,
    [nikName]   VARCHAR (254) NULL,
    [firstName] VARCHAR (254) NULL,
    [surName]   VARCHAR (254) NULL,
    [lastName]  VARCHAR (254) NULL,
    [name]      VARCHAR (254) NULL,
    [shortName] VARCHAR (254) NULL,
    CONSTRAINT [PK_ANKETAADDNAME] PRIMARY KEY CLUSTERED ([custId] ASC, [lang] ASC),
    CONSTRAINT [FK_ANKETAADN_REFERENCE_CUSTOMER] FOREIGN KEY ([custId]) REFERENCES [dbo].[Customer] ([custId])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Название для компании', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AnketaAddName', @level2type = N'COLUMN', @level2name = N'name';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Фамилия', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AnketaAddName', @level2type = N'COLUMN', @level2name = N'lastName';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Отчество', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AnketaAddName', @level2type = N'COLUMN', @level2name = N'surName';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Имена на других языках', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AnketaAddName', @level2type = N'COLUMN', @level2name = N'firstName';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Псевдоним', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AnketaAddName', @level2type = N'COLUMN', @level2name = N'nikName';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Язык ФИО оригинал', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AnketaAddName', @level2type = N'COLUMN', @level2name = N'lang';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор клиента (правообладателя или покупателя)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AnketaAddName', @level2type = N'COLUMN', @level2name = N'custId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Дополнительные имена для Авторов', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AnketaAddName';

