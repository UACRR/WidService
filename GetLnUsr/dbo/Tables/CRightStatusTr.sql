CREATE TABLE [dbo].[CRightStatusTr] (
    [codeI] INT           NOT NULL,
    [lang]  CHAR (2)      NOT NULL,
    [name]  VARCHAR (100) NULL,
    CONSTRAINT [PK_CRIGHTSTATUSTR] PRIMARY KEY CLUSTERED ([codeI] ASC, [lang] ASC),
    CONSTRAINT [FK_CRIGHTST_REFERENCE_CRIGHTST] FOREIGN KEY ([codeI]) REFERENCES [dbo].[CRightStatus] ([codeI])
);

