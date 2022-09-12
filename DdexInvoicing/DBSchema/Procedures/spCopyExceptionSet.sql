USE [DDEX]
GO

/****** Object:  StoredProcedure [dbo].[spCopyExceptionSet]    Script Date: 12.09.2022 13:04:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER procedure [dbo].[spCopyExceptionSet] @setCode int
as
begin
/*
declare @setCode int = 6;
--declare @setCodeNew int = 2;

delete t1
from ExceptionAdd t1
	join ExceptionMember t2 on t1.excId = t2.id
	join ExceptionSet t3 on t2.setCode = t3.setCode
where t3.setCode = @setCode

delete t2
from ExceptionMember t2
	join ExceptionSet t3 on t2.setCode = t3.setCode
where t3.setCode = @setCode

delete t3
from ExceptionSet t3
where t3.setCode = @setCode
*/

--declare @setCode int = 1;
declare @setCodeNew int;

insert ExceptionSet (
	    setName
      , setComment
      , setStatus
      , isUsed
      , dateCreated
      , dateUpdated)
select setName + ' (копія)'
      , setComment
      , 0
      , 0
      , GetDate()
      , GetDate()
from ExceptionSet
where setCode = @setCode

set @setCodeNew = scope_identity();

drop table if exists  #ExceptionMember  
create table  #ExceptionMember (NewId int primary key, OldId int)  

merge into ExceptionMember
using
(
    select  
	    id
      , dateBegin
      , dateEnd
      , setCode
      , rHolderType
      , memberName
      , nameForSeek
      , interCode
      , excType
      , custId
      , comment
      , IPInr
      , GetDate() dateCreated
	from ExceptionMember
	where setCode = @setCode
) as Src
on 1 = 0
when not matched by target then
insert (
	    dateBegin
      , dateEnd
      , setCode
      , rHolderType
      , memberName
      , nameForSeek
      , interCode
      , excType
      , custId
      , comment
      , IPInr
      , dateCreated)
values (
        Src.dateBegin
      , Src.dateEnd
      , @setCodeNew
      , Src.rHolderType
      , Src.memberName
      , Src.nameForSeek
      , Src.interCode
      , Src.excType
      , Src.custId
      , Src.comment
      , Src.IPInr
      , Src.dateCreated)
output 
    Src.id as OldId
    , inserted.id AS NewId
into #ExceptionMember(OldId, NewId)
;

insert ExceptionAdd (
	    excId
      , custId
      , interCode
      , name
      , nameForSeek
      , IPInr
      , dateCreated)
select  t2.NewId
      , t3.custId
      , t3.interCode
      , t3.name
      , t3.nameForSeek
      , t3.IPInr
      , GetDate()
from ExceptionMember t1
	join #ExceptionMember t2 on t2.OldId = t1.Id
	join ExceptionAdd t3 on t1.id = t3.excId
where t1.setCode = @setCode

drop table if exists  #ExceptionMember  

end
GO

