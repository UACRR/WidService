CREATE TABLE [dbo].[PositionType] (
    [codeI] INT           NOT NULL,
    [name]  VARCHAR (200) NULL,
    CONSTRAINT [PK_POSITIONTYPE] PRIMARY KEY CLUSTERED ([codeI] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Должности работников', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'PositionType';

