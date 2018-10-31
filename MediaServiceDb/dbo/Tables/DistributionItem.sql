CREATE TABLE [dbo].[DistributionItem] (
    [distId]      INT             NOT NULL,
    [regId]       INT             NULL,
    [regIItemId]  INT             NULL,
    [amount]      NUMERIC (20, 2) NULL,
    [status]      INT             NULL,
    [regIdBr]     INT             NULL,
    [regItemIdBr] INT             NULL,
    [distItemId]  INT             IDENTITY (1, 1) NOT NULL,
    [objId]       INT             NULL,
    CONSTRAINT [PK_DISTRIBUTIONITEM] PRIMARY KEY CLUSTERED ([distItemId] ASC, [distId] ASC),
    CONSTRAINT [FK_DISTRIBU_REFERENCE_DISTRIBU] FOREIGN KEY ([distId]) REFERENCES [dbo].[Distribution] ([distId]) ON DELETE CASCADE,
    CONSTRAINT [FK_DISTRIBU_REFERENCE_OBJECTRI] FOREIGN KEY ([objId]) REFERENCES [dbo].[ObjectRight] ([objId])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор записи в ведомости', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DistributionItem', @level2type = N'COLUMN', @level2name = N'regIItemId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор ведомости', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DistributionItem', @level2type = N'COLUMN', @level2name = N'regId';

