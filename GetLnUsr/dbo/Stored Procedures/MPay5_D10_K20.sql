CREATE procedure [dbo].[MPay5_D10_K20]
as
begin
/*
*/
SET NOCOUNT ON;
declare @RetCode integer
set @RetCode = 0
--drop table #Doc
  declare @end_date date
  declare @cur_date date
  select @end_date=EOMONTH(getdate())
  select @cur_date= convert(date,getdate())
  
--if @end_date<>@cur_date
--return 0

create table #Doc(
CustID			int ,
accidCredit	int,
AccCredit		varchar(25),
accIdDebet			int,
AccDebet	varchar(25),
amount		money,
primary key (custId,accidCredit)
)


CREATE TABLE #PayTurn(
	TurnId						 int			NOT NULL,
	DateWork				date NOT NULL,
	ND							varchar(25)		NULL,
	NDDate					datetime	NULL,
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
	payturntype				int null,
 PRIMARY KEY CLUSTERED (	TurnId ASC,	DateWork ASC)
)

--select * from #doc


insert #doc (CustID	,accidCredit,AccCredit	,accIdDebet,AccDebet	,amount	
					)
select distinct
				t6.CustId,t6.accId,t6.accNls,t8.accid,t8.accNls,t7.rest
from
		Account t6,SaldoDay t7,Account t8
where
		t6.balsCode in (20,11,40)
		and t7.accId=t6.accId
		and t7.dateEnd='30000101'
		and t7.rest>0
		and  t8.accNls='100001'

 	if @@error	<> 0
		goto __retErr
goto   __forward

__retErr:

return 1

__forward:



if  @@ROWCOUNT=0
return 0

BEGIN
	begin Transaction 
		BEGIN TRY

--формируем платежные документы                                         
insert DocPreparePay( dateWork,regId,distId,nD,nDDate,accIdDebet,accIdCredit,accDebet,accCredit,
			amount,amountCur,payNote,r030,dateOper,payStatus,paidid)
select  convert(date,getdate()),null,null,null,convert(date,getdate()),accIdDebet,accIdCredit,accDebet,accCredit,
			amount ,amount,'Переказ коштів до 1С','980',convert(date,getdate()),1,null			
			  from #Doc

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
END
--проплата документов
declare @DateOper date
declare curso  cursor for   select    distinct dateWork from 
 DocPreparePay
where
	PayStatus=1				and
	AccCredit='21'	
	open curso
    fetch curso into   @DateOper                                   
                                                   
    while @@fetch_status =0                                                   
--2

BEGIN 
delete #PayTurn
insert #PayTurn( TurnId,DateWork,ND,NDDate,AccIdDebet,AccIdCredit,AccDebet,AccCredit,Amount,
							AmountCur,PayNote,DateOper,PayStatus,regId,distid,paidid )
  select 
							DocPayId,DateWork,ND,NDDate,AccIdDebet,AccIdCredit,AccDebet,AccCredit,Amount,
							AmountCur,PayNote,DateOper,PayStatus,regId,distid,paidid
							from DocPreparePay
where
PayStatus=1			
and accDebet like '10%'
and accCredit like'20%'
and dateWork=@DateOper

 	if @@error	<> 0
		goto __retErr

	delete t2
from #PayTurn t1,DocPreparePay t2
where 
t2.DocPayId=t1.TurnId
						update t1
							set payturntype=t3.codei
							from #PayTurn t1, PayTurnType t3
							where					
								convert(int,substring(accdebet,1,2))=balsDbt and
								convert(int,substring(acccredit,1,2))=balsCrdt 


begin Transaction 
BEGIN TRY


exec Pay_Pay_SaldoDay

insert PayTurn( TurnId,DateWork,ND,NDDate,AccIdDebet,AccIdCredit,AccDebet,AccCredit,
						Amount,AmountCur,PayNote,R030,DateOper,PayStatus,regid,distid,payturntype)  select 
 TurnId,DateWork,ND,NDDate,AccIdDebet,AccIdCredit,AccDebet,AccCredit,
						Amount,AmountCur,PayNote,'980',getdate(),2,regId ,distid,payturntype
from #PayTurn


--exec sp__msg  'Ok'

delete t2
from #PayTurn t1,DocPreparePay t2
where 
t2.DocPayId=t1.TurnId


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
--2
END
close curso 
deallocate curso    
return @Retcode
end
