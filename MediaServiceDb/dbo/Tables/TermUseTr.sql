CREATE TABLE [dbo].[TermUseTr] (
    [codeI] INT           NOT NULL,
    [lang]  CHAR (2)      NOT NULL,
    [name]  VARCHAR (100) NULL,
    CONSTRAINT [PK_TERMUSETR] PRIMARY KEY CLUSTERED ([codeI] ASC, [lang] ASC),
    CONSTRAINT [FK_TERMUSET_REFERENCE_TERMUSE] FOREIGN KEY ([codeI]) REFERENCES [dbo].[TermUse] ([codeI])
);

