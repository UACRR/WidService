CREATE procedure [dbo].[p_CreateDistribution_DDEX] @regId int
as
BEGIN
/*
CREATE TABLE #Distribution(
	distId int IDENTITY(1,1) NOT NULL,
	regId int NULL,
	rmId int NULL,
	cRKindCode int NOT NULL,
	status int NOT NULL,
	distribDate date NOT NULL,
	amount money NOT NULL,
	partnerCommiss money NOT NULL,
	courtFee money NOT NULL,
	partnerId int NULL,
	isCourt bit NULL,
	regIdBr int NULL,
	distType int NULL,
	custId int NULL,
	cRightId int NULL,
  PRIMARY KEY CLUSTERED 
(	distId ASC)
) 
CREATE TABLE #DistributionItem(
	distId int NOT NULL,
	regId int NULL,
	regIItemId int NULL,
	amount numeric(20, 2) NULL,
	status int NULL,
	regIdBr int NULL,
	regItemIdBr int NULL,
	distItemId int IDENTITY(1,1) NOT NULL,
	objId int NULL,
 PRIMARY KEY (distItemId ASC,distId ASC)
) 
CREATE TABLE #RegisterCount(
	regCntId numeric(18, 0) IDENTITY(1,1) NOT NULL,
	regId int NULL,
	regIItemId int NULL,
	objId int NULL,
	custId int NULL,
	cRType int NULL,
	cRKindCode int NULL,
	rate decimal(10, 5) NULL,
	rateCommiss decimal(10, 5) NULL,
	cmCustId int NULL,
	regIdBr int NULL,
	regItemIdBr int NULL,
	prepaySum money NULL,
	distItemId int NULL,
	distId int NULL,
  PRIMARY KEY (	regCntId ASC)
) 
*/
--drop table #t
create table #t(
--regId		int,
id			int,
regIItemId	int,
objid		int,
custId		int,
cRType		int,
kindCode	int,
rateXXX		numeric(5,2),
cmCodeXXX	varchar(3),
amountXXX	numeric(20,2),
amount		numeric(20,2),
cmCustid	int
primary key (regIItemId,id)
 )



/*
delete #Distribution
delete #DistributionItem
delete  #RegisterCount
delete #t
*/

--declare @regId		int
--set @regId =7431
declare @custid int
declare @amountMech money
declare @amountPerf money
declare @kindCodePerf int
declare @kindCodeMech int
declare @rmId		int
declare @distIdMech	int
declare @distIdPerf	int
declare @retcode int 
declare @periodId int
 set @retcode = 0

set @custid=(select custid from vregister where regId= @regid)	

if (isnull(@custid,0) = 0) return

set @amountMech=(select sum(amountMech)  from  RegisterCCIDMW	
where	--regId =7431
		regId = @regid
)

set @periodId = ( select periodId  from vRegister where regid = @regId )

set @amountPerf=(select sum(amountPerf)  from  RegisterCCIDMW	
where	--regId =7431
		regId = @regid
)
set @kindCodePerf=(select t3.kindCode
 from vRegister t1 
  join vAgrLicenseType t2 on t1.licCode = t2.licCode 
  join RelSchemaKindCode t3 on t3.schemaCode = t2.schemaId 
  join CopyrightKind t4 on t3.kindCode = t4.codeI
  join CRKindGroup t5 on t5.codeI = t4.crGroupCode
where --t1.regId = 7431
	  		t1.regId = @regid
	  and t4.crGroupCode = 1
	  )	
set @kindCodeMech=(select t3.kindCode
 from vRegister t1 
  join vAgrLicenseType t2 on t1.licCode = t2.licCode 
  join RelSchemaKindCode t3 on t3.schemaCode = t2.schemaId 
  join CopyrightKind t4 on t3.kindCode = t4.codeI
  join CRKindGroup t5 on t5.codeI = t4.crGroupCode
where --t1.regId = 7431
	  		t1.regId = @regid
	  and t4.crGroupCode = 2
	  )	

set @rmId =(select rmId from Register where --regId = 7431
	  		regId = @regid
)


begin Transaction 
BEGIN TRY

insert Distribution(regId,rmId,cRKindCode,	status,	distribDate,amount,partnerCommiss,courtFee, distType,custId
)
select @regId,@rmId,@kindCodeMech,	1,	getdate(),@amountMech,0.,0.,5,@custid

insert Distribution(regId,rmId,cRKindCode,	status,	distribDate,amount,partnerCommiss,courtFee, distType,custId
)
select @regId,@rmId,@kindCodePerf,	1,	getdate(),@amountPerf,0.,0.,5,@custid

set @distIdMech = (select distId from Distribution where regId = @regId and cRKindCode = @kindCodeMech)
set @distIdPerf = (select distId from Distribution where regId = @regId and cRKindCode = @kindCodePerf)

insert DistributionItem(distId,regId,regIItemId,amount,status,	objId )
select @distIdMech,@regId,t1.regIItemId,amountMech,0,t2.objId  from RegisterCCIDMW  t1,RegisterItem t2
where
amountMech <>0 and
t1.regId = @regId and
t2.regId = t1.regId and
t2.regIItemId =t1. regIItemId


