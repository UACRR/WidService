use [RadioStationReports]
go

create or alter procedure spSelectDistribution
	@ReportId int
as
begin

--delete from ReportDistribution where ReportId = @ReportId

drop table if exists #ReportDistribution
create table #ReportDistribution (
	  ReportId						varchar(100)
	, LineNr						varchar(100)
	, AuthorSeqNr					varchar(100)
	, WorkCode						varchar(100)
	, Iswc							varchar(100)
	, TotalShare					decimal(5, 2)
	, TotalShareToPay				decimal(5, 2)

	, ReportLineName				nvarchar(255)
	, ReportLinePerformer			nvarchar(255)
	, ReportLineMusicAuthor			nvarchar(255)
	, ReportLineTextAuthor			nvarchar(255)
	, ReportLineDuration			varchar(20)
	, ReportLineCountUses			varchar(10)
	, ReportLineTotalDuration		varchar(20)

	, ToBeFilledDurationInSec		varchar(255)
	, ToBeFilledWorkRoyalty			varchar(255)
		
	, FoundRhCustId					varchar(100)
	, FoundRhIpBaseNr				varchar(13)
	, FoundRhIpNameNr				varchar(100)
	, FoundRhName					nvarchar(255)
		
	, FoundRhPerShare				decimal(5, 2)
	, FoundRhPerShareToPay			decimal(5, 2)
	, FoundRhPerSocToPayCde			varchar(100)
	, FoundRhPerSocToPayName		varchar(64)
		
	, FoundRhMecShare				decimal(5, 2)
	, FoundRhMecShareToPay			decimal(5, 2)
	, FoundRhMecSocToPayCde			varchar(100)
	, FoundRhMecSocToPayName		varchar(64)

	, FoundRhAgreementNr			varchar(100)
	, FoundRhAgreementStatus		nvarchar(100)

	, SubPublisher					nvarchar(100)
)

insert #ReportDistribution
select
	  cast(t1.ReportId as varchar(max))							as ReportId
	, cast(t1.LineNr as varchar(max))							as LineNr
	, cast(row_number() 
		over (
			partition by t1.LineNr 
			order by t3.FoundCde
	  )	 as varchar(max))										as AuthorSeqNr
	, concat(t2.FoundIn, t2.FoundCde)							as WorkCode 
	, t2.Iswc													as Iswc
	, 0.0														as TotalShare
	, 0.0														as TotalShareToPay
	, t1.Name													as ReportLineName
	, t1.Performer												as ReportLinePerformer
	, t1.MusicAuthor											as ReportLineMusicAuthor
	, t1.TextAuthor												as ReportLineTextAuthor
	, cast(t1.Duration as varchar(max))							as ReportLineDuration
	, cast(t1.CountUses	as varchar(max))						as ReportLineCountUses
	, cast(t1.TotalDuration as varchar(max))					as ReportLineTotalDuration

	, ''														as ToBeFilledDurationInSec
	, ''														as ToBeFilledWorkRoyalty
	
	, cast(t3.CustId as varchar(max))							as FoundRhCustId
	, cast(t3.IpBaseNr as varchar(max))							as FoundRhIpBaseNr
	, cast(t3.IpNameNr as varchar(max))							as FoundRhIpNameNr
	, ''														as FoundRhName

	, t3.PerShr													as FoundRhPerShare
	, t3.PerShr * PerSocShr / 100.								as FoundRhPerShareToPay
	, cast(t3.PerSoc as varchar(max))							as FoundRhPerSocToPayCde
	, ''														as FoundRhPerSocToPayName

	, t3.MecShr													as FoundRhMecShare
	, t3.MecShr * MecSocShr / 100.								as FoundRhMecShareToPay
	, cast(t3.MecSoc as varchar(max))							as FoundRhMecSocToPayCde
	, ''														as FoundRhMecSocToPayName

	, ''														as FoundRhAgreementNr
	, ''														as FoundRhAgreementStatus

	, ''														as SubPublisher

from ReportLines t1
	join Works t2 on t1.WorkId = t2.Id
	left join ReportAuthors t3 on t1.ReportId = t3.ReportId
		and t2.FoundIn = t3.FoundIn
		and t2.FoundCde = t3.FoundCde
where t1.reportId = @ReportId
order by t1.LineNr

