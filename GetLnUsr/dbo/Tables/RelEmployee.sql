CREATE TABLE [dbo].[RelEmployee] (
    [emplid]       INT           NOT NULL,
    [custId]       INT           NOT NULL,
    [positionCode] INT           NOT NULL,
    [relDocument]  VARCHAR (254) NULL,
    CONSTRAINT [PK_RELEMPLOYEE] PRIMARY KEY CLUSTERED ([custId] ASC, [emplid] ASC, [positionCode] ASC),
    CONSTRAINT [FK_RELEMPLO_ASSOCIATI_COMPANY] FOREIGN KEY ([custId]) REFERENCES [dbo].[Company] ([custId]),
    CONSTRAINT [FK_RELEMPLO_ASSOCIATI_EMPLOYEE] FOREIGN KEY ([emplid]) REFERENCES [dbo].[Employee] ([emplid]),
    CONSTRAINT [FK_RELEMPLO_REFERENCE_POSITION] FOREIGN KEY ([positionCode]) REFERENCES [dbo].[PositionType] ([codeI])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Таблица  связи сотрудников с компанией клиента', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RelEmployee';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'ИД сотрудника', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RelEmployee', @level2type = N'COLUMN', @level2name = N'emplid';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор клиента (правообладателя или покупателя)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RelEmployee', @level2type = N'COLUMN', @level2name = N'custId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Документ, на основании которого работает сотрудник', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RelEmployee', @level2type = N'COLUMN', @level2name = N'relDocument';

