CREATE  procedure [dbo].[Merge_Objects] @objid_save int,@objid_delete int
as

--
--слияние объектов
--

begin
declare @RetCode integer
--exec Merge_Objects 7252,5861

CREATE TABLE #Account(
	id					int identity,
	account_save		varchar(25) null,
	accId_save			int			null,
	objid_save			int,
	account_delete		varchar(25)	null,
	accId_delete		int			null,
	objId_delete		int,
primary key (id)
)
insert #Account(account_save,accId_save,objid_save,objId_delete)
select accNls,accId,@objid_save,@objid_delete
from Account
where objId = @objid_save


Merge #Account as t1
Using (select accNls,accId,@objid_save objid_save,@objid_delete objid_delete 
		from Account where objId = @objid_delete) t2
		on
		(substring(t1.account_save,1,5)) =(substring(t2.accNls,1,5))
		When MATCHED then
		update 
		set 
			account_delete = t2.accNls,
			objid_delete   = t2.objid_delete,
			objid_save     = @objid_save
		When not Matched then
		insert(account_save,accId_save,objid_save,account_delete,accId_delete,objId_delete)
		values(null,null,t2.objid_save,t2.accNls,t2.accId,t2.objId_delete);

update #Account
set account_save = rtrim(substring(account_delete,1,5) +CONVERT(varchar(20),objid_save))
where
account_save is null

if (select count(*) from #Account where 
	accId_save is null
	)<>0
--1begin

BEGIN
declare @objname varchar(100)
declare @account_save varchar(20)
select @objname=name from ObjectRight
where objId = @objid_save

declare cur cursor for   select  distinct  account_save from #Account
where accId_save is null

open cur
fetch cur into @account_save

    while @@fetch_status =0                                                   
--2begin
BEGIN 

	Exec  dbo.OpenAccNLS Null, @Objid_save,  '980', @account_save,@objname	
	fetch cur into @account_save

END
--2end

close cur   
deallocate cur 
END
--1END

update #Account
set
	accId_save = accId
from  #Account t1,Account t2
where
t1.account_save = t2.accNls	and
t1.objid_save = t2.objId and 
t1.accId_save is null


BEGIN --!!!!!!!!!

begin Transaction 
BEGIN TRY


if (select count(*) from #Account where 
	accId_delete <>0
	)<>0

--3begin

BEGIN --*****************************
declare  @accId_save int
declare  @accId_delete int
declare  @Account_delete varchar(20)



declare curs cursor for   select  	account_save,accId_save,account_delete,	accId_delete from #Account                                    
where
accId_delete is not NULL

fetch curs into  @Account_save,@accId_save,@Account_delete,@accId_delete

  while @@fetch_status =0                                                   
BEGIN --&&&&&&&&&&&&&&&&&&&&


	exec Merge_Objects_1 @accId_save ,@accId_delete
 
update PayTurn
set
accIdCredit = @accId_delete,
accCredit = @Account_delete
where accIdCredit = @accId_save

update PayTurn
set
accIdDebet = @accId_delete,
accDebet = @Account_delete
where accIdDebet = @accId_save


fetch curs into  @Account_save,@accId_save,@Account_delete,@accId_delete

END --&&&&&&&&&&&&&&&&&&&&

close curs   
deallocate curs 

--3END
END--*****************************

insert ObjectRight_deleted select * from ObjectRight
where objId =@objid_delete

insert CopyRight_deleted select * from CopyRight
where objId =@objid_delete

insert CopyRightHistory_deleted select t2.* from CopyRight t1,CopyRightHistory t2
where 
t1.objId =@objid_delete and
t2.parentId =t1.cRightId

insert Distribution_deleted select t2.* from CopyRight t1,Distribution t2
where 
t1.objId =@objid_delete and
t2.cRightId =t1.cRightId

delete Distribution from CopyRight t1,Distribution t2
where 
t1.objId =@objid_delete and
t2.cRightId =t1.cRightId


delete CopyRightHistory from CopyRight t1,CopyRightHistory t2
where 
t1.objId =@objid_delete and
t2.parentId =t1.cRightId


delete CopyRight
where objId =@objid_delete

delete Authors 
where objId =@objid_delete


update BrRegItem
set objId = @objid_save
where objId = @objid_delete
 
update RegisterItem
set objId = @objid_save
where objId = @objid_delete

update RegisterItem
set objId = @objid_save
where objId = @objid_delete

delete CopyRight
where objId = @objid_delete

update LicenseBigR
set objId = @objid_save
where objId = @objid_delete

update MusicalDesign
set objId = @objid_save
where objId = @objid_delete

delete MediaTrack
where objId = @objid_delete

update RelObjPerformer
set objId = @objid_save
where objId = @objid_delete


delete SeekObject
where objId = @objid_delete

update DistributionItem
set objId = @objid_save
where objId = @objid_delete

delete RelPopGenre
where objId = @objid_delete

delete PortalObjectRights
where objId = @objid_delete

delete ObjectRight
where objId =@objid_delete


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
        ,ERROR_MESSAGE() AS ErrorMessage;  set @Retcode = 1



END CATCH

END --!!!!!!!!!

return

END






