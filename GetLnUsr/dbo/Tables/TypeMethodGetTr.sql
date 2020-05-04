CREATE TABLE [dbo].[TypeMethodGetTr] (
    [codeI] INT           NOT NULL,
    [lang]  CHAR (2)      NOT NULL,
    [name]  VARCHAR (200) NULL,
    CONSTRAINT [PK_TYPEMETHODGETTR] PRIMARY KEY CLUSTERED ([lang] ASC, [codeI] ASC),
    CONSTRAINT [FK_TYPEMETH_REFERENCE_TYPEMETH] FOREIGN KEY ([codeI]) REFERENCES [dbo].[TypeMethodGet] ([codeI])
);

