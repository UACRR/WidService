use SocWidSubmit
go

create or alter procedure spWidSubmGroupWorkSelectWia
	  @GroupId int
	, @ObjId int
as
begin

declare @SubmFileName varchar(max) = (select max(name) from SubmFile where WidSubmGroupId = @GroupId)
declare @SubmFileId int = (select id from SubmFile where Name = @SubmFileName)

select Id, WrkTtl
from RecWia
where SubmFileId = @SubmFileId
	and cast(substring(SubmWrkNr, 3, 1000) as int) = @ObjId

end
go

