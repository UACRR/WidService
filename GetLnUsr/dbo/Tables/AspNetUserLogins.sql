CREATE TABLE [dbo].[AspNetUserLogins] (
    [loginProvider]       NVARCHAR (450) NOT NULL,
    [providerKey]         NVARCHAR (450) NOT NULL,
    [providerDisplayName] NVARCHAR (MAX) NULL,
    [userId]              NVARCHAR (48)  NOT NULL,
    CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED ([loginProvider] ASC, [providerKey] ASC),
    CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([userId]) REFERENCES [dbo].[AspNetUsers] ([id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId]
    ON [dbo].[AspNetUserLogins]([userId] ASC);

