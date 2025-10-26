use CWR
go

create or alter view vRightHoldersOwnAll
as
select t1.*
from MediaService..RightHolder t1
	join MediaService..AgreementAddRH t2 on t1.CustId = t2.CustId
go

--select * from vRightHoldersOwnAll
--select * from vRightHoldersOwnActive
--select * from vRightHoldersOwnInActive