CREATE TABLE [dbo].[RequestStatusTypeTr] (
    [codeI] INT           NOT NULL,
    [lang]  CHAR (2)      NOT NULL,
    [name]  VARCHAR (200) NULL,
    CONSTRAINT [PK_REQUESTSTATUSTYPETR] PRIMARY KEY CLUSTERED ([codeI] ASC, [lang] ASC),
    CONSTRAINT [FK_REQUESTS_REFERENCE_REQUESTS] FOREIGN KEY ([codeI]) REFERENCES [dbo].[RequestStatusType] ([codeI])
);

