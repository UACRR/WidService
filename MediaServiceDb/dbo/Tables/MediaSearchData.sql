CREATE TABLE [dbo].[MediaSearchData] (
    [id]                 BIGINT        IDENTITY (1, 1) NOT NULL,
    [objId]              INT           NOT NULL,
    [typeData]           INT           NOT NULL,
    [alterName]          VARCHAR (256) NOT NULL,
    [alterNameNormalize] VARCHAR (256) NOT NULL,
    CONSTRAINT [PK_MEDIASEARCHDATA] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [CKC_TYPEDATA_MEDIASEA] CHECK ([typeData]=(2) OR [typeData]=(1) OR [typeData]=(0))
);


GO
CREATE NONCLUSTERED INDEX [search_idx]
    ON [dbo].[MediaSearchData]([typeData] ASC, [alterNameNormalize] ASC, [objId] ASC);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = '0 - Название произведения
   1 - Автора Текста
   2 - Автора Музыки', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'MediaSearchData', @level2type = N'COLUMN', @level2name = N'typeData';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор объекта права', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'MediaSearchData', @level2type = N'COLUMN', @level2name = N'objId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Альтернативные названия песен, авторов и композиторов для более точного поиска произведения ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'MediaSearchData';

