use SocCisNet
go

create or alter procedure spInsertWorkPerformer
	  @FstName varchar(128)
	, @LstName varchar(128)
	, @WorkCode  varchar(50)
as
begin
	if exists (select * from WorkPerformers where FstName = @FstName and LstName = @LstName and WorkCode = @WorkCode)
		return

	insert WorkPerformers (
		  FstName
		, LstName
		, WorkCode 
	)
	values (
		  @FstName
		, @LstName
		, @WorkCode
	)
end
go