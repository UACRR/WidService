CREATE TABLE [dbo].[AspNetUserClaims] (
    [id]         INT            IDENTITY (1, 1) NOT NULL,
    [claimType]  NVARCHAR (MAX) NULL,
    [claimValue] NVARCHAR (MAX) NULL,
    [userId]     NVARCHAR (48)  NOT NULL,
    CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([userId]) REFERENCES [dbo].[AspNetUsers] ([id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId]
    ON [dbo].[AspNetUserClaims]([userId] ASC);

