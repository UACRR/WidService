CREATE TABLE [dbo].[SeekTypeTr] (
    [codeI] INT           NOT NULL,
    [lang]  CHAR (2)      NOT NULL,
    [name]  VARCHAR (100) NULL,
    CONSTRAINT [PK_SEEKTYPETR] PRIMARY KEY CLUSTERED ([codeI] ASC, [lang] ASC),
    CONSTRAINT [FK_SEEKTYPE_REFERENCE_SEEKTYPE] FOREIGN KEY ([codeI]) REFERENCES [dbo].[SeekType] ([codeI])
);

