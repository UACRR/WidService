
CREATE function [dbo].[ft_tsk_3_OR_01_SEEK] ( @strSeek varchar(100) = NULL)
RETURNS  @RT Table

--declare @RT Table
(
objid integer not null primary key
)
as BEGIN 

declare @TmpObjectId table 
(objid integer not null primary key)

insert into @TmpObjectId (objid)
select distinct t1.objid
  from objectRight t1 
where isnull(@strSeek,'') = '' 

insert into @TmpObjectId (objid)
select distinct t1.objid
  from objectRight t1 
  --where t1.name like '%'+@strSeek+'%' and t1.objId > 0 and @strSeek <> ''
  --where UPPER(t1.name) COLLATE Ukrainian_CI_AI like '%'+UPPER(@strSeek)+'%' and t1.objId > 0 and @strSeek <> ''
  where t1.name COLLATE Ukrainian_CI_AI like '%'+@strSeek+'%' and t1.objId > 0 and @strSeek <> ''
UNION 
select distinct t1.objid
  from Authors t1 
  where t1.authorName COLLATE Ukrainian_CI_AI like '%'+@strSeek+'%' and @strSeek <> ''
   and t1.objId > 0
UNION 
select distinct t1.objid
  from SeekObject t1 
  where name COLLATE Ukrainian_CI_AI like '%'+@strSeek+'%' and @strSeek <> ''
   and t1.objId > 0

--Добавить поиск по театру для БП

 insert into @RT (objid) 
 select objid 
 from @TmpObjectId

RETURN 
END 

--select * from ft_tsk_3_OR_01_SEEK ('100', '') 
/*
select * from vtsk_3_OR_01 t1 
  join ft_tsk_3_OR_01_SEEK ('')  t2 on t1.objid = t2.objid 
where t1.statusUnDistrib = 1
*/
