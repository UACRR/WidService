CREATE TABLE [dbo].[DistribStatus] (
    [codeI] INT           NOT NULL,
    [name]  VARCHAR (100) NOT NULL,
    CONSTRAINT [PK_DISTRIBSTATUS] PRIMARY KEY CLUSTERED ([codeI] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Код категории объекта автоского права', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DistribStatus', @level2type = N'COLUMN', @level2name = N'codeI';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Наименование Типа авторского права', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DistribStatus', @level2type = N'COLUMN', @level2name = N'name';

