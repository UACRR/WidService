CREATE TABLE [dbo].[ObjectRight_deleted] (
    [categoryCode] INT           NOT NULL,
    [objId]        INT           NOT NULL,
    [reqId]        INT           NULL,
    [genreType]    INT           NULL,
    [name]         VARCHAR (254) NULL,
    [author]       VARCHAR (254) NULL,
    [performer]    VARCHAR (254) NULL,
    [status]       INT           NULL,
    [modifyDate]   DATETIME      NULL,
    [modifyLogin]  VARCHAR (48)  NULL,
    [createDate]   DATETIME      NULL,
    [ObjImg]       VARCHAR (256) NULL,
    [loadid]       INT           NULL,
    [specType]     INT           NULL,
    [actCode]      INT           NULL,
    [innerCode]    VARCHAR (100) NULL,
    [sourceName]   VARCHAR (200) NULL,
    PRIMARY KEY CLUSTERED ([objId] ASC)
);

