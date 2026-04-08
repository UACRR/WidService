use SocWidSubmitEx
go

create or alter view vCurForeignRightHolder
as
select *
from RightHolder
where ValidTo = dbo.fnMaxDate()
	and IsOwn = 0
go

use SocWidSubmitEx
go

create or alter view vCurOwnRightHolder
as
select *
from RightHolder
where ValidTo = dbo.fnMaxDate()
	and IsOwn = 1
go

use SocWidSubmitEx
go

create or alter view vCurRightHolder
as
select *
from RightHolder
where ValidTo = dbo.fnMaxDate()
go

use SocWidSubmitEx
go

create or alter view vCurSubmRecAck
as
	select t2.SubmissionId, t3.RecHdrId, t4.RecGrhId, t3.GrId, t5.*
	from Submission t1
		join RecHdr t2 on t1.Id = t2.SubmissionId
		join RecGrh t3 on t2.Id = t3.RecHdrId
		join RecWiaWiu t4 on t3.Id = t4.RecGrhId
		join RecAck t5 on t4.Id = t5.RecWiaWiuId
	where t1.Id = dbo.fnCurSubmId()
go

use SocWidSubmitEx
go

create or alter view vCurSubmRecAlt
as
	select t2.SubmissionId, t3.RecHdrId, t4.RecGrhId, t3.GrId, t5.*
	from Submission t1
		join RecHdr t2 on t1.Id = t2.SubmissionId
		join RecGrh t3 on t2.Id = t3.RecHdrId
		join RecWiaWiu t4 on t3.Id = t4.RecGrhId
		join RecAlt t5 on t4.Id = t5.RecWiaWiuId
	where t1.Id = dbo.fnCurSubmId()
go

use SocWidSubmitEx
go

create or alter view vCurSubmRecMsg
as
	select
		  t1. Id
		, t1.SubmissionId
		, t1.RecType
		, t1.TransSeqNr
		, t1.RecSeqNr
		, t1.RecTypeRef
		, t2.MsgType
		, t2.MsgLevel
		, t2.ErrCondNr
		, t2.MsgTxt
	from RecMsg t1
		join RecMsgType t2 on t1.RecMsgTypeId = t2.Id
	where SubmissionId = dbo.fncurSubmId()
go

use SocWidSubmitEx
go

create or alter view vCurSubmRecPer
as
	select t2.SubmissionId, t3.RecHdrId, t4.RecGrhId, t3.GrId, t5.*
	from Submission t1
		join RecHdr t2 on t1.Id = t2.SubmissionId
		join RecGrh t3 on t2.Id = t3.RecHdrId
		join RecWiaWiu t4 on t3.Id = t4.RecGrhId
		join RecPer t5 on t4.Id = t5.RecWiaWiuId
	where t1.Id = dbo.fnCurSubmId()
go

use SocWidSubmitEx
go

create or alter view vCurSubmRecSipOip
as
	select t2.SubmissionId, t3.RecHdrId, t4.RecGrhId, t3.GrId, t5.*
	from Submission t1
		join RecHdr t2 on t1.Id = t2.SubmissionId
		join RecGrh t3 on t2.Id = t3.RecHdrId
		join RecWiaWiu t4 on t3.Id = t4.RecGrhId
		join RecSipOip t5 on t4.Id = t5.RecWiaWiuId
	where t1.Id = dbo.fnCurSubmId()
go

use SocWidSubmitEx
go

create or alter view vCurSubmRecSsrOsr
as
	select t2.SubmissionId, t3.RecHdrId, t4.RecGrhId, t3.GrId, t5.RecWiaWiuId, t6.*
	from Submission t1
		join RecHdr t2 on t1.Id = t2.SubmissionId
		join RecGrh t3 on t2.Id = t3.RecHdrId
		join RecWiaWiu t4 on t3.Id = t4.RecGrhId
		join RecSipOip t5 on t4.Id = t5.RecWiaWiuId
		join RecSsrOsr t6 on t5.Id = t6.RecSipOipId
	where t1.Id = dbo.fnCurSubmId()
go

use SocWidSubmitEx
go

