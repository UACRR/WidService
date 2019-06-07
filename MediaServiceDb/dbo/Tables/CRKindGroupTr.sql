CREATE TABLE [dbo].[CRKindGroupTr] (
    [codeI] INT           NOT NULL,
    [lang]  CHAR (2)      NOT NULL,
    [name]  VARCHAR (100) NULL,
    CONSTRAINT [PK_CRKINDGROUPTR] PRIMARY KEY CLUSTERED ([codeI] ASC, [lang] ASC),
    CONSTRAINT [FK_CRKINDGR_REFERENCE_CRKINDGR] FOREIGN KEY ([codeI]) REFERENCES [dbo].[CRKindGroup] ([codeI])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Группы видов прав для красивого ввода', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CRKindGroupTr';

