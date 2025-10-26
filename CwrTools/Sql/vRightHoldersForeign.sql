use CWR
go

create or alter view vRightHoldersForeign
as
select t1.*
from MediaService..RightHolder t1
	left join MediaService..AgreementAddRH t2 on t1.CustId = t2.CustId
where t2.CustId is null
go

--select * from vRightHoldersOwnAll
--select * from vRightHoldersOwnActive
--select * from vRightHoldersOwnInActive
--select * from vRightHoldersForeign