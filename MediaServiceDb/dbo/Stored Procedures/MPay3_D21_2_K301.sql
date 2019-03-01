CREATE procedure [dbo].[MPay3_D21_2_K301]
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
-- drop table #doc1
CREATE TABLE #doc1(
	id	int identity,
	regIItemId int,
	distId int ,
	regId int ,
--	periodId int,
	distribDate date,
	amount money NOT NULL,
	CrKindCode int NOT NULL,
	objid int NULL,
	ItemName varchar(100) NULL,
	categoryCode int NULL,
	AccIdDebet int NULL,
	AccIdCredit int NULL,
	AccDebet				varchar(25)			NULL,
	AccCredit				varchar(25)			NULL,
	custId int NULL,
	rate decimal(5, 2) NULL,
	cRType int NULL,
	amountMy		money null,
	amountBalans	money null,
	amountPay	money null,
	distribType		tinyint	null,
	custIdRh integer NULL,  --!T
	primary key (id)
	)
create table #balance(
	id							int,
	distid					int,
	objid						int,
	regIItemId				int,
	amountBals			money,
	primary key (distid,regIItemid)
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
	flCourt		tinyint		null,
	custidRh				int		null,
 PRIMARY KEY CLUSTERED (	TurnId ASC,	DateWork ASC)
)

create table #Doc(
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
	paynote varchar	(120)		null,
	distribType		tinyint	null,
	custIdRh integer NULL  --!T
)
insert #doc1
		(regIItemId,distId,regId,--periodId,
		distribDate,amount,CrKindCode,objid,ItemName,categoryCode,
		AccIdDebet,AccIdCredit,AccDebet,AccCredit,custId,--clnName,
		rate,		amountMy,	amountBalans,	amountPay,cRType,distribType,custIdRh 
		)
select   
		t3.regIItemId,  t1.distId,t1.regId,--t1.periodId,
		t1.distribDate,t3.amount,t1.CrKindCode,
		t4.objid,null ItemName,null categoryCode ,null  AccIdDebet,null AccIdCredit ,
		'21000'+convert(varchar(10),isnull(t4.cmCustId,t4.custId)) AccDebet,
		rtrim(STUFF('30100',6-len(convert (varchar(2),t1.cRKindCode)),len(convert (varchar(2),t1.cRKindCode)),convert (varchar(2),t1.cRKindCode))
		+convert(varchar(10),t4.objId))  AccCredit,isnull(t4.cmCustId,t4.custId) custid,
		isnull(t4.rate,100.),0,0,0, t4.cRType,t1.distType,t4.custid
from 
		distribution t1,DistributionItem t3,RegisterCount t4
where
		t3.regId=t4.regId	and
		t3.regIItemId=t4.regIItemId and
		t3.distId=t1.distid and
--t1.distid=2411
		t1.status=2		and
		t1.distType=1
		
union
 select t1.regIItemId,d1.distId,t1.regId,--d1.periodId,
 d1.distribDate,t3.rAmount,t1.cRKindCode,t3.objId,
			t3.ItemName,t3.categoryCode,null AccIdDebet,null AccIdCredit,'21000'+convert(varchar(10),t1.custId) AccDebet,
			rtrim(STUFF('30100',6-len(convert (varchar(2),t1.cRKindCode)),len(convert (varchar(2),t1.cRKindCode)),convert (varchar(2),t1.cRKindCode))
		+convert(varchar(10),t3.objId))  AccCredit,t1.custId,
		t1.rate,0	amountMy,0	amountBalans,0	amountPay,t1.cRType,d1.distType,t1.custid
   from distribution d1, RegisterCount t1 , BrRegister t2 ,BrRegItem t3
where
	t1.regIdBr = t2.regId and 
 --t2.regId = 1 and
	t3.regId=t2.regId and
	t1.regItemIdBr=t3.regItemId and
	d1.regIdBr=t2.regId	and
	d1.status=2	and
		d1.distType=1
		
  	if @@error	<> 0
		goto __retErr

--определение суммы каждого правообладателя 
update #doc1
set 
	amountMy=round(amount* isnull(rate,0)/100.,2)
--балансировка

  	if @@error	<> 0
		goto __retErr

insert #balance
			(id,distid,objid,regIItemId,amountBals)
select 
			max(id) id,distid,objid,regIItemId,(sum(amountMy) - max(amount)) amountBals
from #doc1
group by distId,objid,regIItemId

  	if @@error	<> 0
		goto __retErr
/*
update t2
	set 
		amountBalans=t1.amountBals
	from #balance t1,#doc1 t2
	where 
		t2.id=t1.id

  	if @@error	<> 0
		goto __retErr

update #doc1
set amountMy=amountMy-amountBalans

  	if @@error	<> 0
		goto __retErr
*/
update #doc1
set 
		amountPay=amountMy

  	if @@error	<> 0
		goto __retErr

