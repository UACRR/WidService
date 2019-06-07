CREATE TABLE [dbo].[UserRoleType] (
    [codeI]      INT           NOT NULL,
    [isAdmin]    INT           NOT NULL,
    [typeNameRu] VARCHAR (250) NULL,
    [typeNameEn] VARCHAR (250) NULL,
    [name]       VARCHAR (250) NULL,
    CONSTRAINT [PK_USERROLETYPE] PRIMARY KEY CLUSTERED ([codeI] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Признак администратора', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'UserRoleType', @level2type = N'COLUMN', @level2name = N'isAdmin';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Код роли пользователя', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'UserRoleType', @level2type = N'COLUMN', @level2name = N'codeI';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Справочник типов ролей пользователя', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'UserRoleType';

