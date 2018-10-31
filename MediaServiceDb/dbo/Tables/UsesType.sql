CREATE TABLE [dbo].[UsesType] (
    [codeI] INT           NOT NULL,
    [name]  VARCHAR (100) NOT NULL,
    CONSTRAINT [PK_USESTYPE] PRIMARY KEY CLUSTERED ([codeI] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Види споживання творів', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'UsesType';

