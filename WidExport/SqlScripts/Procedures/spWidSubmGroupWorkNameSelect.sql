use SocWidSubmit
go

create or alter procedure spWidSubmGroupWorkNameSelect
	  @WidSubmGroupId int
	, @ObjId int
as
begin
select
	  Id			
	, WidSubmGroupId
	, ObjId			
	, LocalName		
	, WidName		
	, IsMain		
	, IsConfirmed
	, IsDuplicate
	, CreatedBy		
	, ModifiedBy	
	, CreatedAt		
	, ModifiedAt	
from  WidSubmGroupWorkName
where WidSubmGroupId = @WidSubmGroupId
	and ObjId = @ObjId

order by IsMain desc
end
go

-- exec spIpiPartySelect 'KHARCHYSH'
