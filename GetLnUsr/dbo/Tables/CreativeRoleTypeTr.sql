CREATE TABLE [dbo].[CreativeRoleTypeTr] (
    [codeI] INT           NOT NULL,
    [lang]  CHAR (2)      NOT NULL,
    [name]  VARCHAR (128) NULL,
    CONSTRAINT [PK_CREATIVEROLETYPETR] PRIMARY KEY CLUSTERED ([codeI] ASC, [lang] ASC),
    CONSTRAINT [FK_CREATIVE_REFERENCE_CREATIVE] FOREIGN KEY ([codeI]) REFERENCES [dbo].[CreativeRoleType] ([codeI])
);

