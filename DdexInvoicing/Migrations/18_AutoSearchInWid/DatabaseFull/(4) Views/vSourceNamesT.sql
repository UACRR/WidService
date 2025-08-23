use AutoSearch
go

create or alter view vSourceNamesT
as
	select t1.*, t3.Title
	from SourceNamesT t1
		join SourceNameWorks t2 on t1.SourceNameId = t2.SourceNameId
		join Ddex..IdentMw t3 on t2.WorkId = t3.Id
go