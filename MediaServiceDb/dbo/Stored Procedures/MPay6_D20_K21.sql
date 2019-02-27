CREATE procedure [dbo].[MPay6_D20_K21] 
as
BEGIN

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
  
  
  if @end_date<>@cur_date
		return 0

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
 PRIMARY KEY CLUSTERED (	TurnId ASC,	DateWork ASC)
)

--drop table #PayTurnCm
CREATE TABLE #PayTurnCm(
	accId int NOT NULL,
	dateWork datetime NOT NULL,
	kindCode int NOT NULL,
	amount_sum money NULL,
	amountCourt_sum money NULL,
	rateCommiss decimal(10, 5) NULL,
	rateCourt decimal(10, 5) NULL,
	amount money NULL,
	amountCourt money NULL,
	amountCommiss money NULL,
	custid		int null,
	custIdRh int ,
	custIdCm int NULL,
	accNls varchar(25) NULL,
 PRIMARY KEY 
(
	accId ASC,
	dateWork ASC,
	kindCode ASC,
	custIdRh
))

-- drop table #doc2

create table #Doc2(
CustID			int ,
accid			int,
AccNls			varchar(25),
rest				money,
restCourt		money,
datework		date,
primary key (accid)
)

create table #sum_control(
accid			int,
amount			money,
primary key (accid)
)

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


insert #Doc2(CustID, accid, AccNls, rest, restCourt, datework)
select distinct
					t6.CustId,t6.accId,t6.accNls,rest,t7.restCourt ,dateBegin				
from
		Account t6,SaldoDay t7
		where
			 t6.balsCode=21
			 and t7.accId=t6.accId
			 and t7.dateEnd='30000101'
/*select distinct
					CustId,accidCredit,AccCredit, amount,restCourt --,datework				
					from #doc
*/

--select * from #doc2

update #Doc2 set
 datework = t2.datebegin from
 #Doc2 t1, ( select a1.accid ,max(datebegin) datebegin  from #Doc2 a1, SaldoDay a2
						where 
							a1.accid=a2.accId and
							a2.datebegin<convert(date,getdate())
							and restbegin=0
							group by a1.accid
					) t2
where t1.accid=t2.accid


--delete #PayTurnCm
insert  #PayTurnCm(	accId ,	dateWork ,	kindCode ,	amount_sum ,	amountCourt_sum ,
rateCommiss,rateCourt,amount, amountCourt,amountCommiss,
custid,		custIdRh ,	accNls )

select t2.accIdDebet,  convert(date,getdate()),convert(int ,substring(t2.acccredit,4,2)) kindcode, 
sum(t2.amount) amount,sum(t2.amountCur) amountCour, 
0,0,0,0,0,
t1.custid,t2.custIdRh,t2.accDebet
 from  #doc2 t1, PayTurn t2
where 
    t2.accIdDebet=t1.accid
	and t2.accCredit like '3%'
--	and t2.dateWork between t1.datework and @datework
	and t2.dateWork between  t1.datework and convert(date,getdate())
	group  by  t2.accIdDebet, convert(int ,substring(t2.acccredit,4,2)), t1.custid,	 t2.custIdRh,t2.accDebet

-------------------------------контроль сумм оборотов с платежами
insert #sum_control(accid,amount)
select accid,sum(amount_sum) amount from #PayTurnCm
group by accid

