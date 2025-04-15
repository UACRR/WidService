begin try
begin tran
declare @root nvarchar(max) = (
	select dbo.fnTrimRightAfter(TemplateFileFullName, '\', 1)
	from Configuration
)

update Reports
set WorkFilesPath = concat(@root, 'All')
where WorkFilesPath = ''

update Reports
set 
	SearchFileName = ''
	, CheckFileName = ''
	, DistributionFileName = ''

/*
select t1.Id, concat(@root, t5.ShortName, '\', t4.beginDate, '_', t4.endDate) as WorkFilesPath
from Reports t1
	join ReportIdToRegId t2 on t1.Id = t2.ReportId
	join MediaService..Register t3 on t2.RegId = t3.RegId
	join MediaService..PaidPeriod t4 on t3.periodId = t4.PeriodId
	join MediaService..vCustomerNamesShort t5 on t3.CustId = t5.CustId
	join RadioStations t6 on t1.RadioStationId = t6.Id
		and t5.shortName = t6.Name
*/
commit tran

end try

begin catch
rollback tran
end catch

