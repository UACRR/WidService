
create procedure [dbo].[p_CreateDistribution_hand]  as
begin
-- Period
--27-08-2019 7-статус после синхронизации 
create table #workedPeriod  ( 
periodid int not null, 
periodAmount money not null, 
withSum	bit not null,
flagFirst bit not null,
kindCode integer null   --KRPV
primary key(periodid) );

-- Розрахункові листи
create table  #workedRmid  ( 
periodid int not null, 
rmid int not null, 
ticks int, 
regAmount money not null,
periodSum money not null,
primary key(rmid) );

-- Балансування
create table #balansRmid
(
parentId int  null,
id int not null ,
amount money not null 
)

-- Таблиця даних для розрахунку долі на об'єкт
create table   #regTicks ( 
rmId int not null,
regid int not null primary key
, ticks		bigint
, sumTicks	bigint
, cnt1Rows	int 
, sumCnt1Rows	int 
, cnt2Rows	int 
, sumCnt2Rows	int 
, cnt3Rows	int 
, sumCnt3Rows	int 
, regSum	money
, runRegSum money
, algorithmId	int
, cntWithTicks  int -- Кількість записів в RegistryItems з проставленим Ticks
, sum3Share money -- Сума паїв для 3 алгоритму для збірної музики
 );
-- Розподіл
create table  #distrib  ( 
distid int not null, 
rmId int not null, 
regid int not null, 
amount money not null
);

create table #updateRate ( 
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

	insert into #workedPeriod(periodid, periodAmount, withSum, flagFirst )
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
    having --count(*) = sum( case when t2.rgStatus >= 3 then 1 else 0 end ) -- Статус  --27-08-2019
	        count(*) = sum( case when t2.rgStatus >= 7 then 1 else 0 end ) -- Статус  --27-08-2019 (после синхронизации)
			and sum( case when t3.objId is null then 1 else 0 end ) = 0 -- всі об'єкти прив'язані
		    and min( case when t1.royalty is null then 0 else 1 end ) = max (case when t1.royalty is null then 0 else 1 end); -- Однотипні суми;

	-- Для Рапортичок виравніваємо суми оплати по РЛ
	with rrldata as 
	(
		select t1.periodid, sum( t2.royalty ) as royalty 
		from #workedPeriod t1
		join RegisterRatedList t2 on t2.periodId = t1.periodid
		where t1.withSum = 1
		group by t1.periodid
	)
	update #workedPeriod set 
	periodAmount = case when t1.periodAmount <= t2.royalty then t1.periodAmount else t2.royalty end
	from  #workedPeriod t1
	join rrldata t2 on t2.periodid = t1.periodid;

--KRPV
--Проставляю тип прав
  update #workedPeriod 
     set kindCode = t4.kindCode
	from #workedPeriod  t1 
	   join PaidPeriod t2 on t1.periodid = t2.periodId 
	   join LicenseAgreement t3 on t2.licId = t3.licId
	   join AgrLicenseType t4 on t3.licCode = t4.codeI;
--KRPV
	
	print '#workedPeriod';
