use RadioStationReports
go


create table ReportDistribution (
	  ReportId						int
	, LineNr						int
	, AuthorSeqNr					int

	, ReportLineName				nvarchar(255)
	, ReportLinePerformer			nvarchar(255)
	, ReportLineMusicAuthor			nvarchar(255)
	, ReportLineTextAuthor			nvarchar(255)
	, ReportLineDuration			varchar(20)
	, ReportLineCountUses			varchar(10)
	, ReportLineTotalDuration		varchar(20)

	, ToBeFilledDurationInSec		varchar(255)
	, ToBeFilledWorkRoyalty			varchar(255)
		
	, FoundRhCustId					int
	, FoundRhIpBaseNr				varchar(13)
	, FoundRhIpNameNr				int
	, FoundRhName					nvarchar(255)
		
	, FoundRhPerShare				decimal(5, 2)
	, FoundRhPerShareToPay			decimal(5, 2)
	, FoundRhPerSocToPayCde			int
	, FoundRhPerSocToPayName		varchar(64)
		
	, FoundRhMecShare				decimal(5, 2)
	, FoundRhMecShareToPay			decimal(5, 2)
	, FoundRhMecSocToPayCde			int
	, FoundRhMecSocToPayName		varchar(64)

	, FoundRhAgreementNr			int
)
go



