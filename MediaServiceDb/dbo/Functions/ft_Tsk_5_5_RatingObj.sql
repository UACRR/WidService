
CREATE function  [dbo].[ft_Tsk_5_5_RatingObj]  (@category integer = NULL, @cRightKind integer = NULL, @ourAuthor int = NULL, @dateBegin date = NULL, @dateEnd date = NULL)
--@category - 0,NULL - все; 6-большие права, 5-малые права
--@cRightKind - по справочнику cRightKind; 0,NULL - все
--@ourAuthor NULL, 0 - все; 1-наши, 2 - чужие
RETURNS @RT TABLE
(
id integer not null identity primary key,
objId integer, 
objName varchar(200),
categoryName varchar(200), 
genreName varchar(100),
duration time,
spacTypeName varchar(100), 
rateFull decimal(10,5), 
performer varchar(200),
amount money,
ourAuthor smallint 
)
AS
BEGIN  --Користувачі

--declare @dateBegin date, @dateEnd date, @cRightKind integer, @category integer,  @ourAuthor smallint
set @dateBegin = isnull(@dateBegin, (select convert(date, (convert(char(4),year(getdate()))+'-01-01'))))
set @dateEnd = isnull(@dateEnd, getdate())
set @cRightKind = (Case When isnull(@cRightKind,0) = 0 Then NULL Else @cRightKind end)
set @category = (Case When isnull(@category,0) = 0 Then NULL Else @category end)
set @ourAuthor = (Case When isnull(@ourAuthor,0) = 0 Then NULL Else @ourAuthor end)
set @dateBegin = cast(@dateBegin as date)
set @dateEnd = cast(@dateEnd as date)

--обороты по видам права и правообладателям
;with TabTurn as 
(
select t2.objId as objid, sum(t1.amount) as amount 
from PayTurn t1 
  join account t2 on t2.accid = t1.accIdDebet  
  join ObjectRight t3 on t3.objId = t2.objId
where t1.accDebet like '30%' and accCredit like '22%'   --собрали на объекты
   and t1.dateWork between @dateBegin and @dateEnd
   and convert(integer,substring(t1.accDebet,4,2) ) = isnull(@cRightKind,convert(integer,substring(t1.accDebet,4,2) ))
   and t3.categoryCode = isnull(@category,t3.categoryCode)
 group by t2.objid
)
 insert into @RT 
  (objId, objName, categoryName, genreName, duration, spacTypeName, rateFull, performer, amount)
select t1.objid, t2.name as objName, 
      (case  when t2.categoryCode = 6 Then 'B' else 'M' end) as categoryName, 
      t3.name as genreName, 
      t4.duration,   
      t5.name as  specTypeName, 
      0, 
      t2.performer, 
      t1.amount
 from  TabTurn t1 
    join ObjectRight t2 on t1.objId = t2.objId 
    left join GenreType t3 on t3.codeI = t2.genreType
    left join MediaTrack t4 on t4.objid = t2.objid 
    left join specType t5 on t5.codeI = t2.genreType

--Загальний процент
;with TabCR as 
(
 select objid, sum(isnull(rate,0)) as rate
  from  copyright where isnull(status,0)=1
 group by objid
)
update @Rt set rateFull = t2.rate 
 from @RT t1 
  join TabCR t2 on t1.objid = t2.objid 

--Если есть хоть один чужой сервис по выбранному виду права - будет весь чужой твир
;with TabOurSrv as 
(
select  t1.objid, min(isnull(convert(smallint,t3.ourService),0))  as ourService
from @Rt  t1 
 join copyright t2 on t1.objId = t2.objid and t2.status = 1
 left join TermsOfService t3 on t3.custId = t2.custId and t3.CRKindCode = isnull(@cRightKind, t3.CRKindCode)
 group by t1.objid
)
update @Rt set ourAuthor = t2.ourService
 from @Rt  t1 
    join TabOurSrv t2 on t1.objid = t2.objid 

--ourService =0 -чужой, 1-наш
--@ourAuthor =1-наш, 2-чужой
  delete @Rt 
     where  isnull(ourAuthor,0) = 0  and @ourAuthor=1
  delete @Rt 
     where isnull(ourAuthor,0) = 1 and  @ourAuthor=2

 RETURN
 END
 --select  * from ft_Tsk_5_5_RatingObj (NULL, NULL, NULL, '2019-07-11', '2019-07-11')
GO
GRANT SELECT
    ON OBJECT::[dbo].[ft_Tsk_5_5_RatingObj] TO [ReportUser]
    AS [dbo];