--	select '#workedPeriod', * from #workedPeriod;

	-- Розраховуємо суму тривалості та  кількsсть використання треків
	with regSum as (
	select t2.rmId
		, t2.regId
		, sum(t3.ticks) as ticks
		, sum(case when isnull(t3.codeItem,1) = 1 then isnull(t3.countUse,1) else 0 end) as cnt1Rows
		, sum(case when t3.codeItem = 2 then isnull(t3.countUse,1) else 0 end) as cnt2Rows
		, sum(case when t3.codeItem = 3 then isnull(t3.countUse,1) else 0 end) as cnt3Rows
		, min(isnull( t2.authAmount, 0 ) + isnull(t2.musicAmount,0)) as regSum
		, min(isnull(t2.algorithmId,2)) as algorithmId 
		, sum( case when isnull( t3.ticks, 0  ) > 0 then 1 else 0 end ) as cntItemWithTics
		, sum( case when isnull(t2.algorithmId,2) = 3 and t3.codeItem = 3 then isnull(t3.countUse,0) * isnull(rgp.rate,0) else 0 end ) as sum3Share
	from 
	register t2 
	join RegisterItem t3 on t3.regId = t2.regId
	join RegisterRatedList t4 on t4.rmId = t2.rmId
	join #workedPeriod t5 on t5.periodid = t4.periodId
	-- Додаємо ПАЇ для збірної музики
	join ObjectRight obr on obr.objId = t3.objId
	left outer join RelGenrePercent rgp on rgp.genreType = obr.genreType and rgp.actCode = isnull(obr.actCode,1)
	-- фільтруємо неоплачені РЛ
	where
		(isnull( t2.authAmount, 0 ) + isnull(t2.musicAmount,0) = 0 )
	or	(isnull( t2.authAmount, 0 ) + isnull(t2.musicAmount,0) > isnull(t2.paidAmount,0) )
	group by t2.rmId, t2.regId
	)
	, rmSum as
	(
	select rmId
			, sum(ticks) as sumTicks
			, sum(cnt1Rows) as sumCnt1Rows
			, sum(cnt2Rows) as sumCnt2Rows
			, sum(cnt3Rows) as sumCnt3Rows
			, min(algorithmId) as uAlgorithmId -- Єдиний алгорітм для РЛ
	from regSum group by rmId
	)
	insert into #regTicks(rmId,regid,ticks,sumTicks,cnt1Rows,sumCnt1Rows,cnt2Rows,sumCnt2Rows,cnt3Rows, sumCnt3Rows, regSum, runRegSum, algorithmId
			, cntWithTicks, sum3Share)
	select t1.rmid
			, t1.regId
			, t1.ticks
			, t2.sumTicks
			, t1.cnt1Rows
			, t2.sumCnt1Rows
			, t1.cnt2Rows
			, t2.sumCnt2Rows
			, t1.cnt3Rows
			, t2.sumCnt3Rows
			, t1.regSum
			, sum(t1.regSum) over (partition by t1.rmid order by t1.rmid, t1.regid) as runRegSum
			, t2.uAlgorithmId
			, t1.cntItemWithTics
			, t1.sum3Share
	from regSum t1
	join rmSum t2 on t2.rmId = t1.rmId;

	print '#regTicks'
	--select '#regTicks', * from #regTicks
	
	delete #regTicks where cntWithTicks = 0;


	-- Видалити звіти суми яких поза нерозподіленого залишку періоду

	delete #regTicks 
	from #regTicks t1
	join RegisterRatedList t2 on t2.rmId = t1.rmId
	join #workedPeriod t3 on t3.periodId = t2.periodId
	where
	round(t1.runRegSum, 2 ) > t3.periodAmount;  

	print '#regTicks'
--	select '#regTicks', * from #regTicks

-- Суми по розрахунковому листу з проставленими сумами
-- Враховувати, що сума періоду може бути меньшою за суму звіту
    insert into #workedRmid(periodid,rmid,ticks, regAmount, periodSum)
    select t2.periodId, t2.rmId, t3.durationticks, t2.royalty - isnull(t2.paidAmount,0)
	, sum( t2.royalty - isnull(t2.paidAmount,0) ) over ( partition by t2.periodid order by t2.periodid, t2.rmId ) -- накопичуванна сума  РЛ для періода
	from #workedPeriod t1
	join RegisterRatedList t2 on t2.periodId = t1.periodid
	join ( select ti.rmId
				, sum( case when algorithmId = 1 then ticks else cnt3Rows + cnt2Rows + cnt1Rows end ) as durationticks
		   from #regTicks ti 
		   group by ti.rmId
		   ) t3  on t3.rmId = t2.rmId 
	where
	t1.withSum = 1
	and t2.royalty > isnull(t2.paidAmount,0);