update #ReportDistribution
set
	  ReportId						= isnull(ReportId					, '')
	, LineNr						= isnull(LineNr						, '')
	  
	, AuthorSeqNr					= isnull(AuthorSeqNr				, '')

	, WorkCode						= isnull(WorkCode					, '')
	, Iswc							= isnull(Iswc						, '')

	, ReportLineName				= isnull(ReportLineName				, '')
	, ReportLinePerformer			= isnull(ReportLinePerformer		, '')
	, ReportLineMusicAuthor			= isnull(ReportLineMusicAuthor		, '')
	, ReportLineTextAuthor			= isnull(ReportLineTextAuthor		, '')
	, ReportLineDuration			= isnull(ReportLineDuration			, '')
	, ReportLineCountUses			= isnull(ReportLineCountUses		, '')
	, ReportLineTotalDuration		= isnull(ReportLineTotalDuration	, '')
	  
	, ToBeFilledDurationInSec		= isnull(ToBeFilledDurationInSec	, '')
	, ToBeFilledWorkRoyalty		    = isnull(ToBeFilledWorkRoyalty		, '')
	  
	, FoundRhCustId				    = isnull(FoundRhCustId				, '')
	, FoundRhIpBaseNr				= isnull(FoundRhIpBaseNr			, '')
	, FoundRhIpNameNr				= isnull(FoundRhIpNameNr			, '')
	  
	--, FoundRhPerShare				= isnull(FoundRhPerShare			, '')
	--, FoundRhPerShareToPay		    = isnull(FoundRhPerShareToPay		, '')
	, FoundRhPerSocToPayCde		    = isnull(FoundRhPerSocToPayCde		, '')
	, FoundRhPerSocToPayName		= isnull(FoundRhPerSocToPayName		, '')
	  
	--, FoundRhMecShare				= isnull(FoundRhMecShare			, '')
	--, FoundRhMecShareToPay		    = isnull(FoundRhMecShareToPay		, '')
	, FoundRhMecSocToPayCde		    = isnull(FoundRhMecSocToPayCde		, '')
	, FoundRhMecSocToPayName		= isnull(FoundRhMecSocToPayName		, '')
	  
	, FoundRhAgreementNr			= isnull(FoundRhAgreementNr			, '')
	, FoundRhAgreementStatus		= isnull(FoundRhAgreementStatus		, '')

where reportId = @ReportId

; with TmpSums as (
	select 
		  LineNr					as LineNr
		, sum(FoundRhPerShare)	    as TotalShare
		, sum(FoundRhPerShareToPay)	as TotalShareToPay
	from #ReportDistribution
	group by LineNr
)
update t1
set 
	  t1.TotalShare			= t2.TotalShare
	, t1.TotalShareToPay	= t2.TotalShareToPay
from #ReportDistribution t1
	join TmpSums t2 on t1.LineNr = t2.LineNr
where t1.reportId = @ReportId

update t1
set t1.FoundRhPerSocToPayName = trim(t3.shortName)
--select *
from #ReportDistribution t1
	join MediaService..Community t2 on t1.FoundRhPerSocToPayCde = cast(t2.interCode as int)
	join MediaService..vCustomerNamesShort t3 on t2.CustId = t3.CustId
where t1.reportId = @ReportId

update t1
set t1.FoundRhMecSocToPayName = trim(t3.shortName)
--select *
from #ReportDistribution t1
	join MediaService..Community t2 on t1.FoundRhMecSocToPayCde = cast(t2.interCode as int)
	join MediaService..vCustomerNamesShort t3 on t2.CustId = t3.CustId
where t1.reportId = @ReportId

-- Проставляємо CustId на основі IpBaseNr
update t1
set t1.FoundRhCustId = t2.CustId
--select *
from #ReportDistribution t1
	join MediaService..RightHolder t2 on t1.FoundRhIpBaseNr = t2.InterCode
where t1.FoundRhCustId = ''
	and t1.FoundRhIpBaseNr <> ''

-- Знаходимо номери договорів
update t1
set 
	  t1.FoundRhAgreementNr		= isnull(t2.agrNumber, '')
	, t1.FoundRhAgreementStatus	= isnull(t3.name, '')
--select *
from #ReportDistribution t1
	join MediaService..AgreementAddRh t2 on t1.FoundRhCustId = t2.custId
	join MediaService..AgreementStatus t3 on t2.agrStatus = t3.codeI
where t1.reportId = @ReportId

-- Проставляємо імена авторів із СМАРТУ
update t1
set t1.FoundRhName = t2.ShortName
from #ReportDistribution t1
	join vCustomerNamesShort t2 on t1.FoundRhCustId = t2.CustId
where t1.reportId = @ReportId

-- Проставляємо імена авторів із ВІД
update t1
set t1.FoundRhName = trim(concat(t2.Name, ' ', t2.FstName))
from #ReportDistribution t1
	join SocIpi..IpiName t2 on t1.FoundRhIpNameNr = t2.IpNameNr
where t1.reportId = @ReportId
	and t1.FoundRhName = ''

--  Проставляємо субвидавців
update t1
set t1.SubPublisher = trim(t3.shortName)
from #ReportDistribution t1
	join MediaService..RelSubPublish t2 on t1.FoundRhCustId = t2.custIdPub
	join vCustomerNamesShort t3 on t2.custIdSub = t3.custId

-- Виводимо результат
select * 
from #ReportDistribution 
where ReportId = @ReportId 
order by cast(LineNr as int)

end
go

-- exec spSelectDistribution 20