CREATE TABLE [dbo].[SchemaType] (
    [codeI]        INT           NOT NULL,
    [name]         VARCHAR (100) NULL,
    [isMinAmount]  SMALLINT      NULL,
    [isRateAmount] SMALLINT      NULL,
    CONSTRAINT [PK_SCHEMATYPE] PRIMARY KEY CLUSTERED ([codeI] ASC)
);

