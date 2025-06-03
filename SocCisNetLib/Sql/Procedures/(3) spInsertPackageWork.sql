use SocCisNet
go

create or alter procedure spInsertPackageWork
	  @PackageId int
	, @WorkId	 int
as
begin
	if exists (select null from PackageWorks where PackageId = @PackageId and WorkId = @WorkId)
		return

	insert PackageWorks (
		  PackageId
		, WorkId	
	)
	values (
		  @PackageId
		, @WorkId	
	)
end
go


