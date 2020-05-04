CREATE procedure [dbo].[MPPay2_D301_2_K22__#DDEX] @Distid int
as
begin
/*
"переброска средств" со счетов плательщиков  по счетам объектов права
*/
SET NOCOUNT ON;
declare @RetCode integer

set @RetCode = 0

--delete #doc
create table #Doc(
	regIItemId			int			null,
	distId				int			null,		
	regId					int			null,
--	periodId			int			null,
	distribDate		date		null,
	amount				money,
	kindCode			int			null,
	custId				int			null ,
	objid					int			null,
	ItemName			varchar(120)  null,
	categoryCode	int			null,
	AccIdDebet		int			NULL,
	AccIdCredit		int			NULL,
	AccDebet			varchar(25)			NULL,
	AccCredit			varchar(25)			NULL,
--	partnerId			int				null,
--	partnerComiss	money,
	paynote			varchar	(200)		null
)
CREATE TABLE #PayTurn(
	TurnId						 int				NOT NULL,
	DateWork					date		NOT NULL,
	ND							varchar(25)	NULL,
	NDDate					datetime		NULL,
	AccIdDebet				int					NULL,
	AccIdCredit				int					NULL,
	AccDebet					varchar(25)	NULL,
	AccCredit					varchar(25)	NULL,
	Amount						numeric(20, 2)	NULL,
	AmountCur				numeric(20, 2)	NULL,
	PayNote					varchar(200) 	NULL,
	DateOper					datetime					NOT NULL,
	PayStatus				int					 NULL,
	regId							int,
	distid						int,
	paidid						int					null,
	payturntype int null,
 PRIMARY KEY CLUSTERED (	TurnId ASC,	DateWork ASC)
)

/*
declare @distId int
set @distId = 0
set @distId =	(select  min(distId) from Distribution 
where
			status=1 
		and distType=5
				)
*/
if (isnull(@distid,0) = 0 ) return 0


insert #Doc (regIItemId,distId,regId,--periodId,
distribDate,amount,kindCode,custId,objid,ItemName,
					categoryCode,	AccIdDebet,	AccIdCredit,	AccDebet	,AccCredit
					)

select			t3.regIItemId,  t1.distId,t1.regId,--t1.periodId,
t1.distribDate,t3.amount,t1.CrKindCode,t1.custId ,t4.objid,t4.ItemName,
					t4.categoryCode ,null,  null ,null,'22000'+convert(varchar(10),t1.custId)
FROM 
			Distribution t1,DistributionItem t3,RegisterItem t4
where 
		t1.distId =	@distid	and
		t3.distId=t1.distid  and
		t4.regId=t3.regId	and
		t4.regIItemId=t3.regIItemId


  	

  	if @@error	<> 0
		goto __retErr


--select * from #doc

update t1
	set paynote=substring(ltrim(rtrim(t4.Name))+'  '+ltrim(rtrim(t4.Author)),1,120)	from 
			#doc t1,ObjectRight t4
	where
			t1.ObjId=t4.ObjId

	declare     @AccCredit		varchar(24)
    declare     @Account		varchar(24)
set @Account =rtrim('30100')

update #doc
set AccDebet =  STUFF(@Account,6-len(convert (varchar(2),KindCode)),len(convert (varchar(2),KindCode)),convert (varchar(2),KindCode))
+convert(varchar(10),ObjId)

set @Account= '22000'
update #doc
set AccCredit =  @Account+convert(varchar(10),custid)

update t1
	set AccIdDebet=t2.accid
	from  #doc t1,Account t2
	where
		t1.AccDebet=t2.accNls
		and r030='980'
update t1
	set AccIdCredit=t2.accid
	from  #doc t1,Account t2
	where
		t1.AccCredit=t2.accNls
		and r030='980'


 	if @@error	<> 0
		goto __retErr
goto   __forward

__retErr:

return 1

__forward:

--select * from #doc
if  (select count(*) from #Doc)<>0
BEGIN
	begin Transaction 
	BEGIN TRY
--проверка/открытие 301/302 счетов 

exec OpenAccCredit
exec OpenAccDebet

 

--формируем платежные документы    
insert DocPreparePay( dateWork,regId,distId,nD,nDDate,accIdDebet,accIdCredit,	accDebet,accCredit,amount,amountCur,
									payNote,r030,dateOper,payStatus,paidid
									)
select				distribDate,regId,distId,null,distribDate,	AccIdDebet,	AccIdCredit,	AccDebet,AccCredit,amount,0,
						paynote,'980',getdate(),1,	regIItemId
from 
		#Doc t1
		where not exists (select * from DocPreparePay t2
								where 
								t1.distId = t2.distId and
								t1.regId=t2.regId	and
								t2.paidid=t1.regIItemId
								)
IF @@TRANCOUNT > 0 commit tran
END TRY
BEGIN CATCH
  IF @@TRANCOUNT > 0 rollback tran
begin
delete  DocPreparePay
where distId =	@distid
   SELECT   
        ERROR_NUMBER() AS ErrorNumber  
        ,ERROR_SEVERITY() AS ErrorSeverity  
        ,ERROR_STATE() AS ErrorState  
        ,ERROR_PROCEDURE() AS ErrorProcedure  
        ,ERROR_LINE() AS ErrorLine  
        ,ERROR_MESSAGE() AS ErrorMessage;  set @Retcode = 1
end
END CATCH
END

BEGIN

	delete #PayTurn
	insert #PayTurn( TurnId,DateWork,ND,NDDate,AccIdDebet,AccIdCredit,AccDebet,AccCredit,Amount,
							AmountCur,PayNote,DateOper,PayStatus,regId,distid,paidid )
	select 
							DocPayId,DateWork,ND,NDDate,AccIdDebet,AccIdCredit,AccDebet,AccCredit,Amount,
							0,PayNote,DateOper,PayStatus,regId,distid,paidid
							from DocPreparePay
	where
distid= @distid and
(AccDebet like '3%')	and
AccCredit like '22%'

  	if @@error	<> 0
		goto __retErr

		
							update t1
							set payturntype=t3.codei
							from #PayTurn t1, PayTurnType t3
							where					
								convert(int,substring(accdebet,1,2))=balsDbt and
								convert(int,substring(acccredit,1,2))=balsCrdt 

	delete t2
	from #PayTurn t1,DocPreparePay t2
	where 
		t2.DocPayId=t1.TurnId
	update t2
		set		t2.status=2
		from Distribution  t2
		where
			t2.distid in (select distinct distid from #PayTurn)


begin Transaction 
BEGIN TRY
	exec Pay_Pay_SaldoDay
	insert PayTurn( TurnId,DateWork,ND,NDDate,AccIdDebet,AccIdCredit,AccDebet,AccCredit,
						Amount,AmountCur,PayNote,R030,DateOper,PayStatus,regid,distid,regIItemId,payturntype)  
	select		 TurnId,DateWork,ND,NDDate,AccIdDebet,AccIdCredit,AccDebet,AccCredit,
						Amount,0,PayNote,'980',getdate(),2,regId ,distid,paidid,payturntype
	from #PayTurn
	where Amount<>0

--exec sp__msg  'Ok'
	delete t2
	from #PayTurn t1,DocPreparePay t2
	where 
		t2.DocPayId=t1.TurnId
	update t2
		set		t2.status=2
		from Distribution  t2
		where
			t2.distid = @distid
--			t2.distid = 4463

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
			delete t2
	from DocPreparePay t2
	where 
	@distId = distId
		set @Retcode = 1
END CATCH

--2
END
return @Retcode  
end
