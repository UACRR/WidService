CREATE  procedure [dbo].[MPay_D31_2_K20_dt4]
as
begin
/*
Відсуджений реєстр SR
exec [MPay3_D301_2_K20]
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
	custsource int ,
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
	AccDebet varchar(25) NULL,
	AccCredit varchar(25) NULL,
	AccPartner varchar(25) NULL,
	name varchar(254) NULL,
	author varchar(254) NULL,
	performer varchar(254) NULL,
	primary key (id)
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
	flCourt		tinyint		null,
 PRIMARY KEY CLUSTERED (	TurnId ASC,	DateWork ASC)
)

create table #Doc(
	id		int					identity,
	regIItemId				int null,
	distId					int null,		
	regId						int null,
--	periodId				int null,
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
	flCourt		tinyint		null
)
insert #doc1
		(regIItemId,distId,regId,--periodId,
		distribDate,custsource,amount,	amountall	,	partnerCommiss,
	countFee,CrKindCode,objid,ItemName,categoryCode,
		AccIdDebet,AccIdCredit,AccDebet,AccCredit,AccPartner,name,author,performer)
select   
t3.regIItemId,  t1.distId,t1.regId,--t1.periodId,
t1.distribDate,t2.custid,t3.amount,t1.amount  allamount,
t1.partnerCommiss,t1.courtFee,
t1.CrKindCode,
t4.objid,t4.ItemName,t4.categoryCode ,null  AccIdDebet,null AccIdCredit ,
STUFF('30100',6-len(t1.CrKindCode),len(t1.CrKindCode),t1.CrKindCode)+convert(varchar(10),t4.objId)		 AccDebet,
'22000'+convert(varchar(10),t2.custId)  AccCredit,
case when isnull(t1.partnerId,0) =0 then	'110002'
		else  '400' + convert (varchar(10),t1.partnerId)
end,
t6.name,t6.author,t6.performer
FROM Distribution t1,register t2,DistributionItem t3,RegisterItem t4  ,ObjectRight t6
where 
t1.regid=t2.regid	and
t3.distId=t1.distid  and
t4.regId=t3.regId	and
t4.regIItemId=t3.regIItemId and
t6.objId=t4.objid
and t1.status=2
and t1.distType=4

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

insert #Doc (	regIItemId,	distId,	regId	,--	periodId,	
distribDate,	amount,	kindcode,	custId,	objid,	ItemName,	categoryCode,
						AccIdDebet,	AccIdCredit,	AccDebet	,	AccCredit	,	flCourt
					)
select   
						t1.regIItemId,  t1.distId,t1.regId,--t1.periodId,
						t1.distribDate,t1.amount,t1.CrKindCode,t1.custsource ,
						t1.objid,t4.ItemName,t1.categoryCode ,AccIdDebet,  AccIdCredit,	AccDebet	,	AccCredit	,1
from #doc1 t1,RegisterItem t4
where
			t4.regIItemId=t1.regIItemId
			and t1.regid=t4.regid

 	if @@error	<> 0
		goto __retErr

insert #Doc (	regIItemId,	distId,	regId	,	--periodId,
	distribDate,	amount,	kindcode,	custId,	objid,
						ItemName,	categoryCode,	AccIdDebet,	AccIdCredit,	AccDebet	,	AccCredit	,	paynote
						)
select   
						t1.regIItemId,  t1.distId,t1.regId,--t1.periodId,
						t1.distribDate,t1.countFee,t1.CrKindCode,t1.custsource ,t1.objid,
						ItemName,t1.categoryCode ,AccIdDebet,  AccIdCredit,	'110003',	AccCredit	,'Судові витрати'
from #doc1 t1

 	if @@error	<> 0
		goto __retErr

insert #Doc (	regIItemId,	distId,	regId	,--	periodId,
	distribDate,	amount,	kindcode,	custId,	objid,
						ItemName,	categoryCode,	AccIdDebet,	AccIdCredit,	AccDebet	,	AccCredit	,	paynote
						)

select   
						t1.regIItemId,  t1.distId,t1.regId,--t1.periodId,
						t1.distribDate,t1.partnerCommiss,t1.CrKindCode,t1.custsource ,t1.objid,
						ItemName,t1.categoryCode ,AccIdDebet,  AccIdCredit,	AccPartner,	AccCredit	,'Комісія за суд'
from #doc1 t1

 	if @@error	<> 0
		goto __retErr
goto   __forward

__retErr:

return 1

__forward:


BEGIN
	begin Transaction 
		BEGIN TRY
		
--проверка/открытие 301/302 счетов плательщика

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
                                      Exec  dbo.OpenAccNLS Null, Null,  '980', @AccCredit,null	
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
insert DocPreparePay( dateWork,	regId,	distId,	nD,	nDDate,	accIdDebet,	accIdCredit,	accDebet,	accCredit,	amount,	amountCur,
										payNote,	r030,	dateOper,	payStatus,	paidid,	flCourt
										)
select								distribDate,	regId,	distId,	null,	distribDate,	AccIdDebet,	AccIdCredit,	AccDebet,	AccCredit,	amount,
										case flCourt when 1 then amount
												else 0
										end,
										paynote,'980',	getdate(),	1,	regIItemId,	flCourt
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
	accCredit like '20%'		

	open curso
    fetch curso into   @DateOper                                   
                                                   
    while @@fetch_status =0                                                   
--2
BEGIN 
delete #PayTurn
insert #PayTurn( TurnId,DateWork,ND,NDDate,AccIdDebet,AccIdCredit,AccDebet,AccCredit,Amount,
							AmountCur,PayNote,DateOper,PayStatus,regId,distid,paidid ,flCourt)
  select 
							DocPayId,DateWork,ND,NDDate,AccIdDebet,AccIdCredit,AccDebet,AccCredit,Amount,
							AmountCur,PayNote,DateOper,PayStatus,regId,distid,paidid,flCourt
							from DocPreparePay
where
	PayStatus=1	and
	dateOper=@DateOper
--and isnull(flCourt,0)=0		

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