-- Суми по розрахунковому листу з непроставленими сумами для алгоритму 1(по тривалості звучанню)
    
	with periodTics as (
		select t1.periodid, sum( t3.ticks ) as durationticks
		from #workedPeriod t1
	join RegisterRatedList t2 on t2.periodId = t1.periodid
	join #regTicks t3 on t3.rmId = t2.rmId
	group by t1.periodid
	)
	insert into #workedRmid(periodid,rmid,ticks, regAmount, periodSum)
    output inserted.rmid, inserted.regAmount into #balansRmid(id,amount)
	select max(t2.periodId), t2.rmId
	, sum(ti.ticks)
	, max(t1.periodAmount) * ( cast( sum(ti.ticks) as float ) / max(t4.durationticks))   
	, max( t1.periodAmount ) -- сума розрахункових листів не встановлено записуємо суму періода 
	from #workedPeriod t1
	join RegisterRatedList t2 on t2.periodId = t1.periodid
	join #regTicks ti on ti.rmId = t2.rmId
	join periodTics t4 on t4.periodid = t1.periodid
	where
	t1.withSum = 0
	and ti.algorithmId = 1
	group by t2.rmId;

-- Суми по розрахунковому листу з непроставленими сумами для алгоритму 2(ротації)
	with periodTics as (
		select t1.periodid, sum( t3.cnt3Rows + t3.cnt2Rows + t3.cnt1Rows ) as sumCntRows
		from #workedPeriod t1
	join RegisterRatedList t2 on t2.periodId = t1.periodid
	join #regTicks t3 on t3.rmId = t2.rmId
	group by t1.periodid
	)
	insert into #workedRmid(periodid,rmid,ticks, regAmount, periodSum)
    output inserted.rmid, inserted.regAmount into #balansRmid(id,amount)
	select max(t2.periodId), t2.rmId
	, sum(ti.ticks)
	, max(t1.periodAmount) * ( cast( sum(ti.cnt3Rows + ti.cnt2Rows + ti.cnt1Rows ) as float ) / max(t4.sumCntRows))   
	, max( t1.periodAmount ) -- сума розрахункових листів не встановлено записуємо суму періода
	from #workedPeriod t1
	join RegisterRatedList t2 on t2.periodId = t1.periodid
	join #regTicks ti on ti.rmId = t2.rmId
	join periodTics t4 on t4.periodid = t1.periodid
	where
	t1.withSum = 0
	and ti.algorithmId = 2
	group by t2.rmId;

	print '#workedRmid 1';
	--select '#workedRmid 1', * from #workedRmid;

	delete #workedRmid where regAmount <= 0;
	
	delete #workedRmid 
	from #workedRmid t1
	join #workedPeriod t2 on t2.periodid = t1.periodid
	where
	t2.periodAmount < t1.periodSum;

