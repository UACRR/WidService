CREATE TABLE [dbo].[AspNetUserRoles] (
    [userId] NVARCHAR (48)  NOT NULL,
    [roleId] NVARCHAR (450) NOT NULL,
    CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED ([userId] ASC, [roleId] ASC),
    CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([roleId]) REFERENCES [dbo].[AspNetRoles] ([id]) ON DELETE CASCADE,
    CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([userId]) REFERENCES [dbo].[AspNetUsers] ([id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId]
    ON [dbo].[AspNetUserRoles]([roleId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_UserId]
    ON [dbo].[AspNetUserRoles]([userId] ASC);

