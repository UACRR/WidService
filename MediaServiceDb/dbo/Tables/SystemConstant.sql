CREATE TABLE [dbo].[SystemConstant] (
    [codeI] INT            NOT NULL,
    [name]  VARCHAR (100)  NULL,
    [rate]  DECIMAL (5, 2) NULL,
    CONSTRAINT [PK_SYSTEMCONSTANT] PRIMARY KEY CLUSTERED ([codeI] ASC)
);

