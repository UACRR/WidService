CREATE TABLE [dbo].[inputFile] (
    [fileId]        INT           IDENTITY (1, 1) NOT NULL,
    [Asp_id]        NVARCHAR (48) NULL,
    [fileName]      VARCHAR (256) NOT NULL,
    [inputTime]     DATETIME      NOT NULL,
    [countRows]     INT           NOT NULL,
    [countInput]    INT           NOT NULL,
    [countAutoLink] INT           NOT NULL,
    CONSTRAINT [PK_INPUTFILE] PRIMARY KEY CLUSTERED ([fileId] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Користувач, який завантажив файл', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'inputFile', @level2type = N'COLUMN', @level2name = N'fileId';

