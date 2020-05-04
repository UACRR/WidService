CREATE TABLE [dbo].[UseAreaTypeTr] (
    [codeI] INT           NOT NULL,
    [lang]  CHAR (2)      NOT NULL,
    [name]  VARCHAR (100) NULL,
    CONSTRAINT [PK_USEAREATYPETR] PRIMARY KEY CLUSTERED ([codeI] ASC, [lang] ASC),
    CONSTRAINT [FK_USEAREAT_REFERENCE_USEAREAT] FOREIGN KEY ([codeI]) REFERENCES [dbo].[UseAreaType] ([codeI])
);

