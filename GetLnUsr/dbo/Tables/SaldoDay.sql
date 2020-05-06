CREATE TABLE [dbo].[SaldoDay] (
    [accId]          INT             NOT NULL,
    [dateBegin]      DATE            NOT NULL,
    [dateEnd]        DATE            NOT NULL,
    [r030]           CHAR (3)        NULL,
    [rest]           NUMERIC (20, 2) NULL,
    [restCourt]      NUMERIC (20, 2) NULL,
    [deboborot]      NUMERIC (20, 2) NULL,
    [krdOborot]      NUMERIC (20, 2) NULL,
    [deboborotCourt] NUMERIC (20, 2) NULL,
    [krdOborotCourt] NUMERIC (20, 2) NULL,
    [restBegin]      NUMERIC (20, 2) NULL,
    [restBeginCourt] NUMERIC (20, 2) NULL,
    CONSTRAINT [PK_saldoday] PRIMARY KEY CLUSTERED ([accId] ASC, [dateBegin] ASC, [dateEnd] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Таблица накопленных остатков и оборотов в разрезе рабочих дней', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SaldoDay';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор счета', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SaldoDay', @level2type = N'COLUMN', @level2name = N'accId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Дата начала периода', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SaldoDay', @level2type = N'COLUMN', @level2name = N'dateBegin';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Дата окончания периода', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SaldoDay', @level2type = N'COLUMN', @level2name = N'dateEnd';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Код валюты', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SaldoDay', @level2type = N'COLUMN', @level2name = N'r030';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Остаток в национальной валюте', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SaldoDay', @level2type = N'COLUMN', @level2name = N'rest';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Остаток в номинале валюты', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SaldoDay', @level2type = N'COLUMN', @level2name = N'restCourt';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Дебетовы оборот в национальной валюте', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SaldoDay', @level2type = N'COLUMN', @level2name = N'deboborot';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Кредитовый оборот в национальной валюте', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SaldoDay', @level2type = N'COLUMN', @level2name = N'krdOborot';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Дебетовый оборот в  валюте', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SaldoDay', @level2type = N'COLUMN', @level2name = N'deboborotCourt';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'кредитовый оборот в  валюте', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SaldoDay', @level2type = N'COLUMN', @level2name = N'krdOborotCourt';

