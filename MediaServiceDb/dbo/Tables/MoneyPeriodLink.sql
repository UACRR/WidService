CREATE TABLE [dbo].[MoneyPeriodLink] (
    [periodId]   INT   NOT NULL,
    [paidId]     INT   NOT NULL,
    [licId]      INT   NOT NULL,
    [modifyDate] DATE  NOT NULL,
    [amount]     MONEY NOT NULL,
    [status]     INT   NULL,
    CONSTRAINT [PK_MONEYPERIODLINK] PRIMARY KEY CLUSTERED ([paidId] ASC, [periodId] ASC, [licId] ASC),
    CONSTRAINT [FK_MONEYPER_REFERENCE_LICENSEA] FOREIGN KEY ([licId]) REFERENCES [dbo].[LicenseAgreement] ([licId]),
    CONSTRAINT [FK_MONEYPER_REFERENCE_MONEYLIN] FOREIGN KEY ([status]) REFERENCES [dbo].[MoneyLinkStatus] ([codeI]),
    CONSTRAINT [FK_MONEYPER_REFERENCE_MONEYREC] FOREIGN KEY ([paidId]) REFERENCES [dbo].[MoneyReceived] ([paidId]),
    CONSTRAINT [FK_MONEYPER_REFERENCE_PAIDPERI] FOREIGN KEY ([periodId]) REFERENCES [dbo].[PaidPeriod] ([periodId])
);


GO


create trigger tu_MoneyPeriodLink01 on MoneyPeriodLink for update as
begin
   declare @rowcount int,
			@errno int,
			@errmsg varchar(100);
   
   select @rowcount = count(*) from inserted;
   set @errno = 14001;
   set @errmsg = 'Changed distributed sum';
   update  PaidPeriod set 
   Undistribamount = Undistribamount + t2.Amount - t3.Amount
   from PaidPeriod t1
   join inserted t2 on t2.PeriodId = t1.PeriodId
   join deleted t3 on t3.PeriodId = t1.PeriodId
   where t1.undistribamount + t2.amount - t3.amount >=0
   
   if @@rowcount <> @rowcount
   goto error

   update  MoneyReceived set 
   DestribAmount = DestribAmount + t2.Amount - t3.Amount
   from MoneyReceived t1
   join inserted t2 on t2.PaidId = t1.PaidId
   join deleted t3 on t3.PaidId = t1.PaidId
   
   


      return

/*  Errors handling  */
error:
    raiserror( @errno,-1,-1, @errmsg )
    rollback  transaction
end
GO


create trigger ti_MoneyPeriodLink01 on MoneyPeriodLink for insert as
begin
    declare
       @maxcard  int,
       @numrows  int,
       @numnull  int,
       @errno    int,
       @errmsg   varchar(255)

    select  @numrows = @@rowcount
    if @numrows = 0
       return;

    
    with moneyLink as
    (
    select paidId, sum(amount) as amount from inserted group by paidId
    )
    update MoneyReceived set
    destribAmount = destribAmount + t2.amount
    from 
    MoneyReceived t1
    join moneyLink t2 on t2.paidId = t1.paidId;
    
    with moneyLink as
    (
    select periodId, sum(amount) as amount from inserted group by periodId
    )
    update PaidPeriod set
    undistribamount = undistribamount + t2.amount
    from 
    PaidPeriod t1
    join moneyLink t2 on t2.periodId = t1.periodId;
    

    return;

/*  Errors handling  */
error:
    raiserror (@errno, 5000, 1, @errmsg )
    rollback  transaction
end
GO


create trigger td_MoneyPeriodLink01 on MoneyPeriodLink for delete as
begin
    declare
       @numrows  int,
       @errno    int,
       @errmsg   varchar(255)

    select  @numrows = @@rowcount
    if @numrows = 0
       return;
       
    with moneyLink as
    (
    select paidId, sum(amount) as amount from deleted group by paidId
    )
    update MoneyReceived set
    destribAmount = destribAmount - t2.amount
    from 
    MoneyReceived t1
    join moneyLink t2 on t2.paidId = t1.paidId;
    
    with moneyLink as
    (
    select periodId, sum(amount) as amount from deleted group by periodId
    )
    update PaidPeriod set
    undistribamount = undistribamount - t2.amount
    from 
    PaidPeriod t1
    join moneyLink t2 on t2.periodId = t1.periodId;


    return

/*  Errors handling  */
error:
    raiserror (@errno,50000,1, @errmsg)
    rollback  transaction
end