CREATE TABLE [dbo].[KL_R030Tr] (
    [r030]     CHAR (3)      NOT NULL,
    [lang]     CHAR (2)      NOT NULL,
    [r030Name] VARCHAR (100) NULL,
    CONSTRAINT [PK_R030TR] PRIMARY KEY CLUSTERED ([r030] ASC, [lang] ASC),
    CONSTRAINT [FK_R030TR_REFERENCE_KL_R030] FOREIGN KEY ([r030]) REFERENCES [dbo].[KL_R030] ([r030])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Код валюты', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KL_R030Tr', @level2type = N'COLUMN', @level2name = N'r030';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Название с большой буквы', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KL_R030Tr', @level2type = N'COLUMN', @level2name = N'r030Name';

