CREATE function dbo.ft_Tsk_5_33_RegRH (@dateBegin date NULL, @dateEnd date NULL)
--Реєстр правовласників за період
RETURNS Table
Return 
(
select  
ROW_NUMBER () over (order by t1.name) as rowNum, 
t1.custId, isnull(t1.innerCode, t1.custid) as innerCode, t1.interCode as IPI, t1.name as rhName, cntObj, 
--(Case When isnull(t1.community_name, '') = ''  Then  t5.name Else t1.community_name END ) as cmName, 
t11.agrNumber, t11.agrDate, t11.dateBegin, t11.dateEnd, 
country,
t2.name as agrStatusName, t6.name as rHolderTypeName
 from  vTsk_1_ListRightHolder01 t1 
 left join AgreementStatus t2 on t1.agrStatus = t2.codeI 
 join AgreementMaster t10 on t1.custId = t10.custId 
 join AgreementAddRH t11 on t11.agrId = t10.agrId and t11.version = t10.version
 join RightHolder t7 on t1.custId = t7.custId
 left join RHolderType t6 on t7.rHolderType = t6.codeI
 left join vMyAnk t5 on t5.custId = t5.custId
 --where isnull(t11.dateEnd, '3000-01-01') >=isnull(@date, getdate())
 where isnull(t11.agrDate,dateadd(day,1-day(getdate()),getdate()))  between isnull(@dateBegin, dateadd(day,1-day(getdate()),getdate())) and isnull(@dateEnd, '3000-01-01')
 )

--select * from ft_Tsk_5_33_RegRH_ ('2019-02-01', '2019-02-28') order by rowNum
--select * from vTsk_1_ListRightHolder01 where community_name = '' order by name
GO
GRANT SELECT
    ON OBJECT::[dbo].[ft_Tsk_5_33_RegRH] TO [ReportUser]
    AS [dbo];

