CREATE TABLE [dbo].[AspNetRoleClaims] (
    [id]         INT            IDENTITY (1, 1) NOT NULL,
    [claimType]  NVARCHAR (MAX) NULL,
    [claimValue] NVARCHAR (MAX) NULL,
    [roleId]     NVARCHAR (450) NOT NULL,
    CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([roleId]) REFERENCES [dbo].[AspNetRoles] ([id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId]
    ON [dbo].[AspNetRoleClaims]([roleId] ASC);

