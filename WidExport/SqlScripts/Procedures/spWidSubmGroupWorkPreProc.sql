use SocWidSubmit
go

create or alter procedure spWidSubmGroupWorkPreProc
	  @groupId int
	, @objId int
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
declare @AlreadyInWid		int = 8	 -- Існує в WID і має ISWC
declare @ReSent				int = 9	 -- Надіслано повторно
declare @StatusCompleted	int = 10 -- Передачу завершено

-- Твори що мають WIC і ISWC в MS
update t1
set t1.Status = @AlreadyInWid
from WidSubmGroupWork t1
	join ObjIdToWic t2 on t1.ObjId = t2.ObjId
where t1.WidSubmGroupId = @groupId
	and t1.ObjId = @objId
	and isnull(t2.Iswc, '') <> ''
	and Status in (@Unprocessed, @InWork, @Postponed)

-- За замовчуванням відкладаємо 
update WidSubmGroupWork
set Status = @Postponed
from WidSubmGroupWork t1
where t1.WidSubmGroupId = @groupId
	and  t1.ObjId = @objId
	and Status in (@Unprocessed, @InWork, @Postponed)

-- Плануємо до передачі твори, що не містять помилок
; with ReadyToSubmObjIds as (
	select WidSubmGroupId, ObjId
	from WidSubmGroupWorkCheckList
	where 
	    HasOwnAuthor			= 1
	and RolesDefined			= 1
	and HasNonPublisher			= 1
	and AllInIpi				= 1
	and PubShare0or100			= 1
	and MecShare0or100			= 1
	and HasShare				= 1
	and NamesApproved			= 1
	and PerformersApproved		= 1
	and AllIpiCodesValid		= 1
)
update t1
set t1.Status = @Accepted
from WidSubmGroupWork t1
	join ReadyToSubmObjIds t2 on t1.WidSubmGroupId = t2.WidSubmGroupId and t1.ObjId = t2.ObjId
where t1.WidSubmGroupId = @groupId
	and  t1.ObjId = @objId
	and Status in (@Unprocessed, @InWork, @Postponed)

end
go

-- exec spWidSubmGroupPreProc 17
