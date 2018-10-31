CREATE TABLE [dbo].[RequestInternet] (
    [reqId]              INT           NOT NULL,
    [typeInternetObject] INT           NULL,
    [url]                VARCHAR (254) NULL,
    [useDesc]            VARCHAR (254) NULL,
    CONSTRAINT [PK_REQUESTINTERNET] PRIMARY KEY CLUSTERED ([reqId] ASC),
    CONSTRAINT [FK_REQUESTI_REF_INTERNREQUEST] FOREIGN KEY ([reqId]) REFERENCES [dbo].[Request] ([reqId]),
    CONSTRAINT [FK_REQUESTI_REFERENCE_TYPEINTE] FOREIGN KEY ([typeInternetObject]) REFERENCES [dbo].[TypeInternetObject] ([codeI])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Описание использования ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RequestInternet', @level2type = N'COLUMN', @level2name = N'useDesc';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Адрес Интернет-объекта ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RequestInternet', @level2type = N'COLUMN', @level2name = N'url';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Тип Интернет-объекта ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RequestInternet', @level2type = N'COLUMN', @level2name = N'typeInternetObject';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор заявки', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RequestInternet', @level2type = N'COLUMN', @level2name = N'reqId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Информция для заявки на синхронизаяцию для интернета', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RequestInternet';