create or alter view vCurSubmRecWiaWiu
as
	select t2.SubmissionId, t3.RecHdrId, t3.GrId, t4.*
	from Submission t1
		join RecHdr t2 on t1.Id = t2.SubmissionId
		join RecGrh t3 on t2.Id = t3.RecHdrId
		join RecWiaWiu t4 on t3.Id = t4.RecGrhId
	where t1.Id = dbo.fnCurSubmId()
go

use SocWidSubmitEx
go

create or alter view vCurSubmRightHolder
as
select t1.*
from SubmRightHolder t1
	join Submission t2 on t1.SubmissionId = t2.Id
		and t2.EndedAt = datefromparts(9999, 12, 31)
go



use SocWidSubmitEx
go

create or alter view vCurSubmRightHolderEx
as
with PublishedRightHolders as (
	select distinct RightHolderId from SubmRightHolder
)
select
	  t1.Id																				as Id		
	, t1.ValidFrom																		as ValidFrom	
	, t1.ValidTo																		as ValidTo	
	, t1.CreatedAt																		as CreatedAt	
	, t1.CustId																			as CustId	
	, t1.IpBaseNr																		as IpBaseNr	
	, t1.IpNameNr																		as IpNameNr	
	, t1.Name																			as Name
	, t1.FstName																		as FstName
	, t1.NameForWid																		as NameForWid
	, t1.FstNameForWid																	as FstNameForWid
	, t1.IsOwn																			as IsOwn
	, t1.IsActive																		as IsActive
	, t1.HasIpiAgreePer																	as HasIpiAgreePer
	, t1.HasIpiAgreeMec																	as HasIpiAgreeMec
	, case when t2.Id is null then cast(0 as bit) else cast(1 as bit) end 				as IsInCurSubm
	, case when t3.RightHolderId is null then cast(0 as bit) else cast(1 as bit) end	as WasPublished
from RightHolder t1
	left join vCurSubmRightHolder t2 on t1.Id = t2.RightHolderId
	left join PublishedRightHolders t3 on t1.Id = t3.RightHolderId
where t1.IsOwn = 1
go

use SocWidSubmitEx
go

create or alter view vCurSubmWorks
as
select t1.*
from SubmWork t1
	join Submission t2 on t1.SubmissionId = t2.Id
where t2.EndedAt = dbo.fnMaxDate()

go

-- select * from vCurSubmWorks order by ObjIduse SocWidSubmitEx
go

create or alter view vCustomerNamesForWid as 
select 
	  custId								 as CustId
	, isnull(shortName, '')					 as Name
	, ''									 as FstName
	, dbo.ClrTranslitFromUkrToLat(
		isnull(shortName, '')
	  )										 as NameForWid
	, ''									 as FstNameForWid
from MediaService..AnketaCompany
union
select 
	  custId															as CustId
	, isnull(lastName, '')												as Name
	, trim(concat(isnull(firstName, ''), ' ', isnull(surName, '')))		as FstName
	, dbo.ClrTranslitFromUkrToLat(isnull(lastName, ''))					as NameForWid
	, dbo.ClrTranslitFromUkrToLat(
		trim(concat(isnull(firstName, ''), ' ', isnull(surName, '')))
	  )																	as FstNameForWid
from MediaService..AnketaPerson
union
select
	  custId											as CustId
	, isnull(name, '')									as Name
	, ''												as FstName
	, dbo.ClrTranslitFromUkrToLat(isnull(name, ''))		as NameForWid
	, ''												as FstNameForWid
from MediaService..AnketaExternal
go


use SocWidSubmitEx
go

create or alter view vMsRightHoldersActive
as
select 
	  t1.custId			as CustId
	, t1.InterCode		as IpBaseNr
	, t1.IPIBase		as IpNameNr
	, t3.Name			as Name
	, t3.FstName		as FstName
	, t3.NameForWid		as NameForWid
	, t3.FstNameForWid	as FstNameForWid
	, cast(1 as bit)	as IsOwn
	, cast(1 as bit)	as IsActive
from MediaService..RightHolder t1
	join MediaService..AgreementAddRH t2 on t1.custId = t2.custId
	join vCustomerNamesForWid t3 on t2.CustId = t3.CustId
