use SocCisNet
go

create or alter procedure spInsertWorkSubmission
	  @SrcWorkId int
	, @SrcSocCde int
	, @TranCde   varchar(3)
	, @UpdatedAt  datetime
	, @WorkCode    varchar(50)
as
begin
	if exists (select null
		from WorkSubmissions
		where
		    SrcWorkId = @SrcWorkId 
		and SrcSocCde = @SrcSocCde 
		and TranCde   = @TranCde   
		and UpdatedAt  = @UpdatedAt  
		and WorkCode    = @WorkCode  
	)
		return

	insert WorkSubmissions (
		  SrcWorkId
		, SrcSocCde
		, TranCde  
		, UpdatedAt 
		, WorkCode   
	)
	values (
		  @SrcWorkId
		, @SrcSocCde
		, @TranCde  
		, @UpdatedAt 
		, @WorkCode   
	)
			
end
go