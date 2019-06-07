CREATE view vTSK_3_ObjectMusicanLiric
as 
with Author as 
(select t4.objId, 
t4.roleCode, t6.name as custName, 
(Case when t4.roleCode in (1, 4,6,7,8,9) Then 1 Else 0 end) as authorCode, 
t4.rate 
from CopyRight t4 
join ObjectRight t0 on t4.objid = t0.objId
join CreativeRoleType t5 on t5.codeI = t4.roleCode
join vCustomer t6 on t4.custId = t6.custId
where  t0.categoryCode = 5 and 
       getdate() between isnull(t4.beginDate, '1900-01-01') and isnull(t4.endDate, '3000-01-01')
)
select objid,  
max((Case When t4.authorCode = 1 Then aname else '' end )) as aMusican, 
max((Case When t4.authorCode = 0 Then aname else '' end )) as aLiric, 
sum(rate) as fullRate
from 
(
select t1.objid, t1.authorCode, sum(isnull(rate,0)) as Rate, 
aName = STUFF (
( Select ','+custName from Author t0 where t0.objid = t1.objid and t0.authorCode = t1.authorCode FOR XML PATH ('')), 1,1,''
)
  from Author t1
  group by t1.objId, t1.authorCode
) t4 group by objid 


--select * from vTSK_3_ObjectMusicanLiric