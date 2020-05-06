

CREATE procedure [dbo].[p_Tsk_1_LinkExternalPay] @inputFileId int as
begin
declare @data table ( paidid int primary key );
SET NOCOUNT ON;
-- Setup autolink
update ExternalPay
set custId = t2.custId
output inserted.paidId into @data
from ExternalPay t1
join BankAccount t2 on t2.mfo = t1.mfoCorr and t2.accountNumber = t1.accountCorr
where
t1.inputFileId = @inputFileId
and t1.custId is null;

insert into MoneyReceived(paidId, custId, moneyType, dateInvoice, numberInvoice, goalInvoice, amount, destribAmount, destribPrepay )
select t1.paidId, t1.custId, 1, t1.docDate, t1.docNum, t1.nplat, t1.sCredit, 0, 0
from ExternalPay t1
join @data t2 on t2.paidid = t1.paidId;

delete @data;

with vCust as
(
	select INNOKPO, max(custId) as custId from vCustomer 
					where INNOKPO in ( select distinct okpoCorr 
										from ExternalPay where inputFileId = @inputFileId )
	group by INNOKPO
	having count(*) = 1
)
update ExternalPay
set custId = t2.custId
output inserted.paidId into @data
from ExternalPay t1
join vCust t2 on t2.INNOKPO = t1.okpoCorr 
where
inputFileId = @inputFileId
and t1.custId is null;

insert into MoneyReceived(paidId, custId, moneyType, dateInvoice, numberInvoice, goalInvoice, amount, destribAmount, destribPrepay )
select t1.paidId, t1.custId, 1, t1.docDate, t1.docNum, t1.nplat, t1.sCredit, 0, 0
from ExternalPay t1
join @data t2 on t2.paidid = t1.paidId;


end
