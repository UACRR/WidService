CREATE TABLE [dbo].[ClientBrandTr] (
    [codeI] INT           NOT NULL,
    [lang]  CHAR (2)      NOT NULL,
    [name]  VARCHAR (100) NOT NULL,
    CONSTRAINT [PK_CLIENTBRANDTR] PRIMARY KEY CLUSTERED ([lang] ASC, [codeI] ASC),
    CONSTRAINT [FK_CLIENTBR_REFERENCE_CLIENTBR] FOREIGN KEY ([codeI]) REFERENCES [dbo].[ClientBrand] ([codeI])
);

