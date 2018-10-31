

create view [dbo].[vTsk_3_ListObjectRight01] (objId,iswc,name,GenreName,duration,rate,author,performer,profit) as
with copyrights as 
(
select objId, sum(rate) as rate from CopyRight 
where getdate() between beginDate and endDate
group by objId
),
profit as
(
select objId, sum(krdOborot) as proffit from Account t1
join SaldoDay t2 on t2.accId = t1.accId and datepart(YEAR, getdate()) between DATEPART(YEAR, t2.dateBegin) and DATEPART(YEAR, t2.dateEnd )
where objid is not null
and balsCode = 30
group by objId

)
select 
t1.objId
, t2.iswc 
, t1.[name]
, t3.[name] as GenreName
, t2.duration 
, isnull(t4.rate, 0) as rate
, t1.author  
, t1.performer  
, isnull( t5.proffit, 0 ) as profit
from ObjectRight t1
left outer join MediaTrack t2 on t2.objId = t1.objId
left outer join GenreType t3 on t3.codeI = t1.genreType
left outer join copyrights t4 on t4.objId = t1.objId
left outer join profit t5 on t5.objId = t1.objId