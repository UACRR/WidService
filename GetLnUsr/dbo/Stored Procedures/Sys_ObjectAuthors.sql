
CREATE PROCEDURE [dbo].[Sys_ObjectAuthors] @objid integer=NULL
--Записать строку авторов в objectRight, MediaTrack
as
begin
SET NOCOUNT ON;
------
declare @RetCode integer, @cntA integer, @cntP integer
set @RetCode = 0
 
 If  @objid is not NULL 
 BEGIN 

 --Спецаиально через таблицу, чтобы можно было использовать для множества
 create table #TmpObj (objid integer not null primary key )
 insert into #TmpObj (objid) select @objid
 END
 ELSE 
 BEGIN 
   If not exists (select 1 from tempdb.sys.objects where name like '#tmpObj%' ) 
    BEGIN
     print 'Создай таблицу и положи ключи! -- create table #TmpObj (objid integer not null primary key )'
	 RETURN 
	END
 END

  print 'Go on !'



 begin tran TAUth
    BEGIN TRY

update MediaTrack set performers = NULL, composers = NULL, lyrics = NULL 
  from MediaTrack t1 
    join #TmpObj t2 on t1.objId = t2.objid 

update ObjectRight set performer = NULL, author = NULL
  from ObjectRight t1 
    join #TmpObj t2 on t1.objId = t2.objid 


;with TabStr as  
(select  t1.objId, STRING_AGG(CAST(rtrim(t2.authorName) as varchar(254)),', ') AS authorName
 from #TmpObj t1 
   join (select  distinct objid, AuthorName from Authors t2 where rolecode <> 8) t2 on t1.objid = t2.objid 
 group by t1.objId
 )
update objectRight set author = t2.authorName
  from objectRight t1 
    join TabStr t2 on t1.objid = t2.objid 

set @cntA = @@ROWCOUNT

--Заменить строку Lyric
;with TabStr as  
(select  t1.objId, STRING_AGG(CAST(rtrim(t2.authorName) as varchar(254)),', ') AS authorName
 from #TmpObj t1 
   join (select  distinct objid, AuthorName from Authors t2 where rolecode in (1,10)) t2 on t1.objid = t2.objid 
 group by t1.objId
 )
update MediaTrack set lyrics = t2.authorName
  from MediaTrack t1 
    join TabStr t2 on t1.objid = t2.objid 

--Заменить строку Composers
;with TabStr as  
(select  t1.objId, STRING_AGG(CAST(rtrim(t2.authorName) as varchar(254)),', ') AS authorName
 from #TmpObj t1 
   join (select  distinct objid, AuthorName from Authors t2 where rolecode in (2,10)) t2 on t1.objid = t2.objid 
 group by t1.objId
 )
update MediaTrack set composers = t2.authorName
  from MediaTrack t1 
     join TabStr t2 on t1.objid = t2.objid 

--Заменить Исполнителя
;with TabStr as  
(select  t1.objId, STRING_AGG(CAST(rtrim(t2.name) as varchar(254)),', ') AS authorName
 from #TmpObj t1 
   join (select  distinct objid, t2.name from SeekObject t2 where codeI = 2 ) t2 on t1.objid = t2.objid 
 group by t1.objId
 )
update MediaTrack set performers = t2.authorName
  from MediaTrack t1 
   join TabStr t2 on t1.objid = t2.objid 

set @cntP = @@ROWCOUNT

;with TabStr as  
(select  t1.objId, STRING_AGG(CAST(rtrim(t2.name) as varchar(254)),', ') AS authorName
 from #TmpObj t1 
   join (select  distinct objid, t2.name from SeekObject t2 where codeI = 2 ) t2 on t1.objid = t2.objid 
 group by t1.objId
 )
update ObjectRight set performer = t2.authorName
  from ObjectRight  t1 
    join TabStr t2 on t1.objid = t2.objid 


IF @@TRANCOUNT > 0 commit tran
END TRY


   BEGIN CATCH
     IF @@TRANCOUNT > 0 rollback tran

     SELECT   
        ERROR_NUMBER() AS ErrorNumber  
        ,ERROR_SEVERITY() AS ErrorSeverity  
        ,ERROR_STATE() AS ErrorState  
        ,ERROR_PROCEDURE() AS ErrorProcedure  
        ,ERROR_LINE() AS ErrorLine  
        ,ERROR_MESSAGE() AS ErrorMessage;  

        set @Retcode = 1
    return @Retcode
    END CATCH

PRINT 'Кол-во объектов: замена строки Авторов,  - '+convert(varchar(10), @cntA)+',  Исполнителей - '+convert(varchar(10), @cntP )
return @Retcode
END
