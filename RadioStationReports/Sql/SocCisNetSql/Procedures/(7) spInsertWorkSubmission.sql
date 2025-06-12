use SocCisNet
go

create or alter procedure spInsertWorkSubmission
	  @SrcWorkId int
	, @SrcSocCde int
	, @TranCde   varchar(3)
	, @UpdatedAt  datetime
	, @WorkId    int
as
begin
	if exists (select null
		from WorkSubmissions
		where
		    SrcWorkId = @SrcWorkId 
		and SrcSocCde = @SrcSocCde 
		and TranCde   = @TranCde   
		and UpdatedAt  = @UpdatedAt  
		and WorkId    = @WorkId  
	)
		return

	insert WorkSubmissions (
		  SrcWorkId
		, SrcSocCde
		, TranCde  
		, UpdatedAt 
		, WorkId   
	)
	values (
		  @SrcWorkId
		, @SrcSocCde
		, @TranCde  
		, @UpdatedAt 
		, @WorkId   
	)
			
end
go