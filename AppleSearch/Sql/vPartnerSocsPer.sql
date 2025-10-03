use AppleMusic
go

create or alter view vPartnerSocsPer
as
select t1.CustId, t1.interCode
from MediaService..Community t1
	join MediaService..AgreementAddCommunity t2 on t1.CustId = t2.CustId
where t1.InterCode is not null
	and t2.agrStatus = 2
	and t2.IsPer = 1
go