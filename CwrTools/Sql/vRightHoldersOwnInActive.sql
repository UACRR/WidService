use CWR
go

create or alter view vRightHoldersOwnInActive
as
select t1.*
from MediaService..RightHolder t1
	join MediaService..AgreementAddRH t2 on t1.CustId = t2.CustId
where not (t2.agrStatus = 2 and dbo.fnIsDateInInterval(getdate(), t2.DateBegin, t2.DateEnd) = 1)
go

select * from vRightHoldersOwnInActive