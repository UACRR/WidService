CREATE TABLE [dbo].[EpisodeTypeTr] (
    [codeI] INT           NOT NULL,
    [lang]  CHAR (2)      NOT NULL,
    [name]  VARCHAR (200) NULL,
    CONSTRAINT [PK_EPISODETYPETR] PRIMARY KEY CLUSTERED ([codeI] ASC, [lang] ASC),
    CONSTRAINT [FK_EPISODET_REFERENCE_EPISODET] FOREIGN KEY ([codeI]) REFERENCES [dbo].[EpisodeType] ([codeI])
);

