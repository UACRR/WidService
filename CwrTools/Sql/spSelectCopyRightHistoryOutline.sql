use CWR
go

create or alter procedure spSelectCopyRightHistoryOutline
	@copyRightId int
as
begin
	drop table if exists #CopyRightHistoryOutline
	select cRightId as CopyRightId, 1 as SeqNr, cRightId as ParentCopyRightId
	into #CopyRightHistoryOutline
	from MediaService..CopyRight
	where cRightId = @copyRightId

	declare @InsertedRowCount int = @@rowcount
	declare @level int = 1

	while @InsertedRowCount > 0
	begin
		insert #CopyRightHistoryOutline (CopyRightId, SeqNr, ParentCopyRightId)
		select t1.CopyRightId, @level + 1 as SeqNr, parentId
		from #CopyRightHistoryOutline t1
			join MediaService..CopyRightHistory t2 on t1.ParentCopyRightId = t2.ChildId
		where t1.SeqNr = @level
		set @InsertedRowCount = @@rowcount
		set @level = @level + 1
	end

	select t2.cRightId as CopyRightId, t1.SeqNr, t3.CustId, t3.Name, t2.RoleCode, t2.createDate, t2.beginDate, t2.endDate, t2.rate as PerShr, t2.RateMech as MecShr
	from #CopyRightHistoryOutline t1
		left join MediaService..CopyRight t2 on t1.ParentCopyRightId = t2.cRightId
		left join MediaService..vCustomerNames t3 on t2.CUstId = t3.CustId
	order by SeqNr

end

go

-- exec spSelectCopyRightHistoryOutline 1635449