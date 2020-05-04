CREATE TABLE [dbo].[ClientGroupTr] (
    [codeI] INT           NOT NULL,
    [lang]  CHAR (2)      NOT NULL,
    [name]  VARCHAR (100) NOT NULL,
    CONSTRAINT [PK_CLIENTGROUPTR] PRIMARY KEY CLUSTERED ([lang] ASC, [codeI] ASC),
    CONSTRAINT [FK_CLIENTGR_REFERENCE_CLIENTGR] FOREIGN KEY ([codeI]) REFERENCES [dbo].[ClientGroup] ([codeI])
);

