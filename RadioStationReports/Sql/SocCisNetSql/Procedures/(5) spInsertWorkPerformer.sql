use SocCisNet
go

create or alter procedure spInsertWorkPerformer
	  @FstName varchar(128)
	, @LstName varchar(128)
	, @WorkId  int
as
begin
	if exists (select * from WorkPerformers where FstName = @FstName and LstName = @LstName and WorkId = @WorkId)
		return

	insert WorkPerformers (
		  FstName
		, LstName
		, WorkId 
	)
	values (
		  @FstName
		, @LstName
		, @WorkId
	)
end
go