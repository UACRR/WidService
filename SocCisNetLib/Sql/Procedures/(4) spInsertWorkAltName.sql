use SocCisNet
go

create or alter procedure spInsertWorkAltName
	  @Name		varchar(128)
	, @NameType	char(2)
	, @Lan		char(2)
	, @WorkId	int			
as
begin
	if exists (select null from WorkAltNames where Name = @Name and WorkId = @WorkId)
		return

	insert WorkAltNames (
		  Name		
		, NameType	
		, Lan		
		, WorkId	
	)
	values (
		  @Name	
		, @NameType
		, @Lan	
		, @WorkId
	)
end
go