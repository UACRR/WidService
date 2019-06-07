CREATE TABLE [dbo].[EtGenreRate] (
    [actCode]   INT             NOT NULL,
    [genreCode] INT             NOT NULL,
    [rate]      NUMERIC (10, 5) NULL,
    CONSTRAINT [PK_ETGENRERATE] PRIMARY KEY CLUSTERED ([actCode] ASC, [genreCode] ASC),
    CONSTRAINT [FK_ETGENRER_REF_ETGENRE] FOREIGN KEY ([genreCode]) REFERENCES [dbo].[EtGenre] ([codeI]),
    CONSTRAINT [FK_ETGENRER_REFERENCE_ACT] FOREIGN KEY ([actCode]) REFERENCES [dbo].[ObjAct] ([codeI])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'зЗагальний процент за постановку', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'EtGenreRate';

