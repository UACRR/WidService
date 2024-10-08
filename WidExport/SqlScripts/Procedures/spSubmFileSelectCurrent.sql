use SocWidSubmit
go

create or alter procedure spSubmFileSelectCurrent
as
begin
declare @statusCreated int = 0
declare @submFileId int = (select Id from SubmFile where SubmFileStatus = @statusCreated)

if @submFileId is null
begin
	insert SubmFile	(
		  Name
		, Year
		, Month
		, Day
		, SubmFileStatus
	)
	values (
		  'Current'
		, year(getdate())
		, month(getdate())
		, day(getdate())
		, @statusCreated
	)
	set @submFileId = scope_identity()
end

select
	  Id
	, Name
	, Year
	, Month
	, Day
	, SubmFileStatus
from SubmFile
where Id = @submFileId

end
go

-- exec spSubmFileSelectCurrent
