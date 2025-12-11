use CWR
go

create or alter procedure spCreateTmpRightHolderRoleCorrections
as

truncate table TmpRightHolderRoleCorrections

-- Сперш за весь період часу
; with Stat as (
	select 
		  t3.CustId
		, t3.rHolderType
		, sum(case when t2.roleCode = 1 then 1 else 0 end) as CntA
		, sum(case when t2.roleCode = 2 then 1 else 0 end) as CntC
		, sum(case when t2.roleCode = 7 then 1 else 0 end) as CntAR
		, sum(case when t2.roleCode = 8 then 1 else 0 end) as CntE
		, sum(case when t2.roleCode = 10 then 1 else 0 end) as CntCA
	from vWrongRoleRightHolders t1
		join MediaService..CopyRight t2 on t1. CustId = t2.CustId
		join MediaService..RightHolder t3 on t2.CustId = t3.CustId
	group by t3.CustId, t3.rHolderType
)
insert TmpRightHolderRoleCorrections
select
	  CustId		as CustId		
	, rHolderType	as rHolderType
	, CntA			as CntA
	, CntC			as CntC
	, CntAR			as CntAR
	, CntE			as CntE
	, CntCA			as CntCA
	, 0				as CntWRong
	, rHolderType	as RightHolderTypeNew	
	, 0				as CopyRightRoleTypeNew
    , 0				as IsCorrect
    , 0				as IsApplied
from Stat

-- Далі число невірних станом на поточну дату
--select * from TmpRightHolderRoleCorrections
select t1.CustId, count(*) as CntWRong
from TmpRightHolderRoleCorrections t1
	join MediaService..CopyRight t2 on t1.CustId = t2.custId
--where dbo.fnIsDateInInterval(getdate(), t2.beginDate, t2.endDate) = 0
group by t1.CustId


GO


