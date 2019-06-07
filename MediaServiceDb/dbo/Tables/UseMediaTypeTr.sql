CREATE TABLE [dbo].[UseMediaTypeTr] (
    [codeI] INT           NOT NULL,
    [lang]  CHAR (2)      NOT NULL,
    [name]  VARCHAR (200) NULL,
    CONSTRAINT [PK_USEMEDIATYPETR] PRIMARY KEY CLUSTERED ([codeI] ASC, [lang] ASC),
    CONSTRAINT [FK_USEMEDIA_REFERENCE_USEMEDIA] FOREIGN KEY ([codeI]) REFERENCES [dbo].[UseMediaType] ([codeI])
);

