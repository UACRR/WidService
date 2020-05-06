CREATE TABLE [dbo].[DocText] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [DocTypeCode] INT           NULL,
    [Code]        VARCHAR (10)  NULL,
    [Text_Uk]     VARCHAR (512) NULL,
    [Text_Ru]     VARCHAR (512) NULL,
    [Text_En]     VARCHAR (512) NULL,
    CONSTRAINT [PK_DOCTEXT] PRIMARY KEY CLUSTERED ([Id] ASC)
);

