




/*==============================================================*/
/* View: vtsk_3_OR_03_V3                                        */
/*==============================================================*/
CREATE view [dbo].[vtsk_3_OR_03_V3] as
with CPR as 
(select t2.objid, sum(t2.rate) as rate
from copyright t2 
group by t2.objid
)
, 
SDay as 
(select t1.objid, t2.accId, t3.rest
 from ObjectRight t1 
 join Account t2 on t1.objid = t2.objid 
 join SaldoDay t3 on t2.accId = t3.accId and getdate() between t3.dateBegin and t3.dateEnd and t3.rest <> 0
)
select t0.custId, t8.name as nameClient, t1.objid, t1.name, 
(Case When t1.categoryCode = 5 Then 'M' else 'B' end) as Category, t1.genreType, t2.name as genreName, 
 t3.duration, t10. name as roleName, t0.beginDate, t0.endDate, 
 t4.name as specName, 
 isnull(t5.rate,0) as rateTotal, 
 t0.rate as rateRH, 
 isnull(t1.performer, '') as performer, 
 isnull(t6.proffit,0) as profit
,(Case When t0.status = 1 Then 1 Else 0 end ) as statusActive
,(Case When t0.status = 0 Then 1 Else 0 end ) as statusNoActive
,(Case When t5.rate <100 Then 1 Else 0 end ) as statusNoRelate
,(Case When t9.workTypeRh = 1 Then 1 Else 0 end ) as statusWokrRq
,(Case When isnull(t11.Rest,0) <> 0 Then 1 Else 0 end ) statusUnDistrib
from CopyRight t0 
join objectRight t1 on t0.objid = t1.objId
join CreativeRoleType t10 on t0.roleCode = t10.codeI
left join MediaTrack t3 on t1.objid = t3.objId
join GenreType t2 on t1.genreType = t2.codeI
join specType t4 on t1.specType = t4.codeI
join CPR t5 on t1.objid = t5.objId
left join vtsk_4_OR_PROFITFORYEAR t6 on t1.objId = t6.objid
join vCustomer t8 on t8.custId = t0.custId
left join WorkRh t9 on t0.cRightId = t9.cRightId and t9.workTypeRh = 1
left Join SDay t11 on t11.objid = t1.objId 


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Версия vtsk_3_OR_03, где роли по одному правообладателю идут не  сгруппированные с датой возникновения', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vtsk_3_OR_03_V3';

