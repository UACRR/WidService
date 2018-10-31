CREATE TABLE [dbo].[TypeVAT] (
    [codeI] INT           NOT NULL,
    [name]  VARCHAR (200) NULL,
    CONSTRAINT [PK_TYPEVAT] PRIMARY KEY CLUSTERED ([codeI] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Довідник платника НДС (1-платник НДС, 2-не платник НДС)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'TypeVAT';

