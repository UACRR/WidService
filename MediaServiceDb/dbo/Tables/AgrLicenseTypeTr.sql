CREATE TABLE [dbo].[AgrLicenseTypeTr] (
    [codeI] INT           NOT NULL,
    [lang]  CHAR (2)      NOT NULL,
    [name]  VARCHAR (100) NULL,
    CONSTRAINT [PK_ARGLICENSETYPETR] PRIMARY KEY CLUSTERED ([codeI] ASC, [lang] ASC),
    CONSTRAINT [FK_ARGLICEN_REFERENCE_ARGLICEN] FOREIGN KEY ([codeI]) REFERENCES [dbo].[AgrLicenseType] ([codeI]) ON DELETE CASCADE ON UPDATE CASCADE
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Виды лицензиолнных договоров', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AgrLicenseTypeTr';

