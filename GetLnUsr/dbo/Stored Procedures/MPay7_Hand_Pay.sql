CREATE procedure [dbo].[MPay7_Hand_Pay]
as
begin
/*

"ручная оплата"


*/
SET NOCOUNT ON;
declare @RetCode integer
set @RetCode = 0
--delete #doc
-- drop table #doc1

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
	Id	int not null,
	turnId int NULL,
	dateWork date NOT NULL,
	nD varchar(25) NULL,
	nDDate date NULL,
	accIdDebet int NULL,
	accIdCredit int NULL,
	accDebet varchar(25) NULL,
	accCredit varchar(25) NULL,
	amount numeric(20, 2) not NULL,
	amountCur numeric(20, 2) NULL,
	payNote varchar(160) NULL,
	r030 char(3) NULL,
	dateOper datetime NULL,
	payStatus int NULL,
	regId int NULL,
	distId int NULL,
	custIdRh int NULL,
	regIItemId int NULL,
	primary key  (Id)
)

insert #Doc (Id, turnId,	dateWork,nD,nDDate,	accDebet,accCredit,	amount,	amountCur,payNote,r030,dateOper,
				payStatus,regId,distId,custIdRh,regIItemId 
		)
select   
Id, null,	dateWork,nD,nDDate,	accDebet,accCredit,	amount,	isnull(amountCur,0),payNote,r030,dateOper,
				payStatus,regId,distId,custIdRh,regIItemId from 
		HandDocPay
		where payStatus =1

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


update #doc
	set payStatus= 3
where 
  accIdCredit is null or
  accIdDebet is null 

 update t2
  set payStatus= t1.payStatus
 from #doc t1,HandDocPay t2 
 where
	t1.Id=t2.Id
	and t1.payStatus = 3

	delete #doc where payStatus = 3

update t1
set custIdRh = t2.custid
from #doc t1,account t2
where
t1.acciddebet= t2.accId
and SUBSTRING(t1.accDebet,1,2)='21'
and t1.custIdRh is null




--формируем платежные документы    
insert DocPreparePay( dateWork,regId,distId,	nD,nDDate,accIdDebet,accIdCredit,	accDebet,accCredit,amount,
									amountCur,payNote,	r030,dateOper,	payStatus,paidid,	flCourt,custIdRh
									)
select			dateWork,regId,distId,null,nDDate,	AccIdDebet,	AccIdCredit,	AccDebet,AccCredit,amount,
					amountCur,	paynote,'980',getdate(),9,	Id,null,custIdRh 
from #Doc t1



declare @DateOper date
declare curso  cursor for   select    distinct dateWork from 
DocPreparePay
	where
	PayStatus=9	


			
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
	PayStatus=9	

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

__retErr:

return 1

begin Transaction 
BEGIN TRY
		exec Pay_Pay_SaldoDay

		insert PayTurn( TurnId,DateWork,ND,NDDate,AccIdDebet,AccIdCredit,AccDebet,AccCredit,
						Amount,AmountCur,PayNote,R030,DateOper,PayStatus,regid,distid,regIItemId,custIdRh
						,payturntype,DocType,handId)  
		select
				 TurnId,DateWork,ND,NDDate,AccIdDebet,AccIdCredit,AccDebet,AccCredit,
						Amount,AmountCur,PayNote,'980',getdate(),2,regId ,distid,null,custidRh,payturntype,9,paidid
		from
			#PayTurn
		delete t2
			from 
				#PayTurn t1,DocPreparePay t2
				where 
						t2.DocPayId=t1.TurnId

		delete t2
			from 
				#PayTurn t1,HandDocPay t2
				where 
						t2.Id=t1.paidid


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
