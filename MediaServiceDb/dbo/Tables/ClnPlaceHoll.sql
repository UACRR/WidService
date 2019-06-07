CREATE TABLE [dbo].[ClnPlaceHoll] (
    [hollId]     INT           IDENTITY (1, 1) NOT NULL,
    [placeId]    INT           NULL,
    [hollName]   VARCHAR (100) NULL,
    [valuePlace] VARCHAR (256) NULL,
    [valueAdd]   VARCHAR (256) NULL,
    CONSTRAINT [PK_CLNPLACEHOLL] PRIMARY KEY CLUSTERED ([hollId] ASC),
    CONSTRAINT [FK_CLNPLACE_REFERENCE_CLNBUSIN] FOREIGN KEY ([placeId]) REFERENCES [dbo].[ClnBusinessPlace] ([placeId])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Залы майданчика клиента', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ClnPlaceHoll';

