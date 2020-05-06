CREATE TABLE [dbo].[userRole] (
    [custId]   INT           NOT NULL,
    [roleType] INT           NOT NULL,
    [userId]   NVARCHAR (48) NOT NULL,
    [status]   INT           NULL,
    CONSTRAINT [PK_USERROLE] PRIMARY KEY CLUSTERED ([custId] ASC, [roleType] ASC, [userId] ASC),
    CONSTRAINT [FK_USERROLE_REFERENCE_CUSTOMER] FOREIGN KEY ([custId]) REFERENCES [dbo].[Customer] ([custId]),
    CONSTRAINT [FK_USERROLE_REFERENCE_USERROLE] FOREIGN KEY ([roleType]) REFERENCES [dbo].[UserRoleType] ([codeI])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Правовые Роли пользователей', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'userRole';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор клиента (правообладателя или покупателя)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'userRole', @level2type = N'COLUMN', @level2name = N'custId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Тип роли пользователя', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'userRole', @level2type = N'COLUMN', @level2name = N'roleType';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Статус роли пользователя', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'userRole', @level2type = N'COLUMN', @level2name = N'status';

