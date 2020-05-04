
CREATE view [dbo].[vCommunity] as
select ((case WHEN t1.custId = t3.custId Then -1 Else 1 End ) * row_number() over(ORDER BY name) ) as num, t1.custId as cmCustId,  t2.name as cmName, t2.ankMy as isMy, t1.innerCode, t1.interCode 
  from Community t1 
   join vCustomer t2 on t2.custId = t1.custId 
   left join MyAnketa t3 on t1.custId = t3.custId
union
select 0, -1, 'НЕ ВИЗНАЧЕНО', 0, '', ''

