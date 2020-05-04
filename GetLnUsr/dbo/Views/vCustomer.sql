
-------------------------------

CREATE view [dbo].[vCustomer] as 
 with Cust as 
( select t1.custId, custType, status, ankVersion, ankPublish, ankTech, 
  (Case When t2.custid is NUll Then 0 else 1 end) as isRHolder,
  (Case When t3.custid is NUll Then 0 else 1 end) as isClient,
  (Case When t4.custid is NUll Then 0 else 1 end) as isPartner,
  (Case When t5.custid is NUll Then 0 else 1 end) as ankMy, 
   t2.signP,  
   --isnull((Case When isnull(t2.signP,0) = 0 Then t2.CustId Else (select custId from customer where isnull(ankPublish,0)= 1) end), t1.custId) as custIdSP, 
   null as custIdSP, 
   t2.interCode as IPI, 
   t1.userId, 
   t6.userName
 from customer t1 
    left join RightHolder t2 on t1.custId = t2.custId 
    left join Client t3 on t3.custId = t1.custId 
    left join Partner t4 on t4.custId = t1.custId 
    left join myAnketa t5 on t5.custId = t1.custId
	left join AspNetUsers t6 on t1.userId = t6.id
 )
select
   t1.custId,
   t1.custType,
   isnull(t3.shortName, t3.name) as name,
   t3.name as fullName,
   t1.isRHolder,
   t1.isClient,
   t1.isPartner,
   t1.status,
   t1.ankVersion,
   t1.ankMy,
   t1.ankPublish,
   t1.signP,
   t1.custIdSP,
   t3.OKPO as INNOKPO,
   t3.activityCode as activityCode,
   t3.JaCountry as countryCode,
   t1.ankTech,
   t3.registrDate as registrDate,
   t3.jaRegion, 
   t3.jaCity, 
   t3.jaAddress,
   cast(0 as bit) as isAnkExtrn,
   t1.IPI, 
   t1.userId, 
   t1.userName
from
   Cust t1
   join Company t2 on  t2.CustId = t1.CustId
   join AnketaCompany t3 on  t3.CustId = t2.CustId and t3.Version = t1.ankVersion
union
select
   t1.custId,
   t1.custType,
   (Case WHEN t1.custType = 2 THEN 'ФОП ' ELSE '' END)+isnull(t3.LastName,'')+' '+isnull(t3.FirstName,'') + ' ' + isnull(t3.SurName,'') as name ,
   --isnull(t3.LastName,'')+' '+isnull((substring(t3.FirstName,1,1)+'.'),'') + ' ' + isnull((substring(t3.SurName,1,1)+'.'),'') as name,
   isnull(t3.LastName,'')+' '+isnull(t3.FirstName,'') + ' ' + isnull(t3.SurName,'') as fullName ,
   t1.isRHolder,
   t1.isClient,
   t1.isPartner,
   t1.status,
   t1.ankVersion,
   t1.ankMy,
   t1.AnkPublish,
   t1.signP,
   t1.custIdSP,
   t3.INN as INNOKPO,
   null as activityCode,
   t3.reCountry as countryCode,
   t1.ankTech,
   t3.birthDate as registrDate,
   t3.reRegion as jaRegion, 
   t3.reCity as jaCity, 
   t3.reAddress as jaAdress,
   cast(0 as bit) as isAnkExtrn,
   t1.IPI,
   t1.userId, 
   t1.userName
from
   Cust t1
   join Person t2 on  t2.CustId = t1.CustId
   join AnketaPerson t3 on  t3.custId = t2.CustId and t3.Version = t1.ankVersion
union --внешние
select
   t1.custId,
   t1.custType as custType,
   name + isnull(' '+t2.firstName,'') as name,
   name + isnull(' '+t2.firstName,'') as fullName,
   t1.isRHolder,
   t1.isClient,
   t1.isPartner,
   t1.status,
   t1.ankVersion,
   t1.ankMy,
   t1.AnkPublish,
   t1.signP,
   t1.custIdSP,
   t2.innOkpo as INNOKPO,
   null as activityCode,
   NULL as countryCode,
   t1.ankTech,
   NULL as registrDate,
   NULL as jaRegion, 
   NULL as jaCity, 
   NULL as jaAdress,
   cast(1 as bit) as isAnkExtrn, 
   t1.IPI as IPI, 
   t1.userId, 
   t1.userName
from
   Cust t1
   join AnketaExternal t2 on  t2.CustId = t1.CustId
--   where not exists ( select 1 from AnketaPerson t3 where t3.custId = t2.CustId ) and 
--         not exists ( select 1 from AnketaCompany t4 where t4.custId = t2.CustId ) 
