--ALTER procedure [%QUALIFIER%]%PROC%  as
CREATE procedure [dbo].[p_CreateDistribution_L]  as
begin
-- Period
declare @workedPeriod table ( 
periodid int not null, 
periodAmount decimal not null, 
withSum	bit not null,
flagFirst bit not null
primary key(periodid) );

-- Розрахункові листи
declare @workedRmid table ( 
periodid int not null, 
rmid int not null, 
ticks int, 
regAmount decimal not null,
primary key(rmid) );

-- Балансування
declare @balansRmid table
(
parentId int  null,
id int not null ,
amount money not null 
)

-- Таблиця даних для розрахунку долі на об'єкт
declare @regTicks table ( 
rmId int not null,
regid int not null primary key
, ticks		bigint
, sumTicks	bigint
, cntRows	int 
, sumCntRows	int 
, regSum	money
, runRegSum money
, algorithmId	int
 );
-- Розподіл
declare @distrib table ( 
distid int not null, 
rmId int not null, 
regid int not null, 
amount money not null
);

declare @updateRate table( 
regId int not null
, regIItemId int
, objid int not null
, custId int null
, cRType int not null
, kindCode int not null
, rate decimal (10,5) 
, rateCommiss decimal (10,5) 
, cmCustId int
);

-- exec p_CreateDistribution

set nocount on
begin tran
BEGIN TRY
    
    -- Записати музичне оформлення
    exec dbo.p_MusDesignToRegItems;

    -- Отримати звіти для яких є гроші
	-- Відібрати періоди з грощима

	insert into @workedPeriod(periodid, periodAmount, withSum, flagFirst )
	select pp.periodId, 
		min( pp.undistribamount ),
		min( case when isnull(t1.royalty,0) = 0 then 0 else 1 end ),
		min( cast( isnull( pp.fagFirst, 0) as int ))    
	from 
    PaidPeriod pp 
    join RegisterRatedList t1 on t1.periodId = pp.periodId
    join Register t2 on t2.rmId = t1.rmId
	join RegisterItem t3 on t3.regId = t2.regid
    where 
	-- t2.rmId = 125 and  -- отладка 125 РЛ
	pp.status between 2 and 7 and 
	pp.status != 4 and -- всі окрім судової роботи
	pp.undistribamount > 0
    group by pp.periodId
    having count(*) = sum( case when t2.rgStatus >= 3 then 1 else 0 end ) -- Статус  
			and sum( case when t3.objId is null then 1 else 0 end ) = 0 -- всі об'єкти прив'язані
		    and min( case when t1.royalty is null then 0 else 1 end ) = max (case when t1.royalty is null then 0 else 1 end); -- Однотипні суми;


	
	--print '@workedPeriod';
	--select * from @workedPeriod;

	-- Розраховуємо суму тривалості та  кількsсть використання треків
	with regSum as (
	select t2.rmId
		, t2.regId
		, sum(t3.ticks) as ticks
		, count(*) as cntRows
		, min(isnull( t2.authAmount, 0 ) + isnull(t2.musicAmount,0)) as regSum
		, min(isnull(t2.algorithmId,2)) as algorithmId 
	from 
	register t2 
	join RegisterItem t3 on t3.regId = t2.regId
	join RegisterRatedList t4 on t4.rmId = t2.rmId
	join @workedPeriod t5 on t5.periodid = t4.periodId
	-- where t2.rmid = 127
	group by t2.rmId, t2.regId
	)
	, rmSum as
	(
	select rmId
			, sum(ticks) as sumTicks
			, sum(cntRows) as sumCntRows
			, min(algorithmId) as uAlgorithmId -- Єдиний алгорітм для РЛ
	from regSum group by rmId
	)
	insert into @regTicks(rmId,regid,ticks,sumTicks,cntRows, sumCntRows, regSum, runRegSum, algorithmId)
	select t1.rmid
			, t1.regId
			, t1.ticks
			, t2.sumTicks
			, t1.cntRows
			, t2.sumCntRows
			, t1.regSum
			, sum(t1.regSum) over (partition by t1.rmid order by t1.rmid, t1.regid) as runRegSum
			, t2.uAlgorithmId
	from regSum t1
	join rmSum t2 on t2.rmId = t1.rmId;

	--print '@regTicks'
	--select * from @regTicks
	
	-- Видалити звіти суми яких поза нерозподіленого залишку періоду
	delete @regTicks 
	from @regTicks t1
	join RegisterRatedList t2 on t2.rmId = t1.rmId
	join @workedPeriod t3 on t3.periodId = t2.periodId
	where
	t1.runRegSum > t3.periodAmount;  

	--print '@regTicks'
	--select * from @regTicks
