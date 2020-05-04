CREATE TABLE [dbo].[AspNetUserTokens] (
    [userId]        NVARCHAR (450) NOT NULL,
    [loginProvider] NVARCHAR (450) NOT NULL,
    [name]          NVARCHAR (450) NOT NULL,
    [value]         NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED ([userId] ASC, [loginProvider] ASC, [name] ASC)
);

