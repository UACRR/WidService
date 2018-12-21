CREATE procedure [dbo].[MPay_D20_2_K20_dt3]
as
begin
/*
Судова робота 
[MPay_D21_2_K20_dt3]
*/
declare @costs_legal varchar(20) ='110003'
declare @costs_comm varchar(20) ='110002'
declare @costs_partner varchar(20) ='400'

declare @parntnerId		int=0

SET NOCOUNT ON;
declare @RetCode integer
set @RetCode = 0
--delete #doc
-- drop table #doc1
CREATE TABLE #doc1(
	id	int identity,
	regIItemId int NOT NULL,
	distId int NOT NULL,
	regId int NOT NULL,
	--periodId int NOT NULL,
	distribDate date NOT NULL,
	amount money NOT NULL,
	amountall	money  null,
	partnerCommiss	money	null,
	countFee		money	null,
	CrKindCode int NOT NULL,
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
--	clnName varchar(764) NULL,
	rate decimal(5, 2) NULL,
	rateCommiss decimal(10, 5) NULL,
--	rateCourt decimal(10, 5) NULL,
	cRType int NULL,
	amountComm	money null,
	amountMy		money null,
	amountBalans	money null,
	amountPay	money null,
	distType		tinyint	null,
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
 PRIMARY KEY CLUSTERED (	TurnId ASC,	DateWork ASC)
)

create table #Doc(
	id		int					identity,
	regIItemId				int null,
	distId					int null,		
	regId						int null,
	--periodId				int null,
	distribDate			date null,
	amount					money,
--	kindCode				int	null,
	custId					int null ,
	objid						int null,
	ItemName				varchar(100)  null,
	categoryCode		int   null,
	AccIdDebet			int			NULL,
	AccIdCredit			int			NULL,
	AccDebet				varchar(25)			NULL,
	AccCredit				varchar(25)			NULL,
	kindcode				int			null,
	paynote varchar	(100)		null,
	
)
insert #doc1
		(regIItemId,distId,regId,--periodId,
		distribDate,amount,	amountall	,	partnerCommiss,
	countFee,CrKindCode,objid,ItemName,categoryCode,
		AccIdDebet,AccIdCredit,AccDebet,AccCredit,name,author,performer,custId,--clnName,
		rate,rateCommiss,--rateCourt,
		amountComm,	amountMy,	amountBalans,	amountPay,cRType,distType
		)
--select * from #doc1

select   
		t3.regIItemId,  t1.distId,t1.regId,--t1.periodId,
		t1.distribDate,t3.amount,t1.amount allamount,t1.partnerCommiss,t1.courtFee,
		t1.CrKindCode,
		t4.objid,null ItemName,null categoryCode ,null  AccIdDebet,null AccIdCredit ,
		'20000'+convert(varchar(10),isnull(t4.cmCustId,t4.custId)) AccDebet,
		'22000'+convert(varchar(10),t1.custId)  AccCredit,
		NULL name,null author,null performer,
		isnull(t4.cmCustId,t4.custId) custid,
		isnull(t4.rate,100.) rate,t4.rateCommiss ,0 amountComm,0	amountMy,0	amountBalans,0	amountPay, t4.cRType,t1.distType
from 
		distribution t1,DistributionItem t3,RegisterCount t4
where
		t3.regId=t4.regId	and
		t3.regIItemId=t4.regIItemId and
		t3.distId=t1.distid and
		t1.status=2		and
		t1.distType=3
--and t1.distId=19



  	if @@error	<> 0
		goto __retErr

update #doc1
set 
amountMy=round(amount* isnull(rate,0)/100.,2)

  	if @@error	<> 0
		goto __retErr

insert #balance(id,distid,regIItemId,amountBals)
select max(id) id,distid,isnull(regIItemId,0),(sum(amountMy) - max(amount)) amountBals
from #doc1
group by distId,regIItemId

  	if @@error	<> 0
		goto __retErr


update t2
set 
amountBalans=t1.amountBals
from #balance t1,#doc1 t2
where 
t2.id=t1.id

  	if @@error	<> 0
		goto __retErr

/*t1.distid=t2.distId
and t1.regIItemId=t2.regIItemId
*/
update #doc1
set 
rateCommiss=t2.rateCourt
from #doc1 t1,vCopyright t2
where
t1.custId=isnull(t2.cmCustid,t2.custid)
and t1.cRType=t2.cRType
and t1.CrKindCode=t2.CRKindCode
and t1.objid=t2.objId

  	if @@error	<> 0
		goto __retErr

