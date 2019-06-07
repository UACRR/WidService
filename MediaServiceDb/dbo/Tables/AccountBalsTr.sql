CREATE TABLE [dbo].[AccountBalsTr] (
    [codeI] INT           NOT NULL,
    [lang]  CHAR (2)      NOT NULL,
    [name]  VARCHAR (256) NULL,
    CONSTRAINT [PK_ACCOUNTBALSTR] PRIMARY KEY CLUSTERED ([codeI] ASC, [lang] ASC),
    CONSTRAINT [FK_ACCOUNTB_REFERENCE_ACCOUNTB] FOREIGN KEY ([codeI]) REFERENCES [dbo].[AccountBals] ([codeI])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Название категории права', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AccountBalsTr', @level2type = N'COLUMN', @level2name = N'name';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Код характеристики (балансовый счет)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AccountBalsTr', @level2type = N'COLUMN', @level2name = N'codeI';

