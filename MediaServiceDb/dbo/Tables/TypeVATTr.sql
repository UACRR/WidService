CREATE TABLE [dbo].[TypeVATTr] (
    [codeI] INT           NOT NULL,
    [lang]  CHAR (2)      NOT NULL,
    [name]  VARCHAR (200) NULL,
    CONSTRAINT [PK_TYPEVATTR] PRIMARY KEY CLUSTERED ([codeI] ASC, [lang] ASC),
    CONSTRAINT [FK_TYPEVATT_REFERENCE_TYPEVAT] FOREIGN KEY ([codeI]) REFERENCES [dbo].[TypeVAT] ([codeI])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Довідник платника НДС (1-платник НДС, 2-не платник НДС)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'TypeVATTr';

