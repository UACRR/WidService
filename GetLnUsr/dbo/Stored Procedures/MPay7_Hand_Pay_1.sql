create procedure [dbo].[MPay7_Hand_Pay_1]
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


declare @DateOper date
declare curso  cursor for   select    distinct dateWork from 
payturn

			
    open curso
    fetch curso into   @DateOper                                   
     while @@fetch_status =0  
--2	     
BEGIN
delete #PayTurn
insert #PayTurn( TurnId,DateWork,ND,NDDate,AccIdDebet,AccIdCredit,AccDebet,AccCredit,Amount,
							AmountCur,PayNote,DateOper,PayStatus,regId,distid )
  select 
							turnId,DateWork,ND,NDDate,AccIdDebet,AccIdCredit,AccDebet,AccCredit,Amount,
							AmountCur,PayNote,DateOper,PayStatus,regId,distid
							from payturn
	where
	datework=@DateOper

  	if @@error	<> 0
		goto __retErr
				
__retErr:

return 1

begin Transaction 
BEGIN TRY
		exec Pay_Pay_SaldoDay

		delete 
			from 
				#PayTurn 

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
select * from saldoday_copy 