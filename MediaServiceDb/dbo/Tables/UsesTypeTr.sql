CREATE TABLE [dbo].[UsesTypeTr] (
    [codeI] INT           NOT NULL,
    [lang]  CHAR (2)      NOT NULL,
    [name]  VARCHAR (100) NULL,
    CONSTRAINT [PK_USESTYPETR] PRIMARY KEY CLUSTERED ([codeI] ASC, [lang] ASC),
    CONSTRAINT [FK_USESTYPE_REFERENCE_USESTYPE] FOREIGN KEY ([codeI]) REFERENCES [dbo].[UsesType] ([codeI])
);

