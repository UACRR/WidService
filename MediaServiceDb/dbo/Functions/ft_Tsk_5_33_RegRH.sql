CREATE function [dbo].[ft_Tsk_5_33_RegRH] (@date date NULL)
RETURNS Table
Return 
(
select  
ROW_NUMBER () over (order by t1.name) as rowNum, 
t1.custId, t1.interCode as IPI, t1.name as rhName, cntObj, isnull(community_name, t5.name) as cmName, country,
t2.name as agrStatusName, t6.name as rHolderTypeName
 
 from  vTsk_1_ListRightHolder01 t1 
 left join AgreementStatus t2 on t1.agrStatus = t2.codeI 
 join AgreementMaster t10 on t1.custId = t10.custId 
 join AgreementAddRH t11 on t11.agrId = t10.agrId and t11.version = t10.version
 join RightHolder t7 on t1.custId = t7.custId
 left join RHolderType t6 on t7.rHolderType = t6.codeI
 left join vMyAnk t5 on t1.custId <> t5.custId
 where isnull(t11.dateEnd, '3000-01-01') >=isnull(@date, getdate())
 )

--select * from ft_Tsk_5_33_RegRH () order by rowNum
--select * from vTsk_1_ListRightHolder01 order by name