CREATE TABLE [dbo].[Authors] (
    [authId]          INT           IDENTITY (1, 1) NOT NULL,
    [objId]           INT           NOT NULL,
    [roleCode]        INT           NOT NULL,
    [custId]          INT           NULL,
    [authorName]      VARCHAR (100) NOT NULL,
    [isFolkOrUnknown] INT           NULL,
    [folkType]        INT           NULL,
    CONSTRAINT [PK_AUTHORS] PRIMARY KEY CLUSTERED ([authId] ASC),
    CONSTRAINT [CKC_ISFOLKORUNKNOWN_AUTHORS] CHECK ([isFolkOrUnknown] IS NULL OR ([isFolkOrUnknown]=(2) OR [isFolkOrUnknown]=(1))),
    CONSTRAINT [FK_AUTHORS_REFERENCE_CREATIVE] FOREIGN KEY ([roleCode]) REFERENCES [dbo].[CreativeRoleType] ([codeI]),
    CONSTRAINT [FK_AUTHORS_REFERENCE_FOLKTYPE] FOREIGN KEY ([folkType]) REFERENCES [dbo].[FolkType] ([codeI]),
    CONSTRAINT [FK_AUTHORS_REFERENCE_OBJECTRI] FOREIGN KEY ([objId]) REFERENCES [dbo].[ObjectRight] ([objId]),
    CONSTRAINT [FK_AUTHORS_REFERENCE_RIGHTHOL] FOREIGN KEY ([custId]) REFERENCES [dbo].[RightHolder] ([custId])
);


GO
CREATE NONCLUSTERED INDEX [IdxNames]
    ON [dbo].[Authors]([authorName] ASC, [custId] ASC);


GO
CREATE NONCLUSTERED INDEX [I_AuthorsObjId]
    ON [dbo].[Authors]([objId] ASC, [custId] ASC, [authorName] ASC);


GO
CREATE NONCLUSTERED INDEX [iAuthors_CustId]
    ON [dbo].[Authors]([custId] ASC);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор объекта права', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Authors', @level2type = N'COLUMN', @level2name = N'objId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор клиента (правообладателя или покупателя)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Authors', @level2type = N'COLUMN', @level2name = N'custId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'null
   1 - isFolk
   2 - isUnknown', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Authors', @level2type = N'COLUMN', @level2name = N'isFolkOrUnknown';

