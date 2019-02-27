CREATE TABLE [dbo].[AnketaPerson] (
    [custId]                 INT           NOT NULL,
    [version]                INT           NOT NULL,
    [status]                 INT           NOT NULL,
    [firstName]              VARCHAR (254) NULL,
    [surName]                VARCHAR (254) NULL,
    [lastName]               VARCHAR (254) NULL,
    [nikName]                VARCHAR (254) NULL,
    [sex]                    INT           NULL,
    [birthDate]              DATE          NULL,
    [phoneMobileMain]        VARCHAR (254) NULL,
    [phoneMobileExtra]       VARCHAR (254) NULL,
    [phoneHome]              VARCHAR (254) NULL,
    [eMail]                  VARCHAR (254) NULL,
    [citizenship]            CHAR (3)      NULL,
    [residency]              INT           NULL,
    [reCountry]              CHAR (3)      NULL,
    [reAddress]              VARCHAR (254) NULL,
    [inn]                    VARCHAR (254) NULL,
    [pUSeries]               VARCHAR (254) NULL,
    [pUNumber]               VARCHAR (254) NULL,
    [pUIssuedWho]            VARCHAR (254) NULL,
    [pUIssuedWhen]           DATE          NULL,
    [pFSeries]               VARCHAR (254) NULL,
    [pFNumber]               VARCHAR (254) NULL,
    [pFIssuedDate]           DATE          NULL,
    [pFValidity]             DATE          NULL,
    [buisNumberRegistration] VARCHAR (254) NULL,
    [buisDateRegistration]   DATE          NULL,
    [buisNumberPayer]        VARCHAR (254) NULL,
    [buisSertNumberPayer]    VARCHAR (254) NULL,
    [modifyDate]             DATETIME      NULL,
    [modifyLogin]            VARCHAR (100) NULL,
    [typeVAT]                INT           NULL,
    [reCity]                 VARCHAR (100) NULL,
    [faCountry]              CHAR (3)      NULL,
    [faCity]                 VARCHAR (100) NULL,
    [faAddress]              VARCHAR (254) NULL,
    [banAccId]               INT           NULL,
    [faRegion]               INT           NULL,
    [lang]                   CHAR (2)      NULL,
    [reRegion]               INT           NULL,
    [leCountry]              CHAR (3)      NULL,
    [leRegion]               INT           NULL,
    [leCity]                 VARCHAR (100) NULL,
    [leAddress]              VARCHAR (254) NULL,
    [lePostIndex]            VARCHAR (10)  NULL,
    CONSTRAINT [PK_ANKETAPERSON] PRIMARY KEY CLUSTERED ([custId] ASC, [version] ASC),
    CONSTRAINT [FK_ANKETAPE_ASSOCIATI_CUSTOMER] FOREIGN KEY ([custId]) REFERENCES [dbo].[Customer] ([custId]),
    CONSTRAINT [FK_ANKETAPE_ASSOCIATI_PERSON] FOREIGN KEY ([custId]) REFERENCES [dbo].[Person] ([custId]),
    CONSTRAINT [FK_ANKETAPE_REF_RegistCOUNTRY] FOREIGN KEY ([reCountry]) REFERENCES [dbo].[Country] ([countryCode]),
    CONSTRAINT [FK_ANKETAPE_REF_SitizCOUNTRY] FOREIGN KEY ([citizenship]) REFERENCES [dbo].[Country] ([countryCode]),
    CONSTRAINT [FK_ANKETAPE_REFERENCE_ANKETAST] FOREIGN KEY ([status]) REFERENCES [dbo].[AnketaStatus] ([codeI]),
    CONSTRAINT [FK_ANKETAPE_REFERENCE_BANKACCO] FOREIGN KEY ([banAccId]) REFERENCES [dbo].[BankAccount] ([banAccID]),
    CONSTRAINT [FK_ANKETAPE_REFERENCE_COUNTRY] FOREIGN KEY ([faCountry]) REFERENCES [dbo].[Country] ([countryCode]),
    CONSTRAINT [FK_ANKETAPE_REFERENCE_LANG] FOREIGN KEY ([lang]) REFERENCES [dbo].[Lang] ([codeS]),
    CONSTRAINT [FK_ANKETAPE_REFERENCE_REGFa] FOREIGN KEY ([faRegion]) REFERENCES [dbo].[Region] ([codeI]),
    CONSTRAINT [FK_ANKETAPE_REFERENCE_REGLe] FOREIGN KEY ([leRegion]) REFERENCES [dbo].[Region] ([codeI]),
    CONSTRAINT [FK_ANKETAPE_REFERENCE_REGRe] FOREIGN KEY ([reRegion]) REFERENCES [dbo].[Region] ([codeI]),
    CONSTRAINT [FK_ANKETAPE_REFERENCE_RESIDENT] FOREIGN KEY ([residency]) REFERENCES [dbo].[ResidentType] ([codeI]),
    CONSTRAINT [FK_ANKETAPE_REFERENCE_SEXTYPE] FOREIGN KEY ([sex]) REFERENCES [dbo].[SexType] ([codeI]),
    CONSTRAINT [FK_ANKETAPE_REFERENCE_TYPEVAT] FOREIGN KEY ([typeVAT]) REFERENCES [dbo].[TypeVAT] ([codeI])
);




