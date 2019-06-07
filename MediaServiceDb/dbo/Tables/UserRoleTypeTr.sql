CREATE TABLE [dbo].[UserRoleTypeTr] (
    [codeI] INT           NOT NULL,
    [lang]  CHAR (2)      NOT NULL,
    [name]  VARCHAR (250) NOT NULL,
    CONSTRAINT [PK_USERROLETYPETR] PRIMARY KEY CLUSTERED ([codeI] ASC, [lang] ASC),
    CONSTRAINT [FK_USERROLE_REFERENCE_USERROLE2] FOREIGN KEY ([codeI]) REFERENCES [dbo].[UserRoleType] ([codeI])
);

