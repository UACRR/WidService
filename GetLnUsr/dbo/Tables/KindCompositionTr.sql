CREATE TABLE [dbo].[KindCompositionTr] (
    [codeI] INT           NOT NULL,
    [lang]  CHAR (2)      NOT NULL,
    [name]  VARCHAR (200) NULL,
    CONSTRAINT [PK_KINDCOMPOSITIONTR] PRIMARY KEY CLUSTERED ([codeI] ASC, [lang] ASC),
    CONSTRAINT [FK_KINDCOMP_REFERENCE_KINDCOMP] FOREIGN KEY ([codeI]) REFERENCES [dbo].[KindComposition] ([codeI])
);

