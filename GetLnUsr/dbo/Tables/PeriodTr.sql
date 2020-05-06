CREATE TABLE [dbo].[PeriodTr] (
    [codeI] INT           NOT NULL,
    [lang]  CHAR (2)      NOT NULL,
    [name]  VARCHAR (100) NULL,
    [nameR] VARCHAR (100) NULL,
    CONSTRAINT [PK_PERIODTR] PRIMARY KEY CLUSTERED ([codeI] ASC, [lang] ASC),
    CONSTRAINT [FK_PERIODTR_REFERENCE_PERIOD] FOREIGN KEY ([codeI]) REFERENCES [dbo].[Period] ([codeI]) ON DELETE CASCADE ON UPDATE CASCADE
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Періодичність сплати платежів', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'PeriodTr';

