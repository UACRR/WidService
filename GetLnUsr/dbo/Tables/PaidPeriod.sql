CREATE TABLE [dbo].[PaidPeriod] (
    [periodId]        INT           IDENTITY (1, 1) NOT NULL,
    [custId]          INT           NOT NULL,
    [periodType]      INT           NOT NULL,
    [licId]           INT           NOT NULL,
    [beginDate]       DATE          NOT NULL,
    [endDate]         DATE          NOT NULL,
    [status]          INT           NOT NULL,
    [amount]          MONEY         NOT NULL,
    [undistribamount] MONEY         NOT NULL,
    [distribamount]   MONEY         NOT NULL,
    [periodName]      VARCHAR (100) NOT NULL,
    [fagFirst]        BIT           NULL,
    [dateActPrint]    DATE          NULL,
    CONSTRAINT [PK_PAIDPERIOD] PRIMARY KEY CLUSTERED ([periodId] ASC),
    CONSTRAINT [FK_PAIDPERI_REFERENCE_CLIENT] FOREIGN KEY ([custId]) REFERENCES [dbo].[Client] ([custId]),
    CONSTRAINT [FK_PAIDPERI_REFERENCE_LICENSEA] FOREIGN KEY ([licId]) REFERENCES [dbo].[LicenseAgreement] ([licId]),
    CONSTRAINT [FK_PAIDPERI_REFERENCE_PERIOD] FOREIGN KEY ([periodType]) REFERENCES [dbo].[Period] ([codeI]),
    CONSTRAINT [FK_PAIDPERI_REFERENCE_PERIODST] FOREIGN KEY ([status]) REFERENCES [dbo].[PeriodStatus] ([codeI])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [uipaidperiod_001]
    ON [dbo].[PaidPeriod]([licId] ASC, [beginDate] ASC, [endDate] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [idx_paidPeriod01]
    ON [dbo].[PaidPeriod]([periodId] ASC, [periodName] ASC);


GO


create trigger tu_paidperiod01 on [dbo].[PaidPeriod] for update as
begin

	SET NOCOUNT ON;

	  update PaidPeriod set 
	  amount = t2.distribamount + t2.undistribamount
      from PaidPeriod t1
      join inserted t2 on t2.periodId = t1.periodId 
	  join deleted t3 on t3.periodId = t2.periodId 
					and ((t3.distribamount != t2.distribamount) or (t3.undistribamount != t2.undistribamount))
      where
      t2.amount < t2.distribamount + t2.undistribamount;
      
      return;


end

GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Періоди платежів по договорам Споживачів
   ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'PaidPeriod';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Идентификатор клиента (правообладателя или покупателя)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'PaidPeriod', @level2type = N'COLUMN', @level2name = N'custId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Сумма про договору', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'PaidPeriod', @level2type = N'COLUMN', @level2name = N'amount';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Признак первого периода', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'PaidPeriod', @level2type = N'COLUMN', @level2name = N'fagFirst';

