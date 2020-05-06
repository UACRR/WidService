
CREATE view [dbo].[vtsk_3_OR_01] as
select t1.objid, t1.name, 
(Case When t1.categoryCode = 5 Then 'M' else 'B' end) as Category, 
 t1.genreType, t2.name as genreName, 
 --t3.duration, 
 t4.name as specName, isnull(t5.rate,0) as rateTotal, 
 isnull(t1.author, '') as author , -- Патлякевич додав для відображення автора при прив'язці
 (CASE When t1.categoryCode = 5 THEN isnull(t1.performer, '') ELSE t14.name END) as performer, 
 0 as profit  --isnull(t6.proffit,0) as profit
,t11.rest --залишок на рахунку
,(Case When t1.status = 1 Then 1 Else 0 end ) as statusActive -- Діючі
,(Case When t5.isNotAccepted = 0 Then 1 Else 0 end ) as statusNoActive -- Якщо є копірайт без підтвердження
,(Case When isnull(t5.rate,0) <100 Then 1 Else 0 end ) as statusNoRelate -- Не прив"язані
--,(Case When t5.workTypeRh = 1 Then 1 Else 0 end ) as statusWokrRq -- Сформовані запити
,(Case When isnull(t11.Rest,0) <> 0 Then 1 Else 0 end ) statusUnDistrib -- Не розподілені
,t1.categoryCode
, isnull(t1.innerCode, cast(t1.objid as varchar(25))) as innerCode
from objectRight t1 
--left join MediaTrack t3 on t1.objid = t3.objId
left join GenreType t2 on t1.genreType = t2.codeI
left join specType t4 on t1.specType = t4.codeI
left join vObjectRateAccept t5 on t1.objid = t5.objId
--left join vtsk_4_OR_PROFITFORYEAR t6 on t1.objId = t6.objid
left Join vObjectRest31  t11 on t11.objid = t1.objId
left join LicenseBigR t12 on t12.objId = t1.objId
left join LicenseAgreement t13 on t13.licId = t12.licId 
left join vCustomerRHolder t14 on t14.custId = t13.custId 
--left join vCustomer t14 on t14.custId = t13.custId 