-- Суми по розрахунковому листу з проставленими сумами
-- Враховувати, що сума періоду може бути меньшою за суму звіту
    insert into @workedRmid(periodid,rmid,ticks, regAmount)
    select t2.periodId, t2.rmId, t3.durationticks, t2.royalty - isnull(t2.paidAmount,0) 
	from @workedPeriod t1
	join RegisterRatedList t2 on t2.periodId = t1.periodid
	join ( select ti.rmId
				, sum( case when algorithmId = 1 then ticks else cntRows end ) as durationticks
		   from @regTicks ti 
		   group by ti.rmId
		   ) t3  on t3.rmId = t2.rmId 
	where
	t1.withSum = 1
	and t2.royalty > isnull(t2.paidAmount,0);

-- Суми по розрахунковому листу з непроставленими сумами для алгоритму 1(по тривалості звучанню)
    
	with periodTics as (
		select t1.periodid, sum( t3.ticks ) as durationticks
		from @workedPeriod t1
	join RegisterRatedList t2 on t2.periodId = t1.periodid
	join @regTicks t3 on t3.rmId = t2.rmId
	group by t1.periodid
	)
	insert into @workedRmid(periodid,rmid,ticks, regAmount)
    output inserted.rmid, inserted.regAmount into @balansRmid(id,amount)
	select max(t2.periodId), t2.rmId
	, sum(ti.ticks)
	, max(t1.periodAmount) * ( cast( sum(ti.ticks) as float ) / max(t4.durationticks))   
	from @workedPeriod t1
	join RegisterRatedList t2 on t2.periodId = t1.periodid
	join @regTicks ti on ti.rmId = t2.rmId
	join periodTics t4 on t4.periodid = t1.periodid
	where
	t1.withSum = 0
	and ti.algorithmId = 1
	group by t2.rmId;

-- Суми по розрахунковому листу з непроставленими сумами для алгоритму 2(ротації)
	with periodTics as (
		select t1.periodid, sum( t3.cntRows ) as sumCntRows
		from @workedPeriod t1
	join RegisterRatedList t2 on t2.periodId = t1.periodid
	join @regTicks t3 on t3.rmId = t2.rmId
	group by t1.periodid
	)
	insert into @workedRmid(periodid,rmid,ticks, regAmount)
    output inserted.rmid, inserted.regAmount into @balansRmid(id,amount)
	select max(t2.periodId), t2.rmId
	, sum(ti.ticks)
	, max(t1.periodAmount) * ( cast( sum(ti.cntRows) as float ) / max(t4.sumCntRows))   
	from @workedPeriod t1
	join RegisterRatedList t2 on t2.periodId = t1.periodid
	join @regTicks ti on ti.rmId = t2.rmId
	join periodTics t4 on t4.periodid = t1.periodid
	where
	t1.withSum = 0
	and ti.algorithmId = 2
	group by t2.rmId;

	--print '@workedRmid 1';
	--select * from @workedRmid;

	delete @workedRmid where regAmount <= 0;

-- Якщо немає РЛ для оплати -- Вихід
    if( (select count(*) from @workedRmid ) = 0 )
    begin
		commit;
        return;
    end;
