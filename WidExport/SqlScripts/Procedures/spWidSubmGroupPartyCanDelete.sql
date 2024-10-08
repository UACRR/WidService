use SocWidSubmit
go

create or alter procedure spWidSubmGroupPartyCanDelete
	@ipNameNr int
as
begin

-- WidSubmGroupWorkStatus
declare @Unprocessed					int = 0   -- Не оброблено
declare @InWork							int = 1	 -- На розгляді
declare @Postponed						int = 2	 -- Відкладено
declare @Accepted						int = 3	 -- Завтверждено до передачі
declare @Sent							int = 4	 -- Надіслано
declare @Approved						int = 5	 -- Прийнято
declare @Rejected						int = 6	 -- Відхилено
declare @PartApproved					int = 7	 -- Прийнято з зауваженнями
declare @AlreadyInWid					int = 8	 -- Існує в WID
declare @ReSent							int = 9	 -- Надіслано повторно
declare @StatusCompleted				int = 10 -- Передачу завершено

declare @canDelete int

if exists (
	select null 
	from WidSubmGroupParty t1
		join WidSubmGroupPartyWork t2 on t1.WidSubmGroupId = t2.WidSubmGroupId
			and t1.IpNameNr = t2.IpNameNr
		join WidSubmGroupWork t3 on t2.ObjId = t3.ObjId
			and t1.IpNameNr = t2.IpNameNr
	where t1.IpNameNr = @ipNameNr
		and t3.Status in (@Sent, @Approved, @Rejected, @PartApproved, @ReSent)
)
	set @canDelete = 0
else
	set @canDelete = 1

select @canDelete

end
go

-- exec spWidSubmGroupPartyCanDelete 1

