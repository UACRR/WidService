CREATE TABLE [dbo].[CopyrightKind] (
    [codeI]        INT           NOT NULL,
    [name]         VARCHAR (600) NULL,
    [crGroupCode]  INT           NOT NULL,
    [nameDescript] VARCHAR (700) NULL,
    CONSTRAINT [PK_CopyrightKind_1] PRIMARY KEY CLUSTERED ([codeI] ASC),
    CONSTRAINT [CKC_CODEI_COPYRIGH] CHECK ([codeI]>=(1)),
    CONSTRAINT [FK_COPYRIGH_REFERENCE_CRKINDGR] FOREIGN KEY ([crGroupCode]) REFERENCES [dbo].[CRKindGroup] ([codeI])
);






GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Наименование Типа авторского права', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CopyrightKind', @level2type = N'COLUMN', @level2name = N'name';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Код вида правообладателя', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CopyrightKind', @level2type = N'COLUMN', @level2name = N'codeI';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Справочник типов прав на объекты права', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CopyrightKind';


GO
GRANT SELECT
    ON OBJECT::[dbo].[CopyrightKind] TO [ReportUser]
    AS [dbo];

