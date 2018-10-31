CREATE TABLE [dbo].[SeekObject] (
    [id]    INT           IDENTITY (1, 1) NOT NULL,
    [codeI] INT           NULL,
    [objId] INT           NULL,
    [name]  VARCHAR (200) NULL,
    CONSTRAINT [PK_SEEKOBJECT] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_SEEKOBJE_REFERENCE_OBJECTRI] FOREIGN KEY ([objId]) REFERENCES [dbo].[ObjectRight] ([objId]),
    CONSTRAINT [FK_SEEKOBJE_REFERENCE_SEEKTYPE] FOREIGN KEY ([codeI]) REFERENCES [dbo].[SeekType] ([codeI])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор объекта права', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SeekObject', @level2type = N'COLUMN', @level2name = N'objId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'данные для поиска объекта', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SeekObject';

