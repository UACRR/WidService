CREATE procedure [dbo].[MPPay3_D21_2_K301_#DDEX]
as
begin
/*

"переброска средств" со счетов  объектов права по счетам правообладателей (техническим)

exec [MPay3_D21_2_K301]
*/
SET NOCOUNT ON;
declare @RetCode integer
set @RetCode = 0
--delete #doc


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
	flCourt		tinyint		null,
	custidRh				int		null,
	payturntype int null,
 PRIMARY KEY CLUSTERED (	TurnId ASC,	DateWork ASC)
)



create table #Doc(
	regIItemId				int null,
	distId					int null,		
	regId						int null,
	distribDate			date null,
	amount					money,
	custId					int null ,
	objid						int null,
	ItemName				varchar(100)  null,
	categoryCode		int   null,
	AccIdDebet			int			NULL,
	AccIdCredit			int			NULL,
	AccDebet				varchar(25)			NULL,
	AccCredit				varchar(25)			NULL,
	kindcode				int			null,
	paynote varchar	(120)		null,
	distribType		tinyint	null,
	custIdRh integer NULL  --!T
)


declare @distId int
set @distId = 0
set @distId =	(select  min(distId) from Distribution 
where
			status=2 
		and distType=5
				)

if (@distid = 0 ) return 0

insert #doc		(regIItemId,distId,regId,distribDate,amount,custId,objid,ItemName,AccIdDebet,AccIdCredit,
	AccDebet,AccCredit,kindcode,paynote,distribType,custIdRh
)
select   
		t4.regIItemId,  t4.distId,t4.regId,t1.distribDate,t4.prepaySum,isnull(t4.cmCustId,t4.custId),t4.objId,NULL,
		null  AccIdDebet,null AccIdCredit ,	'21000'+convert(varchar(10),isnull(t4.cmCustId,t4.custId)) AccDebet,
		rtrim(STUFF('30100',6-len(convert (varchar(2),t1.cRKindCode)),len(convert (varchar(2),t1.cRKindCode))  ,
		convert (varchar(2),t1.cRKindCode))	+convert(varchar(10),t4.objId))  AccCredit,
		t4.cRKindCode,NULL paynote,5,	t4.custid custIdRh
from 
		distribution t1,RegisterCount t4
where
		t1.status=2				and
		t1.distType=5			and
		t4.distId = t1.distId	and
		t1.distId =	@distId
	
		
  	if @@error	<> 0
		goto __retErr

update #doc
	set 
		AccIdCredit=accId
	from  #doc t1,Account t2
	where
		t2.accNls=t1.AccCredit
update t1
	set AccIdDebet=t2.accid
	from  #doc t1,Account t2
	where
		t1.AccDebet=t2.accNls

  	if @@error	<> 0
		goto __retErr


update t1
			set paynote=substring(ltrim(rtrim(t4.Name))+'  '+ltrim(rtrim(t4.Author)),1,120)
		from #doc t1,ObjectRight t4
		where
				t1.ObjId=t4.ObjId

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
--открытие отсутствующих счетов
exec OpenAccCredit
exec OpenAccDebet

insert DocPreparePay( dateWork,regId,distId,	nD,nDDate,accIdDebet,accIdCredit,	accDebet,accCredit,amount,
									amountCur,payNote,	r030,dateOper,	payStatus,paidid,	custIdRh
									)
select			distribDate,regId,distId,null,distribDate,	AccIdDebet,	AccIdCredit,	AccDebet,AccCredit,amount,
					0,	paynote,'980',getdate(),1,	regIItemId,custIdRh 
from #Doc t1
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

--2	     
BEGIN
delete #PayTurn
insert #PayTurn( TurnId,DateWork,ND,NDDate,AccIdDebet,AccIdCredit,AccDebet,AccCredit,Amount,
							AmountCur,PayNote,DateOper,PayStatus,regId,distid,paidid,flCourt,custidRh )
  select 
							DocPayId,DateWork,ND,NDDate,AccIdDebet,AccIdCredit,AccDebet,AccCredit,Amount,
							AmountCur,PayNote,DateOper,PayStatus,regId,distid,paidid,flCourt,custIdRh
							from DocPreparePay
	where
	PayStatus=1	and
	(AccDebet like '31%' or AccDebet like '21%')	and
	AccCredit like '30%'
	and distid = @distid

  	if @@error	<> 0
		goto __retErr

		delete t2
			from 
				#PayTurn t1,DocPreparePay t2
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
						Amount,AmountCur,PayNote,R030,DateOper,PayStatus,regid,distid,regIItemId,custIdRh
						,payturntype)  
		select
				 TurnId,DateWork,ND,NDDate,AccIdDebet,AccIdCredit,AccDebet,AccCredit,
						Amount,AmountCur,PayNote,'980',getdate(),2,regId ,distid,paidid,custidRh,payturntype
		from
			#PayTurn
	where Amount<>0

		delete t2
			from 
				#PayTurn t1,DocPreparePay t2
				where 
						t2.DocPayId=t1.TurnId
--статус 3 : распределено по правообладателям
update t2
		set 
			t2.status=3
				from Distribution  t2
					where
						t2.distId in (select distinct distId from #PayTurn)

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

--2
END
return @Retcode  
end
