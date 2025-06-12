use SocCisNet
go

create or alter procedure spInsertPackageWork
	  @PackageId int
	, @WorkCode	 varchar(50)
as
begin
	if exists (select null from PackageWorks where PackageId = @PackageId and WorkCode = @WorkCode)
		return

	insert PackageWorks (
		  PackageId
		, WorkCode	
	)
	values (
		  @PackageId
		, @WorkCode	
	)
end
go