if    (
				((	select sum(t1.amount-t2.amount) from #doc t1 ,#sum_control t2 where t1.accidCredit =t2.accid) <>0.0)
				or
				((select count(*) from  #doc ) <> (select count(*) from #Doc t1,#sum_control  t2 where t1.accidCredit=t2.accid))
			)
--select 1
return -- возврат
---------------------------------------------------------------------------------
	update t1
	set custIdcm= t2.cmCustId 
	from #PayTurnCm t1, vCustCmService t2
	where 
	t1.custid=t2.custId	and
	t1.kindcode=t2.CRKindCode

update t1
set
	t1.rateCommiss=isnull(t2.rateCommiss,0),
	t1.rateCourt=isnull(t2.rateCourt,0)
from #PayTurnCm t1, AgreementMaster t3 , AgreementAddRH t2 
where
t3.custId=t1.Custid and
t3.agrId = t2.agrId

update t2
set amountCourt=round(amountCourt_sum*rateCourt/100.,2)
from #PayTurnCm  t2
-- комиссия за обслуживание
update t2
set amountCommiss=round((amount_sum-amountCourt_sum)*rateCommiss/100.,2)
from #PayTurnCm  t2

update t2
set amount=amount_sum-amountCommiss-amountCourt
from #PayTurnCm t2

update a1
set a1.rateComm=a2.rateComm,
		a1.rateCourt=a2.rateCourt,
		a1.amountComm=a2.amountComm,
		a1.amountCourt=a2.amountCourt,
		a1.amountPay=a2.amountPay
from
#Doc a1,(
select accid,max(rateCommiss) rateComm,max(rateCourt) rateCourt,sum(amountCommiss) amountComm,
sum(amountCourt) amountCourt, sum(amount) amountPay
    from #PayTurnCm
	group by accid
) a2
where a1.accidCredit=a2.accId

/*


update t1
set 
	t1.rateComm=isnull(t2.rateCommiss,0),
	t1.rateCourt=isnull(t2.rateCourt,0)
from #Doc t1, AgreementMaster t3 , AgreementAddRH t2 
where
t3.custId=t1.CustID and
t3.agrId = t2.agrId


update t2
set rateCourt=isnull(t1.rateComm,0)
from #Doc t2,#percentComm t1
where
t2.CustID=t1.custid


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
*/
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

BEGIN 
delete #PayTurn
where 
PayStatus=1			
and accCredit like '21%'

insert #PayTurn( TurnId,DateWork,ND,NDDate,AccIdDebet,AccIdCredit,AccDebet,AccCredit,Amount,
							AmountCur,PayNote,DateOper,PayStatus,regId,distid,paidid,flCourt)
  select 
							DocPayId,DateWork,ND,NDDate,AccIdDebet,AccIdCredit,AccDebet,AccCredit,Amount,
							AmountCur,PayNote,DateOper,PayStatus,regId,distid,paidid,flCourt
							from DocPreparePay
where
PayStatus=1			
and accCredit like '21%'

 	if @@error	<> 0
		goto __retErr
goto   __forward



begin Transaction 
BEGIN TRY


exec Pay_Pay_SaldoDay

insert PayTurn( TurnId,DateWork,ND,NDDate,AccIdDebet,AccIdCredit,AccDebet,AccCredit,
						Amount,AmountCur,PayNote,R030,DateOper,PayStatus,regid,distid)  select 
 TurnId,DateWork,ND,NDDate,AccIdDebet,AccIdCredit,AccDebet,AccCredit,
						Amount,AmountCur,PayNote,'980',getdate(),2,regId ,distid
from #PayTurn


--exec sp__msg  'Ok'

delete t2
from #PayTurn t1,DocPreparePay t2
where 
t2.DocPayId=t1.TurnId

delete PayTurnCm
from PayTurnCm t1,#PayTurnCm t2
where
t1.accId=t2.accId and
t1.dateWork=t2.dateWork  and
t1.kindCode=t2.kindCode



insert 
 payturncm(  accId,dateWork,kindCode,amount_sum,amountCourt_sum,rateCommiss,rateCourt,
 amount,amountCourt,amountCommiss,custid,custIdRh,custIdCm,accNls )
 select    accId,dateWork,kindCode,amount_sum,amountCourt_sum,rateCommiss,rateCourt,
 amount,amountCourt,amountCommiss,custid,custIdRh,custIdCm,accNls  
 from #PayTurnCm


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