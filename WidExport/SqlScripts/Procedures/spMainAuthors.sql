use SocWidSubmit
go

create or alter procedure spMainAuthors
	@filter as nvarchar(100)
as
begin
	select 
		  t3.Id										as SubmFileGroupId
		, t3.Name									as SubmFileGroupName
		, trim(concat(t2.Name, ' ', t2.FstName))	as AuthorName
	from WidSubmGroupParty t1
		join SocIpi..IpiName t2 on t1.IpNameNr = t2.IpNameNr
		join WidSubmGroup t3 on t1.WidSubmGroupId = t3.Id
	where trim(concat(t2.Name, ' ', t2.FstName)) like @filter
	order by t2.Name
end
go

-- spMainAuthors '%AL%'