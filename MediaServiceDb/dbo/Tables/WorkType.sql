CREATE TABLE [dbo].[WorkType] (
    [codeI] INT           NOT NULL,
    [name]  VARCHAR (100) NULL,
    CONSTRAINT [PK_WORKTYPE] PRIMARY KEY CLUSTERED ([codeI] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Довідник типів роботи з авторами:
   1-Сформовано запит
   2-Зв''язок втановлено
   3-Угода
   4- Відмова 
   ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'WorkType';