-- Якщо немає РЛ для оплати -- Вихід
    if( (select count(*) from #workedRmid ) = 0 )
    begin
		commit;
        return;
    end;
-- Балансировка
	with deltaSum as 
	(	
		select t1.periodid, min( t1.periodAmount) - sum( t2.regAmount ) as delta
		from #workedPeriod t1
		join #workedRmid t2 on t2.periodid = t1.periodid
		group by t1.periodid
		having min( t1.periodAmount) - sum( t2.regAmount ) > 0
	)
	update #workedRmid 
	set regAmount = regAmount + delta
	from #workedRmid t1
	join ( select top 1 id from #balansRmid order by amount desc  ) t2 on t2.id = t1.rmid
	join deltaSum t3 on t3.periodid = t1.periodid;


	print '#workedRmid 2';
--	select '#workedRmid 2', * from #workedRmid;

	
	delete #balansRmid;
	delete #updateRate;
    
	-- Формування RegisterCount
	-- Дані по правовласникам
	with lic as 
	(
		select reg.regId, t3.licId, t3.licCode 
			from RegisterRatedList rl 
			join Register reg on reg.rmId = rl.rmId
			join #workedRmid t1 on t1.rmid = rl.rmId
			join PaidPeriod pp on pp.periodId = rl.periodId
			join LicenseAgreement t3 on t3.licId = pp.licId and t3.licClass != 1 -- SmallRight
		union
		select reg.regId, t4.licId, t4.licCode 
			from RegisterRatedList rl 
			join Register reg on reg.rmId = rl.rmId
			join #workedRmid t1 on t1.rmid = rl.rmId
			join PaidPeriod pp on pp.periodId = rl.periodId
			join LicenseAgreement t3 on t3.licId = pp.licId and t3.licClass = 1 -- BigRight
			join LicenseAgreement t4 on t4.agrId = t3.agrId and reg.licId = t4.licId

	)
	insert into #updateRate
    select t1.regId, t1.regIItemId, t1.objId, t2.custId, isnull(t2.cRType,1) as cRType, t6.kindCode
								, isnull(t2.rate, 100)
								, isnull(t2.rateCommiss,20) as rateCommiss
								, t2.cmCustId

    from RegisterItem t1
    join lic t5 on t5.regId = t1.regId 
	join AgrLicenseType t6 on t6.codeI = t5.licCode 
    left outer join vCopyright t2 on t2.objId = t1.objId and t2.status = 1 and t6.kindCode = t2.CRKindCode

	-- Додаємо нерозпізнані відсотки
	insert into #updateRate
    select regId, regIItemId, objId, null, cRType , kindCode
								, 100.00 - sum(rate)
								, null
								, null
	from #updateRate
	group by regId, regIItemId, objId, cRType , kindCode
	having sum(rate) < 100

	-- поновлюємо таблицю розподілу по новим правовласникам
	
	print '#updateRate';
--	select '#updateRate', * from #updateRate;
--	select regId, regIItemId, objId, sum(rate) from #updateRate group by regId, regIItemId, objId 
	
	update RegisterCount 
	set rate = t2.rate
	from RegisterCount t1
	join #updateRate t2 on t2.regId = t1.regId and t2.regIItemId = t1.regIItemId and t2.objid = t1.objId 
							and t2.custId is not null and t2.custId = t1.custId and t2.rate <> t1.rate;

	update RegisterCount 
	set rate = t2.rate
	from RegisterCount t1
	join #updateRate t2 on t2.regId = t1.regId and t2.regIItemId = t1.regIItemId and t2.objid = t1.objId 
							and t2.custId is null and t1.custId is null and isnull(t2.rate,999) <> isnull(t1.rate,1000);

	
	delete 	#updateRate
	from #updateRate t1
	join RegisterCount t2 on t2.regId = t1.regId and t2.regIItemId = t1.regIItemId and t2.objId = t1.objid and isnull( t2.custid, 0 ) = isnull( t1.custid, 0)
	
	-- Додаємо нерозподілені відсотки
	insert into RegisterCount(regId,regIItemId,objId,custId,cRType,cRKindCode,rate,cmCustId)
	select regId,regIItemId,objId,custId,cRType,kindCode,rate, cmCustId 
	from #updateRate; 
	
	delete #updateRate;


	print 'RegisterCount';
/*	select 'RegisterCount', t3.*
	from #workedRmid t1
	join Register t2 on t2.rmId = t1.rmid
	join RegisterCount t3 on t3.regId = t2.regId
  */  
	
	-- Формуємо таблицю розподілу по звітам по звітам без прив'язаних сум
	delete #balansRmid;

	insert into Distribution( regId,rmId,custid,status,distribDate,amount, cRKindCode, partnerCommiss, courtFee, partnerId, distType )
    output inserted.distId, inserted.rmId, inserted.regId, inserted.amount	 into #distrib
    select t2.regId, treg.rmid, t2.custId, 1, getdate(), (cast( ti.ticks as float ) / treg.ticks) * treg.regAmount
    , t1.kindCode
    , case when t4.custId is not null then  
	--(case when ti.algorithmId = 1 then ti.ticks else ti.cnt1Rows + ti.cnt2Rows + ti.cnt3Rows end / treg.ticks) * 
	treg.regAmount 
    			* (case when t1.flagFirst = 1 then t4.srFirstRate else  t4.srMonthRate end) / 100 else 0 end
    , 0--@courtFee
    , t4.custId
    , 1
    from #workedPeriod t1
    join #workedRmid treg on treg.periodid = t1.periodid
    join Register t2 on t2.rmId = treg.rmid
    join #regTicks ti on ti.regid = t2.regId
	left outer join vPartner t4 on t4.clCustId = t2.custId
   where 
   isnull(t2.authAmount,0) + isnull(t2.musicAmount,0) = 0
   and treg.ticks > 0;

	insert into Distribution( regId,rmId,custid,status,distribDate,amount, cRKindCode, partnerCommiss, courtFee, partnerId, distType )
    output inserted.distId, inserted.rmId, inserted.regId, inserted.amount	 into #distrib
    select t2.regId, treg.rmid, t2.custId, 1, getdate()
	, isnull(t2.authAmount,0) + isnull(t2.musicAmount,0)
    , t1.kindCode
    , case when t4.custId is not null then  (isnull(t2.authAmount,0) + isnull(t2.musicAmount,0))
    			* (case when t1.flagFirst = 1 then t4.srFirstRate else  t4.srMonthRate end) / 100 else 0 end
    , 0--@courtFee
    , t4.custId
    , 1
    from #workedPeriod t1
    join #workedRmid treg on treg.periodid = t1.periodid
    join Register t2 on t2.rmId = treg.rmid
    join #regTicks ti on ti.regid = t2.regId
    left outer join vPartner t4 on t4.clCustId = t2.custId
   where 
   isnull(t2.authAmount,0) + isnull(t2.musicAmount,0) > 0
   and isnull(t2.authAmount,0) + isnull(t2.musicAmount,0) > isnull(t2.paidAmount,0) -- неоплачені
   and treg.ticks > 0;

   print '#distrib';
--   select '#distrib', t2.* from #distrib t1
 --  join Distribution t2 on t2.distId = t1.distid;

   -- Видаляємо РЛ які не приймають участь в оплаті
   delete #workedRmid where rmid not in ( select rmid from #distrib );

   print '#workedRmid';
 --  select '#workedRmid', * from #workedRmid;


--	Балансировка
	with deltaSum as
	(
		select t1.rmid, min(t1.regAmount) - sum(t2.amount) as delta
		from #workedRmid t1
		join #distrib t2 on t2.rmId = t1.rmid
		group by t1.rmid
		having min(t1.regAmount) - sum(t2.amount) > 0
	) 
	, regOrder as 
	(
	select 
	ROW_NUMBER() over ( partition by rmid order by rmid, amount desc ) as rowid,
	rmid, regid from #distrib 
	)
	update Distribution set 
	amount = amount + delta
	from Distribution t1
	join deltaSum t2 on t2.rmid = t1.rmId
	join regOrder t3 on t3.rmid = t1.rmId and t3.regid = t1.regId and t3.rowid = 1

	delete #balansRmid;
    


	-- Зберігаємо оплачені суми в періоді РЛ та в звіті
	update Register set 
	paidAmount = isnull(t1.paidAmount, 0 ) + t2.amount
	from Register t1
	join Distribution t2 on t2.regId = t1.regId 
	join #distrib t3 on t3.regid = t1.regId;

	
	update RegisterRatedList set
	paidAmount = isnull(t1.paidAmount,0) + t2.regAmount 
	from RegisterRatedList t1
	join #workedRmid t2 on t2.rmid = t1.rmId;


	with rrl_data as 
	(
		select periodid, sum(wr.regAmount) as regAmount from #workedRmid wr group by periodid
	)
	update PaidPeriod set
	undistribamount = t1.undistribamount - t2.regAmount,
	distribamount = t1.distribamount + t2.regAmount
	from PaidPeriod t1
	join rrl_data t2 on t2.periodid = t1.periodId;




	insert into DistributionItem(regId,regIItemId,distId,amount, status, objId )
	output inserted.regId, inserted.regIItemId, inserted.amount into #balansRmid( parentId, id, amount )
	select t1.regId, t1.regIItemId,  t3.distId
	, (case when ti.algorithmId = 1 then cast( t1.ticks as float ) / ti.ticks 
	else isnull(t1.countUse,1)*1./ ti.cnt1Rows end ) * (t3.amount - t3.partnerCommiss - t3.courtFee )
	, 0 -- status
	, t1.objId
	from RegisterItem t1
	join Register treg on treg.regId = t1.regid
	join #regTicks ti on ti.regid = treg.regId
	join #distrib t2 on t2.regId = t1.regId
	join Distribution t3 on t3.distId = t2.distid 
	where
	t1.codeItem = 1; -- Звичайний розподіл


	insert into DistributionItem(regId,regIItemId,distId,amount, status, objId )
	output inserted.regId, inserted.regIItemId, inserted.amount into #balansRmid( parentId, id, amount )
 	select t1.regId, t1.regIItemId,  t3.distId
	, (cast(isnull(t1.countUse,1.) as float) / t4.cnt2Rows) * (treg.authRate / (treg.authRate+isnull(treg.musicRate,0))) * (t3.amount - t3.partnerCommiss - t3.courtFee )
	, 0 -- status
	, t1.objId
    from RegisterItem t1
    join Register treg on treg.regId = t1.regid
    join #distrib t2 on t2.regId = t1.regId
    join Distribution t3 on t3.distId = t2.distid 
    join #regTicks t4 on t4.regid = treg.regid 
	where
	t1.codeItem = 2; -- Твір


	insert into DistributionItem(regId,regIItemId,distId,amount, status, objId )
	output inserted.regId, inserted.regIItemId, inserted.amount into #balansRmid( parentId, id, amount )
     select t1.regId, t1.regIItemId,  t3.distId
	, ( cast(isnull(t1.countUse,1.) as float) / t4.cnt3Rows )  * (isnull(treg.musicRate,0)/(isnull(treg.authRate,0)+isnull(treg.musicRate,0))) * (t3.amount - t3.partnerCommiss - t3.courtFee )
	, 0 -- status
	, t1.objId
    from RegisterItem t1
    join Register treg on treg.regId = t1.regid
    join #distrib t2 on t2.regId = t1.regId
    join Distribution t3 on t3.distId = t2.distid 
    join #regTicks t4 on t4.regid = treg.regid 
	where
	t1.codeItem = 3 
	and isnull(treg.algorithmId,1) != 3; -- Музичне оформлення оформлення Алгоритм 1-2

	insert into DistributionItem(regId,regIItemId,distId,amount, status, objId )
	output inserted.regId, inserted.regIItemId, inserted.amount into #balansRmid( parentId, id, amount )
     select t1.regId, t1.regIItemId,  t3.distId
	, ( cast( t1.countUse * rgp.rate as float )/ t4.sum3Share )  * (isnull(treg.musicRate,0)/(isnull(treg.authRate,0)+isnull(treg.musicRate,0))) * (t3.amount - t3.partnerCommiss - t3.courtFee )
	, 0 -- status
	, t1.objId
    from RegisterItem t1
    join Register treg on treg.regId = t1.regid
    join #distrib t2 on t2.regId = t1.regId
    join Distribution t3 on t3.distId = t2.distid 
    join #regTicks t4 on t4.regid = treg.regid 
	-- Додаємо ПАЇ
	join ObjectRight obr on obr.objId = t1.objId
	left outer join RelGenrePercent rgp on rgp.genreType = obr.genreType and rgp.actCode = isnull(obr.actCode,1)
	where
	t1.codeItem = 3 
	and treg.algorithmId = 3; -- Музичне оформлення Алгоритм 3


	print '#balansRmid';
	--select '#balansRmid', * from #balansRmid;

-- balansing
	with itemData as 
	(	
		select t1.distid, min(t2.amount - t2.partnerCommiss - t2.courtFee ) - sum(t3.amount) as delta
		from #distrib t1 
		join Distribution t2 on t2.distId = t1.distid
		join DistributionItem t3 on t3.distId = t2.distId
		group by t1.distid
	)
	, itemRow as
	(
		select t3.distId, t3.distItemId, 
		ROW_NUMBER() over (partition by t3.distId order by t3.distId , t3.amount desc ) as rowid
		from
		#distrib t1 
		join Distribution t2 on t2.distId = t1.distid
		join DistributionItem t3 on t3.distId = t2.distId
	)
	update DistributionItem set 
	amount = t1.amount + delta
	from DistributionItem t1
	join itemData t2 on t2.distid = t1.distId
	join itemRow t3 on t3.distId = t1.distId and t3.distItemId = t1.distItemId and t3.rowid = 1;

	print '#distrib';
--	select '#distrib', t2.*, t3.* from 		#distrib t2
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
