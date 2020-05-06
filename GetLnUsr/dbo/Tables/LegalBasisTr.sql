CREATE TABLE [dbo].[LegalBasisTr] (
    [codeI] INT           NOT NULL,
    [lang]  CHAR (2)      NOT NULL,
    [name]  VARCHAR (254) NULL,
    CONSTRAINT [PK_LEGALBASISTR] PRIMARY KEY CLUSTERED ([codeI] ASC, [lang] ASC),
    CONSTRAINT [FK_LEGALBAS_REFERENCE_LEGALBAS] FOREIGN KEY ([codeI]) REFERENCES [dbo].[LegalBasis] ([codeI])
);

