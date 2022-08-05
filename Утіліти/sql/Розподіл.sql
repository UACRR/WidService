declare @workedRmid table ( rmid int not null primary key);
declare @distrib table ( distid int not null, periodId int not null, regid int not null );
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

    -- Отримати звіти для яких є гроші
    insert into @workedRmid
    select t1.rmId
    from 
    PaidPeriod pp 
    join RegisterRatedList t1 on t1.periodId = pp.periodId
    join Register t2 on t2.rmId = t1.rmId and t2.rgStatus in (3)
	join RegisterItem t3 on t3.regId = t2.regid
    where 
	pp.status between 2 and 7 and 
	pp.undistribamount <> 0 and
	t1.status = 1 -- Погоджений
    group by t1.rmId
    having count(*) = sum( case when t2.rgStatus >= 3 then 1 else 0 end ) and sum( case when t3.objId is null then 1 else 0 end ) = 0 
			and min(isnull(t2.regAmount,0) ) <= max(pp.undistribamount) -- Є звіти для розподілу;

	select 
	t2.rmid
	, t4.regid
	, min( t3.undistribamount )
	, min( t4.regAmount )
	, sum( t4.regAmount ) over ( partition by t2.rmid  order by t4.isSum , t4.regAmount desc  ) as paidAmount
	, min( t3.undistribamount ) - sum( t4.regAmount ) over ( partition by t2.rmid  order by t4.regAmount desc  ) as paidAmount
	from 
	RegisterRatedList t2
	join PaidPeriod t3 on t3.periodId = t2.periodId
	join ( select rmId, regid, isnull( regRoyalty, 0 ) as regAmount, case when regRoyalty is null then 0 else 1 end as isSum from Register ) t4 on t4.rmId = t2.rmid
	-- where t3.undistribamount > 0
	group by t2.rmid, t4.regid, t4.regAmount
	order by t2.rmid, t4.regAmount desc

	