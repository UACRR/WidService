
/*
declare @ddexReportId int = 3;

insert IdentMw (ResourceTitle, Title, ComposerAuthor, DisplayArtistName, ISWC, [status])
select distinct asTitle, mwTitle, t1.composerauthor, t1.DisplayArtistName, t1.ISWC 0
from DdexIdentificationBacklog t1 left join
	IdentMw t2 on 
			t2.ResourceTitle = t1.AsTitle 
		and t2.Title = t1.mwTitle 
		and t2.ComposerAuthor = t1.ComposerAuthor
		and t2.DisplayArtistName = t1.DisplayArtistname
		and t2.ISWC = t1.ISWC
where ddexReportId = @ddexReportId and t2.Title is null

-- update IdentMw set status = 0 where status is null

delete from IdentBacklog where ddexreportid = @ddexReportId;

insert IdentBacklog (DdexReportId, BlockId, SalesTransactionId, NetRevenue, Usages, ValidityPeriodStart, ValidityPeriodEnd, mwId)
select DdexReportId, BlockId, SalesTransactionId, NetRevenue, Usages, ValidityPeriodStart, ValidityPeriodEnd, t2.id
from DdexIdentificationBacklog t1 
	left join IdentMw t2 on 
			t2.ResourceTitle = t1.AsTitle 
		and t2.Title = t1.mwTitle 
		and t2.ComposerAuthor = t1.ComposerAuthor
		and t2.DisplayArtistName = t1.DisplayArtistname
		and t2.ISWC = t1.ISWC
where ddexReportId = @ddexReportId

select * from IdentBacklog t1 join IdentMW t2 on t2.id = t1.mwid where status <> 0
*/

--delete from IdentMW

--ALTER TABLE IdentMW
  --ADD CONSTRAINT ucIdentInfo UNIQUE (ResourceTitle, Title, ComposerAuthor, DisplayArtistName, ISWC)
  /*
declare @mechRate float = 100, @perfRate float = 100,  @musicRate float = 100, @geRate float = 100;
  select 
		  1
		, 'IN'
		, 'ORI'
		, t1.salestransactionid sales_transaction_id
		, left(t1.dspreleaseid, 60) release_id
		, left(t1.dspresourceid, 60) resource_id
		, left(t2.Resourcetitle, 39) workcode
		, left(t2.title, 60) work_title
		, t1.usages use_quantity
		, case when t1.ContentCategory = 'Music' then @musicRate else @geRate end applied_tariff
		, t1.netrevenue original_release_revenue_basis
		, t1.netrevenue original_resource_revenue_basis
		, case when t1.usages > 0 then cast(t1.netrevenue as float) / t1.usages else null end royalty
		--, resource_share
		, cast(t1.rateTotalMEC as float) * 0.000001 * cast(@mechRate as float) + cast(t1.rateTotalMEC as float) * 0.000001 * cast(@mechRate as float) claim_licensor_combined
		, cast(t1.rateTotalPER as float) * 0.000001 * cast(@mechRate as float) * t1.netrevenue + cast(t1.rateTotalPER as float) * 0.000001 * cast(@mechRate as float) * t1.netrevenue amount_invoiced_total
		, t1.rateTotalMEC claim_licensor_mech
		, t1.rateTotalPER claim_licensor_perf
		, cast(t1.rateTotalMEC as float) * 0.000001 * cast(@mechRate as float) * t1.netrevenue amount_licensor_mech
		, cast(t1.rateTotalPER as float) * 0.000001 * cast(@mechRate as float) * t1.netrevenue amount_licensor_perf
from IdentBacklog t1 inner join IdentMW t2 on t2.id = t1.mwid

*/







