use SocCisNet
go

create or alter procedure spInsertWork
	  @WorkCode		varchar(50)			
	, @Name			varchar(128)
	, @Iswc			varchar(11)
	, @SrcWorkId	int
	, @SrcSocCde	int
	, @SrcDbCde		int
	, @RefWorkCde	int			
	, @SubmittedAt	datetime	
	, @CreatedAt	datetime	
	, @UpdatedAt	datetime	
	, @LoadedAt		datetime	
as
begin
	if exists (select null from Works where WorkCode = @WorkCode)
		return

	insert Works (
		  WorkCode		
		, Name			
		, Iswc			
		, SrcWorkId	
		, SrcSocCde	
		, SrcDbCde		
		, RefWorkCde	
		, SubmittedAt
		, CreatedAt	
		, UpdatedAt	
		, LoadedAt		
	)
	values (
		  @WorkCode		
		, @Name			
		, @Iswc			
		, @SrcWorkId	
		, @SrcSocCde	
		, @SrcDbCde		
		, @RefWorkCde	
		, @SubmittedAt
		, @CreatedAt	
		, @UpdatedAt	
		, @LoadedAt		
	)
end
go