CREATE view [dbo].[vtsk_3_OR_01] as
with CPR as 
(select t2.objid, sum(t2.rate) as rate, min(isnull(t2.status,0)) as isNotAccepted
  from copyright t2 
  --left join WorkRH t3 on t2.cRightId = t3.cRightId and t3.workTypeRh <> 4
  where getdate() between t2.beginDate and t2.endDate
  group by t2.objid
)
,
SDay as 
(select t1.objid, t2.accId, t3.rest
 from ObjectRight t1 
 join Account t2 on t1.objid = t2.objid 
 join SaldoDay t3 on t2.accId = t3.accId and getdate() between t3.dateBegin and t3.dateEnd and t3.rest <> 0
)

select t1.objid, t1.name, 
(Case When t1.categoryCode = 5 Then 'M' else 'B' end) as Category, t1.genreType, t2.name as genreName, 
 t3.duration, t4.name as specName, isnull(t5.rate,0) as rateTotal, isnull(t1.performer, '') as performer, isnull(t6.proffit,0) as profit
,rest --залишок на рахунку
,(Case When t1.status = 1 Then 1 Else 0 end ) as statusActive -- Діючі
,(Case When t5.isNotAccepted = 0 Then 1 Else 0 end ) as statusNoActive -- Якщо є копірайт без підтвердження
,(Case When isnull(t5.rate,0) <100 Then 1 Else 0 end ) as statusNoRelate -- Не прив"язані
--,(Case When t5.workTypeRh = 1 Then 1 Else 0 end ) as statusWokrRq -- Сформовані запити
,(Case When isnull(t11.Rest,0) <> 0 Then 1 Else 0 end ) statusUnDistrib -- Не розподілені
,t1.categoryCode
from objectRight t1 
left join MediaTrack t3 on t1.objid = t3.objId
left join GenreType t2 on t1.genreType = t2.codeI
left join specType t4 on t1.specType = t4.codeI
left join CPR t5 on t1.objid = t5.objId
left join vtsk_4_OR_PROFITFORYEAR t6 on t1.objId = t6.objid
left Join SDay t11 on t11.objid = t1.objId