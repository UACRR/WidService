
/*
create table #TmpSOC 
(SOC varchar(3) not null primary key )
insert into #TmpSOC  select '888'
*/

CREATE  PROCEDURE [dbo].[pTsk10_LOADSOC]  
as
begin

---Вызываемая процедура загрузки из WID_IPI новых обществ

SET NOCOUNT ON;

declare @retCode Integer = 0

create table #TmpId 
( ID integer not null primary key, 
  loadId_I integer )

create table #TmpNewSOC
(SOC varchar(4) not null primary key, 
 custId integer NULL)

insert into #TmpNewSOC (SOC)
 select  distinct SOC 
   from #TmpSOC  

delete #TmpNewSOC 
  from #TmpNewSOC t1 
  join Community t2 on t1.SOC = t2.interCode
-------------------------------------
delete #TmpId
--ОКУ - Открываю новые

 BEGIN TRAN TranfOky
 BEGIN TRY

 insert into Customer (custType, ankVersion, status, loadId)
  output inserted.custId, inserted.loadId into #TmpId (Id, loadId_I)
  select 3, 1, 0,  convert(integer, SOC)
    from #TmpNewSOC 

 update #TmpNewSOC set custId = t2.Id 
   from #TmpNewSOC t1 
    join #TmpId t2 on t2.loadId_I  = cast(t1.SOC as integer)
 
 insert into Company (custId, version )
   select custId, 1
    from #TmpNewSOC t1   
     where isnull(custid, 0) <> 0 

 insert into AnketaCompany ( custId, version, name, shortName, status, modifyDate, modifyLogin )
   select t1.custId, 1, t1.SOC, t1.SOC, 0, getdate(), 'TRANSFER'
    from #TmpNewSOC t1   
     where isnull(custid, 0) <> 0 

 insert into Community (custId, interCode, innerCode) 
  select t1.custId, SOC, cast(custId as varchar(10))
    from #TmpNewSOC t1   
     where isnull(custid, 0) <> 0 

 insert into AgreementMaster (custId, agrStatus, modifyDate, modifyLogin, agrType, version)
  select t1.custId, 0, getdate(), 'TRANSFER', 4, 1
    from #TmpNewSOC t1   
     where isnull(custid, 0) <> 0 
  
 insert into AgreementAddCommunity (agrId, version, custId,  agrNumber, agrDate, ankVersion, agrStatus, modifyDate, modifyLogin)
  select t2.agrId, t2.version, t1.custId, 'Tech', cast (getdate() as date), 1, 0, getdate(), 'TRANSFER'
    from #TmpNewSOC t1   
    join AgreementMaster t2 on t2.custid = t1.custId
     where isnull(t1.custid, 0) <> 0 
         and not exists (Select  1 from AgreementAddCommunity t3 where t3.agrId = t2.agrId and t3.version = t2.version)

--------------------------------------------------------------------
--Записываю в журнал событий
insert into SystemMessage (modifydate, nameMain, name, keyObj, text, sysname, custId)
 select  getdate(), 'Transfer', 'Створено технічний договір з ОКУ', cast(t1.SOC as integer), 'Внесення техн. дог. з ОКУ  '+ t1.SOC, 'pTsk10_TransferSOC', t1.custId 
  from #TmpNewSOC t1 
  where isnull(custId,0) <> 0 

print 'Нових технічних договорів з ОКУ - ' + convert(char(10), @@ROWCOUNT)

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
 --return @Retcode
 END CATCH

return @Retcode

END

-----------------------------------------------
--exec pTsk10_LOADSOC 

--exec [dbo].[DelFullCustomer] 941334
--select * from SystemMessage
