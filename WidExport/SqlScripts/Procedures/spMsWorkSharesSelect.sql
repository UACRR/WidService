use SocWidSubmit
go

create or alter procedure spMsWorkSharesSelect
	  @WidSubmGroupId int
	, @objId int
as
begin
/*drop table if exists #MsAuthors
create table #MsAuthors(
	 cRightId			  int			   not null
   , IpBaseNr             varchar(13)      null
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
	  cRightId
	, IpBaseNr
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
	  t1.cRightId				as cRightId
	, left(t3.interCode, 13)	as IpBaseNr
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
	  cRightId
	, IpBaseNr
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
*/

select
	  CopyRightId
	, CustId
	, IpBaseNr
	, IpNameNr
	, RhType
	, RhRole
	, AggrLocal
	, AggrIpiPer
	, AggrIpiMec
	, PerShr
	, MecShr
	, ModifiedBy
	, AggrInvert
from SocWidSubmit..WidSubmGroupWorkShare
where WidSubmGroupId = @WidSubmGroupId
	and ObjId = @objId

end
go

-- exec spIpiPartySelect 'KHARCHYSH'
