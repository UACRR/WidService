CREATE TABLE [dbo].[RelAdaptUseArea] (
    [reqId]           INT NOT NULL,
    [useAreaTypeCode] INT NOT NULL,
    CONSTRAINT [PK_RELADAPTUSEAREA] PRIMARY KEY CLUSTERED ([reqId] ASC, [useAreaTypeCode] ASC),
    CONSTRAINT [FK_RELADAPT_REFERENCE_REQUESTA] FOREIGN KEY ([reqId]) REFERENCES [dbo].[RequestAdapt] ([reqId]),
    CONSTRAINT [FK_RELADAPT_REFERENCE_USEAREAT] FOREIGN KEY ([useAreaTypeCode]) REFERENCES [dbo].[UseAreaType] ([codeI])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор заявки', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RelAdaptUseArea', @level2type = N'COLUMN', @level2name = N'reqId';

