/****** Object:  UserDefinedFunction [dbo].[ft_Tsk_5_32_RegRH]    Script Date: 15.07.2019 12:22:02 ******/
CREATE function  [dbo].[ft_Tsk_5_32_RegRH]  (@dateBegin date = NULL, @dateEnd date = NULL, @custId integer = NULL)
--Реєстр об'єктів права правовласника
-- @date = NULL - текущая дата
-- @custId - по конкретному сообществу, NULL, 0 - по всем клмиентам
--15-07-2019 - performer
RETURNS @RT TABLE
(
id integer not null identity primary key,
rhCustId integer, --правовласник
rhName varchar(200), 
ipi varchar(254), 
objid integer, 
objName varchar(254), 
rate decimal(5,2), 
roleCode integer, 
roleName varchar(200), 
iswc varchar(254), 
author varchar(254), 
performer varchar(254), 
duration char(12), 
categoryName char(1), 
status integer, --статус в CopyRight
statusName varchar(200), 
workTypeRh integer, 
workName varchar(200),
genreName varchar(200), 
rowNum integer, 
dateBegin date, 
dateEnd date
)
AS
BEGIN  --Користувачі

set @dateBegin =  isnull(@dateBegin, convert(date, (convert(char(4),year(getdate()))+'.'+ substring(convert(char(3),100+MONTH(getdate())),2,2)+'.01' ),102))
set @dateEnd = isnull(@dateEnd, getdate())
set @custId = (Case When isnull(@custId,0) = 0 Then NULL Else @custId end)

insert into @RT (rhCustId, rhName, ipi, objid, objName, iswc, author, performer, 
 categoryName, status, statusName, workTypeRh, workName, roleCode, roleName, rate, duration, genreName, rowNum, 
 dateBegin, dateEnd)
select distinct t1.custId, t4.name as nameRH, t4.ipi, t2.objid, t2.name as objName, t5.iswc, t2.author, t2.performer, 
(Case t2.categoryCode When 5 then 'M' else 'B' end), t1.status, t7.name as statusName, 
t3.workTypeRH, (Case isnull(t1.status,0) WHEN 1 Then '' Else t6.name end ) as workName, 
t1.roleCode, t8.name as roleName, 
(case t2.categoryCode when 6 Then roleRate else rate end ) as rate,
convert(char(12), t5.duration) as duration,
t9.name+ (case isnull(t2.actCode,0) when 0 Then '' Else ', актів - '+isnull(convert(char(1),t2.actCode),'') end ) as genreName,
ROW_NUMBER() OVER( Partition by t1.custId ORDER BY t1.custId, t2.name), 
t1.beginDate, t1.endDate 
from CopyRight t1 
join objectRight t2 on t1.objid  = t2.objid 
left join MediaTrack t5 on t2.objid = t5.objId
left join workRH t3 on t1.cRightId = t3.cRightId
left join WorkType t6 on t3.workTypeRH = t6.codeI
join vCustomer t4 on t1.custId = t4.custId
join CRightStatus t7 on isnull(t1.status,0) = t7.codeI
join CreativeRoleType t8 on t1.roleCode = t8.codeI
left join GenreType t9 on t2.genreType = t9.codeI
where t1.custId = isnull(@custId, t1.custId) 
and @dateEnd between isnull(t1.beginDate, '1900-01-01') and isnull(t1.endDate,'3000-01-01')

 RETURN
 END
 
--select * from ft_Tsk_5_32_RegRH ('2019-01-17', NULL, 3028)
--select * from ft_Tsk_5_33_RegRH ('2019-01-17', NULL)
--select rowNum, rhCustId, rhName, ipi, iswc, objid, objName, rate, roleName,  categoryName, author, duration, genreName, statusName, workName from ft_Tsk_5_32_RegRH ('2019-01-01', 132) order by rowNum
GO
GRANT SELECT
    ON OBJECT::[dbo].[ft_Tsk_5_32_RegRH] TO [ReportUser]
    AS [dbo];

