use DdexAnalysis
go

create or alter procedure spCheckAuthorsVsCcidConsistencyMsPer
	@ddexReportId int
as
begin

	drop table if exists #NoRightWorks
	; with Sums as (
		select 
			  DdexReportId
			, ObjId
			, sum(0.01 * PerShr * isnull(PerSocShr, 0) * 0.5) as Sum
		from WrkDdexReportAuthors
		group by DdexReportId, ObjId
	)
	select  DdexReportId
			, ObjId
	into #NoRightWorks
	from Sums
	where sum = 0 and ddexreportid = @ddexReportId

	declare @WronglyInvoicedCnt int

	select @WronglyInvoicedCnt = count(*)
	from Ddex..CcidInDetail t1
		join Ddex..CcidInFile t2 on t1.fileId = t2.fileId
		join Ddex..CcidInvoice t3 on t2.ccidInvoiceId = t3.Id
		join #NoRightWorks t4 on t4.DdexReportId = t3.ddexReportId
			and concat('ObjId:', t4.ObjId) = t1.workcode
	where t1.claim_licensor_perf > 0

	declare @WronglyPayedCnt int
	select @WronglyPayedCnt = count(*)
	from Ddex.. DdexAdjConsolidatedDetail t1
		join #NoRightWorks t4 on t4.DdexReportId = t1.ddexReportId
			and concat('ObjId:', t4.ObjId) = t1.workcode
	where t1.AllocatedRevenueCompensated > 0 and RightsType = 1 --PER
	end

	print 'Found in MS, PER'
	print '    Share invoiced when no right exist, count = ' + cast(@WronglyInvoicedCnt as varchar(100))
	print '    Paid when share not invoiced, count = ' + cast(@WronglyPayedCnt as varchar(100))

go

create or alter procedure spCheckAuthorsVsCcidConsistencyMsMec
	@ddexReportId int
as
begin

	drop table if exists #NoRightWorks
	; with Sums as (
		select 
			  DdexReportId
			, ObjId
			, sum(0.01 * MecShr * isnull(MecSocShr, 0) * 0.5) as Sum
		from WrkDdexReportAuthors
		group by DdexReportId, ObjId
	)
	select  DdexReportId
			, ObjId
	into #NoRightWorks
	from Sums
	where sum = 0 and ddexreportid = @ddexReportId

	declare @WronglyInvoicedCnt int

	select @WronglyInvoicedCnt = count(*)
	from Ddex..CcidInDetail t1
		join Ddex..CcidInFile t2 on t1.fileId = t2.fileId
		join Ddex..CcidInvoice t3 on t2.ccidInvoiceId = t3.Id
		join #NoRightWorks t4 on t4.DdexReportId = t3.ddexReportId
			and concat('ObjId:', t4.ObjId) = t1.workcode
	where t1.claim_licensor_mech > 0

	declare @WronglyPayedCnt int
	select @WronglyPayedCnt = count(*)
	from Ddex.. DdexAdjConsolidatedDetail t1
		join #NoRightWorks t4 on t4.DdexReportId = t1.ddexReportId
			and concat('ObjId:', t4.ObjId) = t1.workcode
	where t1.AllocatedRevenueCompensated > 0 and RightsType = 0 --Mec
	end

	print 'Found in MS, Mec'
	print '    Share invoiced when no right exist, count = ' + cast(@WronglyInvoicedCnt as varchar(100))
	print '    Paid when share not invoiced, count = ' + cast(@WronglyPayedCnt as varchar(100))

go

create or alter procedure spCheckAuthorsVsCcidConsistencyWidPer
	@ddexReportId int
