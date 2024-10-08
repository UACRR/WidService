use SocWidSubmit
go

create or alter procedure spWidSubmGroupWorkPerformerSelect
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
	, IsConfirmed
	, IsDuplicate
	, CreatedBy		
	, ModifiedBy	
	, CreatedAt		
	, ModifiedAt	
from  WidSubmGroupWorkPerformer
where WidSubmGroupId = @WidSubmGroupId
	and ObjId = @ObjId
end
go

-- exec spIpiPartySelect 'KHARCHYSH'
