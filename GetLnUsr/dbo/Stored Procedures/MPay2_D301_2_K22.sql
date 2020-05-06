CREATE procedure [dbo].[MPay2_D301_2_K22]
as
begin
/*
"переброска средств" со счетов плательщиков  по счетам объектов права
*/
SET NOCOUNT ON;
declare @RetCode integer

set @RetCode = 0
create table #partner (
	distid				int		,
	regId					int	,
	custid				int		null,
	distribDate		date		null,
	partnerId			int				null,
	partnerComiss	money,
	AccIdDebet		 int			NULL,
	AccIdCredit		 int			NULL,
	AccDebet			varchar(25)			NULL,
	AccCredit			varchar(25)			NULL,
primary key (distid)
)
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
		t3.distId=t1.distid  and
		t4.regId=t3.regId	and
		t4.regIItemId=t3.regIItemId
		and t1.status=1 
		and t1.distType=1
		and t1.isCourt is null
		and t1.regIdBr is null
--and t1.distId=1
union
select		t3.regitemId, t1.distId,t3.regId,-- t1.periodId,
t1.distribDate ,t3.rAmount,t1.cRKindCode,t2.custId,t3.objId,t3.ItemName ,
				t3.categoryCode,null,  null ,null,'22000'+convert(varchar(10),t2.custId)
 from 
			Distribution t1 , BrRegister t2 ,BrRegItem t3
 where 
		t1.regIdBr is not null		and
		t1.regIdBr = t2.regId and
		t3.regId=t2.regId		and
		t1.status=1

  	if @@error	<> 0
		goto __retErr


insert #partner(		distid,regId,custid	,distribDate,	partnerId	,partnerComiss,	AccIdDebet,	AccIdCredit,	AccDebet, AccCredit
						)
select		distinct		t1.distId,t2.regId,t2.custId,t1.distribDate,partnerId,t1.partnerCommiss,null,null,'400'+convert(varchar(10),partnerId),
						'22000'+convert(varchar(10),t2.custId)
from 
			Distribution t1, Register t2,#doc t3
where
		t2.regId=t1.regId	and
		(t2.custId is not null and isnull(t1.partnerId,0)<>0 and isnull (t1.partnerCommiss,0)<>0)	
		and t3.distid=t1.distid

  	if @@error	<> 0
		goto __retErr


--select * from #doc
--select * from #partner
update t1
	set paynote=substring(ltrim(rtrim(t4.Name))+'  '+ltrim(rtrim(t4.Author)),1,120)	from 
			#doc t1,ObjectRight t4
	where
			t1.ObjId=t4.ObjId


 	if @@error	<> 0
		goto __retErr
goto   __forward

__retErr:

return 1

__forward:


