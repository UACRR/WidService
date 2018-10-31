CREATE TABLE [dbo].[UsesKindTr] (
    [codeI] INT           NOT NULL,
    [lang]  CHAR (2)      NOT NULL,
    [name]  VARCHAR (100) NULL,
    CONSTRAINT [PK_USESKINDTR] PRIMARY KEY CLUSTERED ([codeI] ASC, [lang] ASC),
    CONSTRAINT [FK_USESKIND_REFERENCE_USESKIND] FOREIGN KEY ([codeI]) REFERENCES [dbo].[UsesKind] ([codeI])
);