update #doc1
set amountMy=amountMy-amountBalans

  	if @@error	<> 0
		goto __retErr

update #doc1
set 
amountComm=round(amountMy* isnull(rateCommiss,0)/100.,2)

  	if @@error	<> 0
		goto __retErr

update #doc1
set 
amountPay=amountMy-amountComm

  	if @@error	<> 0
		goto __retErr

update #doc1
set 
AccIdCredit=accId
from  #doc1 t1,Account t2
where
t2.accNls=t1.AccCredit

  	if @@error	<> 0
		goto __retErr

insert #Doc (
	regIItemId,
	distId,
	regId	,
--	periodId,
	distribDate,
	amount,
	kindcode,
	custId,
	objid,
	ItemName,
	categoryCode,
	AccIdDebet,
	AccIdCredit,
	AccDebet	,
	AccCredit	
)
select   
t1.regIItemId,  t1.distId,t1.regId,--t1.periodId,
t1.distribDate,t1.amountMy,t1.CrKindCode,t1.custId ,
t1.objid,t4.ItemName,t1.categoryCode ,AccIdDebet,  AccIdCredit,	AccDebet	,	AccCredit	
from #doc1 t1,RegisterItem t4
where
t4.regIItemId=t1.regIItemId
and t1.regid=t4.regid

  	if @@error	<> 0
		goto __retErr

insert #Doc (
	regIItemId,
	distId,
	regId	,
--	periodId,
	distribDate,
	amount,
	kindcode,
	custId,
	objid,
	ItemName,
	categoryCode,
	AccIdDebet,
	AccIdCredit,
	AccDebet	,
	AccCredit	,
	paynote
)

select   
null,  t1.distId,t1.regId,--max(t1.periodId) periodId,
max(t1.distribDate) distribDate,
max(isnull(t1.countFee,0)) amountPay,max(t1.CrKindCode) CrKindCode,max(t3.custId) ,
max(t1.objid) objid,'Судові витрати',max(t1.categoryCode) categoryCode ,NUll, Null,	
@costs_legal	,	
--'110003',
max(AccCredit) AccCredit	,
'Судові витрати'
from #doc1 t1,RegisterItem t4,vCustomer t3
where
t4.regIItemId=t1.regIItemId
and t1.regid=t4.regid
and t3.ankMy=1
and isnull(t1.countFee,0)<>0
group by t1.regId,t1.distId

  	if @@error	<> 0
		goto __retErr

insert #Doc (
	regIItemId,
	distId,
	regId	,
--	periodId,
	distribDate,
	amount,
	kindcode,
	custId,
	objid,
	ItemName,
	categoryCode,
	AccIdDebet,
	AccIdCredit,
	AccDebet	,
	AccCredit	,
	paynote
)

select   
t1.regIItemId,  t1.distId,t1.regId,--max(t1.periodId) periodId,
max(t1.distribDate) distribDate,
max(isnull(t1.partnerCommiss,0)) amountPay,max(t1.CrKindCode) CrKindCode,max(t3.custId) ,
max(t1.objid) objid,'Комісія за суд',max(t1.categoryCode) categoryCode ,NUll, Null,
case when isnull(max(t2.partnerId),0) =0 then	@costs_comm
		else  @costs_partner 
		+ convert (varchar(10),max(t2.partnerId))
end,
max(AccCredit) AccCredit	,
'Комісія за суд'
from #doc1 t1,RegisterItem t4,vCustomer t3,Distribution t2
where
t4.regIItemId=t1.regIItemId
and t1.regid=t4.regid
and t2.distId=t1.distId
and t2.regid=t1.regid
and t3.ankMy=1
and isnull(t1.partnerCommiss,0)<>0
group by t1.regIItemId,t1.regId,t1.distId

  	if @@error	<> 0
		goto __retErr


insert #Doc (
	regIItemId,
	distId,
	regId	,
--	periodId,
	distribDate,
	amount,
	kindcode,
	custId,
	objid,
	ItemName,
	categoryCode,
	AccIdDebet,
	AccIdCredit,
	AccDebet	,
	AccCredit	,
	paynote
)

