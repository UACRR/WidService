CREATE view [dbo].[vCommunity] as 
with TmpCm as 
(select cmCustId,  max(cmName) as cmName, MAX(isMy) as isMy
 from vCustCmService 
  group by cmCustId 
 )
select row_number() over(ORDER BY cmName)  as num, cmCustId, cmName, isMy
 from TmpCm where cmCustId >=0
 union
 select cmCustId as num, cmCustId, cmName, isMy 
 from TmpCm where cmCustId <0