-- Балансировка
	with deltaSum as 
	(	
		select t1.periodid, min( t1.periodAmount) - sum( t2.regAmount ) as delta
		from @workedPeriod t1
		join @workedRmid t2 on t2.periodid = t1.periodid
		group by t1.periodid
		having min( t1.periodAmount) - sum( t2.regAmount ) > 0
	)
	update @workedRmid 
	set regAmount = regAmount + delta
	from @workedRmid t1
	join ( select top 1 id from @balansRmid order by amount desc  ) t2 on t2.id = t1.rmid
	join deltaSum t3 on t3.periodid = t1.periodid;


	--print '@workedRmid 2';
	--select * from @workedRmid;

	
	delete @balansRmid;
	delete @updateRate;
    
	-- Формування RegisterCount
	-- Дані по правовласникам
	with lic as 
	(
		select reg.regId, t3.licId, t3.licCode 
			from RegisterRatedList rl 
			join Register reg on reg.rmId = rl.rmId
			join @workedRmid t1 on t1.rmid = rl.rmId
			join PaidPeriod pp on pp.periodId = rl.periodId
			join LicenseAgreement t3 on t3.licId = pp.licId and t3.licClass != 1 -- SmallRight
		union
		select reg.regId, t4.licId, t4.licCode 
			from RegisterRatedList rl 
			join Register reg on reg.rmId = rl.rmId
			join @workedRmid t1 on t1.rmid = rl.rmId
			join PaidPeriod pp on pp.periodId = rl.periodId
			join LicenseAgreement t3 on t3.licId = pp.licId and t3.licClass = 1 -- BigRight
			join LicenseAgreement t4 on t4.agrId = t3.agrId and reg.licId = t4.licId

	)
	,workedObjid as 
	(
		select distinct objid
		from @workedRmid t0
		join Register t1 on t1.rmid = t0.rmid
		join RegisterItem t2 on t2.regid = t1.regId 
	)

	insert into @updateRate
    select t1.regId, t1.regIItemId, t1.objId, t2.custId, isnull(t2.cRType,1) as cRType, t6.kindCode
								--, case when t2.roleRate is null and t2.rate is not null then t2.rate
								--	   when t2.roleRate is null and t2.rate is null then 100 
								--	   when t2.roleRate is not null and t3.sumRoleRate is not null then t2.roleRate / t3.sumRoleRate * 100
								--	   else 100 end 
								, isnull(t2.rate, 100)
								, isnull(t2.rateCommiss,20) as rateCommiss
								, t2.cmCustId

    from RegisterItem t1
    join lic t5 on t5.regId = t1.regId 
	join AgrLicenseType t6 on t6.codeI = t5.licCode 
    left outer join vCopyright t2 on t2.objId = t1.objId and t2.status = 1 and t6.kindCode = t2.CRKindCode
	--left outer join role_right t3 on t3.objId = t1.objid
	-- поновлюємо таблицю розподілу по новим правовласникам
	
	--print '@updateRate';
	--select * from @updateRate;
	
	update RegisterCount 
	set rate = t2.rate
	from RegisterCount t1
	join @updateRate t2 on t2.regId = t1.regId and t2.regIItemId = t1.regIItemId and t2.objid = t1.objId 
							and t2.custId is not null and t2.custId = t1.custId and t2.rate <> t1.rate;

	update RegisterCount 
	set rate = t2.rate
	from RegisterCount t1
	join @updateRate t2 on t2.regId = t1.regId and t2.regIItemId = t1.regIItemId and t2.objid = t1.objId 
							and t2.custId is null and t1.custId is null and isnull(t2.rate,999) <> isnull(t1.rate,1000);
	-- Уточнюєма відсоток нерозподілених коштів
	update RegisterCount 
	set rate = 100 - t2.rate
	from RegisterCount t1
	join @updateRate t2 on t2.regId = t1.regId and t2.regIItemId = t1.regIItemId and t2.objid = t1.objId 
							and t2.custId is not null and t1.custId is null and t1.rate != 100 - t2.rate;
	
	delete 	@updateRate
	from @updateRate t1
	join RegisterCount t2 on t2.regId = t1.regId and t2.regIItemId = t1.regIItemId and t2.objId = t1.objid and isnull( t2.custid, 0 ) = isnull( t1.custid, 0)
	
	-- Додаємо нерозподілені відсотки
	insert into RegisterCount(regId,regIItemId,objId,custId,cRType,cRKindCode,rate)
	select regId,regIItemId,objId,custId,cRType,kindCode,rate 
	from @updateRate; 
	
	delete @updateRate;


	--print 'RegisterCount';
	--select t3.*
	--from @workedRmid t1
	--join Register t2 on t2.rmId = t1.rmid
	--join RegisterCount t3 on t3.regId = t2.regId
    
	
	-- Формуємо таблицю розподілу по звітам по звітам без прив'язаних сум
	delete @balansRmid;

	insert into Distribution( regId,rmId,custid,status,distribDate,amount, cRKindCode, partnerCommiss, courtFee, partnerId, distType )
    output inserted.distId, inserted.rmId, inserted.regId, inserted.amount	 into @distrib
    select t2.regId, treg.rmid, t2.custId, 1, getdate(), (cast( ti.ticks as float ) / treg.ticks) * treg.regAmount
    , 1
    , case when t4.custId is not null then  (case when ti.algorithmId = 1 then ti.ticks else ti.cntRows end / treg.ticks) * treg.regAmount 
    			* (case when t1.flagFirst = 1 then t4.srFirstRate else  t4.srMonthRate end) / 100 else 0 end
    , 0--@courtFee
    , t4.custId
    , 1
    from @workedPeriod t1
    join @workedRmid treg on treg.periodid = t1.periodid
    join Register t2 on t2.rmId = treg.rmid
    join @regTicks ti on ti.regid = t2.regId
	left outer join vPartner t4 on t4.clCustId = t2.custId
   where 
   isnull(t2.authAmount,0) + isnull(t2.musicAmount,0) = 0
   and treg.ticks > 0;

	insert into Distribution( regId,rmId,custid,status,distribDate,amount, cRKindCode, partnerCommiss, courtFee, partnerId, distType )
    output inserted.distId, inserted.rmId, inserted.regId, inserted.amount	 into @distrib
    select t2.regId, treg.rmid, t2.custId, 1, getdate()
	, isnull(t2.authAmount,0) + isnull(t2.musicAmount,0)
    , 1
    , case when t4.custId is not null then  (isnull(t2.authAmount,0) + isnull(t2.musicAmount,0))
    			* (case when t1.flagFirst = 1 then t4.srFirstRate else  t4.srMonthRate end) / 100 else 0 end
    , 0--@courtFee
    , t4.custId
    , 1
    from @workedPeriod t1
    join @workedRmid treg on treg.periodid = t1.periodid
    join Register t2 on t2.rmId = treg.rmid
    join @regTicks ti on ti.regid = t2.regId
    left outer join vPartner t4 on t4.clCustId = t2.custId
   where 
   isnull(t2.authAmount,0) + isnull(t2.musicAmount,0) > 0
   and isnull(t2.authAmount,0) + isnull(t2.musicAmount,0) < t2.paidAmount -- неоплачені
   and treg.ticks > 0;

   --print '@distrib';
   --select t2.* from @distrib t1
   --join Distribution t2 on t2.distId = t1.distid;

