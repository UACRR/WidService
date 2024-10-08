using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WidExport
{
    public static class Constants
    {
        public const string SqlSelectAuthors = @"
drop table if exists #MsAuthors
create table #MsAuthors(
     IpBaseNr             varchar(13)      null
   , custId               int              null
   , IpNameNr             varchar(13)      null
   , RightHolderType      int		       null
   , RoleCode             int		       null
   , HasAgreement         int		       null
   , PerShr				  decimal(5, 2)    null
   , MecShr               decimal(5, 2)    null
   , PerSoc		          varchar(3)       null
   , MecSoc		          varchar(3)       null
   , PerSocShr            decimal(5, 2)    null
   , MecSocShr            decimal(5, 2)    null
)

drop table if exists #CopyRight
create table  #CopyRight (
	  cRightId	int not null primary key
	, objid		int 
	, custId	int 
	, roleCode	int
)

; with Rights as (
	select 
		  objid		
		, custId	
		, roleCode
		, max(crightId) as crightId
	from MediaService..CopyRight
	group by  objId		
			, custId	
			, roleCode
)
insert into #CopyRight (
	  crightId
	, objid
	, custId
	, roleCode
)
select 
	  t2.cRightId as crightId
	, t2.objId	  as objid
	, t2.custId	  as custId
	, t2.roleCode as roleCode
from Rights t1
	join MediaService..CopyRight t2 on t1.crightId = t2.cRightId
where t1.objId = @objId
	and (t2.beginDate <= getdate() and t2.endDate >= getdate()) -- Перевіряємо перетин інтервалів дат

-- Заповнюємо авторів творів	
insert into #MsAuthors (
	  IpBaseNr
	, IpNameNr
	, CustId
	, RightHolderType
	, RoleCode
	, HasAgreement
	, PerShr
	, MecShr
	, PerSoc		
	, MecSoc		
	, PerSocShr  
	, MecSocShr  
)
select distinct -- З невідомих причин можливе дублювання інформації
	  left(t3.interCode, 13)	as IpBaseNr
	, left(t3.IPIbase, 13)		as IpNameNr
	, t2.custId					as CustId
	, t3.rHolderType			as RightHolderType
	, t2.roleCode				as RoleCode
	, null						as HasAgreement
	, t2.rate					as PerShr
	, t2.rateMech				as MecShr
	, null						as PerSoc	
	, null						as MecSoc	
	, 100.00					as PerSocShr -- Припускаємо 100% бо нема звідки взяти
	, 100.00					as MecSocShr -- Припускаємо 100% бо нема звідки взяти
from #CopyRight t1 
	join MediaService..CopyRight t2 on t1.cRightId = t2.cRightId 
	join MediaService..RightHolder t3 on t2.custId = t3.custId 
where isnull(t1.ObjId, 0) <> 0

drop table #CopyRight

-- Заповнюємо ОКУ авторів для публічки 
; with CustomerSocs as (
	select
		  t1.CustId							as CustId
		, min(cast(t2.interCode as int))	as Soc
	from mediaservice..CustCmRight t1
		join mediaservice..community t2 on t1.cmCustId = t2.custId
	where t1.crKindCode in (
		select crKindCode
		from mediaservice..CopyrightKind
		where crGroupCode = 1 --(1 - Per, 2 - Mec)
	)
	group by t1.CustId
)
update t1 
set t1.PerSoc = t2.Soc
from #MsAuthors t1 
    join CustomerSocs t2 on t1.custId = t2.custId 

-- Заповнюємо ОКУ авторів для механіки 
; with CustomerSocs as (
	select
		  t1.CustId							as CustId
		, min(cast(t2.interCode as int))	as Soc
	from mediaservice..CustCmRight t1
		join mediaservice..community t2 on t1.cmCustId = t2.custId
	where t1.crKindCode in (
		select crKindCode
		from mediaservice..CopyrightKind
		where crGroupCode = 2 --(1 - Per, 2 - Mec)
	)
	group by t1.CustId
)
update t1 
set t1.MecSoc = t2.Soc
from #MsAuthors t1 
    join CustomerSocs t2 on t1.custId = t2.custId 

update t1
set t1.IpNameNr = t2.IPInr
from #MsAuthors t1
	left join MediaService..RepMSIPI t2 on t1.custId = t2.custId
where t2.custId is not null

update t1
set t1.IpNameNr = t2.IpNameNr
from #MsAuthors t1
	join SocIpi..IpiName t2 on t1.IpBaseNr = t2.IpBaseNr and t2.NameType = 'PA'
--where t1.IpNameNr is null

update t1
set t1.HasAgreement = case when t2.custId is null then 0 else 1 end
from #MsAuthors t1
	left join MediaService..AgreementMaster t2 on t1.custId = t2.custId
		and t2.agrStatus = 2

select
	  IpBaseNr
	, custId
	, IpNameNr
	, RightHolderType
	, RoleCode
	, HasAgreement
	, PerShr
	, MecShr
	, PerSoc
	, MecSoc
	, PerSocShr
	, MecSocShr
from #MsAuthors
";

        public const string SqlSelectDataForAlt = @"
drop table if exists #alt

