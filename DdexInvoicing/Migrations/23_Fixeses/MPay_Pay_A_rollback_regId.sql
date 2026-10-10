USE [MediaService]
GO
/****** Object:  StoredProcedure [dbo].[MPay_Pay_A_rollback_regId]    Script Date: 08.09.2026 0:02:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[MPay_Pay_A_rollback_regId] @regid int
as
begin
/*
[MPay_Pay_A_rollback_regId] 7425
*/
SET NOCOUNT ON;
declare @RetCode integer
set @RetCode = 0



	CREATE TABLE #PayTurn(
	TurnId						 int			NOT NULL,
	DateWork				date NOT NULL,
	ND							varchar(25)		NULL,
	NDDate					datetime	NULL,
	R030		char(3) null,
	AccIdDebet			 int			NULL,
	AccIdCredit			 int			NULL,
	AccDebet				varchar(25)			NULL,
	AccCredit				varchar(25)			NULL,
	Amount					numeric(20, 2	)	NULL,
	AmountCur				numeric(20, 2)	NULL,
	PayNote					varchar(200) 	NULL,
	DateOper				datetime						NOT NULL,
	PayStatus				int					 NULL,
	regId						int,
	distid					int,
	paidid				int null,
	custIdRh integer NULL,  --!T
 PRIMARY KEY CLUSTERED (	TurnId ASC,	DateWork ASC)
)

--drop table #saldo_turns

--select * from #doc

--отбор согласованных заявок

delete DocPreparePay
where 
--reqid=146
regId=@regId and
payStatus=10



declare @DateOper date
declare curso  cursor for   select    distinct dateWork from 
PayTurn
where
regId = @regId
			
    open curso
    fetch curso into   @DateOper                                   
     while @@fetch_status =0	
BEGIN
/*
if (exists (select 1 from payturn where regid=@regid and datework=@dateoper and amount<0))
goto new_fetch
*/
	 delete #PayTurn

			insert DocPreparePay( dateWork,regId,distId,nD,nDDate,accIdDebet,accIdCredit,accDebet,accCredit,amount,	amountCur,
									payNote,r030,dateOper,payStatus
									, custIdRh,paidid  --!T
									)
			select		dateWork,regId,distId,nD,nDDate,accIdDebet,accIdCredit,accDebet,accCredit,amount,	amountCur,
									payNote,r030,dateOper,10
									, custIdRh,regIItemId
from PayTurn
where 
--distid=1200
regId=@regId  and
dateWork=@DateOper


insert #PayTurn( TurnId,DateWork,ND,r030,NDDate,AccIdDebet,AccIdCredit,AccDebet,AccCredit,Amount,
							AmountCur,PayNote,DateOper,PayStatus,regId,distid,paidid
							,custIdRh  --T
							  )
  select 
							DocPayId,DateWork,ND,r030,NDDate,AccIdDebet,AccIdCredit,AccDebet,AccCredit,Amount,
							0,PayNote,getdate(),PayStatus,regId,distid,paidid
							,custIdRh --!T
							from DocPreparePay
where
--distid=1200
regId=@regId  and
dateWork=@DateOper
and
payStatus=10

/*
select * from #PayTurn
select * from payturn
where reqId=146
*/
if  @@ROWCOUNT<>0
--обработка согласованных заявок
BEGIN
	begin Transaction 
		BEGIN TRY


exec Pay_Pay_ASaldoDay_storno


--execute PayTurnExtra_form

select turnid,dateWork   into #d from PayTurn 
where 
--distid=1200
regId=@regId  and
dateWork=@DateOper


delete PayTurnExtra 
from #d t1,PayTurnExtra  t2
where
t1.turnid = t2.turnid		and
t1.dateWork =t2.dateWork



/*insert PayTurn( TurnId,DateWork,ND,NDDate,AccIdDebet,AccIdCredit,AccDebet,AccCredit,
						Amount,AmountCur,PayNote,R030,DateOper,PayStatus,regid,distid
						,custIdRh,regIItemId --T
						)  select 
 TurnId,DateWork,ND,NDDate,AccIdDebet,AccIdCredit,AccDebet,AccCredit,
						-Amount,-AmountCur,PayNote,'980',getdate(),paystatus,regId ,distid
						,custIdRh ,paidid --!T
from #PayTurn
*/
delete PayTurn
where
--distid=1200
regId=@regId  and
dateWork=@DateOper


delete t2
from #PayTurn t1,DocPreparePay t2
where 
t2.DocPayId=t1.TurnId

-- delete registercount
-- where
-- regId=@regId
-- 
-- delete  DistributionItem
-- where
-- regId=@regId

delete t2
from DistributionItem t1
	join registercount t2 on t1.regId = t2.RegId
where t1.regId = @regId

; with DistIds as (
	select distinct DistId
	from DistributionItem
	where regId = @regId
)
delete t1
from DistributionItem t1
	join DistIds t2 on t1.DistId = t2.DistId

-- 

declare @rollback_amount numeric(20,2)
set @rollback_amount= (select sum(amount)   from Distribution
where regId = @regid)

delete  Distribution
where
regId=@regId


update Register
set rgStatus =7,
paidAmount =0
where
regId=@regId
/*
update PaidPeriod set undistribamount = t1.distribamount, distribamount = 0 ,status = 1
  from PaidPeriod t1 
   join vRegister t2 on t2.regId = @regId and t2.periodId = t1.periodId

declare @periodId int
set @periodId = ( select periodId  from vRegister where regid = @regId )
delete MoneyPeriodLink where periodId = @periodId
*/
update PaidPeriod 
set 
undistribamount = t1.undistribamount + @rollback_amount, 
distribamount = t1.distribamount - @rollback_amount,
status=2
from PaidPeriod t1 
   join vRegister t2 on t2.regId = @regId and t2.periodId = t1.periodId


--select * from PaidPeriod t1 
   --join vRegister t2 on t2.regId = 7425 and t2.periodId = t1.periodId



IF @@TRANCOUNT > 0 commit tran
END TRY


BEGIN CATCH
  IF @@TRANCOUNT > 0 rollback tran
  

   SELECT   
        ERROR_NUMBER() AS ErrorNumber  
        ,ERROR_SEVERITY() AS ErrorSeverity  
        ,ERROR_STATE() AS ErrorState  
        ,ERROR_PROCEDURE() AS ErrorProcedure  
        ,ERROR_LINE() AS ErrorLine  
        ,ERROR_MESSAGE() AS ErrorMessage;  

 set @Retcode = 1

END CATCH

new_fetch:

fetch curso into   @DateOper
END
close curso 
deallocate curso  

return @Retcode
END

end