--технические счета при отсутсвии правообладателей
update #doc1
set AccDebet=rtrim(STUFF('31100',6-len(convert (varchar(2),CrKindCode)),len(convert (varchar(2),CrKindCode)),convert (varchar(2),CrKindCode))
		+convert(varchar(10),ObjId))		
where custId is  null

  	if @@error	<> 0
		goto __retErr

update #doc1
	set 
		AccIdCredit=accId
	from  #doc1 t1,Account t2
	where
		t2.accNls=t1.AccCredit
--открытие отсутствующих счетов

  	if @@error	<> 0
		goto __retErr

if not exists(select 1 from Account where accNls='110001')
	begin
			declare  @custid integer
			select @custid= custId from vCustomer where ankMy=1
			if (@custid) is not null
				exec OpenAccNLS  @custid , null,  '980', '110001', 'Рахунок доходів'
			else 
				return -1
end
--формирование документов
insert #Doc (regIItemId,distId,regId	,--periodId,
distribDate,amount,kindcode,	custId,objid,
					ItemName,	categoryCode,	AccIdDebet,	AccIdCredit,	AccDebet	,AccCredit,distribType,custIdRh 
					)
select   
					t1.regIItemId,  t1.distId,t1.regId,--t1.periodId,
					t1.distribDate,t1.amountPay,t1.CrKindCode,t1.custId ,t1.objid,
					null ,t1.categoryCode ,AccIdDebet,  AccIdCredit,	AccDebet	,	AccCredit	,distribType,custIdRh 
from 
		#doc1 t1

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

    declare cur cursor for   select   regIItemId,KindCode,ObjId,AccCredit,AccDebet,ItemName,custId from #Doc                                    
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
    fetch cur into  @regIItemId,@KindCode,@ObjId,@AccCredit,@AccDebet,@ItemName,@custid1
                                                   
    while @@fetch_status =0                                                   
	    BEGIN 

           if not exists  (select  1 from Account 
                                        where BalsCode=30
                                                   and ObjId=@ObjId												  
												   and AccNls=@AccCredit
												   )
                 begin
                                      Exec  dbo.OpenAccNLS Null, @Objid,  '980', @AccCredit,@ItemName	
                 end
	if (SUBSTRING(@AccDebet,1,2)='21'	)		
	begin
	        if not exists  (select  1 from Account 
                                        where accNls=@AccDebet
												   )
                 begin
						select @custname=name from vCustomer
						where custid=@custid1

                         Exec  dbo.OpenAccNLS  @custid1, Null,  '980', @AccDebet,@custname
                 end
      end 
                                                                   
                                                   
	if (SUBSTRING(@AccDebet,1,2)='31'	)		
	begin
	        if not exists  (select  1 from Account 
                                        where accNls=@AccDebet
												   )
                 begin

--select  @objid,  '980', @AccDebet,@ItemName
                         Exec  dbo.OpenAccNLS  null, @objid,  '980', @AccDebet,@ItemName
                 end
      end 
		fetch cur into  @regIItemId,@KindCode,@ObjId,@AccCredit,@AccDebet,@ItemName,@custid1
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
insert DocPreparePay( dateWork,regId,distId,	nD,nDDate,accIdDebet,accIdCredit,	accDebet,accCredit,amount,
									amountCur,payNote,	r030,dateOper,	payStatus,paidid,	flCourt,custIdRh
									)
select			distribDate,regId,distId,null,distribDate,	AccIdDebet,	AccIdCredit,	AccDebet,AccCredit,amount,
					case distribType 
						when 4 then	amount
						else 0
					end,
					paynote,'980',getdate(),1,	regIItemId,
					case distribType 
						when 4 then	1
						else null
					end,
					custIdRh 
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



declare @DateOper date
declare curso  cursor for   select    distinct dateWork from 
DocPreparePay
	where
	PayStatus=1	and
	(AccDebet like '31%' or AccDebet like '21%')	and
	AccCredit like '30%'
			
    open curso
    fetch curso into   @DateOper                                   
     while @@fetch_status =0  
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
			and dateWork=@DateOper

  	if @@error	<> 0
		goto __retErr


begin Transaction 
BEGIN TRY
		exec Pay_Pay_SaldoDay

		insert PayTurn( TurnId,DateWork,ND,NDDate,AccIdDebet,AccIdCredit,AccDebet,AccCredit,
						Amount,AmountCur,PayNote,R030,DateOper,PayStatus,regid,distid,regIItemId,custIdRh)  
		select
				 TurnId,DateWork,ND,NDDate,AccIdDebet,AccIdCredit,AccDebet,AccCredit,
						Amount,AmountCur,PayNote,'980',getdate(),2,regId ,distid,paidid,custidRh
		from
			#PayTurn
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
fetch curso into   @DateOper
--2
END
close curso 
deallocate curso  
return @Retcode  
end