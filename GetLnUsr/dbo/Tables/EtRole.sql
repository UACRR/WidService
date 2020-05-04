CREATE TABLE [dbo].[EtRole] (
    [codeI]        INT           NOT NULL,
    [name]         VARCHAR (128) NULL,
    [categoryCode] INT           NULL,
    CONSTRAINT [PK_ETROLE] PRIMARY KEY CLUSTERED ([codeI] ASC),
    CONSTRAINT [FK_ETROLE_REFERENCE_CATEGORY] FOREIGN KEY ([categoryCode]) REFERENCES [dbo].[Category] ([codeI])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Єталонніе роли по 72-й постанове', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'EtRole';

