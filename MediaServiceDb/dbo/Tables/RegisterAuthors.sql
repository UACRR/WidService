CREATE TABLE [dbo].[RegisterAuthors] (
    [regId]      INT           NOT NULL,
    [regIItemId] INT           NOT NULL,
    [authId]     INT           NOT NULL,
    [codeRole]   INT           NOT NULL,
    [Name]       VARCHAR (256) NOT NULL,
    CONSTRAINT [PK_REGISTERAUTHORS] PRIMARY KEY CLUSTERED ([regId] ASC, [regIItemId] ASC, [authId] ASC),
    CONSTRAINT [FK_REG_REF_CREAROLE] FOREIGN KEY ([codeRole]) REFERENCES [dbo].[CreativeRoleType] ([codeI])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор записи в ведомости', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RegisterAuthors', @level2type = N'COLUMN', @level2name = N'regIItemId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор ведомости', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RegisterAuthors', @level2type = N'COLUMN', @level2name = N'regId';

