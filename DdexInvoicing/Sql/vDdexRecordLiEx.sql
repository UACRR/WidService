use [ddex]
go

/****** object:  view [dbo].[vddexrecordliex]    script date: 7/25/2019 3:19:11 pm ******/
set ansi_nulls on
go

set quoted_identifier on
go

alter view [dbo].[vddexrecordliex]
as
select        
	su.ddexreportid
	, su.blockid
	, li.recordindex
	, su.salestransactionid
	, su.dspreleaseid
	, su.validityperiodstart
	, su.validityperiodend
	, su.NetRevenue
	, su.Usages
	, [as].dspresourceid
	, [as].isrc
	, [as].title asTitle
	, [as].displayartistname
	, mw.iswc
	, mw.title as mwtitle
	, mw.composerauthor
	, li.rightscontroller
	, li.rightsharepercent
	, li.righttype
	, li.allocatednetrevenue
	, li.allocatedusages
	, ms.marketsharepercent
from  ddexrecordsu as su inner join
	ddexrecordas as [as] on su.ddexreportid = [as].ddexreportid and su.blockid = [as].blockid inner join
	ddexrecordli as li on su.ddexreportid = li.ddexreportid and su.blockid = li.blockid and su.recordindex = li.ownersurecordindex inner join
	ddexrecordmw as mw on mw.ddexreportid = li.ddexreportid and mw.blockid = li.blockid and mw.ownerlirecordindex = li.recordindex inner join
	ddexmarketshareperli as ms on ms.ddexreportid = li.ddexreportid and ms.blockid = li.blockid and ms.lirecordindex = li.recordindex
go