as
begin

	drop table if exists #NoRightWorks
	; with SuWid as (
		select 
			  DdexReportId
			, Wic
			, sum(0.01 * PerShr * isnull(PerSocShr, 0) * 0.5) as Sum
		from WrkDdexReportAuthors
		group by DdexReportId, Wic
	)
	select  DdexReportId
			, Wic
	into #NoRightWorks
	from SuWid
	where sum = 0 and ddexreportid = @ddexReportId

	declare @WronglyInvoicedCnt int

	select @WronglyInvoicedCnt = count(*)
	from Ddex..CcidInDetail t1
		join Ddex..CcidInFile t2 on t1.fileId = t2.fileId
		join Ddex..CcidInvoice t3 on t2.ccidInvoiceId = t3.Id
		join #NoRightWorks t4 on t4.DdexReportId = t3.ddexReportId
			and concat('Wic:', t4.Wic) = t1.workcode
	where t1.claim_licensor_perf > 0

	declare @WronglyPayedCnt int
	select @WronglyPayedCnt = count(*)
	from Ddex.. DdexAdjConsolidatedDetail t1
		join #NoRightWorks t4 on t4.DdexReportId = t1.ddexReportId
			and concat('Wic:', t4.Wic) = t1.workcode
	where t1.AllocatedRevenueCompensated > 0 and RightsType = 1 --PER
	end

	print 'Found in Wid, PER'
	print '    Share invoiced when no right exist, count = ' + cast(@WronglyInvoicedCnt as varchar(100))
	print '    Paid when share not invoiced, count = ' + cast(@WronglyPayedCnt as varchar(100))

go

create or alter procedure spCheckAuthorsVsCcidConsistencyWidMec
	@ddexReportId int
as
begin

	drop table if exists #NoRightWorks
	; with SuWid as (
		select 
			  DdexReportId
			, Wic
			, sum(0.01 * MecShr * isnull(MecSocShr, 0) * 0.5) as Sum
		from WrkDdexReportAuthors
		group by DdexReportId, Wic
	)
	select  DdexReportId
			, Wic
	into #NoRightWorks
	from SuWid
	where sum = 0 and ddexreportid = @ddexReportId

	declare @WronglyInvoicedCnt int

	select @WronglyInvoicedCnt = count(*)
	from Ddex..CcidInDetail t1
		join Ddex..CcidInFile t2 on t1.fileId = t2.fileId
		join Ddex..CcidInvoice t3 on t2.ccidInvoiceId = t3.Id
		join #NoRightWorks t4 on t4.DdexReportId = t3.ddexReportId
			and concat('Wic:', t4.Wic) = t1.workcode
	where t1.claim_licensor_mech > 0

	declare @WronglyPayedCnt int
	select @WronglyPayedCnt = count(*)
	from Ddex.. DdexAdjConsolidatedDetail t1
		join #NoRightWorks t4 on t4.DdexReportId = t1.ddexReportId
			and concat('Wic:', t4.Wic) = t1.workcode
	where t1.AllocatedRevenueCompensated > 0 and RightsType = 0 --Mec
	end

	print 'Found in Wid, Mec'
	print '    Share invoiced when no right exist, count = ' + cast(@WronglyInvoicedCnt as varchar(100))
	print '    Paid when share not invoiced, count = ' + cast(@WronglyPayedCnt as varchar(100))

go

create or alter procedure spCheckAuthorsVsCcidConsistencyPerRep
	@ddexReportId int
as
begin
	set nocount on
	print '>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>'
	
	declare @Id as int
		, @FileType varchar(100)
		, @year int
		, @quarter int
		, @month int
	select @Id = t1.Id
		, @FileType = t1.FileType
		, @year = t2.year
		, @quarter = t2.quarter
		, @month = t2.month
	from Ddex..DdexReport t1
		join Ddex.. DdexReportingPeriod t2 on t1.ddexReportingPeriodId = t2.Id
	where t1.Id = @ddexReportId
	print concat('REPORT: Id = ', @Id,'; FileType = ', @FileType, '; Year = ', @year, '; Quarter = ', @quarter, '; Month = ', @month);

	exec spCheckAuthorsVsCcidConsistencyMsPer @ddexReportId
	exec spCheckAuthorsVsCcidConsistencyMsMec @ddexReportId
	exec spCheckAuthorsVsCcidConsistencyWidPer @ddexReportId
	exec spCheckAuthorsVsCcidConsistencyWidMec @ddexReportId

	print '<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<'
end
go

create or alter procedure spCheckAuthorsVsCcidConsistencyAll
as
begin
	declare @Id int
	declare rep_cursor cursor for select Id from Ddex..DdexReport order by Id   
	open rep_cursor  
  
	fetch next from rep_cursor into @Id
  
	while @@fetch_status = 0  
	begin  
		exec spCheckAuthorsVsCcidConsistencyPerRep @Id
		fetch next from rep_cursor into @Id
	end
end
go

exec spCheckAuthorsVsCcidConsistencyPerRep 43
go

--exec spCheckAuthorsVsCcidConsistencyAll
go


