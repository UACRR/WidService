
CREATE view [dbo].[vtsk_3_OR_03_V2] as
with CPR as 
(select t2.objid, sum(t2.rate) as rate
from copyright t2 
where getdate() between t2.beginDate and t2.endDate
group by t2.objid
)
, 
CPRH as 
(select t1.custId, t1.objid, sum(rate) as rate, min(isnull(status,0)) as status,
roleName = STUFF (
(select ','+t22.name 
from copyright t11 
join CreativeRoleType t22 on t11.roleCode = t22.codeI  and t11.custId = t1.custId and t1.objId = t11.objId
where getdate() between t11.beginDate and t11.endDate
FOR XML PATH ('')), 1,1,''
)
from CopyRight t1 
where getdate() between t1.beginDate and t1.endDate
group by t1.custId, t1.objId
)
select t7.custId, t8.name as nameClient, t1.objid, t1.name, 
(Case When t1.categoryCode = 5 Then 'M' else 'B' end) as Category, t1.genreType, t2.name as genreName, 
 t3.duration, t7.roleName,
 t4.name as specName, isnull(t5.rate,0) as rateTotal, 
 t7.rate as rateRH, 
 isnull(t1.performer, '') as performer, 
 isnull(t6.proffit,0) as profit
,(Case When t7.status = 1 Then 1 Else 0 end ) as statusActive
,(Case When t7.status = 0 Then 1 Else 0 end ) as statusNoActive
,(Case When t5.rate <100 Then 1 Else 0 end ) statusNoRelate, 
t3.iswc
 from objectRight t1 
left join MediaTrack t3 on t1.objid = t3.objId
left join GenreType t2 on t1.genreType = t2.codeI
left join specType t4 on t1.specType = t4.codeI
join CPR t5 on t1.objid = t5.objId
left join vtsk_4_OR_PROFITFORYEAR t6 on t1.objId = t6.objid
join CPRH t7 on t7.objid = t1.objId
join vCustomer t8 on t8.custId = t7.custId
GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Версия vtsk_3_OR_03, где роли по одному правообладателю идут в строку через запятую (автор тексу, автор музики)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vtsk_3_OR_03_V2';

