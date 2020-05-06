
CREATE PROCEDURE [dbo].[DelObjectRightTable]  
AS
BEGIN 
SET NOCOUNT ON;

declare @RetCode integer = 0, @Msg varchar(200) = '', @cnt integer = 0, @ErrMsg varchar(200) = ''

create table #TmpObj 
(objid integer not null primary key)

--Отмечаю те, по которым были платежи
select  @cnt = count( distinct t1.objId) 
  from DeleteObjectRight t1
   join Account t2 on t2.objid = t1.objid 
   where isnull(t1.status,0) = 0 

set @Msg = 'Не видалено - '+ ltrim(convert(varchar(10), @cnt))+'.'

update DeleteObjectRight set status = 1  
   from DeleteObjectRight t1 
   join Account t2 on t2.objid = t1.objid 
   where isnull(t1.status,0) = 0 

insert into #TmpObj  (objid)
select objid from DeleteObjectRight 
  where isnull(status,0) = 0

select @cnt = count(*) from #TmpObj
set @Msg = isnull(@Msg,'') + 'Видалено - '+ ltrim(convert(varchar(10), @cnt))+'.'

begin Transaction DelObj 
BEGIN TRY

delete MediaFile 
  from  MediaFile  t0 
   join MediaTrack t1 on (t0.objid = t1.objid) 
   join #TmpObj  t2 on t2.objid = t0.objid 

delete MediaTrack  
 from MediaTrack  t1 
     join #TmpObj  t2 on t2.objid = t1.objid 
 
delete Authors
 from Authors t1 
     join #TmpObj  t2 on t2.objid = t1.objid 

delete SeekObject
 from SeekObject t1 
     join #TmpObj  t2 on t2.objid = t1.objid 

delete RelPopGenre
 from RelPopGenre t1 
     join #TmpObj  t2 on t2.objid = t1.objid 

delete MusicalDesign
 from MusicalDesign t1 
     join #TmpObj  t2 on t2.objid = t1.objid 

delete CopyRightHistory 
   from CopyRightHistory t1, 
        CopyRight   t2,  
        #TmpObj  t3 
  where (t1.parentId = t2.cRightId or t1.childId = t2.cRightId) 
      and t3.objid = t2.objid 
  
--Каталоги
update PubCatalogItem set cRightId = NULL, objId = NULL  
  from PubCatalogItem t1 
     join #TmpObj  t2 on t2.objid = t1.objid 

update RHCatalogItem set objId = NULL, cRightId = NULL
   from RHCatalogItem t1
     join #TmpObj  t2 on t2.objid = t1.objid 

delete CopyRight   
 from CopyRight   t1 
     join #TmpObj  t2 on t2.objid = t1.objid  
 
delete from RelObjPerformer 
  from RelObjPerformer t1 
     join #TmpObj  t2 on t2.objid = t1.objid  

delete from ObjectRight 
  from ObjectRight t1 
     join #TmpObj  t2 on t2.objid = t1.objid  

--Проставляю статус удаленного
update DeleteObjectRight set status = 9 
  from DeleteObjectRight t1 
    join #TmpObj t2 on t2.objid = t1.objId

IF (@@TRANCOUNT > 0 and @RetCode = 0 ) commit tran
END TRY


BEGIN CATCH
  IF (@@TRANCOUNT > 0 or @RetCode <> 0 ) rollback tran
    DECLARE @ErrorMessage NVARCHAR(4000);
    DECLARE @ErrorSeverity INT;
    DECLARE @ErrorState INT;
    SELECT @ErrorMessage = @ErrMsg + ' '+ERROR_MESSAGE(),
           @ErrorSeverity = ERROR_SEVERITY(),
           @ErrorState = ERROR_STATE();

    -- Use RAISERROR inside the CATCH block to return 
    -- error information about the original error that 
    -- caused execution to jump to the CATCH block.
    RAISERROR (@ErrorMessage, -- Message text.
               @ErrorSeverity, -- Severity.
               @ErrorState -- State.
               );
 set @Retcode = 1

END CATCH

print @Msg

Return @Retcode
END

--exec  DelObjectRightTable
--select t2.accId, * from ObjectRight t1 left join account t2 on  t2.objid = t1.objid  order by name
