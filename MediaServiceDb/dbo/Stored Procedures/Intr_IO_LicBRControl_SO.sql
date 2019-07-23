
CREATE PROCEDURE Intr_IO_LicBRControl_SO
as
begin
-----Загрузка лицензий по большим правам. Контроль.

SET NOCOUNT ON;
declare @RetCode integer, @tprt varchar(100)
set @RetCode = 0

--Идентификатор клиента -  беру из таблицы  loads..ImportClientTheater (theaterId)
----CUSTID -------------------------------------------------------------
 declare @cntV1 integer, @cntV2 integer 

 BEGIN TRAN IO_BRLic
 BEGIN TRY

 update LOADS..ImportSpectacle set errFlag = NULL, errComment = NULL where workFlag = 1
 update LOADS..ImportSpectacleMusic set errFlag = NULL, errComment = NULL where workFlag = 1


 update LOADS..ImportSpectacle 
        set clCustid = t3.custid 
    from LOADS..ImportSpectacle t1 
      join loads..ImportClientTheater t2 on t2.id = t1.theaterId
      join vCustomer t3 on t3.custId = t2.custId 
     where isnull(t1.clCustid,0) = 0 
       and t1.workFlag = 1

  set @cntV1 = (select count(distinct t1.theaterName) from LOADS..ImportSpectacle t1 where clcustId is null and t1.workFlag = 1)
  set @cntV2 = (select count(distinct t1.theaterName) from LOADS..ImportSpectacle t1 where isnull(clcustId,0) <> 0  and t1.workFlag = 1)

  update LOADS..ImportSpectacle 
    set errFlag = 1, errComment = isnull(errComment,'') + ' Театр! ' 
	where isnull(clCustId,0) = 0 
	     and workFlag = 1
  Print 'Не ідентифіковано театрів - '+cast(@cntV1 as varchar(10)) + '. Ідентифіковано - '+cast(@cntV2 as varchar(10))

 -- Идентификация объектов права  --ObjId  
 update LOADS..ImportSpectacle set objid = t3.objid, rhCustId = t2.CustId, cRightId = t2.cRightId 
    from LOADS..ImportSpectacle t1 
      join loads..ImportObject t2 on t2.authorInnerCode = t1.authorInnerCode and t2.objInnerCode = t1.spectCode  
      join CopyRight t3 on t3.custId = t2.custId 
    where isnull(t1.spectCode,0) = 0 
      and t1.workFlag = 1

--  set @cntV1 = (select count(distinct spectCode) from LOADS..ImportSpectacle t1 where cRightId is null and t1.workFlag = 1)
--  set @cntV2 = (select count(distinct spectCode) from LOADS..ImportSpectacle t1 where isnull(cRightId,0) <> 0  and t1.workFlag = 1)
  set @cntV1 = (select count(*) from LOADS..ImportSpectacle t1 where cRightId is null and t1.workFlag = 1)
  set @cntV2 = (select count(*) from LOADS..ImportSpectacle t1 where isnull(cRightId,0) <> 0  and t1.workFlag = 1)
  update LOADS..ImportSpectacle 
    set errFlag = 1, errComment = isnull(errComment,'') + ' Право! '  
      where isnull(cRightId,0) = 0 
	     and workFlag = 1
  Print 'Не ідентифіковано прав - '+cast(@cntV1 as varchar(10)) + '. Ідентифіковано - '+cast(@cntV2 as varchar(10))


--  update LOADS..ImportSpectacleMusic set errFlag = 1, errComment ='Ідентифікатор!'
--     where workFlag = 1 and (isnull(objidBr,0) = 0 or isnull(clCustId,0) = 0 or isnull(objId,0) = 0 )

--Названия для муз.сопровождения
  update  LOADS..ImportSpectacleMusic  
    set objName	 = t2.name, 
        nameMusician = t3.composers, 
	nameSinger = t3.performers,
        authorText = t3.lyrics, 
        duration = t3.duration 
     from LOADS..ImportSpectacleMusic   t1 
       join objectRight t2 on t1.objid = t2.objid 
       join mediaTrack t3 on t3.objid = t2.objid 


  update LOADS..ImportSpectacle set errFlag = 1, errComment ='Ідентифікатор!'
     where workFlag = 1 and (isnull(objid,0) = 0 or isnull(clcustId,0) = 0 or isnull(cRightId,0) = 0 ) 

  update LOADS..ImportSpectacle set errFlag = 1, errComment ='Ідентифікатор Муз.Супроводу!'
     from LOADS..ImportSpectacle t1 
       join LOADS..ImportSpectacleMusic t2 on t1.theaterId = t2.theaterId and t1.spectCode = t2.spectCode 
          and (isnull(t2.objidBr,0) = 0 or isnull(t2.clCustId,0) = 0 or isnull(t2.objId,0) = 0 )
     where t1.workFlag = 1 
     

 /*
 -- Идентификация правообладателей 
 update LOADS..ImportSpectacle set rhCustId = t2.custId
    from LOADS..ImportSpectacle t1 
      join rightHolder t2 on t2.InnerCode = t1.spectCode 
    where isnull(t1.rhCustId,0) = 0 
      and t1.workFlag = 1

  set @cntV1 = (select count(distinct spectCode) from LOADS..ImportSpectacle t1 where rhCustId is null and t1.workFlag = 1)
  set @cntV2 = (select count(distinct spectCode) from LOADS..ImportSpectacle t1 where isnull(rhCustId,0) <> 0  and t1.workFlag = 1)
  update LOADS..ImportSpectacle set errFlag = 1, errComment = isnull(errComment,'') + ' Автор! '  
     where isnull(rhCustId,0) = 0
	  and workFlag = 1
  Print 'Не ідентифіковано правовласників - '+cast(@cntV1 as varchar(10)) + '. Ідентифіковано - '+cast(@cntV2 as varchar(10))


 -- Идентификация Прав 
 update LOADS..ImportSpectacle set cRightId = t2.cRightId
    from LOADS..ImportSpectacle t1 
      join CopyRight t2 on t2.objid = t1.objid and t2.custId = t1.rhCustId and t2.roleCode = t1.roleCode
    where isnull(t1.rhCustId,0) = 0 
      and t1.workFlag = 1

  set @cntV1 = (select count(distinct spectCode) from LOADS..ImportSpectacle t1 where rhCustId is null and t1.workFlag = 1)
  set @cntV2 = (select count(distinct spectCode) from LOADS..ImportSpectacle t1 where isnull(rhCustId,0) <> 0  and t1.workFlag = 1)
  update LOADS..ImportSpectacle set errFlag = 1, errComment =  isnull(errComment,'') + ' Право! '  
     where isnull(cRightId,0) = 0
	 and workFlag = 1
  Print 'Не ідентифіковано прав - '+cast(@cntV1 as varchar(10)) + '. Ідентифіковано - '+cast(@cntV2 as varchar(10) )
  */
-------------------------------------
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

-------------------------------------------------------------
/*
--update LOADS..ImportSpectacle set workFlag = 1
--EXEC Intr_IO_LicBRControl_SO

---Проверки
select * from LOADS..ImportSpectacle where errFlag = 1
select * from loads..ImportObject

*/