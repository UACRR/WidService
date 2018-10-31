--drop function dbo.ft_ProductTime
create FUNCTION dbo.ft_ProductTime (@reqId integer, @lang char(2) = NULL)
RETURNS @RT TABLE
( id integer not null identity primary key, 
  reqId integer  null, 
  objId integer null, 
  objName varchar(254) null, 
  objAuthor varchar(254) null,
  objPerfomer varchar(254) null, 
  countUse integer null,               --кол-во использования
  countUseName varchar(100) null,      --кол-во использования словами
  EpisodeName varchar(100) null,       --наименование эпизода
  epDuration time null,               --хронометраж 
  TimeDesc varchar(254) null           --эпизод и хронометраж словами
)
  as
  BEGIN 
--declare @reqId integer 
--set @reqId = 115
 set @lang = (Case When @lang is NULL or  @lang not in ('Uk', 'Ru','En') Then 'Uk' Else  @lang end)

Insert into @RT
select  
rr.reqId, rr.objid, rr.objName, rr.objAuthor, rr.objPerfomer
,rr.countUse
,rr.countUseName
,dd.episodeTypeName 
,dd.epDuration
,dd.TimeDesc
from 
(
select ROW_NUMBER() OVER(ORDER BY o1.objid ) AS RowR, 
r1.reqId, o1.objid, o1.name as objName, o1.author as objAuthor, o1.performer as objPerfomer
,r1.countUse
,d1.dName as countUseName
from request r1 
join ObjectRight o1 on r1.objid = o1.objId
left join vlDicList d1 on dKind = 'CountUse' and d1.dCode = isnull(r1.countUse,0) and lang = @lang
where r1.reqId = @reqId
) RR
right join 
(
select 
ROW_NUMBER() OVER(ORDER BY t1.episodeTypeCode ) AS RowD, 
Ep1.reqId
,t1.episodeTypeCode
,t1.episodeTypeName 
,TIMEFROMPARTS ( isnull(Ep1.epDuration,0)/3600, isnull(Ep1.epDuration,0)/60, convert(integer,isnull(Ep1.epDuration,0))%60, 0,0 ) as epDuration
,t1.episodeTypeName + ' '+convert(char(10), TIMEFROMPARTS ( isnull(Ep1.epDuration,0)/3600, isnull(Ep1.epDuration,0)/60, convert(integer,isnull(Ep1.epDuration,0))%60, 0,0 ) ) as TimeDesc
from 
vlepisodeType t1 
left join 
(select m1.reqId, m1.episodeTypeCode, m1.epDuration from RelMovieEpisode  m1 where reqId = @reqId
union 
select m1.reqId, m1.episodeTypeCode, m1.epDuration from RelSerialEpisode  m1 where reqId = @reqId
union 
select m1.reqId, m1.episodeTypeCode, m1.epDuration from RelTVEpisode  m1 where reqId = @reqId 
) Ep1  
on ep1.episodeTypeCode = t1.episodeTypeCode  
where t1.lang = @lang 
) DD
on rr.RowR = dd.RowD


RETURN 
END  

--select * from dbo.ft_ProductTime (112,'En')