CREATE TABLE [dbo].[Partner] (
    [custId] INT NOT NULL,
    CONSTRAINT [PK_PARTNER] PRIMARY KEY CLUSTERED ([custId] ASC),
    CONSTRAINT [FK_PARTNER_REFERENCE_CUSTOMER] FOREIGN KEY ([custId]) REFERENCES [dbo].[Customer] ([custId])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор Партнера', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Partner', @level2type = N'COLUMN', @level2name = N'custId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Партнеры', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Partner';

