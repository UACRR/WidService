CREATE TABLE [dbo].[AlgorithmTypeTr] (
    [codeI] INT           NOT NULL,
    [lang]  CHAR (2)      NOT NULL,
    [name]  VARCHAR (100) NULL,
    CONSTRAINT [PK_ALGORITHMTYPETR] PRIMARY KEY CLUSTERED ([codeI] ASC, [lang] ASC),
    CONSTRAINT [FK_ALGORITH_REFERENCE_ALGORITH] FOREIGN KEY ([codeI]) REFERENCES [dbo].[AlgorithmType] ([codeI])
);

