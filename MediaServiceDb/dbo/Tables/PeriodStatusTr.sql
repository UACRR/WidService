CREATE TABLE [dbo].[PeriodStatusTr] (
    [codeI] INT           NOT NULL,
    [name]  VARCHAR (100) NOT NULL,
    [lang]  CHAR (2)      NOT NULL,
    CONSTRAINT [PK_PERIODSTATUSTR] PRIMARY KEY CLUSTERED ([codeI] ASC),
    CONSTRAINT [FK_PERIODST_REFERENCE_PERIODST] FOREIGN KEY ([codeI]) REFERENCES [dbo].[PeriodStatus] ([codeI])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Язык ФИО оригинал', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'PeriodStatusTr', @level2type = N'COLUMN', @level2name = N'lang';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Код категории объекта автоского права', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'PeriodStatusTr', @level2type = N'COLUMN', @level2name = N'codeI';

