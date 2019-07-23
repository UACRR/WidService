CREATE function [dbo].[ft_Tsk_5_36_Objects] (@datebegin date =NULL, @dateEnd date NULL)
RETURNS TABLE 
AS RETURN
(
select --ROW_NUMBER () Over (order by t1.name, t1.objid, t5.name, t6.name) as row_numb,
       ROW_NUMBER () Over (order by t1.createDate, t1.name, t1.objid, t6.name) as row_numb,
       t1.objid, t1.innerCode, t2.iswc, t1.name as objName, t3.name as genreName, 
       t5.name as roleName, t6.name as rhName, t6.innerCode as rhInnerCode, t6.interCode as IPI, 
       t4.rate, t4.status as cRightStatus, 
       t7.name as cRightStatusName, t6.agrStatus, t8.name as agrStatusName, t1.createDate
from objectright t1 
join MediaTrack t2 on t1.objid = t2.objid 
left join GenreType t3 on t3.codeI = t1.genreType 
left join copyRight t4 on t4.objid = t1.objId
left join CreativeRoleType t5 on t5.codei = t4.roleCode
left join vCustomerRHolder t6 on t6.custid = t4.custId 
left join CRightStatus t7 on t7.codeI = t4.status 
left join AgreementStatus t8 on t8.codeI = t6.agrStatus
where t1.categoryCode = 5 
--за текущий месяц при NULL
      and cast (isnull(t1.createDate, '2018-01-01') as date) between isnull(@dateBegin, dateadd(day,1-day(getdate()),getdate())) and isnull(@dateEnd, getdate()) 
--select dateadd(day,1-day(getdate()),getdate())
--select dateadd(month,1,dateadd(day,1-day(getdate()),getdate()))-1
)

/*
select row_numb, objid, innerCode,iswc, objName, genreName, roleName, rhName, rhInnerCode, IPI, rate, cRightStatus, cRightStatusName, agrStatus, agrStatusName, createDate
 from ft_Tsk_5_36_Objects ('2019-02-01', '2019-02-28') order by row_numb

select * from ft_Tsk_5_36_Objects ('2019-07-01', '2019-07-09')
select * from ft_Tsk_5_36_Objects ('2019-01-01', '2019-01-31')
*/
GO
GRANT SELECT
    ON OBJECT::[dbo].[ft_Tsk_5_36_Objects] TO [ReportUser]
    AS [dbo];

