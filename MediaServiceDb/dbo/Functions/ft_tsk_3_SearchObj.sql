
-- *******************************************************
CREATE function [dbo].[ft_tsk_3_SearchObj]( @name varchar(100), @authors varchar(255), @performer varchar(255) )
RETURNS Table
Return 
(
with search_object as 
(
-- declare  @name varchar(100), @authors varchar(255), @performer varchar(255) 
select distinct * from ObjectRight 
where left( name, 1 ) =  left( @name , 1 ) 
and [dbo].[Ft_tsk_3_Compare]( name, @name, 0.01 ) >= 0.3
union 
select distinct t1.* from ObjectRight t1
join SeekObject t2 on t2.objId = t1.objId and t2.codeI = 1 and @name = t2.name
where 
SUBSTRING( t1.name , 1, 1 ) = SUBSTRING( @name, 1, 1 )
and [dbo].[Ft_tsk_3_Compare]( t1.name, @name, 0.01 ) >= 0.3


)
select t1.objid, t1.innerCode, t1.name, t1.performer, t1.author, t2.name as genre, t3.duration from search_object t1
join GenreType t2 on t2.codeI = t1.genreType
left outer join MediaTrack t3 on t3.objId = t1.objId

)