if  (select count(*) from #Doc)<>0
BEGIN
	begin Transaction 
	BEGIN TRY
--проверка/открытие 301/302 счетов 

    declare cur cursor for   select  distinct  distid,regIItemId,KindCode,ObjId,AccCredit,ItemName,custId from #Doc                                    
    declare     @regIItemId		integer
	declare		@KindCode		int                                            
    declare     @ObjId         integer
	declare     @AccCredit		varchar(14)
    declare     @Account		varchar(14)
	declare		@AccID		integer
	declare		@KindCodeCH  varchar(2)  
	declare		@AccName	varchar(30)                                          
	declare		@ItemName		varchar(100)
	declare		@custid		int
	declare @custname varchar(100)
	declare		 @distid int
    open cur                                                   
    fetch cur into  @distid,@regIItemId,@KindCode,@ObjId,@AccCredit,@ItemName,@custid
                                                   
    while @@fetch_status =0                                                   
	    BEGIN 
		select @Account= rtrim('30100')
		select  @KindCodeCH  =convert (varchar(2),@KindCode)
		select @Account= STUFF(@Account,6-len(@KindCodeCH),len(@KindCodeCH),@KindCodeCH)		
		select @Account= rtrim(@Account+convert(varchar(10),@ObjId))


           if not exists  (select  1 from Account 
                                        where BalsCode=30
                                                   and ObjId=@ObjId												  
												   and AccNls=@Account
												   )
                 begin
                                      Exec  dbo.OpenAccNLS Null, @Objid,  '980', @Account,@ItemName	
                 end
				
				update #Doc
				 set AccDebet=@Account
				 where
				 @regIItemId	=regIItemId	and
				 @ObjId  =objid						and
				 @KindCode =kindCode		and
				 @ItemName=ItemName		and
				 @distid = distId
            if not exists  (select  1 from Account 
                                        where BalsCode=22
                                                   and CustID=@CustID
												   --and R030=@R030
												   )
                 begin
						select @custname=name from vCustomer
						where custid=@custid
                        select @Account= '22000'+convert(varchar(10),@custid)
	--					select @CustID, Null,  '980', @Account,@custname
                         Exec  dbo.OpenAccNLS  @CustID, Null,  '980', @Account,@custname
                 end
 
        fetch cur into  @distid,@regIItemId,@KindCode,@ObjId,@AccCredit,@ItemName ,@custid                                                  
    	END                                                                                                    
close cur   
deallocate cur 
     
--проверка "наличия" счетов партнеров
if (select count(*) from #partner)<>0
	begin
			declare c cursor for   select  distinct AccDebet,partnerId  from #partner
			open c 
			fetch c into  @Account,@custid
			 while @@fetch_status =0                                                   
				BEGIN 
						select @custname=name from vCustomer
						where custid=@custid
						       if not exists  (select  1 from Account 
                                        where									  
												   AccNls=@Account
												   )
						 Exec  dbo.OpenAccNLS  @CustID, Null,  '980', @Account,@custname			
						 update t1 set AccIdDebet=AccId
						 from  #partner t1, Account t2
						 where
						 t2.accNls=@Account and
						 t1.AccDebet=@Account
						fetch c into  @Account,@custid
				END
				update t1
				set AccIdCredit=t2.accid
				from  #partner t1,Account t2
				where
					t1.AccCredit=t2.accNls
				close c
				deallocate c      
	end

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
								t1.regId=t2.regId	and
								t2.paidid=t1.regIItemId
								)
insert DocPreparePay(	dateWork,regId,distId,nD,	nDDate,accIdDebet,	accIdCredit,	accDebet,accCredit,amount,amountCur,
									payNote,r030,dateOper,payStatus,paidid
									)
select					distribDate,regId,distId,null,distribDate,	AccIdDebet,	AccIdCredit,	AccDebet,AccCredit,partnerComiss,0,
							Null,	'980',	getdate(),	1,	Null
from #partner t1
/*where not exists (select * from DocPreparePay t2
								where 
								t1.regId=t2.regId	and
								t2.paidid=t1.regIItemId
								)

*/
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
declare curso  cursor for   select    distinct dateWork
		from 	DocPreparePay
		where
			PayStatus=1	
and isnull(flCourt,0)=0			and
(AccDebet like '3%' or AccDebet like '4%')	and
AccCredit like '22%'
    open curso
    fetch curso into   @DateOper                                   
     while @@fetch_status =0      
BEGIN
	delete #PayTurn
	insert #PayTurn( TurnId,DateWork,ND,NDDate,AccIdDebet,AccIdCredit,AccDebet,AccCredit,Amount,
							AmountCur,PayNote,DateOper,PayStatus,regId,distid,paidid )
	select 
							DocPayId,DateWork,ND,NDDate,AccIdDebet,AccIdCredit,AccDebet,AccCredit,Amount,
							0,PayNote,DateOper,PayStatus,regId,distid,paidid
							from DocPreparePay
	where
		PayStatus=1	
		and dateWork=@DateOper
and isnull(flCourt,0)=0			and
(AccDebet like '3%' or AccDebet like '4%')	and
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
			t2.distid in (select distinct distid from #PayTurn)
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
