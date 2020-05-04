CREATE TABLE [dbo].[ItemStatusTr] (
    [codeI] INT           NOT NULL,
    [lang]  CHAR (2)      NOT NULL,
    [name]  VARCHAR (100) NULL,
    CONSTRAINT [PK_ITEMSTATUSTR] PRIMARY KEY CLUSTERED ([codeI] ASC, [lang] ASC),
    CONSTRAINT [FK_ITEMSTAT_REFERENCE_ITEMSTAT] FOREIGN KEY ([codeI]) REFERENCES [dbo].[ItemStatus] ([codeI])
);