where t2.agrStatus = 2
	and (t2.dateBegin is null or t2.dateBegin <= getdate())
	and (t2.dateEnd is null or t2.dateEnd >= getdate())
go

use SocWidSubmitEx
go

create or alter view vSubmRightHolderEx
as
with PublishedRightHolders as (
	select distinct RightHolderId from SubmRightHolder
)
select
	  t1.Id																				as Id		
	, t1.ValidFrom																		as ValidFrom	
	, t1.ValidTo																		as ValidTo	
	, t1.CreatedAt																		as CreatedAt	
	, t1.CustId																			as CustId	
	, t1.IpBaseNr																		as IpBaseNr	
	, t1.IpNameNr																		as IpNameNr	
	, t1.Name																			as Name
	, t1.FstName																		as FstName
	, t1.NameForWid																		as NameForWid
	, t1.FstNameForWid																	as FstNameForWid
	, t1.IsOwn																			as IsOwn
	, t1.IsActive																		as IsActive
	, t1.HasIpiAgreePer																	as HasIpiAgreePer
	, t1.HasIpiAgreeMec																	as HasIpiAgreeMec
	, case when t2.Id is null then cast(0 as bit) else cast(1 as bit) end 				as IsInCurSubm
	, case when t3.RightHolderId is null then cast(0 as bit) else cast(1 as bit) end	as WasPublished
	, t2.SubmissionId																	as SubmissionId
from RightHolder t1
	left join SubmRightHolder t2 on t1.Id = t2.RightHolderId
	left join PublishedRightHolders t3 on t1.Id = t3.RightHolderId
where t1.IsOwn = 1
go

-- select * from vCurSubmRightHolderEx

--select * from SubmRightHolder

-- select t2.* from vCurSubmRightHolder t1 join RightHolder t2 on t1.RightHolderId = t2.Id order by Name
-- 
-- select * from vCurSubmRightHolderEx where IsInCurSubm = 1 order by NAme
use SocWidSubmitEx
go

create or alter view vSubmWorkAltNameErrors
as
select
      t1.Id as SubmWorkAltNameId
	, t1.SubmWorkId as SubmWorkId
	, t1.OrigNames as OrigNames    
	, t1.NameForWid as NameForWid  
	, t5.MsgTxt
--select *
from SubmWorkAltName t1
	join RecAlt t2 on t1.Id = t2.SubmWorkAltNameId
	left join MsgMapRecAlt t3 on t2.Id = t3.RecAltId
	left join RecMsg t4 on t3.RecMsgId = t4.Id
	left join RecMsgType t5 on t4.RecMsgTypeId = t5.Id
go

use SocWidSubmitEx
go

create or alter view vSubmWorkErrors
as
select t1.*, t5.MsgTxt
from SubmWork t1
	join RecWiaWiu t2 on t1.Id = t2.SubmWorkId
	left join MsgMapRecWiaWiu t3 on t2.Id = t3.RecWiaWiuId
	left join RecMsg t4 on t3.RecMsgId = t4.Id
	left join RecMsgType t5 on t4.RecMsgTypeId = t5.Id
go

use SocWidSubmitEx
go

create or alter view vSubmWorkPerformerErrors
as
select
      t1.Id as SubmWorkPerformerId
	, t1.SubmWorkId as SubmWorkId
	, t1.OrigNames as OrigNames    
	, t1.NameForWid as NameForWid  
	, t5.MsgTxt
--select *
from SubmWorkPerformer t1
	join RecPer t2 on t1.Id = t2.SubmWorkPerformerId
	left join MsgMapRecPer t3 on t2.Id = t3.RecPerId
	left join RecMsg t4 on t3.RecMsgId = t4.Id
	left join RecMsgType t5 on t4.RecMsgTypeId = t5.Id
go

use SocWidSubmitEx
go

