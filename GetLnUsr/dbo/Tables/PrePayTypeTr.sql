CREATE TABLE [dbo].[PrePayTypeTr] (
    [codeI] INT           NOT NULL,
    [lang]  CHAR (2)      NOT NULL,
    [name]  VARCHAR (256) NULL,
    CONSTRAINT [PK_PREPAYTYPETR] PRIMARY KEY CLUSTERED ([codeI] ASC, [lang] ASC),
    CONSTRAINT [FK_PREPAYTY_REFERENCE_PREPAYTY] FOREIGN KEY ([codeI]) REFERENCES [dbo].[PrePayType] ([codeI])
);

