CREATE TABLE [dbo].[AnketaAddNick] (
    [addId]   INT           IDENTITY (1, 1) NOT NULL,
    [custId]  INT           NOT NULL,
    [nikName] VARCHAR (254) NULL,
    CONSTRAINT [PK_ANKETAADD] PRIMARY KEY CLUSTERED ([addId] ASC),
    CONSTRAINT [FK_ANKETAAD_REFERENCE_RIGHTHOL] FOREIGN KEY ([custId]) REFERENCES [dbo].[RightHolder] ([custId])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Псевдоним', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AnketaAddNick', @level2type = N'COLUMN', @level2name = N'nikName';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор клиента (правообладателя или покупателя)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AnketaAddNick', @level2type = N'COLUMN', @level2name = N'custId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Дополнительные имена для Авторов', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AnketaAddNick';

