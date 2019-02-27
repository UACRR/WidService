CREATE TABLE [dbo].[SystemMessage] (
    [id]         INT           IDENTITY (1, 1) NOT NULL,
    [modifydate] DATETIME      NULL,
    [nameMain]   VARCHAR (100) NULL,
    [name]       VARCHAR (100) NULL,
    [keyObj]     INT           NULL,
    [text]       VARCHAR (200) NULL,
    [sysname]    VARCHAR (200) NULL,
    [custId]     INT           NULL,
    CONSTRAINT [PK_SYSTEMMESSAGE] PRIMARY KEY CLUSTERED ([id] ASC)
);

