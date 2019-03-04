CREATE procedure [dbo].[MPay_Pay_A_rollback_turnid] @turnid integer
as
begin
/*
[MPay_Pay_A_rollback_turnid] 11047
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

/*
declare @turnid int
set @turnid=11076
	 */--delete #PayTurn
	 
			insert DocPreparePay( dateWork,regId,distId,nD,nDDate,accIdDebet,accIdCredit,accDebet,accCredit,amount,	amountCur,
									payNote,r030,dateOper,payStatus
									, custIdRh ,paidid --!T
									)
			select		dateWork,regId,distId,nD,nDDate,accIdDebet,accIdCredit,accDebet,accCredit,amount,	amountCur,
									payNote,r030,dateOper,10
									, custIdRh,regIItemId
from PayTurn
where 

--distid=1200
turnid=@turnid


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
paystatus=10

/*
select * from #PayTurn
select * from payturn
where reqId=146
*/
if  @@ROWCOUNT<>0
BEGIN
	begin Transaction 
		BEGIN TRY


exec Pay_Pay_ASaldoDay_storno
execute PayTurnExtra_form
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


return @Retcode
END

end