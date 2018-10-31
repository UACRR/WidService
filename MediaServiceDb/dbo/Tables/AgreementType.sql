CREATE TABLE [dbo].[AgreementType] (
    [codeI]        INT           NOT NULL,
    [name]         VARCHAR (100) NULL,
    [templateName] VARCHAR (256) NULL,
    CONSTRAINT [PK_AGREEMENTTYPE] PRIMARY KEY CLUSTERED ([codeI] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Тип договора - Клиентский, с правообладаетем, с партнером', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AgreementType';

