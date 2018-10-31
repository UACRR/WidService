CREATE view [dbo].[vTsk_1_ListRHCommunity]
(custId, cmCustId, custStatus, agrStatus, innerCode, interCode, name, registrDate, cntObj, yearProfit, community_name, country) as
with 
TmpMyAnk as 
(
select custId as cmMyCustId, name as cmMyName from vCustomer t1 where t1.ankMy = 1 
)
,
TmpRHCommunity as
(
select 
t3.custId, max(t1.name) as name, t3.cmCustId
from vCustomer t1
join Community t2 on t2.custId = t1.custId
join CustCmRight t3 on t3.cmCustId = t1.custId 
group by t3.custId, t3.cmCustId
union 
select t1.custId, max(t3.cmMyName), t3.cmMyCustId
  from RightHolder t1 
  join TermsOfService t2 on t1.custId = t2.custId and isnull(t2.ourservice,0) = 1
  left join TmpMyAnk t3 on t3.cmMyCustId <> 0
  group by t1.custId, t3.cmMyCustId
), 
TabRHObjects AS
(SELECT   t1.custId, COUNT(DISTINCT t2.objId) AS cntObj
      FROM            dbo.vCustomer AS t1 INNER JOIN
                      dbo.CopyRight AS t2 ON t2.custId = t1.custId AND GETDATE() BETWEEN t2.beginDate AND t2.endDate
      WHERE           (t1.isRHolder = 1)
      GROUP BY t1.custId
), 
 TmpProfit AS 
(SELECT  t1.custId, SUM(t2.deboborot) AS yearProfit
   FROM  dbo.Account AS t1 INNER JOIN
         dbo.SaldoDay AS t2 ON t2.accId = t1.accId AND t2.dateBegin >= CAST(DATEADD(DAY, - DATEPART(DAYOFYEAR, GETDATE()) + 1, GETDATE()) AS date)
    GROUP BY t1.custId
)
select t1.custId, t1.cmCustId, t2.status, t3.agrStatus, t4.innerCode, t4.interCode, t2.name, isnull(t2.registrDate, '1900-01-01') as registrDate, 
 isnull(t6.cntObj,0), isnull(yearProfit,0), t1.name as community_name, isnull(t5.countryName,'')
 from TmpRHCommunity t1 
 join vCustomer t2 on t1.custId = t2.custId
 join AgreementMaster t3 on t1.custId = t3.custId 
 join RightHolder t4 on t1.custId = t4.custId 
 left join Country t5 on t2.countryCode = t5.countryCode
 left join TabRHObjects t6 on t1.custId = t6.custId
 left join TmpProfit t7 on t1.custId = t7.custId