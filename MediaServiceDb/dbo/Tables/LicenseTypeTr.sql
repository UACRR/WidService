CREATE TABLE [dbo].[LicenseTypeTr] (
    [codeI] INT           NOT NULL,
    [lang]  CHAR (2)      NOT NULL,
    [name]  VARCHAR (254) NULL,
    CONSTRAINT [PK_LICENSETYPETR] PRIMARY KEY CLUSTERED ([codeI] ASC, [lang] ASC),
    CONSTRAINT [FK_LICENSET_REFERENCE_LICENSET] FOREIGN KEY ([codeI]) REFERENCES [dbo].[LicenseType] ([codeI])
);

