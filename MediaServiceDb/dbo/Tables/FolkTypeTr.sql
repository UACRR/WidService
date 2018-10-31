CREATE TABLE [dbo].[FolkTypeTr] (
    [codeI] INT           NOT NULL,
    [lang]  CHAR (2)      NOT NULL,
    [name]  VARCHAR (100) NULL,
    CONSTRAINT [PK_FOLKTYPETR] PRIMARY KEY CLUSTERED ([codeI] ASC, [lang] ASC),
    CONSTRAINT [FK_FOLKTYPE_REFERENCE_FOLKTYPE] FOREIGN KEY ([codeI]) REFERENCES [dbo].[FolkType] ([codeI])
);

