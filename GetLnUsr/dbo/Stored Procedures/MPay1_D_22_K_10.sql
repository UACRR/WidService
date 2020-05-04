
CREATE procedure [dbo].[MPay1_D_22_K_10]
as
-- оплата документов, поступивших из 1С
--корр. счет + 20 счет плательщика
begin
/*
*/
SET NOCOUNT ON;
declare @RetCode integer
set @RetCode = 0

create table #Doc(
dateWork		date null,
paidId		int null,
regId       int null,
distId       int null,
custID      int ,
ObjId        int null,
distribDate	date,
amount		money,
kindCode		int null,
periodid		int null,
payNote			varchar(2000),
docNum	varchar(30),
okpo     varchar(20)
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
	payturntype int null,
 PRIMARY KEY CLUSTERED (	TurnId ASC,	DateWork ASC)
)
--select * from #doc

--отбор подготовленных distribution (status=1)
insert #doc (dateWork,paidid,regId ,distid,custID,ObjId,distribDate,amount	,kindCode,periodId,payNote,docNum,okpo	)
select	distinct	getdate(), paidId,NULL,NULL,custID
,NULL ,dateOper,sCredit	,NULL,NULL,nplat,docNum,okpoCorr
from Externalpay 
where 
	status=1

  	if @@error	<> 0
		goto __retErr

/*
update #doc set 
custID= null

  	if @@error	<> 0
		goto __retErr

update #doc 
set custID = t2.custid
from #Doc t1,  ExternalPay t3
,BankAccount t2 
where t2.mfo = cast( t3.mfoCorr as numeric )
and t2.accountNumber = t3.accountCorr
and t1.paidId =t3.paidId

  	if @@error	<> 0
		goto __retErr
*/
delete #doc
where custid is null

goto   __forward

__retErr:

return 1

__forward:





if (select count(*) from #doc)<>0
--обработка согласованных заявок
BEGIN
	begin Transaction 
	BEGIN TRY
--проверка/открытие 22 счетов плательщика
--и 10счетов системы
    declare cur cursor for   select    distinct CustID  from #Doc                                    
    declare     @CustID		integer
	declare     @Account		varchar(14)
	declare		@R030		char(3) 
	declare		 @custname varchar(100)
	set @R030= '980'
    open cur                                                   
    fetch cur into   @CustID                                                   
    while @@fetch_status =0                                                   
--1
	BEGIN 

            if not exists  (select  1 from Account 
                                        where BalsCode=22
                                                   and CustID=@CustID
												   )
                 begin					
                        select @Account= '22000'+convert(varchar(10),@CustID)
						select @custname=name from vCustomer
						where custId=@CustID
                         Exec  dbo.OpenAccNLS  @CustID, Null,  '980', @Account,@custname
                 end
	
  if not exists  (select  1 from Account 
                                        where BalsCode=10
 --                                                  and CustID=1
													and AccNls='100001'											
												   )
                 begin
                        select @Account= '100001'
						select @custid= custId from vCustomer where ankMy=1
	                    Exec  dbo.OpenAccNLS  @custid, Null,  '980', @Account,'Надходження коштів з 1С'
                 end
	 fetch cur into   @CustID                                                   
    END                                                   
--1                                                   
close cur   
deallocate cur
      
--формируем платежные документы                                        
insert DocPreparePay( dateWork,paidId,	nD,nDDate,	accIdDebet,	accIdCredit,	accDebet,accCredit,amount,
									amountCur,	payNote,	r030,	dateOper,	payStatus  
									)
select			t1.dateWork	,t1.paidId	,t1.docNum	,convert(date,distribDate)	,t5.AccId	,t2.AccId	,t5.AccNls ,t2.AccNls,t1.Amount,
					0	,t1.PayNote	,'980'	,getdate()	,1
from #Doc t1,Account t2,Account t5
	   where
	   t5.CustID=t1.CustID	and
	   t2.BalsCode=10			and
	   t5.BalsCode=22
	   and t1.paidId not in (select distinct paidId from DocPreparePay)

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
	AccCredit='100001'	and
	AccDebet like '22%'
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
							0,PayNote,DateOper,PayStatus,regId,distid,paidid
							from DocPreparePay
	where
	PayStatus=1				and
	AccCredit='100001'	and
	AccDebet like '22%'	and
	dateWork=@DateOper

  	if @@error	<> 0
		goto __retErr

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
						Amount,AmountCur,PayNote,R030,DateOper,PayStatus,regid,distid,payturntype)  
	select 
						TurnId,DateWork,ND,NDDate,AccIdDebet,AccIdCredit,AccDebet,AccCredit,
						Amount,0,PayNote,'980',getdate(),2,regId ,distid,payturntype
	from #PayTurn

insert PayTurnExtra(turnid,datework,custid,payturntype)
					select t1.turnid,t1.DateWork,t2.custId,t3.codei
					from #PayTurn t1,Account t2,PayTurnType t3
					where t2.accId=t1.AccIdDebet and
						  t3.balsDbt=22	and
						  t3.balsCrdt=10 

--exec sp__msg  'Ok'
	delete t2
	from #PayTurn t1,DocPreparePay t2
	where 
		t2.DocPayId=t1.TurnId

-- документ переводится в статус  'оплачен'
update t2		set 
						t2.status=2
							from externalpay  t2
								where
									t2.paidId in (select distinct paidid from #PayTurn)

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
	from #PayTurn t1,DocPreparePay t2
	where 
		t2.DocPayId=t1.TurnId

 set @Retcode = 1

END CATCH
fetch curso into   @DateOper
--2
END
close curso 
deallocate curso    
return @Retcode
end
