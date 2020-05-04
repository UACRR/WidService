CREATE procedure [dbo].[Pay_Pay_A_rollback_regId] @regId integer
as
begin
/*
[Pay_Pay_A_rollback_regId] 2336
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
	 delete #PayTurn

			insert DocPreparePay( dateWork,regId,distId,nD,nDDate,accIdDebet,accIdCredit,accDebet,accCredit,amount,	amountCur,
									payNote,r030,dateOper,payStatus
									, custIdRh  --!T
									)
			select		dateWork,regId,distId,nD,nDDate,accIdDebet,accIdCredit,accDebet,accCredit,amount,	amountCur,
									payNote,r030,dateOper,10
									, custIdRh
from PayTurn
where 
--distid=1200
regId=@regId  and
dateWork=@DateOper


insert #PayTurn( TurnId,DateWork,ND,NDDate,AccIdDebet,AccIdCredit,AccDebet,AccCredit,Amount,
							AmountCur,PayNote,DateOper,PayStatus,regId,distid,paidid
							,custIdRh  --T
							  )
  select 
							DocPayId,DateWork,ND,NDDate,AccIdDebet,AccIdCredit,AccDebet,AccCredit,Amount,
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

insert PayTurn( TurnId,DateWork,ND,NDDate,AccIdDebet,AccIdCredit,AccDebet,AccCredit,
						Amount,AmountCur,PayNote,R030,DateOper,PayStatus,regid,distid
						,custIdRh,regIItemId --T
						)  select 
 TurnId,DateWork,ND,NDDate,AccIdDebet,AccIdCredit,AccDebet,AccCredit,
						-Amount,-AmountCur,PayNote,'980',getdate(),paystatus,regId ,distid
						,custIdRh ,paidid --!T
from #PayTurn

delete t2
from #PayTurn t1,DocPreparePay t2
where 
t2.DocPayId=t1.TurnId


-- 
delete  Distribution
where
regId=@regId

delete  DistributionItem
where
regId=@regId

delete registercount
where
regId=@regId



update Register
set rgStatus =0
where
regId=@regId


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
fetch curso into   @DateOper
END
close curso 
deallocate curso  

return @Retcode
END

end



