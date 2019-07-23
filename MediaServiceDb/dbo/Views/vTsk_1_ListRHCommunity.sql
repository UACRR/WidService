CREATE view [dbo].[vTsk_1_ListRHCommunity]
(custId, cmCustId, custStatus, agrStatus, innerCode, interCode, name, registrDate, cntObj, yearProfit, community_name, country) as
with 
TmpRHCommunity as
(
select cmCustId, max(custId) as custId
from custCmRight t1  
where getdate() between isnull(dateBegin, '1900-01-01') and isnull(dateEnd, '3000-01-01')
group by cmCustId, custId
union 
--свои И НЕ ТОЛЬКО! правообладатели
select t3.custId as cmCustId, t2.custId
from RightHolder t1 
     join TermsOfService t2 on t1.custId = t2.custId and t2.ourService = 1
	 join vMyAnk t3 on t3.custId = t3.custId --and ankMy = 1
--     join AgreementMaster t4 on t2.custId = t4.custId and t4.agrStatus = 2
group by t3.custId, t2.custId
)
, 
TabRHObjects AS
(SELECT   t2.custId, COUNT(DISTINCT t2.objId) AS cntObj
      FROM           CopyRight AS t2 
      WHERE            GETDATE() BETWEEN t2.beginDate AND t2.endDate
      GROUP BY t2.custId
)
, 
 TmpProfit AS 
(SELECT  t1.custId, SUM(t2.deboborot) AS yearProfit
   FROM  dbo.Account AS t1 
      JOIN dbo.SaldoDay AS t2 ON t2.accId = t1.accId AND t2.dateBegin >= CAST(DATEADD(DAY, - DATEPART(DAYOFYEAR, GETDATE()) + 1, GETDATE()) AS date)
      where t1.balsCode = 21
    GROUP BY t1.custId
)
select t1.custId, t1.cmCustId, 2 as status, t3.agrStatus, t4.innerCode, t4.interCode, t2.name, isnull(t2.registrDate, '1900-01-01') as registrDate, 
 isnull(t6.cntObj,0), isnull(yearProfit,0), 
 t10.name as community_name, 
 isnull(t5.countryName,'')
 from  TmpRHCommunity t1
    join RightHolder t4 on t1.custId = t4.custId 
    join vCustomerRHolder t2 on t2.custId = t4.custId 
 join vCustomerRHolder t10 on t10.custid = t1.cmCustId
 left join AgreementMaster t3 on t1.custId = t3.custId 
 left join Country t5 on t2.countryCode = t5.countryCode
 left join TabRHObjects t6 on t1.custId = t6.custId
 left join TmpProfit t7 on t1.custId = t7.custId

--select * from vTsk_1_ListRHCommunity where cmCustId = 138   --3051  10034.03  --5574.46
--select count(*) from vTsk_1_ListRHCommunity 