CREATE TABLE [dbo].[DocumentTypeTr] (
    [codeI] INT           NOT NULL,
    [lang]  CHAR (2)      NOT NULL,
    [name]  VARCHAR (100) NULL,
    CONSTRAINT [PK_DOCUMENTTYPETR] PRIMARY KEY CLUSTERED ([codeI] ASC, [lang] ASC),
    CONSTRAINT [FK_DOCUMENT_REFERENCE_DOCUMENT] FOREIGN KEY ([codeI]) REFERENCES [dbo].[DocumentType] ([codeI])
);



