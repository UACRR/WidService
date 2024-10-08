use SocWidSubmit
go

create or alter procedure spSubmFilePostSent
	@submFileId int
as
begin
	-- WidSubmGroupWorkStatus
	declare @Unprocessed		int = 0   -- Не оброблено
	declare @InWork				int = 1	 -- На розгляді
	declare @Postponed			int = 2	 -- Відкладено
	declare @Accepted			int = 3	 -- Завтверждено до передачі
	declare @Sent				int = 4	 -- Надіслано
	declare @Approved			int = 5	 -- Прийнято
	declare @Rejected			int = 6	 -- Відхилено
	declare @PartApproved		int = 7	 -- Прийнято з зауваженнями
	declare @AlreadyInWid		int = 8	 -- Існує в WID
	declare @ReSent				int = 9	 -- Надіслано повторно
	declare @StatusCompleted	int = 10 -- Передачу завершено

	-- SubmFileStatus
	declare @SubmFileStatusCurrent	 int = 0 -- Поточний
	declare @SubmFileStatusSubmitted int = 1 --	Переданий
	
	-- WidSubmGroupStatus
	declare @WidSubmGroupStatusCreated			int = 0
	declare @WidSubmGroupStatusFileCreated		int = 1
	declare @WidSubmGroupStatusFileSubmitted	int = 2
	declare @WidSubmGroupStatusResponded		int = 3
	declare @WidSubmGroupStatusCompleted		int = 4

	-- Параметри
	declare @GroupId int = (select WidSubmGroupId from SubmFile where Id = @submFileId)

	-- Статус файлу
	update SubmFile 
	set SubmFileStatus = @SubmFileStatusSubmitted 
	where Id = @submFileId

	-- Статус групи
	update WidSubmGroup 
	set Status = @WidSubmGroupStatusFileSubmitted
	where Id = @groupId 

	--  Статус творів групи
	update WidSubmGroupWork 
    set 
		  Status = @StatusCompleted
	where WidSubmGroupId = @GroupId
        and Status in (@Approved, @PartApproved, @AlreadyInWid)

	update WidSubmGroupWork 
    set 
		  Status = @StatusCompleted
	where WidSubmGroupId = @GroupId
        and Status = @Rejected and ShouldResubmit = 0

	update WidSubmGroupWork 
    set 
		  SubmFileId = @submFileId
		, Status = @Sent
	where WidSubmGroupId = @GroupId
        and Status = @Accepted

	update WidSubmGroupWork 
    set 
		    SubmFileId = @submFileId
		  , Status = @ReSent
		  , ShouldResubmit = null
	where WidSubmGroupId = @GroupId
        and Status = @Rejected and ShouldResubmit = 1
end
go

--select format(getdate(), 'hhmmss')

-- exec spIpiPartySelect 'KHARCHYSH'
