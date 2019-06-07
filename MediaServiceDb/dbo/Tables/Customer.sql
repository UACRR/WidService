CREATE TABLE [dbo].[Customer] (
    [custId]     INT           IDENTITY (1, 1) NOT NULL,
    [custType]   INT           NULL,
    [status]     INT           NOT NULL,
    [ankVersion] INT           NULL,
    [ankMy]      TINYINT       NULL,
    [ankPublish] TINYINT       NULL,
    [ankTech]    TINYINT       NULL,
    [userId]     NVARCHAR (48) NULL,
    CONSTRAINT [PK_CUSTOMER] PRIMARY KEY CLUSTERED ([custId] ASC),
    CONSTRAINT [FK_CUSTOMER_REFERENCE_ASPNETUS] FOREIGN KEY ([userId]) REFERENCES [dbo].[AspNetUsers] ([id]),
    CONSTRAINT [FK_CUSTOMER_REFERENCE_CUSTOMER] FOREIGN KEY ([custType]) REFERENCES [dbo].[CustomerType] ([codeI]),
    CONSTRAINT [FK_CUSTOMER_REFERENCE_Status] FOREIGN KEY ([status]) REFERENCES [dbo].[CustomerStatus] ([codeI])
);



