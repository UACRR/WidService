CREATE TABLE [dbo].[RequestOther] (
    [reqId]   INT           NOT NULL,
    [useDesc] VARCHAR (254) NOT NULL,
    CONSTRAINT [PK_REQUESTOTHER] PRIMARY KEY CLUSTERED ([reqId] ASC),
    CONSTRAINT [FK_REQUESTO_REFERENCE_REQUEST] FOREIGN KEY ([reqId]) REFERENCES [dbo].[Request] ([reqId])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Описание использования ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RequestOther', @level2type = N'COLUMN', @level2name = N'useDesc';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор заявки', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RequestOther', @level2type = N'COLUMN', @level2name = N'reqId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Информция для заявки на синхронизаяцию', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RequestOther';

