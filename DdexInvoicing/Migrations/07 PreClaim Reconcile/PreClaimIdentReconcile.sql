use ddex

drop table if exists PreClaimIdentReconcile

create table PreClaimIdentReconcile (
	  ddexReportId int
	, mwId int
	, TITLE varchar(256)
	, TITLE_FROM_ISWC_IN_WID varchar(256)
	, ARTIST varchar(64)
	, isConfirmed bit
	, isRejected bit
	, needsReIdent bit
	, isAutoConfirmed bit
	, isApplied bit
)

create nonclustered index idxPreClaimIdentReconcile_MwId on PreClaimIdentReconcile(MwId)