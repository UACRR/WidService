CREATE TABLE [dbo].[TypePlaceTr] (
    [codeI] INT           NOT NULL,
    [lang]  CHAR (2)      NOT NULL,
    [name]  VARCHAR (100) NULL,
    CONSTRAINT [PK_TYPEPLACETR] PRIMARY KEY CLUSTERED ([codeI] ASC, [lang] ASC),
    CONSTRAINT [FK_TYPEPLAC_REFERENCE_TYPEPLAC] FOREIGN KEY ([codeI]) REFERENCES [dbo].[TypePlace] ([codeI])
);