select 
	  name as AltTtl
	, 'OT' as TtlType
into #alt
from MediaService..ObjectRight
where ObjId = @objId

insert #alt (
	  AltTtl
	, TtlType
)
select distinct
	  name as AltTtl
	, 'ET' as TtlType
from MediaService..SeekObject
where codeI = 1
	and ObjId = @objId
	and name <> (select name from #alt)

select 
	  AltTtl
	, TtlType
from #alt
";

		public const string SqlSelectDataForPer = @"
select distinct
    name as PerfArtistLstName
from MediaService..SeekObject
where codeI = 2
	and ObjId = @objId
";

		public const string SqlSelectDataForSipAndOip = @"
drop table if exists #MsAuthors
create table #MsAuthors(
     IpBaseNr             varchar(13)      null
   , custId               int              null
   , IpNameNr             varchar(13)      null
   , RightHolderType      int		       null
   , RoleCode             int		       null
   , HasAgreement         int		       null
   , PerShr				  decimal(5, 2)    null
   , MecShr               decimal(5, 2)    null
)

drop table if exists #CopyRight
create table  #CopyRight (
	  cRightId	int not null primary key
	, objid		int 
	, custId	int 
	, roleCode	int
)

; with Rights as (
	select 
		  objid		
		, custId	
		, roleCode
		, max(crightId) as crightId
	from MediaService..CopyRight
	group by  objId		
			, custId	
			, roleCode
)
insert into #CopyRight (
	  crightId
	, objid
	, custId
	, roleCode
)
select 
	  t2.cRightId as crightId
	, t2.objId	  as objid
	, t2.custId	  as custId
	, t2.roleCode as roleCode
from Rights t1
	join MediaService..CopyRight t2 on t1.crightId = t2.cRightId
where t1.objId = @objId
	and (t2.beginDate <= getdate() and t2.endDate >= getdate()) -- Перевіряємо перетин інтервалів дат

-- Заповнюємо авторів творів	
insert into #MsAuthors (
	  IpBaseNr
	, IpNameNr
	, CustId
	, RightHolderType
	, RoleCode
	, HasAgreement
	, PerShr
	, MecShr
)
select distinct -- З невідомих причин можливе дублювання інформації
	  left(t3.interCode, 13)	as IpBaseNr
	, left(t3.IPIbase, 13)		as IpNameNr
	, t2.custId					as CustId
	, t3.rHolderType			as RightHolderType
	, t2.roleCode				as RoleCode
	, null						as HasAgreement
	, t2.rate					as PerShr
	, t2.rateMech				as MecShr
from #CopyRight t1 
	join MediaService..CopyRight t2 on t1.cRightId = t2.cRightId 
	join MediaService..RightHolder t3 on t2.custId = t3.custId 
where isnull(t1.ObjId, 0) <> 0

drop table #CopyRight

update t1
set t1.IpNameNr = t2.IPInr
from #MsAuthors t1
	left join MediaService..RepMSIPI t2 on t1.custId = t2.custId
where t2.custId is not null

update t1
set t1.IpNameNr = t2.IpNameNr
from #MsAuthors t1
	join SocIpi..IpiName t2 on t1.IpBaseNr = t2.IpBaseNr and t2.NameType = 'PA'
--where t1.IpNameNr is null


update t1
set t1.IpNameNr = t2.IpNameNr
from #MsAuthors t1
	join SocIpi..IpiName t2 on t1.IpBaseNr = t2.IpBaseNr
where t1.IpNameNr is null

update t1
set t1.HasAgreement = case when t2.custId is null then 0 else 1 end
from #MsAuthors t1
	left join MediaService..AgreementMaster t2 on t1.custId = t2.custId
		and t2.agrStatus = 2

select
	  t1.IpBaseNr
	, t1.custId as IpNr
	, t1.IpNameNr as IpNameNr
	, t1.RightHolderType
	, case 
		when t1.RightHolderType = 1 then
			case
				when t1.RoleCode = 1 then 'A'
				when t1.RoleCode = 2 then 'C'
				when t1.RoleCode = 10 then 'CA'
				else ''
			end
		when t1.RightHolderType = 3 then 'E'
		else ''
	  end as IpRole
	, t1.RoleCode
	, t1.HasAgreement
	, t1.PerShr
	, t1.MecShr
	, t2.Name as IpName
	, t2.FstName as IpFstName
from #MsAuthors t1
	left join SocIpi..IpiName t2 on t1.IpNameNr = t2.IpNameNr
";

		public const string SqlSelectDataForWia = @"
select 
	name as WrkTtl
	, null as LngCode
	, ObjId as SubmWrkNr
	, null as Iswc
	, null as CprDate
	, null as CprNr
	, 'UNC' as MwDistrCat
	, null as Dur
	, '???' as RecInd -- was recorded or not Y/N
	, null as TxtMusicRel
	, null as CmpType
	, '???' as VerType -- MOD/ORI
	, null as ExcType
	, '???' as MusicArr
	, '???' as LyrAdapt
	, null as WicCode
	, null as UpdDate
	, null as FstSendDateToCis
	, null as LstSendDateToCis
	, null as SocWrkType
from MediaService..ObjectRight
where objId = @objId
";
	}
}