select   
t1.regIItemId,  t1.distId,t1.regId,--t1.periodId,
t1.distribDate,
t1.amountComm,t1.CrKindCode,t1.custId ,
t1.objid,'Комісія підвищена за обслуговування',t1.categoryCode ,NUll, Null,	'110002'	,	AccDebet AccCredit	,
'Комісія підвищена за обслуговування'
from #doc1 t1,RegisterItem t4,vCustomer t3
where
t4.regIItemId=t1.regIItemId
and t1.regid=t4.regid
and t3.ankMy=1
and t1.amountComm<>0

  	if @@error	<> 0
		goto __retErr


update t1
set paynote=ltrim(rtrim(t4.Name))+'  '+ltrim(rtrim(t4.Author))
from #doc t1,ObjectRight t4
where
t1.ObjId=t4.ObjId
and paynote is null

  	if @@error	<> 0
		goto __retErr

goto   __forward

__retErr:

return 1


__forward:

BEGIN
	begin Transaction 
		BEGIN TRY
		
--проверка/открытие  счетов плательщика

    declare cur cursor for   select  id, regIItemId,KindCode,ObjId,AccCredit,AccDebet,ItemName,custId from #Doc                                    
    declare     @id		integer
	declare     @regIItemId		integer
	declare		@KindCode		int                                            
    declare     @ObjId         integer
	declare     @AccCredit		varchar(14)
    declare     @AccDebet		varchar(14)
	declare		@AccID		integer
	declare		@KindCodeCH  varchar(2)  
	declare		@AccName	varchar(30)                                          
	declare		@ItemName		varchar(100)
	declare		@custid1		int
	declare @custname varchar(100)
    open cur                                                   
    fetch cur into @id, @regIItemId,@KindCode,@ObjId,@AccCredit,@AccDebet,@ItemName,@custid1
                                                   
    while @@fetch_status =0                                                   
	    BEGIN 

           if not exists  (select  1 from Account 
                                        where 
												    AccNls=@AccCredit
												   )
                 begin
                                      Exec  dbo.OpenAccNLS Null, Null,  '980', @AccCredit,@ItemName	
                 end
	        if not exists  (select  1 from Account 
                                        where accNls=@AccDebet
												   )
                 begin

                         Exec  dbo.OpenAccNLS  @custid1, Null,  '980', @AccDebet,@ItemName	
                 end
		fetch cur into  @id,@regIItemId,@KindCode,@ObjId,@AccCredit,@AccDebet,@ItemName,@custid1
END                                                   
close cur   
deallocate cur      


update t1
set AccIdDebet=t2.accid
from  #doc t1,Account t2
where
t1.AccDebet=t2.accNls

update t1
set AccIdCredit=t2.accid
from  #doc t1,Account t2
where
t1.AccCredit=t2.accNls


--формируем платежные документы    
insert DocPreparePay( 
	dateWork,
	regId,
	distId,
	nD,
	nDDate,
	accIdDebet,
	accIdCredit,
	accDebet,
	accCredit,
	amount,
	amountCur,
	payNote,
	r030,
	dateOper,
	payStatus,
	paidid
		)
select 
	distribDate,
	regId,
	distId,
	null,
	distribDate,
	AccIdDebet,
	AccIdCredit,
	AccDebet,
	AccCredit,
	amount,
	amount,
	paynote,
	'980',
	getdate(),
	1,
	regIItemId
from #Doc t1
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

--проплата документов
declare @DateOper date
declare curso  cursor for   select    distinct dateOper from 
 DocPreparePay
where
	PayStatus=1				and
	(accCredit like '20%' or accCredit like '22%')
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
	and isnull(flCourt,0)=0	and
	dateOper=@DateOper	

  	if @@error	<> 0
		goto __retErr


begin Transaction 
BEGIN TRY


exec Pay_Pay_SaldoDay

insert PayTurn( TurnId,DateWork,ND,NDDate,AccIdDebet,AccIdCredit,AccDebet,AccCredit,
						Amount,AmountCur,PayNote,R030,DateOper,PayStatus,regid,distid,regIItemId)  select 
 TurnId,DateWork,ND,NDDate,AccIdDebet,AccIdCredit,AccDebet,AccCredit,
						Amount,AmountCur,PayNote,'980',getdate(),2,regId ,distid,paidid
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