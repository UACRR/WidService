
CREATE view [dbo].[vPubSub] as
with rhNames as
(
select t1.custId, isnull(isnull(t2.shortName, isnull(t4.name, (isnull(t3.LastName,'')+' '+isnull(t3.firstName,'')+' '+isnull(t3.surName,'')))), t2.name ) as name
from RightHolder t1
left join AnketaCompany t2 on t2.custId = t1.custId 
left join AnketaPerson t3 on t3.custId = t1.custId 
left join AnketaExternal t4 on t4.custId = t1.custId
)

select t1.*
,t2.name as PubName
,t3.name as SubName 
from RelSubPublish t1
left join rhNames t2 on t2.custId = t1.custIdPub
left join rhNames t3 on t3.custId = t1.custIdSub
