CREATE TABLE [dbo].[FixStageStatus] (
    [codeI]      INT            NOT NULL,
    [StageName]  NVARCHAR (255) NULL,
    [StatusName] NVARCHAR (255) NULL,
    [StageCode]  INT            NULL,
    [StatusCode] INT            NULL,
    CONSTRAINT [PK_FIXSTAGESTATUS] PRIMARY KEY CLUSTERED ([codeI] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Етап і статус подання', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'FixStageStatus';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Ідентифікатор етапу і статусу подання', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'FixStageStatus', @level2type = N'COLUMN', @level2name = N'codeI';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Назва етапу подання', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'FixStageStatus', @level2type = N'COLUMN', @level2name = N'StageName';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Назва статусу подання', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'FixStageStatus', @level2type = N'COLUMN', @level2name = N'StatusName';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Код етапу подання', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'FixStageStatus', @level2type = N'COLUMN', @level2name = N'StageCode';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Код статусу подання', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'FixStageStatus', @level2type = N'COLUMN', @level2name = N'StatusCode';

