

CREATE view [dbo].[vtsk_3_OR_03] as
with CPR as 
(select t2.objid, sum(t2.rate) as rate
from copyright t2 
group by t2.objid
)
, 
CPRH as 
(select custId, objid, sum(rate) as rate, t1.roleCode, max(t2.name) as roleName   
from CopyRight t1 
join CreativeRoleType t2 on t1.roleCode = t2.codeI 
group by t1.custId, t1.objid, t1.roleCode
)
select t7.custId, t8.name as nameClient, t1.objid, t1.name, 
(Case When t1.categoryCode = 5 Then 'M' else 'B' end) as Category, t1.genreType, t2.name as genreName, 
 t3.duration, t7.roleName, t4.name as specName, 
 isnull(t5.rate,0) as rateTotal, 
 t7.rate as rateRH, 
 isnull(t1.performer, '') as performer, 
 isnull(t6.proffit,0) as profit
 from objectRight t1 
left join MediaTrack t3 on t1.objid = t3.objId
left join GenreType t2 on t1.genreType = t2.codeI
left join specType t4 on t1.specType = t4.codeI
left join CPR t5 on t1.objid = t5.objId
left join vtsk_4_OR_PROFITFORYEAR t6 on t1.objId = t6.objid
left join CPRH t7 on t7.objid = t1.objId
left join vCustomer t8 on t8.custId = t7.custId

GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Роли по одному правообладателю НЕ собрані  в строку через запятую (автор тексу, автор музики), а идут отдельно', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vtsk_3_OR_03';

