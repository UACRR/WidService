CREATE TABLE [dbo].[AspNetUsers] (
    [id]                   NVARCHAR (48)      NOT NULL,
    [accessFailedCount]    INT                NOT NULL,
    [concurrencyStamp]     NVARCHAR (MAX)     NULL,
    [email]                NVARCHAR (256)     NULL,
    [emailConfirmed]       BIT                NOT NULL,
    [firstName]            NVARCHAR (256)     NULL,
    [lastName]             NVARCHAR (256)     NULL,
    [lockoutEnabled]       BIT                NOT NULL,
    [lockoutEnd]           DATETIMEOFFSET (7) NULL,
    [normalizedEmail]      NVARCHAR (256)     NULL,
    [normalizedUserName]   NVARCHAR (256)     NULL,
    [passwordHash]         NVARCHAR (MAX)     NULL,
    [phoneNumber]          NVARCHAR (MAX)     NULL,
    [phoneNumberConfirmed] BIT                NOT NULL,
    [securityStamp]        NVARCHAR (MAX)     NULL,
    [surName]              NVARCHAR (256)     NULL,
    [twoFactorEnabled]     BIT                NOT NULL,
    [userName]             NVARCHAR (256)     NULL,
    CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED ([id] ASC)
);




GO
CREATE NONCLUSTERED INDEX [EmailIndex]
    ON [dbo].[AspNetUsers]([normalizedEmail] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [UI_AspNetUsers_Email]
    ON [dbo].[AspNetUsers]([email] ASC) WHERE ([email] IS NOT NULL);

