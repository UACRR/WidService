CREATE TABLE [dbo].[RegisterExtra] (
    [regExtraId] INT           IDENTITY (1, 1) NOT NULL,
    [regId]      INT           NOT NULL,
    [regIItemId] INT           NOT NULL,
    [roleCode]   INT           NOT NULL,
    [name]       VARCHAR (100) NOT NULL,
    CONSTRAINT [PK_REGISTEREXTRA] PRIMARY KEY CLUSTERED ([regExtraId] ASC),
    CONSTRAINT [FK_REGEX_REF_CREATIVEROLE] FOREIGN KEY ([roleCode]) REFERENCES [dbo].[CreativeRoleType] ([codeI]),
    CONSTRAINT [FK_REGEX_REF_REGITEM] FOREIGN KEY ([regId], [regIItemId]) REFERENCES [dbo].[RegisterItem] ([regId], [regIItemId]) ON DELETE CASCADE
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор записи в ведомости', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RegisterExtra', @level2type = N'COLUMN', @level2name = N'regIItemId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор ведомости', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RegisterExtra', @level2type = N'COLUMN', @level2name = N'regId';

