use SocWidSubmit
go

create or alter procedure spRespFileSelectOrCreate
	@name varchar(32)
as
begin
declare @respFileId int = (select Id from RespFile where name = @name)

if @respFileId is null
begin
	insert RespFile	(
		  Name
		, Year
		, Month
		, Day
	)
	values (
		 @name
		, year(getdate())
		, month(getdate())
		, day(getdate())
	)
	set @respFileId = scope_identity()
end

select
	  Id
	, Name
	, Year
	, Month
	, Day
from RespFile
where Id = @respFileId

end
go

-- exec spSubmFileSelectCurrent
