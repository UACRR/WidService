CREATE TABLE [dbo].[RequestAimTr] (
    [codeI] INT           NOT NULL,
    [lang]  CHAR (2)      NOT NULL,
    [name]  VARCHAR (200) NULL,
    CONSTRAINT [PK_REQUESTAIMTR] PRIMARY KEY CLUSTERED ([codeI] ASC, [lang] ASC),
    CONSTRAINT [FK_REQUESTA_REFERENCE_REQUESTA] FOREIGN KEY ([codeI]) REFERENCES [dbo].[RequestAim] ([codeI])
);

