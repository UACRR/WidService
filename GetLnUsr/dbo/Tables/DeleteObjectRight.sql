CREATE TABLE [dbo].[DeleteObjectRight] (
    [id]           INT           IDENTITY (1, 1) NOT NULL,
    [objId]        INT           NOT NULL,
    [genreType]    INT           NULL,
    [name]         VARCHAR (254) NULL,
    [author]       VARCHAR (254) NULL,
    [performer]    VARCHAR (254) NULL,
    [categoryCode] INT           NULL,
    [actCode]      INT           NULL,
    [loadId]       INT           NULL,
    [sourceName]   VARCHAR (200) NULL,
    [status]       INT           NULL,
    CONSTRAINT [PK_DELETEOBJECTRIGHT] PRIMARY KEY CLUSTERED ([id] ASC)
);

