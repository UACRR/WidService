CREATE TABLE [dbo].[WorkRH] (
    [cRightId]       INT            NOT NULL,
    [workTypeRH]     INT            NULL,
    [workCommentRH]  VARCHAR (2048) NULL,
    [workDateRH]     DATE           NULL,
    [workTypeCl]     INT            NULL,
    [workDateCl]     DATE           NULL,
    [workCoommentCl] VARCHAR (2048) NULL,
    [modifyDate]     DATETIME       NULL,
    [modifyLogin]    VARCHAR (48)   NULL,
    CONSTRAINT [PK_WORKRH] PRIMARY KEY CLUSTERED ([cRightId] ASC),
    CONSTRAINT [FK_WORKCL_REFERENCE_WORKTYPE] FOREIGN KEY ([workTypeCl]) REFERENCES [dbo].[WorkType] ([codeI]),
    CONSTRAINT [FK_WORKRH_REFERENCE_COPYRIGH] FOREIGN KEY ([cRightId]) REFERENCES [dbo].[CopyRight] ([cRightId]) ON DELETE CASCADE,
    CONSTRAINT [FK_WORKRH_REFERENCE_WORKTYPE] FOREIGN KEY ([workTypeRH]) REFERENCES [dbo].[WorkType] ([codeI])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Пользователь, кто модифицировал запись', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'WorkRH', @level2type = N'COLUMN', @level2name = N'modifyLogin';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Дата время модификации записи (автомат)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'WorkRH', @level2type = N'COLUMN', @level2name = N'modifyDate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Тип роботи з автором', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'WorkRH', @level2type = N'COLUMN', @level2name = N'workTypeRH';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор в таблице правообладания авторским правом', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'WorkRH', @level2type = N'COLUMN', @level2name = N'cRightId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Работа с авторпми и клиентами
   Согласование условий
   Может использоваться кем угодно', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'WorkRH';

