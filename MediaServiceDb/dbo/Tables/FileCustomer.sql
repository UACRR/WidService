CREATE TABLE [dbo].[FileCustomer] (
    [docId]       INT           IDENTITY (1, 1) NOT NULL,
    [custId]      INT           NOT NULL,
    [docType]     INT           NOT NULL,
    [createDate]  DATETIME      NULL,
    [docFile]     VARCHAR (255) NULL,
    [docComment]  VARCHAR (500) NULL,
    [mimeType]    VARCHAR (10)  NULL,
    [modifyDate]  DATETIME      NULL,
    [modifyLogin] VARCHAR (48)  NULL,
    CONSTRAINT [PK_FILECUSTOMER] PRIMARY KEY CLUSTERED ([docId] ASC),
    CONSTRAINT [FK_FILECUST_REFERENCE_CUSTOMER] FOREIGN KEY ([custId]) REFERENCES [dbo].[Customer] ([custId]),
    CONSTRAINT [FK_FILECUST_REFERENCE_TYPE] FOREIGN KEY ([docType]) REFERENCES [dbo].[FileType] ([codeI])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Пользователь, кто модифицировал запись', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'FileCustomer', @level2type = N'COLUMN', @level2name = N'modifyLogin';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Дата модификации записи', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'FileCustomer', @level2type = N'COLUMN', @level2name = N'modifyDate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Файл документа', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'FileCustomer', @level2type = N'COLUMN', @level2name = N'docFile';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Дата документа', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'FileCustomer', @level2type = N'COLUMN', @level2name = N'createDate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Код типа документа', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'FileCustomer', @level2type = N'COLUMN', @level2name = N'docType';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор клиента (правообладателя или покупателя)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'FileCustomer', @level2type = N'COLUMN', @level2name = N'custId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор документа', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'FileCustomer', @level2type = N'COLUMN', @level2name = N'docId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Документ заявки', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'FileCustomer';

