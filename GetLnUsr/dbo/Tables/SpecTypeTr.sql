CREATE TABLE [dbo].[SpecTypeTr] (
    [codeI] INT           NOT NULL,
    [lang]  CHAR (2)      NOT NULL,
    [name]  VARCHAR (100) NULL,
    CONSTRAINT [PK_SPECTYPETR] PRIMARY KEY CLUSTERED ([codeI] ASC, [lang] ASC),
    CONSTRAINT [FK_SPECTYPE_REFERENCE_SPECTYPE] FOREIGN KEY ([codeI]) REFERENCES [dbo].[SpecType] ([codeI])
);

