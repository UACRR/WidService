

create function [dbo].[ft_tsk_3_SearchObj]( @name varchar(100), @authors varchar(255), @performer varchar(255) )
RETURNS Table
Return 
(
with search_object as 
(
-- declare  @name varchar(100), @authors varchar(255), @performer varchar(255) 
select distinct * from ObjectRight 
where name like @name + '%'
union 
select distinct t1.* from ObjectRight t1
join SeekObject t2 on t2.objId = t1.objId and t2.codeI = 1 and @name = t2.name
where 
SUBSTRING( t1.name , 1, 1 ) = SUBSTRING( @name, 1, 1 )
and [Ft_tsk_3_Compare]( t1.name, @name, 0.75 ) = 1
union 
select t1.* from ObjectRight t1
join SeekObject t2 on t2.objId = t1.objId and t2.codeI = 1 and @name = t2.name
union 
select distinct t1.* from ObjectRight t1
join SeekObject t2 on t2.objId = t1.objId and t2.codeI = 2 and @performer = t2.name
where 
SUBSTRING( t1.name , 1, 1 ) = SUBSTRING( @name, 1, 1 )
and [Ft_tsk_3_Compare]( t1.name, @name, 0.75 ) = 1
union 
select distinct t1.* from ObjectRight t1
join Authors t2 on t2.objId = t1.objId and @authors = t2.authorName
where 
SUBSTRING( t1.name , 1, 1 ) = SUBSTRING( @name, 1, 1 )
and [Ft_tsk_3_Compare]( t1.name, @name, 0.75 ) = 1

)
select t1.objid, t1.name, t1.performer, t1.author, t2.name as genre, t3.duration from search_object t1
join GenreType t2 on t2.codeI = t1.genreType
left outer join MediaTrack t3 on t3.objId = t1.objId

)