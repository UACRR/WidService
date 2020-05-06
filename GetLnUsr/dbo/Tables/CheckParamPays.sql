CREATE TABLE [dbo].[CheckParamPays] (
    [inputFileId] INT             NOT NULL,
    [checkId]     INT             NOT NULL,
    [accountCorr] VARCHAR (25)    NOT NULL,
    [okpoCorr]    VARCHAR (15)    NOT NULL,
    [mfoCorr]     VARCHAR (32)    NULL,
    [docNum]      VARCHAR (50)    NOT NULL,
    [docDate]     DATE            NOT NULL,
    [sCredit]     NUMERIC (20, 2) NOT NULL,
    [nplat]       VARCHAR (512)   NOT NULL,
    [inputStatus] INT             NULL,
    [LinkStatus]  INT             NULL,
    CONSTRAINT [PK_CHECKPARAMPAYS] PRIMARY KEY CLUSTERED ([inputFileId] ASC, [checkId] ASC),
    CONSTRAINT [FK_CHECKPAR_REFERENCE_INPUTFIL] FOREIGN KEY ([inputFileId]) REFERENCES [dbo].[inputFile] ([fileId])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Таблиця для перевірки на дублі платежів', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CheckParamPays';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = '0 - новий запис
   1 - дубль', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CheckParamPays', @level2type = N'COLUMN', @level2name = N'inputStatus';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = '0 - не привязано
   1 - автоматично прив''язано', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CheckParamPays', @level2type = N'COLUMN', @level2name = N'LinkStatus';

