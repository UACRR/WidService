



CREATE procedure [dbo].[p_MusDesignToRegItems] as
begin
/*
 begin tran
 exec p_MusDesignToRegItems
 rollback
*/
declare @period TABLE  (
licid int ,
periodid int ,
childLicId int 
);

insert into @period
select t1.licId, t1.periodId, t21.licId as childLicId
from PaidPeriod t1
join LicenseAgreement t2 on t2.licId = t1.licid and t2.licClass = 1
join LicenseAgreement t21 on t2.agrId = t21.agrId and t21.licClass = 2
join LicenseBigR t3 on t3.licid = t21.licid and t3.objid is not null
join MusicalDesign t4 on t4.licId = t21.licId
where 
t1.undistribamount > 0 and 
t3.objid is not null
group by t1.licId, t1.periodId, t21.licId
having count(*) = sum( case when t4.objid is not null then 1 else 0 end  );

-- select * from @period;

with validLicId as
(select distinct ri.regId , p.childLicId as licid from @period p join register ri on ri.licId = p.childLicId )  
insert into RegisterItem(regId,regIItemId,objId,codeItem,ItemName,categoryCode,performer,authorMusic,authorText,durationUse,countUse,durationItem,durationticks,ticks,isAuto)
select 
t1.regId,																								-- regId,
isnull(t3.regIItemId,0) + ROW_NUMBER() over (partition by t1.regid order by t1.regid) as regIItemId,    -- regIItemId,
t4.objId,                                                                                               -- objId,
3,                                                                                                      -- codeItem,
t4.objName,                                                                                             -- ItemName,
5,                                                                                                      -- categoryCode,
t4.nameSinger,                                                                                          -- performer,
t4.nameMusician,                                                                                        -- authorMusic,
t4.authorText,                                                                                          -- authorText,
t4.duration,                                                                                            -- durationUse,
1,                                                                                                      -- countUse,
t4.duration,                                                                                            -- durationItem,
1,                                                                                                      -- durationticks,
1,                                                                                                      -- ticks,
1																										-- isAuto
from Register t1
join validLicId t2 on t2.licid = t1.licId
left outer join ( select ri.regId, max(ri.regIItemId) as regIItemId from RegisterItem ri 
		where ri.regid in (select distinct regId from validLicId )  
		group by ri.regId ) t3 on t3.regId = t1.regId
join LicenseBigR t31 on t31.licId = t2.licid and t31.objId = t31.objId
join RegisterItem t32 on t32.regId = t1.regId and t32.codeItem = 2 and t32.objId = t31.objid
join MusicalDesign t4 on t4.licId = t2.licid 
left outer join  RegisterItem t5 on t5.regId = t1.regId and t5.objId = t4.objid
where t5.regId is null
order by t1.regid;


end
