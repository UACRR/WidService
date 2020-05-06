CREATE PROCEDURE dbo.Intr_IO_DELETE 
as
begin
--Удаление объектов права, которые были загружены из файла 
--Имя файла должен быть обязательным и клиент должны быть удалены
SET NOCOUNT ON;
------
create table #TabObjDel (objid integer not null primary key) 
create table #TabCustDel (custId integer not null primary key) 


delete #TabCustDel
  insert into #TabCustDel (custId) 
  select distinct t1.custId 
    from test..ImportObject t1
    where t1.workFlag = 9 
	and not exists (select  1 from account t2 where t2.custId = t1.custId)  --еще не было оплат

delete #TabObjDel
  insert into #TabObjDel (objid) 
  select distinct t1.objid 
    from test..ImportObject t1
    where t1.workFlag = 9 
	and not exists (select  1 from test..ImportObject t2 where t2.objid = t1.objid and isnull(t2.custid,0) <> 0 )  --нет привязки к клиенту
	and not exists (select  1 from account t2 where t2.objid = t1.objid)  --еще не было оплат

-----------

  declare @RetCode integer = 0
  create table #TabId (id1 integer, id2 integer)

    begin tran DEL
     BEGIN TRY

    --Удаление клиента
    delete  CopyRight 
       from CopyRight t1 
       join #TabCustDel t2 on t1.custId = t2.custid 

    delete TermsOfService
        from TermsOfService t1 
       join #TabObjDel t2 on t1.custId = t2.custId 

    delete AnketaExternal
       from AnketaExternal t1 
       join #TabCustDel t2 on t1.custId = t2.custid 

    delete AgreementAddRH
       from AgreementAddRH t1 
       join #TabCustDel t2 on t1.custId = t2.custid 

    delete AgreementMaster
       from AgreementMaster t1 
       join #TabCustDel t2 on t1.custId = t2.custid 

    delete AnketaPerson
       from AnketaPerson t1 
       join #TabCustDel t2 on t1.custId = t2.custid 

    delete Person
       from Person t1 
       join #TabCustDel t2 on t1.custId = t2.custid 

    delete RightHolder
       from RightHolder t1 
       join #TabCustDel t2 on t1.custId = t2.custid 

    delete customer
       from customer t1 
       join #TabCustDel t2 on t1.custId = t2.custid 

    update  ImportObject set custId = NULL 
       from ImportObject t1 
       join #TabCustDel t2 on t1.custId = t2.custid 
      
 -------------Объекты-----------------------------
    delete  CopyRight 
       from CopyRight t1 
       join #TabObjDel t2 on t1.objid = t2.objid 

     delete #TabId 
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

   -----Обнуляю ключи 
	update test..ImportObject set objid = NULL, perId = NULL, workFlag = 99
	  from test..ImportObject t1 
	     join #TabObjDel t2 on t2.objid = t1.objid

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

--exec dbo.Intr_IO_DELETE

