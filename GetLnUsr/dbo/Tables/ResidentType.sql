CREATE TABLE [dbo].[ResidentType] (
    [codeI] INT           NOT NULL,
    [name]  VARCHAR (100) NULL,
    CONSTRAINT [PK_RESIDENTTYPE] PRIMARY KEY CLUSTERED ([codeI] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Резиденство', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ResidentType';

