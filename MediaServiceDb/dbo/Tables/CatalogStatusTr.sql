CREATE TABLE [dbo].[CatalogStatusTr] (
    [codeI] INT           NOT NULL,
    [lang]  VARCHAR (2)   NOT NULL,
    [name]  VARCHAR (100) NULL,
    CONSTRAINT [PK_CATALOGSTATUSTR] PRIMARY KEY CLUSTERED ([codeI] ASC, [lang] ASC),
    CONSTRAINT [FK_CATALOGS_REFERENCE_CATALOGS] FOREIGN KEY ([codeI]) REFERENCES [dbo].[CatalogStatus] ([codeI])
);

