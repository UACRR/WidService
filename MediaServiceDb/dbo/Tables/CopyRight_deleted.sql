CREATE TABLE [dbo].[CopyRight_deleted] (
    [cRightId]      INT            NOT NULL,
    [custId]        INT            NOT NULL,
    [objId]         INT            NULL,
    [lBasis]        INT            NULL,
    [rate]          DECIMAL (5, 2) NULL,
    [roleRate]      DECIMAL (5, 2) NULL,
    [beginDate]     DATE           NULL,
    [endDate]       DATE           NULL,
    [lBasisComment] VARCHAR (254)  NULL,
    [createDate]    DATETIME       NULL,
    [modifyDate]    DATETIME       NULL,
    [modifyLogin]   VARCHAR (48)   NULL,
    [permCode]      BIT            NULL,
    [parentId]      INT            NULL,
    [roleCode]      INT            NULL,
    [status]        INT            NULL,
    [rateMech]      DECIMAL (5, 2) NULL,
    [loadId]        INT            NULL,
    [sourceName]    VARCHAR (200)  NULL,
    PRIMARY KEY CLUSTERED ([cRightId] ASC)
);

