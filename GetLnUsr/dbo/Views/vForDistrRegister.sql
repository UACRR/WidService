create view vForDistrRegister as
with TabPeriod as
( select pp.periodId, max(pp.custId) as custId, 
	    COUNT(DISTINCT t2.regId) AS cntRegister,
		min( pp.undistribamount ) as undistribamount,
		min( case when isnull(t1.royalty,0) = 0 then 0 else 1 end ) as royalty,
		min( cast( isnull( pp.fagFirst, 0) as int )) as fagFirst
	from 
    PaidPeriod pp 
    join RegisterRatedList t1 on t1.periodId = pp.periodId
    join Register t2 on t2.rmId = t1.rmId
	join RegisterItem t3 on t3.regId = t2.regid
    where 
	-- t2.rmId = 125 and -- Отладка
	pp.status between 2 and 7 and 
	pp.undistribamount <> 0
    group by pp.periodId
    having count(*) = sum( case when t2.rgStatus >= 3 then 1 else 0 end ) -- Статус  
			and sum( case when t3.objId is null then 1 else 0 end ) = 0 -- всі об'єкти прив'язані
		    and min( case when t1.royalty is null then 0 else 1 end ) = max (case when t1.royalty is null then 0 else 1 end) -- Однотипні суми
)
select pp.periodId, pp.custId, t4.name as custName, t2.licId, pp.cntRegister, pp.undistribamount, pp.fagFirst, t1.rmId, t1.amount as RateListAmount, t2.regId, t2.regAmount, t2.regRate, t2.regRoyalty,  t2.authRate, t2.authAmount, t2.musicRate, t2.musicAmount,
   t2.fileName, t2.rgStatus  
from TabPeriod pp 
     join RegisterRatedList t1 on t1.periodId = pp.periodId
     join Register t2 on t2.rmId = t1.rmId
--  	 join RegisterItem t3 on t3.regId = t2.regid
     join vcustomer t4 on pp.custId = t4.custId
