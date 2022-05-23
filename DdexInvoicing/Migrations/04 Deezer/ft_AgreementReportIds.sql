drop function if exists ft_AgreementReportIds;
go

create function ft_AgreementReportIds (@ddexReportId int)
returns @retTable
table(id int)
as
begin
	-- Returns ids of all reports that belong to the same period and agreement as the one with id = @ddexReportId
	insert into @retTable
	select t2.Id
	from DdexReport t1
		join DdexReport t2 on t1.ddexReportingPeriodId = t2.ddexReportingPeriodId
			and t1.licId = t2.licId
			and t1.custId = t2.custId
	where t1.id = @ddexReportId
	return
end 
go
