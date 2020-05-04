CREATE procedure [dbo].[p_CreateDistribution_DDEX_valuation] @regId int  --, @ExchangeRate numeric(30,10)
 as
begin

--drop table #valuation
    create table #valuation(
	regIItemId int NOT NULL,
	amountMech numeric(30, 10) NOT NULL,
	amountPerf numeric(30, 10) NOT NULL,
	amountMechCur numeric(30, 10) NULL,
	amountPerfCur numeric(30, 10) NULL,
	aMP numeric(30, 10) NULL
  PRIMARY KEY (	regIItemId )
 )	
	
	declare     @regIItemId		int
	declare		@amountMech		numeric(30,10)
	declare		@amountPerf		numeric(30,10)
	declare		@amountMechCur	numeric(30,10)
	declare		@amountPerfCur	numeric(30,10)
	declare		@aMP			numeric(30,10)
	declare     @rowcount		int


	declare @ExchangeRate numeric(30,10) = (select ExchangeRate from registerCCID where regId = @regId);
		if (isnull(@ExchangeRate, 0) = 0) return 1;


declare @regRoyaltyReal money
declare @delta money
declare @regRoyalty money = (select round(amountCur * @ExchangeRate,2)  from RegisterCCID
		where regId = @regId
		)
		if ((select regRoyalty from register where regId = @regId)<> @regRoyalty) return 1;

--производим конвертацию

update RegisterCCIDMW
	set 
	amountMech = round(amountMechCur * @ExchangeRate,2),
	amountPerf = round(amountPerfCur * @ExchangeRate,2)
	where regId = @regId

select @regRoyaltyReal = (sum(amountMech)+sum(amountPerf)) from RegisterCCIDMW
  where regId = @regId

--разбаланс

	select @delta =@regRoyalty - @regRoyaltyReal

	if (@delta = 0) 
	GOTO	_RETURN 

--===========================================
	if (@delta >0)
--===========================================

	BEGIN
	set @rowcount = cast(@delta/0.01 as int) 
	set rowcount  @rowcount

    insert #valuation(
		regIItemId,
		amountMech,
		amountPerf,
		amountMechCur,
		amountPerfCur,
		aMP	
		)
  select  distinct regIItemId,amountMech+case when amountMechCur > amountPerfCur then 0.01 else 0 end ,
  amountPerf+case when amountMechCur > amountPerfCur then 0 else 0.01 end ,
  amountMechCur,amountPerfCur,(amountMechCur + amountPerfCur) aMP
  from RegisterCCIDMW
  where
		regId =@regId		and
--		regId =7431		and
		(amountMech+amountPerf)	 = 0	and
		(amountMechCur + amountPerfCur) <> 0 
		order by (amountMechCur + amountPerfCur) desc
	set rowcount 0		

update t1
set
		amountMech = t2.amountMech,
		amountPerf = t2.amountPerf
from  #valuation t2,RegisterCCIDMW t1
where
t1.regId = @regId	and
t1.regIItemId = t2.regIItemId

	END

_Cikl:

select @regRoyaltyReal = (sum(amountMech)+sum(amountPerf)) from RegisterCCIDMW
  where regId = @regId
select @delta =@regRoyalty - @regRoyaltyReal


	if (@delta = 0) 
		GOTO	_RETURN 



--===========================================
if (@delta <0)
--===========================================

	BEGIN

	set @rowcount = cast(@delta/0.01 as int) 
	set rowcount  @rowcount

truncate table #valuation

    insert #valuation(
		regIItemId,
		amountMech,
		amountPerf,
		amountMechCur,
		amountPerfCur,
		aMP	
		)
  select  distinct regIItemId,amountMech+case when amountMechCur > amountPerfCur then -0.01 else 0 end ,
  amountPerf+case when amountMechCur > amountPerfCur then 0 else 0.01 end ,
  amountMechCur,amountPerfCur,(amountMechCur + amountPerfCur) aMP
  from RegisterCCIDMW
  where
		regId =@regId		and
--		regId =7431		and
		(amountMechCur + amountPerfCur) <> 0 
		order by (amountMechCur + amountPerfCur) desc
	set rowcount 0		

update t1
set
		amountMech = t2.amountMech,
		amountPerf = t2.amountPerf
from  #valuation t2,RegisterCCIDMW t1
where
t1.regId = @regId	and
t1.regIItemId = t2.regIItemId

	END

	select @regRoyaltyReal = (sum(amountMech)+sum(amountPerf)) from RegisterCCIDMW
  where regId = @regId

  	select @delta =@regRoyalty - @regRoyaltyReal
	if (@delta =  0) 
			GOTO _RETURN

--===========================================
if (@delta >0)
--===========================================

BEGIN
truncate table #valuation

	set @rowcount = cast(@delta/0.01 as int) 
	set rowcount  @rowcount

    insert #valuation(
		regIItemId,
		amountMech,
		amountPerf,
		amountMechCur,
		amountPerfCur,
		aMP	
		)
  select  distinct regIItemId,amountMech+case when amountMechCur > amountPerfCur then 0.01 else 0 end ,
  amountPerf+case when amountMechCur > amountPerfCur then 0 else 0.01 end ,
  amountMechCur,amountPerfCur,(amountMechCur + amountPerfCur) aMP
  from RegisterCCIDMW
  where
		regId =@regId		and
--		regId =7431		and
		(amountMechCur + amountPerfCur) <> 0 
		order by (amountMechCur + amountPerfCur) desc
	set rowcount 0		

update t1
set
		amountMech = t2.amountMech,
		amountPerf = t2.amountPerf
from  #valuation t2,RegisterCCIDMW t1
where
t1.regId = @regId	and
t1.regIItemId = t2.regIItemId

	END

	goto _Cikl




_RETURN:

update t1 
set royalty = @regRoyalty 
from RegisterRatedList t1,vRegister t2
where
t1.periodId = t2.periodId	and
t2.regId= @regId

update t1 
set rgstatus = 3
from Register t1
where
t1.regId= @regId


return 0





end

