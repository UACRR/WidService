use MediaSericeDataFix
go

drop table if exists RightHolderFixed
create table RightHolderFixed (
	  CustId int primary key
	, IpBaseNr varchar(25)
	, IpNameNr varchar(25)
	, IpBaseNrNew varchar(25)
	, IpNameNrNew varchar(25)
)
go

-- Fill-in RightHolderFixed
insert RightHolderFixed
select
	  CustId
	, InterCode
	, IPIBase
	, InterCode
	, IPIBase
from MediaService..RightHolder
go

drop table if exists RightHolderProblemFixes
create table RightHolderProblemFixes (
	  CustId int
	, ProblemType int
	, primary key (CustId, ProblemType)
)
go
-->>>>>>>>>>>>>>>>>>>>>>>>> IpBaseNr
-- 1 - set IpBaseNr null
insert RightHolderProblemFixes select CustId, 1 from RightHolderFixed where trim(IpBaseNrNew) = ''
update t1 set t1.IpBaseNrNew = null from RightHolderFixed t1 join RightHolderProblemFixes t2 on t1.CustId = t2.CustId and t2.ProblemType = 1
go

-- 2 - trim IpBaseNr
insert RightHolderProblemFixes select CustId, 2 from RightHolderFixed where IpBaseNrNew is not null and (left(IpBaseNrNew, 1) = '' or right(IpBaseNrNew, 1) = '')
update t1 set t1.IpBaseNrNew = trim(t1.IpBaseNrNew) from RightHolderFixed t1 join RightHolderProblemFixes t2 on t1.CustId = t2.CustId and t2.ProblemType = 2
go

-- 3 - Check IpBaseNr wrong format
insert RightHolderProblemFixes select CustId, 3 from RightHolderFixed where dbo.fnCheckIpBaseNrFormat(IpBaseNrNew) <> 0
update t1 set t1.IpBaseNrNew = null from RightHolderFixed t1 join RightHolderProblemFixes t2 on t1.CustId = t2.CustId and t2.ProblemType = 3
go

-- 4 - Restore IpBaseNr from misplaced IpNameNr
drop table if exists #Source4
select t1.CustId, t1.IpBaseNr, t3.IpBaseNr as IpBaseNrNew
into #Source4
from RightHolderFixed t1
	join RightHolderProblemFixes t2 on t1.CustId = t2.CustId
		and t2.ProblemType = 3
	join SocIpi..IpiName t3 on t1.IpBaseNr = t3.IpNameNr
where try_cast(t1.IpBaseNr as int) is not null

insert RightHolderProblemFixes select CustId, 4 from #Source4

update t1
set t1.IpBaseNrNew = t2.IpBaseNrNew
from RightHolderFixed t1
	join #Source4 t2 on t1.CustId = t2.CustId
go

-- 5 - Lost IpBaseNr
drop table if exists #Source5
select t1.*
into #Source5
from RightHolderFixed t1
	left join SocIpi..IpiBase t2 on t1.IpBaseNrNew = t2.IpBaseNr
where t1.IpBaseNrNew is not null
	and t2.IpBaseNr is null

insert RightHolderProblemFixes select CustId, 5 from #Source5
go

-->>>>>>>>>>>>>>>>>>>>>>>>> IpNameNr
-- 6 - set IpNameNr null
insert RightHolderProblemFixes select CustId, 6 from RightHolderFixed where trim(IpNameNrNew) = ''
update t1 set t1.IpNameNrNew = null from RightHolderFixed t1 join RightHolderProblemFixes t2 on t1.CustId = t2.CustId and t2.ProblemType = 6
go

-- 7 - trim IpNameNr
insert RightHolderProblemFixes select CustId, 7 from RightHolderFixed where IpNameNr is not null and (left(IpNameNrNew, 1) = '' or right(IpNameNrNew, 1) = '')
update t1 set t1.IpNameNrNew = trim(t1.IpNameNrNew) from RightHolderFixed t1 join RightHolderProblemFixes t2 on t1.CustId = t2.CustId and t2.ProblemType = 7
go

-- 8 - Check IpNameNr wrong format
insert RightHolderProblemFixes select CustId, 8 from RightHolderFixed where try_cast(IpNameNr as int) = null
update t1 set t1.IpNameNrNew = null from RightHolderFixed t1 join RightHolderProblemFixes t2 on t1.CustId = t2.CustId and t2.ProblemType = 8
go

-- 9 - Restore IpNameNr from IpBaseNr
drop table if exists #Source9
select t1.CustId, t2.IpNameNr, cast(t2.IpNameNr as varchar(max)) as IpNameNrNew
into #Source9
from RightHolderFixed t1
	join SocIpi..IpiName t2 on t1.IpBaseNrNew = t2.IpBaseNr
		and t2.NameType = 'PA'
where t1.IpNameNrNew is null

insert RightHolderProblemFixes select CustId, 9 from #Source9

update t1
set t1.IpNameNrNew = t2.IpNameNrNew
from RightHolderFixed t1
	join #Source9 t2 on t1.CustId = t2.CustId
go

-- 10 - Lost IpNameNr
drop table if exists #Source10
select t1.*
into #Source10
from RightHolderFixed t1
	left join SocIpi..IpiName t2 on t1.IpNameNrNew = t2.IpNameNr
where t1.IpNameNrNew is not null
	and t2.IpNameNr is null

insert RightHolderProblemFixes select CustId, 10 from #Source10
go

-- 11 - Not Found IpBaseNr
drop table if exists #Source11
select t1.*
into #Source11
from RightHolderFixed t1
	left join SocIpi..IpiBase t2 on t1.IpBaseNrNew = t2.IpBaseNr
where t1.IpBaseNrNew is not null
	and t2.IpBaseNr is null

insert RightHolderProblemFixes select CustId, 11 from #Source11
	-- Make NULL to provide for further search bu name
update t2
set t2.IpBaseNrNew = null
from vRightHolderFixed t1
	join RightHolderFixed t2 on t1.CustId = t2.CustId
where t1.ProblemType = 11
go

-- 12 - Not Matching IpBaseNr-IpNameNr
drop table if exists #Source12
select t1.*
into #Source12
from RightHolderFixed t1
	left join SocIpi..IpiName t2 on t1.IpBaseNrNew = t2.IpBaseNr and t1.IpNameNrNew = t2.IpNameNr
where t1.IpBaseNrNew is not null
	and t1.IpNameNrNew is not null
	and t2.IpBaseNr is null

insert RightHolderProblemFixes select CustId, 12 from #Source12
	-- Update name code from base code
update t2
set t2.IpNameNrNew = t3.IpNameNr
from vRightHolderFixed t1
	join RightHolderFixed t2 on t1.CustId = t2.CustId
	join SocIpi..IpiName t3 on t3.NameType = 'PA'
		and t1.IpBaseNrNew = t3.IpBaseNr
where t1.ProblemType = 12
go

select * from vRightHolderFixed where ProblemType = 13 order by ProblemType