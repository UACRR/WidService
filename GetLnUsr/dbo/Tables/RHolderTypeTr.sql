CREATE TABLE [dbo].[RHolderTypeTr] (
    [codeI] INT           NOT NULL,
    [lang]  CHAR (2)      NOT NULL,
    [name]  VARCHAR (100) NULL,
    CONSTRAINT [PK_RHOLDERTYPETR] PRIMARY KEY CLUSTERED ([codeI] ASC, [lang] ASC),
    CONSTRAINT [FK_RHOLDERT_REFERENCE_RHOLDERT] FOREIGN KEY ([codeI]) REFERENCES [dbo].[RHolderType] ([codeI])
);

