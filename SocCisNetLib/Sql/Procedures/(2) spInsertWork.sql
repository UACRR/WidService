use SocCisNet
go

create or alter procedure spInsertWork
	  @WorkId		int			
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
	if exists (select null from Works where WorkId = @WorkId)
		return

	insert Works (
		  WorkId		
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
		  @WorkId		
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