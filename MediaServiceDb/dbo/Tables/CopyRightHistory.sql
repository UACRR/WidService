CREATE TABLE [dbo].[CopyRightHistory] (
    [parentId] INT            NOT NULL,
    [childId]  INT            NOT NULL,
    [rate]     DECIMAL (5, 2) NULL,
    CONSTRAINT [PK_COPYRIGHTHISTORY] PRIMARY KEY CLUSTERED ([parentId] ASC, [childId] ASC),
    CONSTRAINT [FK_COPYRIGH_REF_COPYRIGHC] FOREIGN KEY ([childId]) REFERENCES [dbo].[CopyRight] ([cRightId]),
    CONSTRAINT [FK_COPYRIGH_REF_COPYRIGHP] FOREIGN KEY ([parentId]) REFERENCES [dbo].[CopyRight] ([cRightId])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = '% правообладания объектов права
   Нужно удалить в следующей версии портала - берется из MainCopyright', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CopyRightHistory', @level2type = N'COLUMN', @level2name = N'rate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор в таблице правообладания авторским правом', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CopyRightHistory', @level2type = N'COLUMN', @level2name = N'childId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор в таблице правообладания авторским правом', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CopyRightHistory', @level2type = N'COLUMN', @level2name = N'parentId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'История передачи прав', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CopyRightHistory';

