

CREATE procedure [dbo].[MPay4_D20_K21]
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
rateComm	numeric(10,5),
rateCourt	numeric(10,5),
amount		money,
restCourt		money,
amountComm	money,
amountCourt		money,
amountPay		money,
primary key (custId)
)
create table #percentComm(
custid	int,
rateComm	numeric(10,5),
rateCourt	numeric(10,5),	
primary key (custid)
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
	flCourt				tinyint,
	payturntype			int null,
 PRIMARY KEY CLUSTERED (	TurnId ASC,	DateWork ASC)
)

--select * from #doc


insert #doc 
					(CustID,accidCredit,AccCredit,accIdDebet,AccDebet,rateComm,rateCourt,amount,restCourt,
					amountComm,amountCourt,amountPay	
					)
select distinct
					t6.CustId,t6.accId,t6.accNls,Null,'20000' +convert(varchar(10),custid),0,0,rest,t7.restCourt,
					0,0,0
from
		Account t6,SaldoDay t7
		where
			 t6.balsCode=21
			 and t7.accId=t6.accId
			 and t7.dateEnd='30000101'
			 and t7.rest<>0

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

--проверка/открытие 20 счетов получателя
    declare cur cursor for   select   distinct CustID ,AccDebet
	 from #Doc                                    
    declare     @CustID		integer
    declare     @AccDebet		varchar(14)
	declare		@AccID		integer
	declare		@R030		char(3) 
	declare		@custname	varchar(100)
    open cur                                                   
    fetch cur into   @CustID ,@AccDebet                                      
                                                   
    while @@fetch_status =0                                                   
	    BEGIN 
            if not exists  (select  1 from Account 
                                        where BalsCode=20
                                                and CustID=@CustID
												and AccNls=@AccDebet
												   )
                 begin
                        select @custname=name from vCustomer
						where custId=@CustID
                         Exec  dbo.OpenAccNLS  @CustID, Null, '980', @AccDebet,@custname
                 end
    fetch cur into   @CustID ,@AccDebet                                      
                                                   
    	END                                                   
                                                   
close cur   
deallocate cur      

update t2
set 
AccidDebet=t1.accid 
from Account t1,#Doc t2
where
t2.custID=t1.CustID	and
t2.AccDebet=t1.accNls

update t1
set 
	t1.rateComm=isnull(t2.rateCommiss,0),
	t1.rateCourt=isnull(t2.rateCourt,0)
from #Doc t1, AgreementMaster t3 , AgreementAddRH t2 
where
t3.custId=t1.CustID and
t3.agrId = t2.agrId


/*
update t2
set rateCourt=isnull(t1.rateComm,0)
from #Doc t2,#percentComm t1
where
t2.CustID=t1.custid
*/

--повышенная комиссия за обслуживание
update t2
set amountCourt=round(restCourt*rateCourt/100.,2)
from #Doc t2
-- комиссия за обслуживание
update t2
set amountComm=round((amount-restCourt)*rateComm/100.,2)
from #Doc t2


update t2
set amountPay=amount-amountComm-amountCourt
from #Doc t2

--формируем платежные документы                                         
insert DocPreparePay( dateWork,regId,distId,nD,nDDate,accIdDebet,accIdCredit,accDebet,accCredit,
			amount,amountCur,payNote,r030,dateOper,payStatus,paidid)
select  convert(date,getdate()),null,null,null,convert(date,getdate()),accIdDebet,accIdCredit,accDebet,accCredit,
			amountPay ,amountCourt,'Переказ коштів з технічного рахунку','980',convert(date,getdate()),1,null			
			  from #Doc


if not exists(select 1 from Account where accNls='110001')
begin
		select @custid= custId from vCustomer where ankMy=1
	if (@custid) is not null
	exec OpenAccNLS  @custid , null,  '980', '110001', 'Рахунок доходів'
			else 
				return -1
end


select @AccID =accid from Account 
where accNls='110001'

insert DocPreparePay( dateWork,regId,distId,nD,nDDate,accIdDebet,accIdCredit,accDebet,accCredit,
			amount,amountCur,payNote,r030,dateOper,payStatus,paidid)
select  convert(date,getdate()),null,null,null,convert(date,getdate()),@AccID,accIdCredit,'110001',accCredit,
			amountComm ,0,'Комісійні доходи','980',convert(date,getdate()),1,null			
			  from #Doc where amountComm<>0
if not exists(select 1 from Account where accNls='110002')
begin
		select @custid= custId from vCustomer where ankMy=1
	if (@custid) is not null
	exec OpenAccNLS  @custid , null,  '980', '110002', 'Комісія за суд'
			else 
				return -1
end

select @AccID =accid from Account 
where accNls='110002'
insert DocPreparePay( dateWork,regId,distId,nD,nDDate,accIdDebet,accIdCredit,accDebet,accCredit,
			amount,amountCur,payNote,r030,dateOper,payStatus,paidid,flCourt)

select  convert(date,getdate()),null,null,null,convert(date,getdate()),@AccID,accIdCredit,'110002',accCredit,
			amountCourt ,amountCourt,'Підвищені комісійні доходи','980',convert(date,getdate()),1,null,1			
			  from #Doc where amountCourt<>0





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
	AccCredit like '21%'	
	open curso
    fetch curso into   @DateOper                                   
                                                   
    while @@fetch_status =0                                                   
--2

BEGIN 
delete #PayTurn
insert #PayTurn( TurnId,DateWork,ND,NDDate,AccIdDebet,AccIdCredit,AccDebet,AccCredit,Amount,
							AmountCur,PayNote,DateOper,PayStatus,regId,distid,paidid,flCourt)
  select 
							DocPayId,DateWork,ND,NDDate,AccIdDebet,AccIdCredit,AccDebet,AccCredit,Amount,
							AmountCur,PayNote,DateOper,PayStatus,regId,distid,paidid,flCourt
							from DocPreparePay
where
PayStatus=1			
--and isnull(flCourt,0)=0
and dateWork=@DateOper

 	if @@error	<> 0
		goto __retErr
goto   __forward
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