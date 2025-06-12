use SocCisNet
go

create or alter procedure spInsertPackage
	  @PackageId int
	, @CreatedAt datetime
	, @LoadedAt datetime
as
begin
	if exists (select null from Packages where PackageId = @PackageId)
		return

	insert Packages (
		  PackageId
		, CreatedAt
		, LoadedAt 
	)
	values (
		  @PackageId
		, @CreatedAt
		, @LoadedAt 
	)
end