create or alter view vSubmWorksAccepted
as
	-- Ã≤—“»“‹ “¬Œ–» « Œ—“¿ÕÕ‹Œ√Œ —≈¿Õ—” ¬ ﬂ ŒÃ” “¬≤– ¡”¬ œ–»…Õﬂ“»… ¬≤ƒ
	with SubmWorksOrdered as (
		select 
			  t1.SubmissionId									as SubmissionId
			, t1.Id												as SubmWorkId
			, t1.ObjId											as ObjId
			, row_number() 
				over (
					  partition by t1.SubmissionId, t1.ObjId
					  order by t2.EndedAt desc
				)												as SeqNr
		from SubmWork t1
			join Submission t2 on t1.SubmissionId = t2.Id
		where t2.EndedAt <> dbo.fnMaxDate()
	)
	select t1.*
	from SubmWork t1
		 join SubmWorksOrdered t2 on t1.Id = t2.SubmWorkId
	where t2.SeqNr = 1
go

use SocWidSubmitEx
go

create or alter view vSubmWorkShareErrors
as
select
      t1.Id as SubmWorkShareId
	, t1.SubmWorkId as SubmWorkId
	, t6.CustId as RhCustId    
	, t6.IpBaseNr as RhIpBaseNr  
	, t6.IpNameNr as RhIpNameNr  
	, trim(concat(t6.Name, ' ', t6.FstName)) as RhName      
	, trim(concat(t6.NameForWid, ' ', t6.FstNameForWid)) as RhNameForWid
	, t6.IsOwn as RhIsOwn
	, t1.RoleForWid as RhRoleForWid
	, t1.ShrPer as RhShrPer    
	, t1.ShrMec as RhShrMec
	, t5.MsgTxt
from SubmWorkShare t1
	join RecSipOip t2 on t1.Id = t2.SubmWorkShareId
	left join MsgMapRecSipOip t3 on t2.Id = t3.RecSipOipId
	left join RecMsg t4 on t3.RecMsgId = t4.Id
	left join RecMsgType t5 on t4.RecMsgTypeId = t5.Id
	join RightHolder t6 on t1.RightHolderId = t6.Id

union

select
      t1.Id as SubmWorkShareId
	, t1.SubmWorkId as SubmWorkId
	, t7.CustId as RhCustId    
	, t7.IpBaseNr as RhIpBaseNr  
	, t7.IpNameNr as RhIpNameNr  
	, trim(concat(t7.Name, ' ', t7.FstName)) as RhName      
	, trim(concat(t7.NameForWid, ' ', t7.FstNameForWid)) as RhNameForWid
	, t7.IsOwn as RhIsOwn
	, t1.RoleForWid as RhRoleForWid
	, t1.ShrPer as RhShrPer    
	, t1.ShrMec as RhShrMec
	, t6.MsgTxt
from SubmWorkShare t1
	join RecSipOip t2 on t1.Id = t2.SubmWorkShareId
	join RecSsrOsr t3 on t2.Id = t3.RecSipOipId
	left join MsgMapRecSsrOsr t4 on t3.Id = t4.RecSsrOsrId
	left join RecMsg t5 on t4.RecMsgId = t5.Id
	left join RecMsgType t6 on t5.RecMsgTypeId = t6.Id
	join RightHolder t7 on t1.RightHolderId = t7.Id
go

use SocWidSubmitEx
go

create or alter view vSubmWorkShares
as
	select
		  t1.Id												as SubmWorkId   
		, t2.RightHolderId									as RightHolderId
		, t3.CustId											as RhCustId       
		, t3.IpBaseNr										as RhIpBaseNr     
		, t3.IpNameNr										as RhIpNameNr     
		, dbo.fnFullName(t3.Name, t3.FstName)  				as RhName
		, dbo.fnFullName(t3.NameForWid, t3.FstNameForWid)	as RhNameForWid
		, concat(t4.codeI, ' - ', t4.name)					as RhTypeName     
		, concat(t5.codeI, ' - ', t5.name)					as RhRoleName     
		, t2.RoleForWid										as RhRoleForWid   
		, t3.IsOwn											as RhIsOwn        
		, t3.IsActive										as RhIsActive     
		, t2.ShrPer											as RhShrPer       
		, t2.ShrMec											as RhShrMec       
	from SubmWork t1
		join SubmWorkShare t2 on t1.Id = t2.SubmWorkId
		join vCurRightHolder t3 on t2.RightHolderId = t3.Id
		join MediaService..RHolderType t4 on t3.RhType = t4.codeI
		join MediaService..CreativeRoleType t5 on t2.RhRole = t5.codeI
go

