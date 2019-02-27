--Удаление объектов
---------------------------------------
/*
------------------Подготовка ключей для удаления
create table #TabObjDel (objid integer not null primary key) 
delete #TabObjDel
  insert into #TabObjDel (objid) --select distinct objid from test..Go_InCRight
  select objid from objectRight where isnull(loadId,0) <> 0 order by objid 
*/

CREATE PROCEDURE [dbo].[Intr_DelObject] 
as
begin
--Внесение процентов
SET NOCOUNT ON;
------
create table #TabObjDel (objid integer not null primary key) 
delete #TabObjDel
  insert into #TabObjDel (objid) --select distinct objid from test..Go_InCRight
  select objid from objectRight where isnull(loadId,0) <> 0 
  and objid=0 --!!!!!! от случайного запуска
  order by objid 
------

declare @RetCode integer 
set @RetCode = 0

    begin tran DEL
     BEGIN TRY

	 delete #TabId 
     create table #TabId (id1 integer, id2 integer)

     delete  CopyRight 
        from CopyRight t1 
           join #TabObjDel t2 on t1.objid = t2.objid 

     delete RelObjPerformer 
       output deleted.perid, deleted.objid into #TabId (id1, id2)
       from  RelObjPerformer  t1 
        join #TabObjDel t2 on t1.objid = t2.objid 

     delete Performer
       from  Performer t1 
         join #TabId t2 on t1.perId = t2.id1 
      where not exists ( select  1 from RelObjPerformer t3 where t3.perId = t2.id1 and t3.objid <> t2.id2 )

     delete Authors  
        from Authors t1 
          join #TabObjDel t2 on t1.objid = t2.objid 

     delete MediaTrack 
        from MediaTrack t1 
          join #TabObjDel t2 on t1.objid = t2.objid 

     delete objectRight 
        from objectRight t1 
          join #TabObjDel t2 on t1.objid = t2.objid 

	print 'Вилучено об''єкти права: ' + cast (@@rowcount as varchar(20))

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

return @Retcode
END

--exec Intr_DelObject 
--select * from test..GO_InCRight