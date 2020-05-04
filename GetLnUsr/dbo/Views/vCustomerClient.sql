CREATE view [dbo].[vCustomerClient] as
--Вьюшка показывает клиентов с признаком малых и больших прав
(
select t1.custId, max(INNOKPO) as INNOKPO, max(t1.name) as name, 
   max((Case When t3.usesType = 2 then 1 else 0 end)) as isSR, 
   max((Case WHEN t3.usesType = 1 then 1 else 0 END)) as isBR
 from vCustomer t1
 left join vLicenseAgreement t3 on t3.custId = t1.custId 
 where  t1.isClient = 1 
 group by t1.custId
) 
