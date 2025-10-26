use CWR
go

create or alter procedure spCreateCopyRightHistoryOutline
as
begin
	
	truncate table Z_CopyRightHistoryOutline
	insert Z_CopyRightHistoryOutline (
		  FinalCopyRightId
		, CopyRightId
		, SeqNr
		, SeqNrReversed
	)
	select distinct
		  t1.ChildId	as FinalCopyRightId
		, t1.ChildId	as CopyRightId
		, 1				as SeqNr
		, 0				as SeqNrReversed
	from MediaService..CopyRightHistory t1
		left join MediaService..CopyRightHistory t2 on t1.ChildId = t2.ParentId
	where t2.ParentId is null

	declare @InsertedRowCount int = @@rowcount
	declare @level int = 1

	while @InsertedRowCount > 0
	begin
		insert Z_CopyRightHistoryOutline (
			  FinalCopyRightId
			, CopyRightId
			, SeqNr
			, SeqNrReversed
		)
		select distinct
			  t1.FinalCopyRightId
			, t2.ParentId	as CopyRightId
			, @level + 1    as SeqNr
			, 0				as SeqNrReversed
		from Z_CopyRightHistoryOutline t1
			join MediaService..CopyRightHistory t2 on t1.CopyRightId = t2.ChildId
		where t1.SeqNr = @level
		set @InsertedRowCount = @@rowcount
		set @level = @level + 1
	end

	; with Reversed as (
		select 
		    FinalCopyRightId
		  , CopyRightId
		  , SeqNr
		  , row_number() over (partition by FinalCopyRightId order by SeqNr desc ) as SeqNrReversed
		from Z_CopyRightHistoryOutline
	)
	update t1
	set t1.SeqNrReversed = t2.SeqNrReversed
	from Z_CopyRightHistoryOutline t1
		join Reversed t2 on 
			t1.FinalCopyRightId = t2.FinalCopyRightId
			and t1.CopyRightId = t2.CopyRightId
			and t1.SeqNr = t2.SeqNr

	--select t3.rHolderType, t2.RoleCode, dbo.fnCheckRoleDefined(t3.rHolderType, t2.RoleCode), 0
	update t1
	set 
		  t1.RightHolderType = t3.rHolderType
		, t1.CopyRightRole = t2.RoleCode
		, t1.IsRoleDefiled = dbo.fnCheckRoleDefined(t3.rHolderType, t2.RoleCode)
		, t1.CopyRightRoleNew = 0
	from Z_CopyRightHistoryOutline t1
		join MediaService..CopyRight t2 on t1.CopyRightId = t2.cRightId
		join MediaService..RightHolder t3 on t2.CustId = t3.CustId

	--select *
	declare @seqNrReversedCur int = 1
	declare @seqNrReversedMax int = (select max(SeqNrReversed) from Z_CopyRightHistoryOutline)
	while @seqNrReversedCur <= @seqNrReversedMax
	begin
		update t1
		set t1.CopyRightRoleNew = t2.CopyRightRole
		from Z_CopyRightHistoryOutline t1
			join Z_CopyRightHistoryOutline t2 on 
				t1.FinalCopyRightId = t2.FinalCopyRightId
		where t1.SeqNr = 1
			and t2.SeqNrReversed = @seqNrReversedCur
			and t1.IsRoleDefiled = 0
			and t1.CopyRightRoleNew = 0
			and t2.IsRoleDefiled = 1
			and t1.RightHolderType = t2.RightHolderType

		set @seqNrReversedCur = @seqNrReversedCur + 1
	end
end

go

-- exec spCreateCopyRightHistoryOutline

