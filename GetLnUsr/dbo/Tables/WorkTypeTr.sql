CREATE TABLE [dbo].[WorkTypeTr] (
    [codeI] INT           NOT NULL,
    [lang]  CHAR (2)      NOT NULL,
    [name]  VARCHAR (100) NULL,
    CONSTRAINT [PK_WORKTYPETR] PRIMARY KEY CLUSTERED ([codeI] ASC, [lang] ASC),
    CONSTRAINT [FK_WORKTYPE_REFERENCE_WORKTYPE] FOREIGN KEY ([codeI]) REFERENCES [dbo].[WorkType] ([codeI])
);

