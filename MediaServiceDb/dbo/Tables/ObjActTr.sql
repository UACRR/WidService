CREATE TABLE [dbo].[ObjActTr] (
    [codeI] INT           NOT NULL,
    [lang]  CHAR (10)     NOT NULL,
    [name]  VARCHAR (100) NULL,
    CONSTRAINT [PK_OBJACTTR] PRIMARY KEY CLUSTERED ([codeI] ASC, [lang] ASC),
    CONSTRAINT [FK_OBJACTTR_REFERENCE_OBJACT] FOREIGN KEY ([codeI]) REFERENCES [dbo].[ObjAct] ([codeI])
);

