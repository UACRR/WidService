select *
from DdexIdentificationBacklog
where DdexReportId = 1505
order by BlockId

select DdexReportId, BlockId, SalesTransactionId, DspResourceId, DspReleaseId, ContentCategory
        , NetRevenue, Usages, ValidityPeriodStart, ValidityPeriodEnd, 0, 0, t2.id
from DdexIdentificationBacklog t1 
    left join IdentMw t2 on 
        t2.ResourceTitle = t1.AsTitle 
        and t2.Title = t1.mwTitle 
        and t2.ComposerAuthor = t1.ComposerAuthor
        and t2.DisplayArtistName = t1.DisplayArtistname
        and t2.ISWC = t1.ISWC
where ddexReportId in (1505,1506)

select t2.ResourceTitle
        , t2.Title
        , t2.ComposerAuthor
        , t2.DisplayArtistName
        , t2.ISWC
		, count(*)
from IdentMw t2
group by t2.ResourceTitle
        , t2.Title
        , t2.ComposerAuthor
        , t2.DisplayArtistName
        , t2.ISWC
having count(*) > 1

ALTER TABLE dbo.IdentMWAuthor DROP CONSTRAINT FK_IDENTMWA_REFERENCE_IDENTMW;
ALTER TABLE dbo.IdentReportMwRecords DROP CONSTRAINT FK_IdentReportMwRecords_IdentMW


truncate table IdentMw

set identity_insert IdentMw on
insert IdentMw (
	[id]				
	, [WIC]				
	, [objId]				
	, [ResourceTitle]		
	, [Title]				
	, [ComposerAuthor]	
	, [DisplayArtistName] 
	, [ISWC]				
	, [status]			
	, [IdentifiedTitle]
)
select * from DdexIdentMwTransfer..IdentMw
set identity_insert IdentMw off

update t1
set MwId = null
from IdentBacklog t1
	left join IdentMw t2 on t1.MwId = t2.Id
where t2.Id is null

update t1
set MwId = null
from IdentMWAuthor t1
	left join IdentMw t2 on t1.MwId = t2.Id
where t2.Id is null

delete t1
from IdentReportMwRecords t1
	left join IdentMw t2 on t1.MwId = t2.Id
where t2.Id is null

ALTER TABLE IdentBacklog
ADD CONSTRAINT fk_IdentBacklog_MwId FOREIGN KEY (MwId)
REFERENCES IdentMw (Id);

ALTER TABLE IdentMWAuthor
ADD CONSTRAINT fk_IdentMWAuthor_MwId FOREIGN KEY (MwId)
REFERENCES IdentMw (Id);

ALTER TABLE IdentReportMwRecords
ADD CONSTRAINT fk_IdentReportMwRecords_MwId FOREIGN KEY (MwId)
REFERENCES IdentMw (Id);