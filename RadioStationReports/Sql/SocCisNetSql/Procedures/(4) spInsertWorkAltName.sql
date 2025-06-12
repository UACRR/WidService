use SocCisNet
go

create or alter procedure spInsertWorkAltName
	  @Name		varchar(128)
	, @NameType	char(2)
	, @Lan		char(2)
	, @WorkCode	varchar(50)			
as
begin
	if exists (select null from WorkAltNames where Name = @Name and WorkCode = @WorkCode)
		return

	insert WorkAltNames (
		  Name		
		, NameType	
		, Lan		
		, WorkCode	
	)
	values (
		  @Name	
		, @NameType
		, @Lan	
		, @WorkCode
	)
end
go