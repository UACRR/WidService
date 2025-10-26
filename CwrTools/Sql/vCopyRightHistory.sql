use CWR
go

create or alter view vCopyRightHistory
as
select 
	  t3.ObjId
	, t3.categoryCode
	, t3.Name as n1
	, t2.cRightId
	, t5.CustId
	, t1.SeqNr
	, t5.Name as n2
	, t4.rHolderType
	, t2.roleCode
	, t2.createDate
	, t2.beginDate
	, t2.endDate
	, t2.rate
	, t2.rateMech
from Z_CopyRightHistoryOutline t1
	join MediaService..CopyRight t2 on t1.CopyRightId = t2.cRightId
	join MediaService..ObjectRight t3 on t2.ObjId = t3.ObjId 
	join MediaService..RightHolder t4 on t2.CustId = t4.CustId
	join MediaService..vCustomerNames t5 on t2.CustId = t5.CustId
--order by t3.Name, t1.FinalCopyRightId, t1.SeqNr

go