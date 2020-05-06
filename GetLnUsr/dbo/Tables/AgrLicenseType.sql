CREATE TABLE [dbo].[AgrLicenseType] (
    [codeI]        INT             NOT NULL,
    [name]         VARCHAR (100)   NULL,
    [kindCode]     INT             NULL,
    [usesKind]     INT             NULL,
    [templateName] VARCHAR (256)   NULL,
    [needPlace]    BIT             NULL,
    [schemaId]     INT             NULL,
    [algorithmId]  INT             NULL,
    [series]       VARCHAR (10)    NULL,
    [authRate]     NUMERIC (10, 5) NULL,
    [isPortal]     SMALLINT        NULL,
    CONSTRAINT [PK_ARGLICENSETYPE] PRIMARY KEY CLUSTERED ([codeI] ASC),
    CONSTRAINT [FK_AGRLICEN_REFERENCE_COPYRIGH] FOREIGN KEY ([kindCode]) REFERENCES [dbo].[CopyrightKind] ([codeI]),
    CONSTRAINT [FK_AGRLICEN_REFERENCE_USESKIND] FOREIGN KEY ([usesKind]) REFERENCES [dbo].[UsesKind] ([codeI]),
    CONSTRAINT [FK_AGRLICENTYPE_REF_ALGORITH] FOREIGN KEY ([algorithmId]) REFERENCES [dbo].[AlgorithmType] ([codeI])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Виды лицензиолнных договоров', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AgrLicenseType';

