CREATE TABLE [dbo].[AccountStatusTr] (
    [codeI] INT           NOT NULL,
    [lang]  CHAR (2)      NOT NULL,
    [name]  VARCHAR (100) NULL,
    CONSTRAINT [PK_ACCOUNTSTATUSTR] PRIMARY KEY CLUSTERED ([codeI] ASC, [lang] ASC),
    CONSTRAINT [FK_ACCOUNTS_REFERENCE_ACCOUNTS] FOREIGN KEY ([codeI]) REFERENCES [dbo].[AccountStatus] ([codeI])
);

