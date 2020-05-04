
CREATE function [dbo].[ft_Tsk_5_33_RegRH] (@dateBegin date NULL, @dateEnd date NULL)
--Реєстр правовласників за період
RETURNS Table
Return 
(
--declare @dateBegin date = '2019-01-01', @dateEnd date = '2020-01-01'
with TabAgr as 
(
select t7.custId, t7.interCode, t7.innerCode, t7.IPIBase, t7.rHolderType, t11.agrNumber, t11.agrDate, t11.dateBegin, t11.dateEnd,  t11.agrStatus, t7.comment 
 from RightHolder t7 
 join AgreementMaster t10 on t10.custId = t7.custId
 join AgreementAddRH t11 on t11.agrId = t10.agrId and t11.version = t10.version
where isnull(t11.agrDate,dateadd(day,1-day(getdate()),getdate()))  between isnull(@dateBegin, dateadd(day,1-day(getdate()),getdate())) and isnull(@dateEnd, '3000-01-01')
), 
TabObj as 
(select t2.custId, count(distinct t2.objId)  as cntObj
  from TabAgr t1 
    join Copyright t2 on t1.custId = t2.custId
  group by t2.custId
)
select ROW_NUMBER () over (order by t2.name) as rowNum, 
t1.custId, isnull(t1.innerCode, t1.custid) as innerCode, t1.interCode as IPI, t2.name as rhName, cntObj, 
t1.agrNumber, t1.agrDate, t1.dateBegin, t1.dateEnd, t7.countryName as country,
t5.name as agrStatusName, t6.name as rHolderTypeName, t4.email, t4.phoneMobileMain
 from TabAgr t1 
   join vcustomer t2 on t1.custId = t2.custId 
   left join TabObj t3 on t1.custId = t3.custId 
   left join vCustomerEmail t4 on t1.custId = t4.custId 
   left join AgreementStatus t5 on t1.agrStatus = t5.codeI
   left join RHolderType t6 on t1.rHolderType = t6.codeI
   left join Country t7 on t2.countryCode = t7.countryCode
)

GO
GRANT SELECT
    ON OBJECT::[dbo].[ft_Tsk_5_33_RegRH] TO [ReportUser]
    AS [dbo];

