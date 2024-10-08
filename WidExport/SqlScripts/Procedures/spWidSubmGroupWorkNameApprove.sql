use SocWidSubmit
go

create or alter procedure spWidSubmGroupWorkNameApprove
	  @WidSubmGroupWorkNameId int
	, @IsDuplicate bit
	, @WidName varchar(100)
	, @ModifiedBy varchar(10)
as
begin
	update SocWidSubmit..WidSubmGroupWorkName
	set
		  WidName		= @WidName
		, IsConfirmed	= 1
		, IsDuplicate	= @IsDuplicate
		, ModifiedBy	= @ModifiedBy
		, ModifiedAt	= getdate()
	where Id = @WidSubmGroupWorkNameId
end
go

-- spWidSubmGroupSelect
