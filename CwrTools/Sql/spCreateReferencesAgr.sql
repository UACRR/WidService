use CWR
go

create or alter procedure spCreateReferencesAgr
	@cwrFileId int
as
begin
	declare @rowNumberShift int = (select isnull(max(BaseRecTranId), 0) from BaseRecTran)
	drop table if exists #BaseRecTranRows
	select 
		  @rowNumberShift + row_number() over (order by TranSeqNr) as BaseRecTranId
		, RecGrhId
		, TranSeqNr
		, RecAgrId as RecId
	into #BaseRecTranRows
	from RecAgr t1
		join RecGrh t2 on t2.TranType = 'Agr'
		join RecHdr t3 on t2.RecHdrId = t3.RecHdrId
		join CwrFiles t4 on t3.CwrFileId = t4.CwrFileId
	where t1.BaseRecTranId is null
		and t4.CwrFileId = @cwrFileId

	insert BaseRecTran(BaseRecTranId, RecGrhId, TranSeqNr)
	select BaseRecTranId, RecGrhId, TranSeqNr
	from #BaseRecTranRows

	update t2
	set t2.BaseRecTranId = t1.BaseRecTranId
	from #BaseRecTranRows t1
		join RecAgr t2 on t1.RecId = t2.RecAgrId
end 