CREATE TABLE [dbo].[UsesKind] (
    [codeI]    INT           NOT NULL,
    [usesType] INT           NULL,
    [name]     VARCHAR (100) NOT NULL,
    CONSTRAINT [PK_USESKIND] PRIMARY KEY CLUSTERED ([codeI] ASC),
    CONSTRAINT [FK_USESKIND_REFERENCE_USESTYPE] FOREIGN KEY ([usesType]) REFERENCES [dbo].[UsesType] ([codeI])
);

