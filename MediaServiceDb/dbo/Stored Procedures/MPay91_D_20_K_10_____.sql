
create procedure [dbo].[MPay91_D_20_K_10_____]
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
docNum	varchar(30)
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
--select * from #doc

--отбор подготовленных distribution (status=1)
insert #doc (dateWork,paidid,regId ,distid,custID,ObjId,distribDate,amount	,kindCode,periodId,payNote,docNum
					)
select		inputDate, paidId,NULL, NULL, t2.custID, NULL ,dateOper,sCredit	,NULL,NULL,nplat,docNum
from Externalpay t1,AnketaCompany t2
where t2.okpo=t1.okpocorr
and
	t1.status=1

if  @@ROWCOUNT<>0
--обработка согласованных заявок
BEGIN
	begin Transaction 
	BEGIN TRY
--проверка/открытие 20 счетов плательщика
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
                                        where BalsCode=20
                                                   and CustID=@CustID
												   )
                 begin					
                        select @Account= '20000'+convert(varchar(10),@CustID)
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
	   t5.BalsCode=20
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
declare curso  cursor for   select    distinct dateOper from 
 DocPreparePay
where
	PayStatus=1				and
	AccCredit='100001'	and
	AccDebet like '20%'
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
	AccDebet like '20%'	and
	dateOper=@DateOper
begin Transaction 
BEGIN TRY
	exec Pay_Pay_SaldoDay
	insert PayTurn( TurnId,DateWork,ND,NDDate,AccIdDebet,AccIdCredit,AccDebet,AccCredit,
						Amount,AmountCur,PayNote,R030,DateOper,PayStatus,regid,distid)  
	select 
						TurnId,DateWork,ND,NDDate,AccIdDebet,AccIdCredit,AccDebet,AccCredit,
						Amount,0,PayNote,'980',getdate(),2,regId ,distid
	from #PayTurn

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
 set @Retcode = 1

END CATCH
fetch curso into   @DateOper
--2
END
close curso 
deallocate curso    
return @Retcode
end