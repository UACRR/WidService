CREATE TABLE [dbo].[TypePlaceParamTr] (
    [codeI] INT           NOT NULL,
    [lang]  CHAR (2)      NOT NULL,
    [name]  VARCHAR (100) NOT NULL,
    CONSTRAINT [PK_TYPEPLACEPARAMTR] PRIMARY KEY CLUSTERED ([codeI] ASC, [lang] ASC),
    CONSTRAINT [FK_TYPEPLAC_REF_TYPEPLACTR] FOREIGN KEY ([codeI]) REFERENCES [dbo].[TypePlaceParam] ([codeI])
);

