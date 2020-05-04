CREATE TABLE [dbo].[MusicalDesign] (
    [mdId]         INT           IDENTITY (1, 1) NOT NULL,
    [licId]        INT           NOT NULL,
    [objid]        INT           NULL,
    [actNumb]      INT           NULL,
    [objName]      VARCHAR (256) NULL,
    [nameMusician] VARCHAR (256) NULL,
    [nameSinger]   VARCHAR (256) NULL,
    [authorText]   VARCHAR (100) NULL,
    [duration]     TIME (7)      NULL,
    [numbPerfom]   INT           NULL,
    CONSTRAINT [PK_MUSICALDESIGN] PRIMARY KEY CLUSTERED ([mdId] ASC),
    CONSTRAINT [FK_MUSICALD_REFERENCE_LICENSEB] FOREIGN KEY ([licId]) REFERENCES [dbo].[LicenseBigR] ([licId]),
    CONSTRAINT [FK_MUSICALD_REFERENCE_OBJECTRI] FOREIGN KEY ([objid]) REFERENCES [dbo].[ObjectRight] ([objId])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Музичне оформлення', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'MusicalDesign';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Номер акту', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'MusicalDesign', @level2type = N'COLUMN', @level2name = N'actNumb';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Назва твору', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'MusicalDesign', @level2type = N'COLUMN', @level2name = N'objName';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'ПІБ композитора', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'MusicalDesign', @level2type = N'COLUMN', @level2name = N'nameMusician';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'ПІБ виконавця', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'MusicalDesign', @level2type = N'COLUMN', @level2name = N'nameSinger';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Автор текста', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'MusicalDesign', @level2type = N'COLUMN', @level2name = N'authorText';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Тривалість звучання', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'MusicalDesign', @level2type = N'COLUMN', @level2name = N'duration';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Кількість виконань', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'MusicalDesign', @level2type = N'COLUMN', @level2name = N'numbPerfom';

