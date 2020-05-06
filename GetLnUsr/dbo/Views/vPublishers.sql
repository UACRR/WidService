CREATE view [dbo].[vPublishers] as
select t1.custId, isnull(isnull(t2.shortName, isnull(t4.name, (isnull(t3.LastName,'')+' '+isnull(t3.firstName,'')+' '+isnull(t3.surName,'')))), t2.name ) as PublisherName
from RightHolder t1
left join AnketaCompany t2 on t2.custId = t1.custId 
left join AnketaPerson t3 on t3.custId = t1.custId 
left join AnketaExternal t4 on t4.custId = t1.custId
where t1.rHolderType = 3
