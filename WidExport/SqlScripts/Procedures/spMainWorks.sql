use SocWidSubmit
go

create or alter procedure spMainWorks
	@filter nvarchar(100)
as
begin
	select top 1000
		  t2.Id												as GroupId	
		, t2.Name											as GroupName
		, t1.ObjId											as ObjId
		, t1.LocalName										as LocalName
		, t1.WidName										as WidName
		, min(t4.IpNameNr)									as IpNameNr
		, string_agg (
			  convert(
				  nvarchar(max)
				, trim(concat(t4.Name, ' ', t4.FstName))
			  )
			, ', '
		  )
		  within group ( order by t4.Name )					as Authors
	from WidSubmGroupWorkName t1
		join WidSubmGroup t2 on t1.WidSubmGroupId = t2.Id
		join WidSubmGroupPartyWork t3 on t2.Id = t3.WidSubmGroupId and t1.ObjId = t3.ObjId
		join SocIpi..IpiName t4 on t3.IpNameNr = t4.IpNameNr
	where t1.IsMain = 1
		and LocalName like @filter
	group by   
		  t2.Id
		, t2.Name
		, t1.ObjId
		, t1.LocalName
		, t1.WidName
	order by t1.LocalName
end
go

-- spMainWorks '%'

