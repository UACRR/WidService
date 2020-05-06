CREATE TABLE [dbo].[CRKindGroup] (
    [codeI] INT           NOT NULL,
    [name]  VARCHAR (100) NULL,
    CONSTRAINT [PK_CRKINDGROUP] PRIMARY KEY CLUSTERED ([codeI] ASC),
    CONSTRAINT [CKC_CODEI_CRKINDGR] CHECK ([codeI]>=(1))
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Группы видов прав для красивого ввода', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CRKindGroup';

