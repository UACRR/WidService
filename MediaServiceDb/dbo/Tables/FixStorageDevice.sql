CREATE TABLE [dbo].[FixStorageDevice] (
    [fixId]        INT            NOT NULL,
    [storageId]    INT            IDENTITY (1, 1) NOT NULL,
    [name]         NVARCHAR (255) NOT NULL,
    [serialNumber] NVARCHAR (255) NOT NULL,
    [capacity]     NUMERIC (18)   NULL,
    CONSTRAINT [PK_FIXSTORAGEDEVICE] PRIMARY KEY CLUSTERED ([storageId] ASC, [fixId] ASC),
    CONSTRAINT [FK_FIXSTORAGE_REF_FIXATION] FOREIGN KEY ([fixId]) REFERENCES [dbo].[Fixation] ([fixId])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Ідентифікатор пристрою накопичення інформації', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'FixStorageDevice', @level2type = N'COLUMN', @level2name = N'storageId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Ідентифікатор подання', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'FixStorageDevice', @level2type = N'COLUMN', @level2name = N'fixId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Пристрій накопичення інформації', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'FixStorageDevice';

