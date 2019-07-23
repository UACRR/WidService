
CREATE view [dbo].[vCommunity_190404] as 
with TmpCm as 
(select cmCustId,  max(cmName) as cmName, MAX(cast(isnull(ourService,0) as int)) as isMy
 from --vCustCmService
    vTermsOfService 
  group by cmCustId 
 )
select row_number() over(ORDER BY cmName)  as num, cmCustId, cmName, isMy
 from TmpCm where cmCustId >=0
 union
 select cmCustId as num, cmCustId, cmName, isMy 
 from TmpCm where cmCustId <0