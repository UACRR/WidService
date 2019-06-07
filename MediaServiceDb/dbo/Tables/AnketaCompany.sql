CREATE TABLE [dbo].[AnketaCompany] (
    [custId]        INT           NOT NULL,
    [version]       INT           NOT NULL,
    [activityCode]  INT           NULL,
    [status]        INT           NOT NULL,
    [name]          VARCHAR (254) NULL,
    [shortName]     VARCHAR (254) NULL,
    [faAddress]     VARCHAR (254) NULL,
    [jaAddress]     VARCHAR (254) NULL,
    [okpo]          VARCHAR (254) NULL,
    [registrDate]   DATE          NULL,
    [typeVAT]       INT           NULL,
    [numberVAT]     VARCHAR (254) NULL,
    [modifyDate]    DATETIME      NULL,
    [modifyLogin]   VARCHAR (100) NULL,
    [jaCity]        VARCHAR (100) NULL,
    [faCity]        VARCHAR (100) NULL,
    [jaCountry]     CHAR (3)      NULL,
    [faCountry]     CHAR (3)      NULL,
    [banAccId]      INT           NULL,
    [jaRegion]      INT           NULL,
    [faRegion]      INT           NULL,
    [registrNumber] VARCHAR (254) NULL,
    [registrWho]    VARCHAR (254) NULL,
    [leCity]        VARCHAR (100) NULL,
    [leCountry]     CHAR (3)      NULL,
    [lePostIndex]   VARCHAR (10)  NULL,
    [leRegion]      INT           NULL,
    [leAddress]     VARCHAR (254) NULL,
    CONSTRAINT [PK_ANKETACOMPANY] PRIMARY KEY CLUSTERED ([custId] ASC, [version] ASC),
    CONSTRAINT [FK_ANKETACO_ASSOCIATI_COMPANY] FOREIGN KEY ([custId]) REFERENCES [dbo].[Company] ([custId]),
    CONSTRAINT [FK_ANKETACO_ASSOCIATI_CUSTOMER] FOREIGN KEY ([custId]) REFERENCES [dbo].[Customer] ([custId]),
    CONSTRAINT [FK_ANKETACO_REF_FaCOUNTRY] FOREIGN KEY ([faCountry]) REFERENCES [dbo].[Country] ([countryCode]),
    CONSTRAINT [FK_ANKETACO_REF_jaCOUNTRY] FOREIGN KEY ([jaCountry]) REFERENCES [dbo].[Country] ([countryCode]),
    CONSTRAINT [FK_ANKETACO_REF_LEREGION] FOREIGN KEY ([leRegion]) REFERENCES [dbo].[Region] ([codeI]),
    CONSTRAINT [FK_ANKETACO_REFERENCE_ACTIVITY] FOREIGN KEY ([activityCode]) REFERENCES [dbo].[ActivityType] ([codeI]),
    CONSTRAINT [FK_ANKETACO_REFERENCE_ANKETAST] FOREIGN KEY ([status]) REFERENCES [dbo].[AnketaStatus] ([codeI]),
    CONSTRAINT [FK_ANKETACO_REFERENCE_BANKACCO] FOREIGN KEY ([banAccId]) REFERENCES [dbo].[BankAccount] ([banAccID]),
    CONSTRAINT [FK_ANKETACO_REFERENCE_COUNTRY] FOREIGN KEY ([leCountry]) REFERENCES [dbo].[Country] ([countryCode]),
    CONSTRAINT [FK_ANKETACO_REFERENCE_REGFA] FOREIGN KEY ([faRegion]) REFERENCES [dbo].[Region] ([codeI]),
    CONSTRAINT [FK_ANKETACO_REFERENCE_REGION] FOREIGN KEY ([jaRegion]) REFERENCES [dbo].[Region] ([codeI]),
    CONSTRAINT [FK_ANKETACO_REFERENCE_REGJA] FOREIGN KEY ([jaRegion]) REFERENCES [dbo].[Region] ([codeI]),
    CONSTRAINT [FK_ANKETACO_REFERENCE_TYPEVAT] FOREIGN KEY ([typeVAT]) REFERENCES [dbo].[TypeVAT] ([codeI]),
    CONSTRAINT [FK_ANKETALE_REF_LECOUNTRY] FOREIGN KEY ([leCountry]) REFERENCES [dbo].[Country] ([countryCode])
);


GO
CREATE NONCLUSTERED INDEX [Association26_FK]
    ON [dbo].[AnketaCompany]([custId] ASC);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Номер плательщика НДС', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AnketaCompany', @level2type = N'COLUMN', @level2name = N'numberVAT';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'тип плательщика НДС', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AnketaCompany', @level2type = N'COLUMN', @level2name = N'typeVAT';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Дата регистрации', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AnketaCompany', @level2type = N'COLUMN', @level2name = N'registrDate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'ЕДРПОУ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AnketaCompany', @level2type = N'COLUMN', @level2name = N'okpo';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Юридический адрес - адрес', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AnketaCompany', @level2type = N'COLUMN', @level2name = N'jaAddress';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Фактический адрес - адрес', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AnketaCompany', @level2type = N'COLUMN', @level2name = N'faAddress';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Сокращенное наименование юридического лица', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AnketaCompany', @level2type = N'COLUMN', @level2name = N'shortName';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Полное наименование юридического лица', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AnketaCompany', @level2type = N'COLUMN', @level2name = N'name';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Статус анкеты', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AnketaCompany', @level2type = N'COLUMN', @level2name = N'status';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Код вида деятельности', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AnketaCompany', @level2type = N'COLUMN', @level2name = N'activityCode';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Версия', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AnketaCompany', @level2type = N'COLUMN', @level2name = N'version';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор клиента (правообладателя или покупателя)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AnketaCompany', @level2type = N'COLUMN', @level2name = N'custId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Анкета клиента юридического лица', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AnketaCompany';

