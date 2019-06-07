CREATE TABLE [dbo].[RightHolder] (
    [custId]      INT          NOT NULL,
    [signP]       TINYINT      NULL,
    [aroundWord]  BIT          NULL,
    [interCode]   VARCHAR (25) NULL,
    [innerCode]   VARCHAR (25) NULL,
    [rHolderType] INT          DEFAULT ((1)) NULL,
    CONSTRAINT [PK_RIGHTHOLDER] PRIMARY KEY CLUSTERED ([custId] ASC),
    CONSTRAINT [FK_RIGHTHOL_REFERENCE_CUSTOMER] FOREIGN KEY ([custId]) REFERENCES [dbo].[Customer] ([custId])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор клиента (правообладателя или покупателя)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RightHolder', @level2type = N'COLUMN', @level2name = N'custId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Правообладатели', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RightHolder';

