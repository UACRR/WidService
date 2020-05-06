use [ddex]
go

/****** object:  view [dbo].[vccidinitialindetail]    script date: 7/25/2019 3:08:45 pm ******/
set ansi_nulls on
go

set quoted_identifier on
go

alter view [dbo].[vccidinitialindetailbase]
as
with perf as (
select 
	ddexreportid
	, blockid
	, recordindex
	, salestransactionid
	, validityperiodstart
	, validityperiodend
	, dspreleaseid
	, dspresourceid
	, isrc
	, astitle
	, displayartistname
	, iswc
	, mwtitle
	, composerauthor
	, NetRevenue
	, usages
	, rightscontroller
	, rightsharepercent
	, righttype
	, allocatednetrevenue
	, allocatedusages
	, marketsharepercent
from  vddexrecordliex
where righttype = 'performingright'
), mech as (
select         
	ddexreportid
	, blockid
	, recordindex
	, salestransactionid
	, validityperiodstart
	, validityperiodend
	, dspreleaseid
	, dspresourceid
	, isrc
	, astitle
	, displayartistname
	, iswc
	, mwtitle
	, composerauthor
	, NetRevenue
	, usages
	, rightscontroller
	, rightsharepercent
	, righttype
	, allocatednetrevenue
	, allocatedusages
	, marketsharepercent
from  vddexrecordliex
where righttype = 'mechanicalright'
)
select        
	mech.ddexreportid
	, mech.blockid
	, mech.recordindex
	, mech.dspreleaseid
	, mech.dspresourceid
	, mech.salestransactionid
	, mech.astitle
	, mech.netrevenue
	, mech.usages
	, mech.rightscontroller
	, mech.rightsharepercent as rightsharemech
	, mech.allocatednetrevenue as revenuemech
	, mech.allocatedusages as usagesmech
	, mech.marketsharepercent as marketsharemech
	, perf.rightsharepercent as rightshareperf
	, perf.allocatednetrevenue as revenueperf
	, perf.allocatedusages as usagesperf
	, perf.marketsharepercent as marketshareperf
from  perf inner join
	mech on mech.salestransactionid = perf.salestransactionid and mech.rightscontroller = perf.rightscontroller
go


