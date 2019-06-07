CREATE TABLE [dbo].[TypeInternetObjectTr] (
    [codeI] INT           NOT NULL,
    [lang]  CHAR (2)      NOT NULL,
    [name]  VARCHAR (200) NULL,
    CONSTRAINT [PK_TYPEINTERNETOBJECTTR] PRIMARY KEY CLUSTERED ([codeI] ASC, [lang] ASC),
    CONSTRAINT [FK_TYPEINTE_REFERENCE_TYPEINTE] FOREIGN KEY ([codeI]) REFERENCES [dbo].[TypeInternetObject] ([codeI])
);

