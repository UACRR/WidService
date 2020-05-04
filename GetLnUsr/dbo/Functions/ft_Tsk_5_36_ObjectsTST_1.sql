CREATE function [dbo].[ft_Tsk_5_36_ObjectsTST_1] (@datebegin date =NULL, @dateEnd date NULL ,@numBLK int,@length int)

RETURNS TABLE 

AS RETURN

(
--declare @dateBegin date = '2019-07-01', @dateEnd date = '2019-08-01'
--;
with TabObj as 
(select t1.objid, t1.innerCode, t1.name as objName, t1.createDate, t1.genreType
 from objectRight t1
 where t1.categoryCode = 5 
--за текущий месяц при NULL
      and cast (isnull(t1.createDate, '2018-01-01') as date) between isnull(@dateBegin, dateadd(day,1-day(getdate()),getdate())) and isnull(@dateEnd, getdate()) 
), 
TabAuthors as 
(
select  t1.objId, t9.roleCode, t9.authorName, t9.custId, t4.rate, t4.rateMech, t4.status
 from Authors t9 
 join TabObj t1 on t1.objid = t9.objid 
 left join CopyRight t4 on t4.objid = t1.objId and t4.custId = t9.custId and t4.roleCode = t9.roleCode and getdate() between t4.beginDate and t4.endDate
union 
 select t10.objId, 3 as roleCode, t10.name as authorName, null as custId, NULL as rate, null as rateMexh, NULL as status
  from SeekObject t10 
  join TabObj t1 on t10.objid = t1.objId and t10.codeI = 2
)
select --ROW_NUMBER () Over (order by t1.createDate, t1.objname, t1.objid, t5.CRType, t4.roleCode, t6.name) as row_numb,
       t1.objid, isnull(t1.innerCode, convert(varchar(20), t1.objId)) as innerCode, t2.iswc, t1.objName, t3.name as genreName, 
       t5.name as roleName, isnull(t6.name, t4.authorName) as rhName, t6.innerCode as rhInnerCode, t6.interCode as IPI, 
       t4.rate, t4.status as cRightStatus, 
       isnull(t7.name,'') as cRightStatusName, t6.agrStatus, t8.name as agrStatusName, t1.createDate,
	   t2.performers
from TabObj t1 
join MediaTrack t2 on t1.objid = t2.objid 
left join GenreType t3 on t1.genreType = t3.codeI 
left join TabAuthors t4 on t4.objid = t1.objId
left join CreativeRoleType t5 on t5.codei = t4.roleCode
left join vCustomerRHolder t6 on t6.custid = t4.custId 
left join CRightStatus t7 on t7.codeI = t4.status 
left join AgreementStatus t8 on t6.agrStatus = t8.codeI
ORDER BY  t1.createDate, t1.objname, t1.objid, t5.CRType, t4.roleCode, t6.name
OFFSET isnull(@length,10000)*isnull(@numBLK,0)  ROWS FETCH first isnull(@length,10000) ROWS ONLY

--select dateadd(day,1-day(getdate()),getdate())
--select dateadd(month,1,dateadd(day,1-day(getdate()),getdate()))-1
)


/*
select row_numb, objid, innerCode,iswc, objName, genreName, roleName, rhName, rhInnerCode, IPI, rate, cRightStatus, cRightStatusName, agrStatus, agrStatusName, createDate, performers
 from ft_Tsk_5_36_Objects ('2019-02-01', '2019-02-28') order by row_numb

select * from ft_Tsk_5_36_ObjectsTST_1 ('1900-07-01', '2019-07-09',1,30000)
select * from ft_Tsk_5_36_Objects ('2019-07-01', '2019-08-31')
*/


GO
GRANT SELECT
    ON OBJECT::[dbo].[ft_Tsk_5_36_ObjectsTST_1] TO [ReportUser]
    AS [dbo];

