CREATE TABLE [dbo].[DocReq] (
    [docId] INT NOT NULL,
    [reqId] INT NOT NULL,
    CONSTRAINT [PK_DOCREQ] PRIMARY KEY CLUSTERED ([docId] ASC, [reqId] ASC),
    CONSTRAINT [FK_DOCREQ_REFERENCE_REQUEST] FOREIGN KEY ([reqId]) REFERENCES [dbo].[Request] ([reqId])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор заявки', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DocReq', @level2type = N'COLUMN', @level2name = N'reqId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор документа к заявке', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DocReq', @level2type = N'COLUMN', @level2name = N'docId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Документы по заявке', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DocReq';

