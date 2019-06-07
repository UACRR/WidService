CREATE TABLE [dbo].[CounterNumber] (
    [counterId] INT           IDENTITY (1, 1) NOT NULL,
    [name]      VARCHAR (100) NULL,
    [cNum]      INT           NULL,
    [prefix]    VARCHAR (10)  NULL,
    [symbolN]   CHAR (1)      NULL,
    [templYear] SMALLINT      DEFAULT (NULL) NULL,
    CONSTRAINT [PK_COUNTERNUMBER] PRIMARY KEY CLUSTERED ([counterId] ASC),
    CONSTRAINT [CKC_TEMPLYEAR_COUNTERN] CHECK ([templYear] IS NULL OR ([templYear]=(4) OR [templYear]=(2) OR [templYear]=(0)))
);

