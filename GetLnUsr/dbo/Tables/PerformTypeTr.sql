CREATE TABLE [dbo].[PerformTypeTr] (
    [codeI] INT           NOT NULL,
    [lang]  CHAR (2)      NOT NULL,
    [name]  VARCHAR (100) NULL,
    CONSTRAINT [PK_PERFORMTYPETTR] PRIMARY KEY CLUSTERED ([codeI] ASC, [lang] ASC),
    CONSTRAINT [FK_PERFORMT_REFERENCE_PERFORMT] FOREIGN KEY ([codeI]) REFERENCES [dbo].[PerformType] ([codeI])
);

