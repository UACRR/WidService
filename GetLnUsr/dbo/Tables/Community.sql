CREATE TABLE [dbo].[Community] (
    [custId]    INT          NOT NULL,
    [interCode] VARCHAR (25) NULL,
    [innerCode] VARCHAR (25) NULL,
    CONSTRAINT [PK_COMMUNITY] PRIMARY KEY CLUSTERED ([custId] ASC),
    CONSTRAINT [FK_COMMUNIT_REFERENCE_CUSTOMER] FOREIGN KEY ([custId]) REFERENCES [dbo].[Customer] ([custId])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Сообщества', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Community';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор клиента (правообладателя или покупателя)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Community', @level2type = N'COLUMN', @level2name = N'custId';

