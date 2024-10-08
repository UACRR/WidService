use SocWidSubmit
go

create or alter procedure spSubmFileDecline
	@SubmFileId int
as
begin

declare @WorkStatusSent int = 4
	, @WorkStatusAccepted int = 3
	, @SubmFileStatusDeclined int = 3
declare @WidSubmGroupId int = (
	select WidSubmGroupId
	from SubmFile 
	where Id = 2026
)

update t1
set 
	  t1.Status = @WorkStatusAccepted
	, t1.ShouldResubmit = 1
from WidSubmGroupWork t1
	join RecWia t2 on t1.RecWiaId = t2.Id
where t1.WidSubmGroupId = @WidSubmGroupId
	and Status = @WorkStatusSent

update SubmFile 
set SubmFileStatus = @SubmFileStatusDeclined 
where Id = @SubmFileId

end