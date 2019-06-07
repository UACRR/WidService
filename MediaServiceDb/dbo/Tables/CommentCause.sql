CREATE TABLE [dbo].[CommentCause] (
    [causeCode]   INT           NOT NULL,
    [causeNameUk] VARCHAR (256) NULL,
    [causeNameRu] VARCHAR (256) NULL,
    [causeNameEn] VARCHAR (256) NULL,
    CONSTRAINT [PK_COMMENTCAUSE] PRIMARY KEY CLUSTERED ([causeCode] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Виды комментариев - справочник', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CommentCause';

