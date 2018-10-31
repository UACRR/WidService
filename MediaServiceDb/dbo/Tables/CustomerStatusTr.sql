CREATE TABLE [dbo].[CustomerStatusTr] (
    [codeI] INT           NOT NULL,
    [lang]  CHAR (2)      NOT NULL,
    [name]  VARCHAR (100) NULL,
    CONSTRAINT [PK_CUSTOMERSTATUSTR] PRIMARY KEY CLUSTERED ([codeI] ASC, [lang] ASC),
    CONSTRAINT [FK_CUSTOMER_REFERENCE_CUSTOMTr] FOREIGN KEY ([codeI]) REFERENCES [dbo].[CustomerStatus] ([codeI])
);

