create procedure dbo.p_Tsk_1_CheckInputFile @inputFileId int as
begin
-- Пошук дублів
update CheckParamPays 
set inputStatus = 0
from CheckParamPays t1
join ExternalPay t2 on t1.accountCorr = t2.accountCorr and t1.okpoCorr = t2.okpoCorr and t1.docNum = t2.docNum
						and t1.docDate = t2.docDate and t1.sCredit = t2.sCredit and t1.nplat = t2.nplat
where
t1.inputFileId = @inputFileId;

-- Не дублі
update CheckParamPays
set inputStatus = 1
where
inputFileId = @inputFileId
and inputStatus is null;

-- Setup autolink
update CheckParamPays
set LinkStatus = 1
from CheckParamPays t1
join BankAccount t2 on t2.mfo = t1.mfoCorr and t2.accountNumber = t1.accountCorr
where
t1.inputFileId = @inputFileId;


with vCust as
(
	select INNOKPO from vCustomer where INNOKPO in ( select distinct okpoCorr from CheckParamPays where inputFileId = @inputFileId )
	group by INNOKPO
	having count(*) = 1
)
update CheckParamPays
set LinkStatus = 1
from CheckParamPays t1
join vCust t2 on t2.INNOKPO = t1.okpoCorr 
where
inputFileId = @inputFileId
and LinkStatus is null;

update CheckParamPays
set LinkStatus = 0
where
LinkStatus is null;



end