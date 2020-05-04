CREATE TABLE [dbo].[Period] (
    [codeI] INT           NOT NULL,
    [name]  VARCHAR (100) NULL,
    [nameR] VARCHAR (100) NULL,
    CONSTRAINT [PK_PERIOD] PRIMARY KEY CLUSTERED ([codeI] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Періодичність сплати платежів', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Period';

