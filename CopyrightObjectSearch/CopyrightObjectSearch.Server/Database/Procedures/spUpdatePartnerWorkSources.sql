use CopyrightObjectSearch
go

create or alter procedure spUpdatePartnerWorkSources
as
begin

insert PartnerWorkSources (
	  Title
	, PartnerId
	, SourceId
	, SourceTypeId
	, FileName
	, Year
	, Quarter
	, Month
	, CreatedAt
	, UpdatedAt
)
select
        dbo.fnDdexFileTitle(t1.FileType, t2.Year, isnull(t2.Quarter, 0), isnull(t2.Month, 0))	as Title
      , dbo.fnDdexFileTypePartnerId(t1.FileType)												as PartnerId
      , t1.Id																					as SourceId
      , dbo.fnDdexFileTypeSourceTypeId(t1.FileType)												as SourceTypeId
      , ''																						as FileName
      , t2.Year																					as Year
      , isnull(t2.Quarter, 0)																	as Quarter
      , isnull(t2.Month, 0)																		as Month
      , getdate()																				as CreatedAt
      , getdate()																				as UpdatedAt
from  Ddex..DdexReport t1
	join Ddex..DdexReportingPeriod t2 on t1.ddexReportingPeriodId = t2.Id
	left join PartnerWorkSources t3 on
		    dbo.fnDdexFileTypePartnerId(t1.FileType) = t3.PartnerId
		and t1.Id									 = t3.SourceId
		and t2.year									 = t3.year
		and isnull(t2.Quarter, 0)					 = t3.Quarter
		and isnull(t2.Month, 0)						 = t3.Month
where t1.NetRevenue is null -- skip secondary Deezer reports
	and t3.PartnerId is null

end
go

-- exec spUpdatePartnerWorkSources