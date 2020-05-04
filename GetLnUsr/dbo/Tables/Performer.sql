CREATE TABLE [dbo].[Performer] (
    [perId]   INT           IDENTITY (1, 1) NOT NULL,
    [perName] VARCHAR (200) NULL,
    CONSTRAINT [PK_PERFOMER] PRIMARY KEY CLUSTERED ([perId] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Таблиця виконавців', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Performer';

