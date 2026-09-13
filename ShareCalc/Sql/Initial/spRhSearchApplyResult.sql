use ShareCalc
go

create or alter procedure spRhSearchApplyResult
	  @foundBy varchar(32)
	, @cancelMultiFoundSearch bit
as
begin
	truncate table ShareCalc..Z_RhFoundRanked

	insert ShareCalc..Z_RhFoundRanked
	select CustId, count(*)
	from ShareCalc..Z_RhFound group by CustId

	update t3
	set t3.IpBaseNr = t2.IpBaseNr
		, FoundBy = @foundBy
	from ShareCalc..Z_RhFoundRanked t1
		join ShareCalc..Z_RhFound t2 on t1.CustId = t2.CustId
		join ShareCalc..Z_RhNamesTr t3 on t1.CustId = t3.CustId
	where t1.Count = 1

	if @cancelMultiFoundSearch = 1
	begin
		update t3
		set t3.IpBaseNr = 'I-000000000-0'
			, FoundBy = @foundBy
		from ShareCalc..Z_RhFoundRanked t1
			join ShareCalc..Z_RhFoundRanked t2 on t1.CustId = t2.CustId
			join ShareCalc..Z_RhNamesTr t3 on t1.CustId = t3.CustId
		where t1.Count > 1
	end
end
go
