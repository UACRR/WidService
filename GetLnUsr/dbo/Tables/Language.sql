CREATE TABLE [dbo].[Language] (
    [codeS]       CHAR (2)      NOT NULL,
    [name]        VARCHAR (100) NULL,
    [nameId]      INT           NULL,
    [nameSh3]     CHAR (3)      NULL,
    [shortChoise] SMALLINT      NULL,
    CONSTRAINT [PK_LANGUAGE] PRIMARY KEY CLUSTERED ([codeS] ASC)
);

