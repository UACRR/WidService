CREATE TABLE [dbo].[RelSchemaKindCode] (
    [schemaCode] INT         NOT NULL,
    [kindCode]   INT         NOT NULL,
    [CDE]        VARCHAR (3) NULL,
    CONSTRAINT [PK_RELSCHEMAKINDCODE] PRIMARY KEY CLUSTERED ([schemaCode] ASC, [kindCode] ASC),
    CONSTRAINT [FK_RELSCHEM_REFERENCE_COPYRIGH] FOREIGN KEY ([kindCode]) REFERENCES [dbo].[CopyrightKind] ([codeI]),
    CONSTRAINT [FK_RELSCHEM_REFERENCE_SCHEMATY] FOREIGN KEY ([schemaCode]) REFERENCES [dbo].[SchemaType] ([codeI])
);

