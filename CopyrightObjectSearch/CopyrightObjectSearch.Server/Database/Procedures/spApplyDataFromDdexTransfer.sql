use DdexTransfer
go

create or alter procedure spApplyDataFromDdexTransfer
as
begin

delete from Ddex..DdexReportingPeriod
set identity_insert Ddex..DdexReportingPeriod on
insert Ddex..DdexReportingPeriod (
	    id
	  , status
      ,	substatus
      ,	year
      ,	quarter
      ,	month
)
select
		id
	  , status
      ,	substatus
      ,	year
      ,	quarter
      ,	month
from DdexReportingPeriod
set identity_insert Ddex..DdexReportingPeriod off

delete from Ddex..DdexReport
set identity_insert Ddex..DdexReport on
insert Ddex..DdexReport (
	  Id
	, ddexReportingPeriodId
	, Status
	, SubStatus
	, SourceUri
	, TargetFolder
	, FileType
	, SalesTransCnt
	, MwCnt
	, MwCntUnmatched
	, NetRevenue
	, NetRevenueUnmatched
	, MwCntIswcTotal
	, MwNetRevenueIswcTotal
	, MwCntIswcMatched
	, MwNetRevenueIswcMatched
	, CcidNetRevenueExcluded
	, CcidNetRevenueClaimed
	, CcidNetRevenueClaimPending
	, CcidNetRevenueReadyToClaim
	, CcidNetRevenuePaid
	, CcidNetRevenueRejected
	, SetCode
	, custId
	, licId
	, licVersion
	, royaltyThreshold
	, cntSalesInFile
	, cntMwInFile
	, cntSalesLoaded
	, cntMwLoaded
	, musicRate
	, geRate
	, mechSplit
	, perfSplit
	, musicPSM
	, gePSM
	, exchRate
)
select
	  Id
	, ddexReportingPeriodId
	, Status
	, SubStatus
	, SourceUri
	, TargetFolder
	, FileType
	, SalesTransCnt
	, MwCnt
	, MwCntUnmatched
	, NetRevenue
	, NetRevenueUnmatched
	, MwCntIswcTotal
	, MwNetRevenueIswcTotal
	, MwCntIswcMatched
	, MwNetRevenueIswcMatched
	, CcidNetRevenueExcluded
	, CcidNetRevenueClaimed
	, CcidNetRevenueClaimPending
	, CcidNetRevenueReadyToClaim
	, CcidNetRevenuePaid
	, CcidNetRevenueRejected
	, null --SetCode
	, custId
	, licId
	, licVersion
	, royaltyThreshold
	, cntSalesInFile
	, cntMwInFile
	, cntSalesLoaded
	, cntMwLoaded
	, musicRate
	, geRate
	, mechSplit
	, perfSplit
	, musicPSM
	, gePSM
	, exchRate
from DdexReport
set identity_insert Ddex..DdexReport off

delete from Ddex..IdentMw
set identity_insert Ddex..IdentMw on
insert Ddex..IdentMw (
	  id
	, WIC
	, objId
	, ResourceTitle
	, Title
	, ComposerAuthor
	, DisplayArtistName
	, ISWC
	, status
	, IdentifiedTitle
)
select distinct
	  id
	, WIC
	, objId
	, ResourceTitle
	, Title
	, ComposerAuthor
	, DisplayArtistName
	, ISWC
	, status
	, IdentifiedTitle
from IdentMw
set identity_insert Ddex..IdentMw off

delete from Ddex..IdentBacklog
insert Ddex..IdentBacklog (
	    DdexReportId
      , BlockId
      , SalesTransactionId
      , DspReleaseId
      , DspResourceId
      , ContentCategory
      , NetRevenue
      , Usages
      , ValidityPeriodStart
      , ValidityPeriodEnd
      , rateTotalPER
      , rateTotalMEC
      , mwId
      , IncludedInCcid
)
select distinct
	    DdexReportId
      , BlockId
      , SalesTransactionId
      , DspReleaseId
      , DspResourceId
      , ContentCategory
      , NetRevenue
      , Usages
      , ValidityPeriodStart
      , ValidityPeriodEnd
      , rateTotalPER
      , rateTotalMEC
      , mwId
      , IncludedInCcid
from IdentBacklog

end