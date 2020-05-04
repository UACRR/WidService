CREATE TABLE [dbo].[RelObjPerformer] (
    [objId] INT NOT NULL,
    [perId] INT NOT NULL,
    CONSTRAINT [PK_RELOBJPERFOMER] PRIMARY KEY CLUSTERED ([objId] ASC, [perId] ASC),
    CONSTRAINT [FK_RELOBJPE_REFERENCE_OBJECTRI] FOREIGN KEY ([objId]) REFERENCES [dbo].[ObjectRight] ([objId]),
    CONSTRAINT [FK_RELOBJPE_REFERENCE_PERFOMER] FOREIGN KEY ([perId]) REFERENCES [dbo].[Performer] ([perId])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор объекта права', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RelObjPerformer', @level2type = N'COLUMN', @level2name = N'objId';

