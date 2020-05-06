CREATE TABLE [dbo].[RelReqMedia] (
    [useMediaTypeCode] INT NOT NULL,
    [reqId]            INT NOT NULL,
    CONSTRAINT [PK_RELREQMEDIA] PRIMARY KEY CLUSTERED ([useMediaTypeCode] ASC, [reqId] ASC),
    CONSTRAINT [FK_RELREQME_REFERENCE_REQUEST] FOREIGN KEY ([reqId]) REFERENCES [dbo].[Request] ([reqId]),
    CONSTRAINT [FK_RELREQME_REFERENCE_USEMEDIA] FOREIGN KEY ([useMediaTypeCode]) REFERENCES [dbo].[UseMediaType] ([codeI])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Использование композиции в медиаресурсах', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RelReqMedia';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор заявки', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RelReqMedia', @level2type = N'COLUMN', @level2name = N'reqId';

