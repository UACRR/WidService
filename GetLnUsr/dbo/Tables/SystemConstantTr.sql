CREATE TABLE [dbo].[SystemConstantTr] (
    [codeI] INT           NOT NULL,
    [lang]  CHAR (2)      NOT NULL,
    [name]  VARCHAR (100) NULL,
    CONSTRAINT [PK_SYSTEMCONSTANTTR] PRIMARY KEY CLUSTERED ([codeI] ASC, [lang] ASC),
    CONSTRAINT [FK_SYSTEMCO_REFERENCE_SYSTEMCO] FOREIGN KEY ([codeI]) REFERENCES [dbo].[SystemConstant] ([codeI])
);