insert DistributionItem(distId,regId,regIItemId,amount,status,	objId )
select @distIdPerf,@regId,t1.regIItemId,amountPerf,0,t2.objId  from RegisterCCIDMW  t1,RegisterItem t2
where
amountPerf <>0 and
t1.regId = @regId and
t2.regId = t1.regId and
t2.regIItemId =t1. regIItemId


insert #t(id,regIItemId,objid,custId,cRType,kindCode,rateXXX,cmCodeXXX,amountXXX,amount)  
select  row_number() over(partition by t1.regId, t1.regIItemId order by t1.regId, t1.regIItemId asc,t2.rateMec desc ) id
	,t1.regIItemId, t1.objId, t2.custId, 1 as cRType, t5.kindCode, isnull(t2.rateMec, 100) rateXXX
	, t2.cmCodeMec
	,r1.amountMech,0
from RegisterItem t1 left join RegisterCCIDMW r1
	on t1.regId =r1.regId and t1.regIItemId = r1.regIItemId
    left outer join RegisterCCIDAuthor  t2 on 
	t1.regId = t2.regId		and
	t1.regIItemId= t2.regIItemId
	join vRegister t3 on t1.regId =t3.regId 
  join vAgrLicenseType t4 on t3.licCode = t4.licCode 
  join RelSchemaKindCode t5 on t5.schemaCode = t4.schemaId 
  join CopyrightKind t6 on t5.kindCode = t6.codeI
  join CRKindGroup t7 on t7.codeI = t6.crGroupCode
where 
--t1.regId = 7431 and
t1.regId = @regId and
t6.crGroupCode = 2
and amountMech<>0
and  isnull(t2.rateMEC, 100)<>0
order by t1.regIItemId asc,t2.rateMec desc

		exec p_CreateDistribution_DDEX_balans @regid

insert  RegisterCount(regId,regIItemId,objId,custId,cRType,cRKindCode,rate,cmCustId,prepaySum,	distItemId,	distId)
select @regId ,regIItemId,objId,custId,cRType,KindCode,rateXXX,cmCustid,amount,  null,@distIdMech from #t

	truncate table #t


insert #t(id,regIItemId,objid,custId,cRType,kindCode,rateXXX,cmCodeXXX,amountXXX,amount)  
select  row_number() over(partition by t1.regId, t1.regIItemId order by t1.regId, t1.regIItemId asc,t2.ratePer desc  ) id
	,t1.regIItemId, t1.objId, t2.custId, 1 as cRType, t5.kindCode, isnull(t2.ratePer, 100) rateXXX
	, t2.cmCodePer
	,r1.amountPerf,0
from RegisterItem t1 left join RegisterCCIDMW r1
	on t1.regId =r1.regId and t1.regIItemId = r1.regIItemId
    left outer join RegisterCCIDAuthor  t2 on 
	t1.regId = t2.regId		and
	t1.regIItemId= t2.regIItemId
	join vRegister t3 on t1.regId =t3.regId 
  join vAgrLicenseType t4 on t3.licCode = t4.licCode 
  join RelSchemaKindCode t5 on t5.schemaCode = t4.schemaId 
  join CopyrightKind t6 on t5.kindCode = t6.codeI
  join CRKindGroup t7 on t7.codeI = t6.crGroupCode
where 
--t1.regId = 7431 and
t1.regId = @regId and
t6.crGroupCode = 1
and amountPerf<>0
and  isnull(t2.ratePer, 100)<>0
order by t1.regIItemId asc,t2.ratePer desc
	exec p_CreateDistribution_DDEX_balans @regid
insert  RegisterCount(regId,regIItemId,objId,custId,cRType,cRKindCode,rate,cmCustId,prepaySum,	distItemId,	distId)
select @regId ,regIItemId,objId,custId,cRType,KindCode,rateXXX,cmCustid,amount,null,@distIdPerf from #t


update t1
set distItemId = t2.distItemId
from RegisterCount t1,DistributionItem t2
where
t1.distId = @distIdMech	and
t1.distId = t2.distId and
t1.regId  = t2.regId  and
t1.regIItemId =t2.regIItemId

update t1
set distItemId = t2.distItemId
from RegisterCount t1,DistributionItem t2
where
t1.distId = @distIdPerf	and
t1.distId = t2.distId and
t1.regId  = t2.regId  and
t1.regIItemId =t2.regIItemId
/*
update paidPeriod 
set 
distribAmount = distribAmount +  @amountMech + @amountPerf , 
undistribamount = amount - @amountMech - @amountPerf
  where periodId = @periodId
*/
update paidPeriod 
set 
distribAmount = distribAmount +  @amountMech + @amountPerf , 
undistribamount = undistribamount - @amountMech - @amountPerf
  where periodId = @periodId


  update register
set rgStatus = 13
where regId = @regId

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
set @retcode = 1
END CATCH

return @retcode

END
