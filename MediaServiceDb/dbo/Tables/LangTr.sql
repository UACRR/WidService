CREATE TABLE [dbo].[LangTr] (
    [codeS] CHAR (2)      NOT NULL,
    [lang]  CHAR (2)      NOT NULL,
    [name]  VARCHAR (100) NULL,
    CONSTRAINT [PK_LANGTR] PRIMARY KEY CLUSTERED ([codeS] ASC, [lang] ASC),
    CONSTRAINT [FK_LANGTR_REFERENCE_LANG] FOREIGN KEY ([codeS]) REFERENCES [dbo].[Lang] ([codeS])
);

