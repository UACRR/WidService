use SocWidSubmit
go

create or alter procedure spWidSubmGroupPartySelect
	@groupId int
as
begin

drop table if exists #Party

create table #Party (
	  Id				int		
	, WidSubmGroupId	int
	, CustId			int		
	, IpBaseNr			varchar(13)	
	, IpNameNr			int
	, InterName			nvarchar(100)
	, LocalName			nvarchar(100)
)

insert #Party (
	  Id			
	, WidSubmGroupId
	, CustId		
	, IpBaseNr		
	, IpNameNr		
	, InterName		
	, LocalName
)
select
	  t1.Id										as Id			
	, t1.WidSubmGroupId							as WidSubmGroupId
	, t1.CustId									as CustId		
	, t1.IpBaseNr								as IpBaseNr		
	, t1.IpNameNr								as IpNameNr		
	, trim(concat(t2.Name, ' ', t2.FstName))	as InterName		
	, ''										as LocalName
from SocWidSubmit..WidSubmGroupParty t1
	join SocIpi..IpiName t2 on t1.IpBaseNr = t2.IpBaseNr
		and t1.IpNameNr = t2.IpNameNr
where WidSubmGroupId = @groupId

select
	  Id			
	, WidSubmGroupId
	, CustId		
	, IpBaseNr		
	, IpNameNr		
	, InterName		
	, LocalName
from #Party
order by InterName

drop table if exists #Party

end
go

-- exec spWidSubmGroupPartySelect 1
