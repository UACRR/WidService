CREATE TABLE [dbo].[MonthNameTr] (
    [codeI] INT           NOT NULL,
    [lang]  CHAR (2)      NOT NULL,
    [name]  VARCHAR (100) NULL,
    CONSTRAINT [PK_MONTHNAMETR] PRIMARY KEY CLUSTERED ([codeI] ASC, [lang] ASC),
    CONSTRAINT [FK_MONTHNAM_REFERENCE_MONTHNAM] FOREIGN KEY ([codeI]) REFERENCES [dbo].[MonthName] ([codeI])
);

