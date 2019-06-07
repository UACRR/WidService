CREATE TABLE [dbo].[Employee] (
    [emplid]      INT            IDENTITY (1, 1) NOT NULL,
    [custId]      INT            NULL,
    [userId]      NVARCHAR (48)  NULL,
    [firstName]   VARCHAR (254)  NULL,
    [surName]     VARCHAR (254)  NULL,
    [lastName]    VARCHAR (254)  NULL,
    [phoneNumber] VARCHAR (254)  NULL,
    [email]       VARCHAR (254)  NULL,
    [comment]     VARCHAR (1024) NULL,
    CONSTRAINT [PK_EMPLOYEE] PRIMARY KEY CLUSTERED ([emplid] ASC),
    CONSTRAINT [FK_EMPLOYEE_REFERENCE_ASPNETUS] FOREIGN KEY ([userId]) REFERENCES [dbo].[AspNetUsers] ([id]),
    CONSTRAINT [FK_EMPLOYEE_REFERENCE_CUSTOMER] FOREIGN KEY ([custId]) REFERENCES [dbo].[Customer] ([custId])
);






GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'EMail', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Employee', @level2type = N'COLUMN', @level2name = N'email';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Номер телефона сотрудника', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Employee', @level2type = N'COLUMN', @level2name = N'phoneNumber';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = ' Фомилия сотрудника', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Employee', @level2type = N'COLUMN', @level2name = N'lastName';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Отчество', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Employee', @level2type = N'COLUMN', @level2name = N'surName';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Имя сотрудника', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Employee', @level2type = N'COLUMN', @level2name = N'firstName';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор клиента (правообладателя или покупателя)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Employee', @level2type = N'COLUMN', @level2name = N'custId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'ИД сотрудника', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Employee', @level2type = N'COLUMN', @level2name = N'emplid';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Сотрудники компаний клиентов покупателей', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Employee';


GO
CREATE UNIQUE NONCLUSTERED INDEX [UI_Employee_Email]
    ON [dbo].[Employee]([email] ASC) WHERE ([email] IS NOT NULL);

