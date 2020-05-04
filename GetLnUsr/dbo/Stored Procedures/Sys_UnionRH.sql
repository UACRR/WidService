
CREATE PROCEDURE [dbo].[Sys_UnionRH] @custIdForDel integer, @custIdMain integer
--Объединение анкет правообладателей
as
begin
SET NOCOUNT ON;
------
declare @RetCode integer 
set @RetCode = 0

    begin tran DEL
     BEGIN TRY


 --Запоминаю объекты, чтобы потом пересчитать
 create table #TmpObj (objid integer not null primary key )

 insert into #TmpObj (objid) 
 select  distinct objid 
  from Authors
  where custId in (@custIdForDel, @custIdMain )

   update copyright  set custid = @custIdMain where custid = @custIdForDel
   print 'Замінено: copyright - ' + cast (@@rowcount as varchar(20))
   update Authors  set custid = @custIdMain where custid = @custIdForDel
   print 'Замінено: Authors - ' + cast (@@rowcount as varchar(20))

--Заменить строку авторов 
;with TabStr as  
(select  t1.objId, STRING_AGG(CAST(rtrim(t2.authorName) as varchar(254)),', ') AS authorName
 from #TmpObj t1 
   join (select  distinct objid, AuthorName from Authors t2 where rolecode <> 8) t2 on t1.objid = t2.objid 
 group by t1.objId
 )
update objectRight set author = t2.authorName
  from objectRight t1 
    join TabStr t2 on t1.objid = t2.objid 

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

exec DelFullCustomer @custIdForDel

return @Retcode
END

--exec Sys_UnionRH 1, 2

