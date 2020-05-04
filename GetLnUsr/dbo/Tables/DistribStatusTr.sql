CREATE TABLE [dbo].[DistribStatusTr] (
    [codeI] INT           NOT NULL,
    [lang]  CHAR (2)      NOT NULL,
    [name]  VARCHAR (100) NULL,
    CONSTRAINT [PK_DISTRIBSTATUSTR] PRIMARY KEY CLUSTERED ([codeI] ASC, [lang] ASC),
    CONSTRAINT [FK_DISTRIBS_REFERENCE_DISTRIBS] FOREIGN KEY ([codeI]) REFERENCES [dbo].[DistribStatus] ([codeI])
);

