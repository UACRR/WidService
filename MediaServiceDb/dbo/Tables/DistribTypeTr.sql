CREATE TABLE [dbo].[DistribTypeTr] (
    [codeI] INT           NOT NULL,
    [lang]  CHAR (2)      NOT NULL,
    [name]  VARCHAR (100) NOT NULL,
    CONSTRAINT [PK_DISTRIBTYPETR] PRIMARY KEY CLUSTERED ([codeI] ASC, [lang] ASC),
    CONSTRAINT [FK_DISTRIBT_REFERENCE_DISTRIBT] FOREIGN KEY ([codeI]) REFERENCES [dbo].[DistribType] ([codeI])
);

