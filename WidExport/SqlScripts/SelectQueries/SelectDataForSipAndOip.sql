declare @objId int  = 8058

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
