CREATE procedure [dbo].[MPay31_D21_2_K301]
as
begin
/*
нашелся правобладатель
[MPay31_D21_2_K301]
*/
SET NOCOUNT ON;
declare @RetCode integer
set @RetCode = 0
--delete #doc
-- drop table #doc1
CREATE TABLE #doc1(
	id	int identity,
	regIItemId int  NULL,
	distId int  NULL,
	regId int  NULL,
	--periodId int  NULL,
	distribDate date NOT NULL,
	amount money NOT NULL,
	kindCode int NOT NULL,
	objid int NULL,
	ItemName varchar(100) NULL,
	categoryCode int NULL,
	AccIdDebet int NULL,
	AccIdCredit int NULL,
	AccDebet int NULL,
	AccCredit int NULL,
	name varchar(254) NULL,
	author varchar(254) NULL,
	performer varchar(254) NULL,
	custId int NULL,
	rate decimal(5, 2) NULL,
	amountMy		money null,
	amountBalans	money null,
	amountPay	money null,
	cRType int NULL,
	disttype		int,
	paynote varchar	(100)		null,
	custIdRh integer NULL,  --!T
	primary key (id)
	)
create table #balance(
	id							int,
	distid					int,
	regIItemId				int,
	amountBals			money,
	primary key (distid,regIItemid)
	)
	
	CREATE TABLE #PayTurn(
	TurnId						 int			NOT NULL,
	DateWork				datetime NOT NULL,
	ND							varchar(25)		NULL,
	NDDate					datetime	NULL,
	AccIdDebet			 int			NULL,
	AccIdCredit			 int			NULL,
	AccDebet				varchar(25)			NULL,
	AccCredit				varchar(25)			NULL,
	Amount					numeric(20, 2	)	NULL,
	AmountCur				numeric(20, 2)	NULL,
	PayNote					varchar(200) 	NULL,
	DateOper				date						NOT NULL,
	PayStatus				int					 NULL,
	regId						int,
	distid					int,
	paidid				int null,
	custIdRh integer NULL,  --!T
 PRIMARY KEY CLUSTERED (	TurnId ASC,	DateWork ASC)
)
insert #doc1
		(regIItemId,distId,regId,--periodId,
		distribDate,amount,kindCode,objid,ItemName,categoryCode,
		AccIdDebet,AccIdCredit,AccDebet,AccCredit,
		name,author,performer,
		custId,--clnName,
		rate,
		amountMy,	amountBalans,	amountPay,cRType,distType, custIdRh
		)
select   
		t3.regIItemId,  t1.distId,t1.regId,--t1.periodId,
		t1.distribDate,t3.amount,t1.CrKindCode,
		t4.objid,null ItemName,null categoryCode ,null  AccIdDebet,null AccIdCredit ,
		'21000'+convert(varchar(10),isnull(t4.cmCustId,t4.custId)) AccDebet,
		rtrim(STUFF('31100',6-len(convert (varchar(2),t1.cRKindCode)),len(convert (varchar(2),t1.cRKindCode)),convert (varchar(2),t1.cRKindCode))
		+convert(varchar(10),t4.objId))  AccCredit,null name,null author,null performer,
		isnull(t4.cmCustId,t4.custId) custid,
		isnull(t4.rate,100.),0,0,0, t4.cRType,t1.distType, t4.custId --!T
from 
		distribution t1,DistributionItem t3,RegisterCount t4
where
		t3.distId=t4.distId	and
		t3.distItemId=t4.distItemId and
		t3.distId=t1.distid and
		t1.status=2		and
		t1.distType=2

update #doc1
set 
amountMy=round(amount* isnull(rate,0)/100.,2)

insert #balance(id,distid,regIItemId,amountBals)
select max(id) id,distid,regIItemId,(sum(amountMy) - max(amount)) amountBals
from #doc1
group by distId,regIItemId

update t2
set 
amountBalans=t1.amountBals
from #balance t1,#doc1 t2
where
 t1.distid=t2.distid 	and
 t1.regIItemId=t2.regIItemId


update #doc1
set amountPay=amountMy-amountBalans

update t1
set paynote=ltrim(rtrim(t4.Name))+'  '+ltrim(rtrim(t4.Author))
from #doc1 t1,ObjectRight t4
where
t1.ObjId=t4.ObjId

if  @@ROWCOUNT<>0

BEGIN
	begin Transaction 
		BEGIN TRY
-- проверка наличия счетов
			exec MPay_CheckAccounts
--формируем платежные документы    
			insert DocPreparePay( dateWork,regId,distId,nD,nDDate,accIdDebet,accIdCredit,accDebet,accCredit,amount,	amountCur,
									payNote,r030,dateOper,payStatus,paidid
									, custIdRh  --!T
									)
			select		distribDate,regId,distId,null,distribDate,	AccIdDebet,AccIdCredit,AccDebet,AccCredit,amount,0,paynote,
							'980',getdate(),1,regIItemId
							, custIdRh
			from #Doc1 t1
			where not exists (select * from DocPreparePay t2
								where 
								t1.regId=t2.regId	and
								t2.paidid=t1.regIItemId
								)

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
        ,ERROR_MESSAGE() AS ErrorMessage;  set @Retcode = 1

END CATCH
END

declare @DateOper date
declare curso  cursor for   select    distinct dateOper from 
DocPreparePay
where
PayStatus=1			
and isnull(flCourt,0)=0
			
    open curso
    fetch curso into   @DateOper                                   
     while @@fetch_status =0  
--2	     
BEGIN
delete #PayTurn
insert #PayTurn( TurnId,DateWork,ND,NDDate,AccIdDebet,AccIdCredit,AccDebet,AccCredit,Amount,
							AmountCur,PayNote,DateOper,PayStatus,regId,distid,paidid
							,custIdRh  --T
							  )
  select 
							DocPayId,DateWork,ND,NDDate,AccIdDebet,AccIdCredit,AccDebet,AccCredit,Amount,
							0,PayNote,DateOper,PayStatus,regId,distid,paidid
							,custIdRh --!T
							from DocPreparePay
where
PayStatus=1			
and isnull(flCourt,0)=0
and dateOper=@DateOper

begin Transaction 
BEGIN TRY


exec Pay_Pay_SaldoDay

insert PayTurn( TurnId,DateWork,ND,NDDate,AccIdDebet,AccIdCredit,AccDebet,AccCredit,
						Amount,AmountCur,PayNote,R030,DateOper,PayStatus,regid,distid
						,custIdRh,regIItemId --T
						)  select 
 TurnId,DateWork,ND,NDDate,AccIdDebet,AccIdCredit,AccDebet,AccCredit,
						Amount,AmountCur,PayNote,'980',getdate(),2,regId ,distid
						,custIdRh ,paidid --!T
from #PayTurn

--exec sp__msg  'Ok'

delete t2
from #PayTurn t1,DocPreparePay t2
where 
t2.DocPayId=t1.TurnId

update t2
set 
t2.status=3
from Distribution  t2
where
t2.regId in (select distinct regId from #PayTurn)

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