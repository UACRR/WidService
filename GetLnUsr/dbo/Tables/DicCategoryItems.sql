CREATE TABLE [dbo].[DicCategoryItems] (
    [dicName]  VARCHAR (256) NOT NULL,
    [code]     INT           NOT NULL,
    [name]     VARCHAR (256) NOT NULL,
    [url]      VARCHAR (256) NOT NULL,
    [dicType]  CHAR (1)      NULL,
    [dicLevel] INT           NULL,
    CONSTRAINT [PK_DICCATEGORYITEMS] PRIMARY KEY CLUSTERED ([dicName] ASC),
    CONSTRAINT [FK_DICCATEG_REFERENCE_DICTCATE] FOREIGN KEY ([code]) REFERENCES [dbo].[DictCategory] ([code])
);

