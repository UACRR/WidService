CREATE TABLE [dbo].[RegisterListStatusTr] (
    [codeI] INT           NOT NULL,
    [lang]  CHAR (2)      NOT NULL,
    [name]  VARCHAR (100) NULL,
    CONSTRAINT [PK_REGISTERLISTSTATUSTR] PRIMARY KEY CLUSTERED ([codeI] ASC, [lang] ASC),
    CONSTRAINT [FK_REGISTERList_REF_REGISTERSt] FOREIGN KEY ([codeI]) REFERENCES [dbo].[RegisterListStatus] ([codeI])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Статус ведомости', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RegisterListStatusTr', @level2type = N'COLUMN', @level2name = N'codeI';

