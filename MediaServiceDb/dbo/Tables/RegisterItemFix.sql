CREATE TABLE [dbo].[RegisterItemFix] (
    [regId]     INT      NOT NULL,
    [regItemId] INT      NOT NULL,
    [timeStart] TIME (7) NULL,
    [timeEnd]   TIME (7) NULL,
    CONSTRAINT [PK_REGISTERITEMFIX] PRIMARY KEY CLUSTERED ([regId] ASC, [regItemId] ASC),
    CONSTRAINT [FK_REGITEM_REF_REGITEMFIX] FOREIGN KEY ([regId], [regItemId]) REFERENCES [dbo].[RegisterItem] ([regId], [regIItemId]) ON DELETE CASCADE
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Час завершення звучання твору', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RegisterItemFix', @level2type = N'COLUMN', @level2name = N'timeEnd';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Час початку звучання твору', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RegisterItemFix', @level2type = N'COLUMN', @level2name = N'timeStart';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор записи в ведомости', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RegisterItemFix', @level2type = N'COLUMN', @level2name = N'regItemId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор ведомости', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RegisterItemFix', @level2type = N'COLUMN', @level2name = N'regId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Додаткові дані по фіксації', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RegisterItemFix';

