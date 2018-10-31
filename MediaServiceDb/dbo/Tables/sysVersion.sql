CREATE TABLE [dbo].[sysVersion] (
    [versId]   INT           IDENTITY (1, 1) NOT NULL,
    [versCode] VARCHAR (100) NOT NULL,
    [versName] VARCHAR (200) NULL,
    [versDate] DATE          NULL,
    PRIMARY KEY CLUSTERED ([versId] ASC)
);

