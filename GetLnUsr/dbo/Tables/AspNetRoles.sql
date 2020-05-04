CREATE TABLE [dbo].[AspNetRoles] (
    [id]               NVARCHAR (450) NOT NULL,
    [concurrencyStamp] NVARCHAR (MAX) NULL,
    [description]      NVARCHAR (256) NULL,
    [name]             NVARCHAR (256) NULL,
    [normalizedName]   NVARCHAR (256) NULL,
    CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED ([id] ASC)
);


GO
CREATE NONCLUSTERED INDEX [RoleNameIndex]
    ON [dbo].[AspNetRoles]([normalizedName] ASC);

