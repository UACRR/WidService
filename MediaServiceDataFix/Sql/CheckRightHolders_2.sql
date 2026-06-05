use MediaSericeDataFix
go

-- 13 - Search codes by rightholder name
drop table if exists MsRightHolderNamesTr
select t1.CustId, MediaService.dbo.TransLitFromUkrToLat(t2.ShortName) as Name
into MsRightHolderNamesTr
from RightHolderFixed t1
	left join MediaService..vCustomerNamesShort t2 on t1.CustId = t2.CustId
where t1.IpBaseNrNew is null

drop table if exists IpiRightHolderNames
select IpNameNr, trim(concat(Name, ' ', FstName)) as Name
into IpiRightHolderNames
from SocIpi..IpiName

drop table if exists #Source13
; with FoundNames as (
	select t1.*, t2.IpNameNr
	from MsRightHolderNamesTr t1
		left join IpiRightHolderNames t2 on t1.Name = t2.Name
	where t2.Name is not null
),
NoDupCustIds as (
	select CustId from FoundNames group by CustId having count(*) = 1
)
select t1.*
into #Source13
from FoundNames t1
	join NoDupCustIds t2 on t1.CustId = t2.CustId

insert RightHolderProblemFixes select CustId, 13 from #Source13

update t2
set t2.IpBaseNrNew = t4.IpBaseNr, t2.IpNameNrNew = t4.IpNameNr
from vRightHolderFixed t1
	join RightHolderFixed t2 on t1.CustId = t2.CustId
	join #Source13 t3 on t1.CustId = t3.CustId
	join SocIpi..IpiName t4 on t3.IpNameNr = t4.IpNameNr
where t1.ProblemType = 13

go

-- 14 - No name rightholders to delete

insert RightHolderProblemFixes
select t1.CustId, 14
from RightHolderFixed t1
	left join MediaService..vCustomerNamesShort t2 on t1.CustId = t2.CustId
	left join MediaService..CopyRight t3 on t1.CustId = t3.CustId
where IpBaseNrNew is null and isnull(shortName, '') = '' and t3.CustId is null


-- 15 - Remaining Missing Codes
drop table if exists #Source15
select t1.*, t2.shortName, t3.Name
into #Source15
from RightHolderFixed t1
	join MediaService..vCustomerNamesShort t2 on t1.CustId = t2.CustId
	join MsRightHolderNamesTr t3 on t1.CustId = t3.CustId
where IpBaseNrNew is null and isnull(shortName, '') <> ''
order by isnull(shortName, '')

select *
from #Source15 t1
	left join MediaService..CopyRight t2 on t1.CustId = t2.CustID
where t2.CustId is null





delete t3
--select *
from RightHolderFixed t1
	left join MediaService..vCustomerNamesShort t2 on t1.CustId = t2.CustId
	join MediaService..Customer t3 on t1.CustId = t3.CustId
where t1.IpBaseNrNew is null
	and t2.ShortName is null


