
CREATE view [dbo].[vTsk_3_ObjectsCopyright]
(
	  objid
	, custId
	, name
	, cRightId
	, beginDate
	, endDate
	, ratePer
	, rateMech
	, roleCode
	, status
) as
with ObjList as
(
	select custid, objid from vtsk_3_OR_03_Transfer 
	group by objid, custId
)
select t1.objid
	 , t1.custid
	 , isnull(isnull(t4.shortName, isnull(t6.name + isnull(' '+t6.firstName,'') , (isnull(t5.LastName,'')+' '+isnull(t5.firstName,'')+' '+isnull(t5.surName,'')))), t4.name ) as name
	 , t2.cRightId
	 , t2.beginDate
	 , t2.endDate
	 , t2.rate
	 , t2.rateMech
	 , t2.roleCode
	 , t2.status
from ObjList t1
left join CopyRight t2 on t2.objId = t1.objid
left join AnketaCompany t4 on t4.custId = t2.custId 
left join AnketaPerson t5 on t5.custId = t2.custId 
left join AnketaExternal t6 on t6.custId = t2.custId 
where (getdate() between t2.beginDate and t2.endDate) or getdate() <= t2.beginDate
