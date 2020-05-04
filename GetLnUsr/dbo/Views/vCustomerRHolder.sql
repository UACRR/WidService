
CREATE view [dbo].[vCustomerRHolder] as

with TabRH as 
(
select t0.custId, 
 max(case when isnull(categoryCode,0)=5 then 1 else 0 end) as isSR, 
 max(case when isnull(categoryCode,0)=6 then 1 else 0 end) as isBR, 
 count(distinct t1.objid) as cntObj
 from 
 rightHolder t0 
  join CopyRight t1 on t0.custId = t1.custId
  join objectRight t2 on t2.objId = t1.objid 
 group by t0.custId
)
, 
TabRes as 
(
select t1.custId, t1.innerCode, t1.interCode, t1.rHolderType, t3.rateCommiss, t3.rateCourt, isSR, isBR, 0 as isCm, t4.cntObj, 
       t3.agrId, t3.agrNumber, t3.agrDate,  t2.agrStatus, t1.IPIBase
 from RightHolder t1 
  left join AgreementMaster t2 on t2.custId = t1.custId 
  left join AgreementAddRH t3 on t3.agrId = t2.agrId and t3.version = t2.version
  left join TabRH t4 on t4.custId = t1.custId
--/*
union 
select t1.custId, t1.innerCode, t1.interCode, 2 as rHolderType, t3.rateCommiss, t3.rateCourt, 0 as isSR, 0 as isBR, 1 as isCm, 0 as cntObj, 
       t3.agrId, t3.agrNumber, t3.agrDate,  t2.agrStatus, NULL as IPIBase
 from Community t1 
  left join AgreementMaster t2 on t2.custId = t1.custId 
  left join AgreementAddCommunity t3 on t3.agrId = t2.agrId and t3.version = t2.version
--*/
)
 select 
   t1.custId, 
   isnull(isnull(t2.shortName, isnull(t4.name + isnull(' '+t4.firstName,''), (isnull(t3.LastName,'')+' '+isnull(t3.firstName,'')+' '+isnull(t3.surName,'')) )
   ), t2.name ) as name, 
   isnull(isnull(t2.shortName, isnull(t4.name, (isnull(t3.LastName,'')) ) ), t2.name ) as lastName, 
   isnull(isnull(t2.shortName, isnull(t4.firstName, (isnull(t3.firstName,'')+' '+isnull(t3.surName,'')) ) ), t2.name ) as firstName, 
  t1.innerCode, t1.interCode, t1.rHolderType, t1.rateCommiss, t1.rateCourt, t1.isSR, t1.isBR, t1.isCm, isnull(t2.registrDate, t3.birthDate) as registrDate, 
  isnull(isnull(t2.jaCountry, t3.reCountry),t4.countryCode) as countryCode, cntObj, 
  agrId, agrNumber, agrDate,  agrStatus, isnull(t3.inn, t2.okpo) as InnOkpo, t5.custType, t5.status as custStatus, t1.IPIBase
 from TabRes t1 
   join customer t5 on t5.custid = t1.custId
   left join AnketaCompany t2 on t2.custId = t1.custId 
   left join AnketaPerson t3 on t3.custId = t1.custId 
   left join AnketaExternal t4 on t4.custId = t1.custId 
