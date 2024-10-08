use SocWidSubmit
go

create or alter procedure spWidSubmGroupWorkPerformerApprove
	  @WidSubmGroupWorkPerformerId int
	, @WidPerformer varchar(100)
	, @ModifiedBy varchar(10)
as
begin
	update SocWidSubmit..WidSubmGroupWorkPerformer
	set
		  WidName		= @WidPerformer
		, IsConfirmed	= 1
		, ModifiedBy	= @ModifiedBy
		, ModifiedAt	= getdate()
	where Id = @WidSubmGroupWorkPerformerId
end
go

-- spWidSubmGroupSelect
