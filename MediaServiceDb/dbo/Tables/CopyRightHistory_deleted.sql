CREATE TABLE [dbo].[CopyRightHistory_deleted] (
    [parentId] INT            NOT NULL,
    [childId]  INT            NOT NULL,
    [rate]     DECIMAL (5, 2) NULL,
    PRIMARY KEY CLUSTERED ([parentId] ASC, [childId] ASC)
);

