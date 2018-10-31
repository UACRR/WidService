CREATE TABLE [dbo].[KindSerialTr] (
    [codeI] INT           NOT NULL,
    [lang]  CHAR (2)      NOT NULL,
    [name]  VARCHAR (200) NULL,
    CONSTRAINT [PK_KINDSERIALTR] PRIMARY KEY CLUSTERED ([codeI] ASC, [lang] ASC),
    CONSTRAINT [FK_KINDSERI_REFERENCE_KINDSERI] FOREIGN KEY ([codeI]) REFERENCES [dbo].[KindSerial] ([codeI])
);