--	Балансировка
	with deltaSum as
	(
		select t1.rmid, min(t1.regAmount) - sum(t2.amount) as delta
		from @workedRmid t1
		join @distrib t2 on t2.rmId = t1.rmid
		group by t1.rmid
		having min(t1.regAmount) - sum(t2.amount) > 0
	) 
	, regOrder as 
	(
	select 
	ROW_NUMBER() over ( partition by rmid order by rmid, amount desc ) as rowid,
	rmid, regid from @distrib 
	)
	update Distribution set 
	amount = amount + delta
	from Distribution t1
	join deltaSum t2 on t2.rmid = t1.rmId
	join regOrder t3 on t3.rmid = t1.rmId and t3.regid = t1.regId and t3.rowid = 1

	delete @balansRmid;

	-- Зберігаємо оплачені суми в періоді РЛ та в звіті
	update Register set 
	paidAmount = isnull(t1.paidAmount, 0 ) + t2.amount
	from Register t1
	join Distribution t2 on t2.regId = t1.regId 
	join @distrib t3 on t3.regid = t1.regId;

	
	update RegisterRatedList set
	paidAmount = isnull(t1.paidAmount,0) + t2.regAmount 
	from RegisterRatedList t1
	join @workedRmid t2 on t2.rmid = t1.rmId;


	with rrl_data as 
	(
		select periodid, sum(wr.regAmount) as regAmount from @workedRmid wr group by periodid
	)
	update PaidPeriod set
	undistribamount = t1.undistribamount - t2.regAmount,
	distribamount = t1.distribamount + t2.regAmount
	from PaidPeriod t1
	join rrl_data t2 on t2.periodid = t1.periodId


	insert into DistributionItem(regId,regIItemId,distId,amount, status, objId )
	output inserted.regId, inserted.regIItemId, inserted.amount into @balansRmid( parentId, id, amount )
	select t1.regId, t1.regIItemId,  t3.distId
	, (case when ti.algorithmId = 1 then cast( t1.ticks as float ) / ti.ticks else 1./ ti.cntRows end ) * (t3.amount - t3.partnerCommiss - t3.courtFee )
	, 0 -- status
	, t1.objId
	from RegisterItem t1
	join Register treg on treg.regId = t1.regid
	join @regTicks ti on ti.regid = treg.regId
	join @distrib t2 on t2.regId = t1.regId
	join Distribution t3 on t3.distId = t2.distid 
	where
	t1.codeItem = 1; -- Звичайний розподіл


	insert into DistributionItem(regId,regIItemId,distId,amount, status, objId )
	output inserted.regId, inserted.regIItemId, inserted.amount into @balansRmid( parentId, id, amount )
 	select t1.regId, t1.regIItemId,  t3.distId
	, (1. / t4.cntRows) * (treg.authRate / (treg.authRate+isnull(treg.musicRate,0))) * (t3.amount - t3.partnerCommiss - t3.courtFee )
	, 0 -- status
	, t1.objId
    from RegisterItem t1
    join Register treg on treg.regId = t1.regid
    join @distrib t2 on t2.regId = t1.regId
    join Distribution t3 on t3.distId = t2.distid 
    join @regTicks t4 on t4.regid = treg.regid 
	where
	t1.codeItem = 2; -- Твір


	insert into DistributionItem(regId,regIItemId,distId,amount, status, objId )
	output inserted.regId, inserted.regIItemId, inserted.amount into @balansRmid( parentId, id, amount )
     select t1.regId, t1.regIItemId,  t3.distId
	, ( 1. / t4.cntRows )  * (isnull(treg.musicRate,0)/(isnull(treg.authRate,0)+isnull(treg.musicRate,0))) * (t3.amount - t3.partnerCommiss - t3.courtFee )
	, 0 -- status
	, t1.objId
    from RegisterItem t1
    join Register treg on treg.regId = t1.regid
    join @distrib t2 on t2.regId = t1.regId
    join Distribution t3 on t3.distId = t2.distid 
    join @regTicks t4 on t4.regid = treg.regid 
	where
	t1.codeItem = 3; -- Музичне оформлення

	--print '@balansRmid';
	--select * from @balansRmid;

