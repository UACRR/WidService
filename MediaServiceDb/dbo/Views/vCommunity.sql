CREATE view [dbo].[vCommunity] as
select row_number() over(ORDER BY name)  as num, t1.custId as cmCustId,  t2.name as cmName, t2.ankMy as isMy 
  from Community t1 
   join vCustomer t2 on t2.custId = t1.custId 
union
select 0, -1, 'НЕ ВИЗНАЧЕНО', 0
GO
GRANT SELECT
    ON OBJECT::[dbo].[vCommunity] TO [ReportUser]
    AS [dbo];