GO
CREATE NONCLUSTERED INDEX [Association26_FK]
    ON [dbo].[AnketaPerson]([custId] ASC);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'СПД - Номер свидетельства регистрации плательщика НДС', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AnketaPerson', @level2type = N'COLUMN', @level2name = N'buisSertNumberPayer';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'СПД - Номер плательщика НДС', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AnketaPerson', @level2type = N'COLUMN', @level2name = N'buisNumberPayer';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'СПД - Дата регистрации', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AnketaPerson', @level2type = N'COLUMN', @level2name = N'buisDateRegistration';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'СПД - Номер регистрации', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AnketaPerson', @level2type = N'COLUMN', @level2name = N'buisNumberRegistration';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Загран. Паспорт-Срок действия', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AnketaPerson', @level2type = N'COLUMN', @level2name = N'pFValidity';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Загран. Паспорт-Дата выдачи', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AnketaPerson', @level2type = N'COLUMN', @level2name = N'pFIssuedDate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Загран. Паспорт-Номер', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AnketaPerson', @level2type = N'COLUMN', @level2name = N'pFNumber';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Загран. Паспорт-Серия', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AnketaPerson', @level2type = N'COLUMN', @level2name = N'pFSeries';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Паспорт Украины-Когда выдано', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AnketaPerson', @level2type = N'COLUMN', @level2name = N'pUIssuedWhen';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Паспорт Украины-Кем выдано', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AnketaPerson', @level2type = N'COLUMN', @level2name = N'pUIssuedWho';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Паспорт Украины-Номер', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AnketaPerson', @level2type = N'COLUMN', @level2name = N'pUNumber';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Паспорт Украины-Серия', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AnketaPerson', @level2type = N'COLUMN', @level2name = N'pUSeries';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'ИНН', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AnketaPerson', @level2type = N'COLUMN', @level2name = N'inn';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Адрес регистрации', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AnketaPerson', @level2type = N'COLUMN', @level2name = N'reAddress';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Страна регистрации', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AnketaPerson', @level2type = N'COLUMN', @level2name = N'reCountry';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Резидентность', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AnketaPerson', @level2type = N'COLUMN', @level2name = N'residency';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Гражданство', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AnketaPerson', @level2type = N'COLUMN', @level2name = N'citizenship';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'EMail', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AnketaPerson', @level2type = N'COLUMN', @level2name = N'eMail';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Домашний телефонный номер', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AnketaPerson', @level2type = N'COLUMN', @level2name = N'phoneHome';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Мобильный номер дополнительный', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AnketaPerson', @level2type = N'COLUMN', @level2name = N'phoneMobileExtra';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Мобильный номер основной', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AnketaPerson', @level2type = N'COLUMN', @level2name = N'phoneMobileMain';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Дата рождения', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AnketaPerson', @level2type = N'COLUMN', @level2name = N'birthDate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Пол', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AnketaPerson', @level2type = N'COLUMN', @level2name = N'sex';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Псевдоним', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AnketaPerson', @level2type = N'COLUMN', @level2name = N'nikName';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Фамилия', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AnketaPerson', @level2type = N'COLUMN', @level2name = N'lastName';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Отчество', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AnketaPerson', @level2type = N'COLUMN', @level2name = N'surName';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Имя', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AnketaPerson', @level2type = N'COLUMN', @level2name = N'firstName';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Статус анкеты', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AnketaPerson', @level2type = N'COLUMN', @level2name = N'status';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Версия', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AnketaPerson', @level2type = N'COLUMN', @level2name = N'version';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор клиента (правообладателя или покупателя)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AnketaPerson', @level2type = N'COLUMN', @level2name = N'custId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Анкета клиента физического лица', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AnketaPerson';


GO
CREATE UNIQUE NONCLUSTERED INDEX [UI_AnketaPerson_Email]
    ON [dbo].[AnketaPerson]([eMail] ASC) WHERE ([email] IS NOT NULL);

