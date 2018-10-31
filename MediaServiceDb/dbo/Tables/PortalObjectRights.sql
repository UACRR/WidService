CREATE TABLE [dbo].[PortalObjectRights] (
    [objId]      INT NOT NULL,
    [cRKindCode] INT NOT NULL,
    [enable]     INT NOT NULL,
    CONSTRAINT [PK_PORTALOBJECTRIGHTS] PRIMARY KEY CLUSTERED ([objId] ASC, [cRKindCode] ASC),
    CONSTRAINT [FK_PORTALOB_REFERENCE_OBJECTRI] FOREIGN KEY ([objId]) REFERENCES [dbo].[ObjectRight] ([objId]),
    CONSTRAINT [FK_PORTALOB_REFERENCE_PORTALSU] FOREIGN KEY ([cRKindCode]) REFERENCES [dbo].[PortalSupportRights] ([cRKindCode])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Разришение на формирование заявки', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'PortalObjectRights', @level2type = N'COLUMN', @level2name = N'enable';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Код вида правообладателя', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'PortalObjectRights', @level2type = N'COLUMN', @level2name = N'cRKindCode';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор объекта права', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'PortalObjectRights', @level2type = N'COLUMN', @level2name = N'objId';

