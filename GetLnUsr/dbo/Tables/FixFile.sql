CREATE TABLE [dbo].[FixFile] (
    [fixId]  INT            NOT NULL,
    [fileId] INT            IDENTITY (1, 1) NOT NULL,
    [name]   NVARCHAR (255) NOT NULL,
    [path]   NVARCHAR (255) NULL,
    CONSTRAINT [PK_FIXFILE] PRIMARY KEY CLUSTERED ([fileId] ASC, [fixId] ASC),
    CONSTRAINT [FK_FIXFILE_REF_FIXATION] FOREIGN KEY ([fixId]) REFERENCES [dbo].[Fixation] ([fixId])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Файл фіксації порушення права', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'FixFile';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Ідентифікатор подання', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'FixFile', @level2type = N'COLUMN', @level2name = N'fixId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Ідентифікатор файлу фіксації подання', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'FixFile', @level2type = N'COLUMN', @level2name = N'fileId';

