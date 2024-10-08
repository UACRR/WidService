use SocWidSubmit
go

create or alter procedure spWidSubmGroupStatistics
	@groupId as int
as
begin

-- WidSubmGroupWorkStatus
declare @Unprocessed			int = 0   -- Не оброблено
declare @InWork					int = 1	 -- На розгляді
declare @Postponed				int = 2	 -- Відкладено
declare @Accepted				int = 3	 -- Завтверждено до передачі
declare @Sent					int = 4	 -- Надіслано
declare @Approved				int = 5	 -- Прийнято
declare @Rejected				int = 6	 -- Відхилено
declare @PartApproved			int = 7	 -- Прийнято з зауваженнями
declare @AlreadyInWid			int = 8	 -- Існує в WID
declare @ReSent					int = 9	 -- Надіслано повторно
declare @StatusCompleted		int = 10 -- Передачу завершено

select 
	  isnull(count(*)												, 0)	as Total
	, isnull(sum(case when Status = @Accepted then 1 else 0 end)	, 0)	as Accepted
	, isnull(sum(case when Status = @AlreadyInWid then 1 else 0 end), 0)	as AlreadyInWid
	, isnull(sum(case when Status = @Approved then 1 else 0 end)	, 0)	as Approved
	, isnull(sum(case when Status = @Postponed then 1 else 0 end)	, 0)	as Postponed
	, isnull(sum(case when Status = @Sent then 1 else 0 end)		, 0)	as Sent
	, isnull(sum(case when Status = @ReSent then 1 else 0 end)		, 0)	as ReSent
	, isnull(sum(case when Status = @Approved then 1 else 0 end)	, 0)	as Approved
	, isnull(sum(case when Status = @PartApproved then 1 else 0 end), 0)	as PartApproved
	, isnull(sum(case when Status = @Rejected then 1 else 0 end)	, 0)	as RejectedAsExisting
	, isnull(sum(case when Status = @Rejected then 1 else 0 end)	, 0)	as RejectedMayResubmit
	, isnull(sum(case when Status = @Rejected then 1 else 0 end)	, 0)	as RejectedFinally
from WidSubmGroupWork
where WidSubmGroupId = @groupId


end
go