-- balansing
	with itemData as 
	(	
		select t1.distid, min(t2.amount - t2.partnerCommiss - t2.courtFee ) - sum(t3.amount) as delta
		from @distrib t1 
		join Distribution t2 on t2.distId = t1.distid
		join DistributionItem t3 on t3.distId = t2.distId
		group by t1.distid
	)
	, itemRow as
	(
		select t3.distId, t3.distItemId, 
		ROW_NUMBER() over (partition by t3.distId order by t3.distId , t3.amount desc ) as rowid
		from
		@distrib t1 
		join Distribution t2 on t2.distId = t1.distid
		join DistributionItem t3 on t3.distId = t2.distId
	)
	update DistributionItem set 
	amount = t1.amount + delta
	from DistributionItem t1
	join itemData t2 on t2.distid = t1.distId
	join itemRow t3 on t3.distId = t1.distId and t3.distItemId = t1.distItemId and t3.rowid = 1;

	--print '@distrib';
	--select t2.*, t3.* from 		@distrib t2
	--	 join DistributionItem t3 on t3.distId = t2.distid 

    -- скидаємо суму для розподілу



    commit;
END TRY
BEGIN CATCH 
    declare @errnum int,
			@errseverity int,
			@errstate int,
			@errmessage varchar(255),
			@errorline int;
	
	if	@@TRANCOUNT > 0
	begin
		rollback
	end
	
	select @errnum = ERROR_NUMBER(), @errseverity = ERROR_SEVERITY(), @errstate = ERROR_STATE(), @errmessage = ERROR_MESSAGE(), @errorline = ERROR_LINE();
    RAISERROR( @errmessage, @errseverity,   @errstate, @errorline )
	print 'Error line number = ' + cast( @errorline as varchar(10))
	
END CATCH 

return
end
