CREATE TABLE [dbo].[RequestTypeTr] (
    [codeI] INT           NOT NULL,
    [lang]  CHAR (2)      NOT NULL,
    [name]  VARCHAR (512) NULL,
    CONSTRAINT [PK_REQUESTTYPETR] PRIMARY KEY CLUSTERED ([codeI] ASC, [lang] ASC),
    CONSTRAINT [FK_REQUESTT_REF_REQUESTTR] FOREIGN KEY ([codeI]) REFERENCES [dbo].[RequestType] ([codeI])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Код типа заявки', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'RequestTypeTr', @level2type = N'COLUMN', @level2name = N'codeI';

