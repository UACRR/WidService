CREATE view [dbo].[vCustomerRHolder_] as
with TabRH as 
(select t1.custId, max(case when categoryCode=5 then 1 else 0 end) as isSR, max(case when categoryCode=6 then 1 else 0 end) as isBR
 from CopyRight t1 
 join objectRight t2 on t2.objId = t1.objid 
 group by t1.custId
)
select t1.custId, t1.innerCode, t1.interCode, t1.rHolderType, t3.rateCommiss, t3.rateCourt, isSR, isBR, 0 as isCm
 from RightHolder t1 
  join AgreementMaster t2 on t2.custId = t1.custId 
  join AgreementAddRH t3 on t3.agrId = t2.agrId and t3.version = t2.version
  join TabRH t4 on t4.custId = t1.custId
union 
select t1.custId, t1.innerCode, t1.interCode, 2 as rHolderType, t3.rateCommiss, t3.rateCourt, 1 as isSR, 1 as isBR, 1 as isCm
 from Community t1 
  left join AgreementMaster t2 on t2.custId = t1.custId 
  left join AgreementAddCommunity t3 on t3.agrId = t2.agrId and t3.version = t2.version