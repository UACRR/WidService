use CWR
go

create or alter procedure spCwrFileRegister
	  @Direction varchar(3)
	, @Path nvarchar(512)
	, @Name nvarchar(32)
as

begin

	declare @cwrFileId int = (select CwrFileId from CwrFiles where Name = @Name)

	if @cwrFileId is not null
		exec spDeleteFile @cwrFileId

	insert CwrFiles (
			Direction
		, Path
		, Name
		, RespPath
		, RespName
		, Status
	) 
	values (
		  @Direction
		, @Path
		, @Name
		, null
		, null
		, 0
	)
	end

	select cast(scope_identity() as int)

go
