create procedure dbo.p_Tsk_1_LinkExternalPay @inputFileId int as
begin

-- Setup autolink
update ExternalPay
set custId = t2.custId
from ExternalPay t1
join BankAccount t2 on t2.mfo = t1.mfoCorr and t2.accountNumber = t1.accountCorr
where
t1.inputFileId = @inputFileId;


with vCust as
(
	select INNOKPO, max(custId) as custId from vCustomer 
					where INNOKPO in ( select distinct okpoCorr 
										from CheckParamPays where inputFileId = @inputFileId )
	group by INNOKPO
	having count(*) = 1
)
update ExternalPay
set custId = t2.custId
from ExternalPay t1
join vCust t2 on t2.INNOKPO = t1.okpoCorr 
where
inputFileId = @inputFileId
and t1.custId is null;


end