CREATE TABLE [dbo].[EtGenre] (
    [codeI]        INT           NOT NULL,
    [name]         VARCHAR (100) NULL,
    [categoryCode] INT           NULL,
    CONSTRAINT [PK_ETGENRE] PRIMARY KEY CLUSTERED ([codeI] ASC),
    CONSTRAINT [FK_ETGENRE_REFERENCE_CATEGORY] FOREIGN KEY ([categoryCode]) REFERENCES [dbo].[Category] ([codeI])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Эталонные жанры по 72-й постанове', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'EtGenre';

