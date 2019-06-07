CREATE TABLE [dbo].[EtGenreRole] (
    [genreCode] INT             NOT NULL,
    [roleCode]  INT             NOT NULL,
    [actCode]   INT             NOT NULL,
    [rate]      NUMERIC (10, 5) NULL,
    CONSTRAINT [PK_ETGENREROLE] PRIMARY KEY CLUSTERED ([genreCode] ASC, [roleCode] ASC, [actCode] ASC),
    CONSTRAINT [FK_ETGENRER_REFERENCE_ETGENRE] FOREIGN KEY ([genreCode]) REFERENCES [dbo].[EtGenre] ([codeI]),
    CONSTRAINT [FK_ETGENRER_REFERENCE_ETROLE] FOREIGN KEY ([roleCode]) REFERENCES [dbo].[EtRole] ([codeI]),
    CONSTRAINT [FK_ETGENRER_REFERENCE_OBJACT] FOREIGN KEY ([actCode]) REFERENCES [dbo].[ObjAct] ([codeI])
);

