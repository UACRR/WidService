CREATE TABLE [dbo].[ObjectRight] (
    [categoryCode] INT           NOT NULL,
    [objId]        INT           IDENTITY (1, 1) NOT NULL,
    [reqId]        INT           NULL,
    [genreType]    INT           NULL,
    [name]         VARCHAR (254) NULL,
    [author]       VARCHAR (254) NULL,
    [performer]    VARCHAR (254) NULL,
    [status]       INT           NULL,
    [modifyDate]   DATETIME      NULL,
    [modifyLogin]  VARCHAR (48)  NULL,
    [createDate]   DATETIME      NULL,
    [ObjImg]       VARCHAR (256) NULL,
    [loadid]       INT           NULL,
    [specType]     INT           NULL,
    [actCode]      INT           NULL,
    [innerCode]    VARCHAR (100) NULL,
    CONSTRAINT [PK_OBJECTRIGHT] PRIMARY KEY CLUSTERED ([objId] ASC),
    CONSTRAINT [FK_OBJECTRI_REFERENCE_CATEGORY] FOREIGN KEY ([categoryCode]) REFERENCES [dbo].[Category] ([codeI]),
    CONSTRAINT [FK_OBJECTRI_REFERENCE_OBJACT] FOREIGN KEY ([actCode]) REFERENCES [dbo].[ObjAct] ([codeI]),
    CONSTRAINT [FK_OBJECTRI_REFERENCE_OBJECTST] FOREIGN KEY ([status]) REFERENCES [dbo].[ObjectStatus] ([codeI]),
    CONSTRAINT [FK_OBJECTRI_REFERENCE_SPECTYPE] FOREIGN KEY ([specType]) REFERENCES [dbo].[SpecType] ([codeI])
);


GO
CREATE NONCLUSTERED INDEX [idx_name]
    ON [dbo].[ObjectRight]([name] ASC, [author] ASC, [performer] ASC);


GO
CREATE NONCLUSTERED INDEX [Relationship_13_FK]
    ON [dbo].[ObjectRight]([reqId] ASC);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Статус объекта права', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ObjectRight', @level2type = N'COLUMN', @level2name = N'status';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Исполнители объекта права', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ObjectRight', @level2type = N'COLUMN', @level2name = N'performer';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Авторы объекта права', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ObjectRight', @level2type = N'COLUMN', @level2name = N'author';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Наименование объекта права', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ObjectRight', @level2type = N'COLUMN', @level2name = N'name';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'код типа объекта права', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ObjectRight', @level2type = N'COLUMN', @level2name = N'genreType';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор заявки на адаптацию, согласно которой получился новый объект права', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ObjectRight', @level2type = N'COLUMN', @level2name = N'reqId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор объекта права', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ObjectRight', @level2type = N'COLUMN', @level2name = N'objId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Код категории объекта автоского права', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ObjectRight', @level2type = N'COLUMN', @level2name = N'categoryCode';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Объект права', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ObjectRight';

