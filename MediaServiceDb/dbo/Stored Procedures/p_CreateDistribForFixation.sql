--create procedure [%QUALIFIER%]%PROC%  as
CREATE procedure dbo.p_CreateDistribForFixation  as
begin

-- Розподіл
declare @distrib table ( 
distid int not null, 
rmId int not null, 
regid int not null, 
amount money not null
);

-- Балансування
declare @balansRmid table
(
parentId int  null,
id int not null ,
amount money not null 
);

set nocount on
begin tran
BEGIN TRY

-- Заповнюємо інформацію по розподілу
insert into Distribution( regId,rmId,custid,status,distribDate,amount, cRKindCode, partnerCommiss, courtFee, partnerId, distType, isCourt )
output inserted.distId, inserted.rmId, inserted.regId, inserted.amount into @distrib
select t3.regId, t3.rmId, t4.clientCustId, 2, getdate(), t1.undistribamount, 1
, case when t4.partnerCustId is not null then  (t4.rewardAmount - isnull(t4.courtFeeAmount,0) ) * t5.courtRate / 100 else 0 end
, t4.courtFeeAmount
, t4.partnerCustId
, 3 -- Судова робота
, 1 -- isCourt
from PaidPeriod t1
join RegisterRatedList t2 on t2.periodId = t1.periodId
join Register t3 on t3.rmid = t2.rmId
join Fixation t4 on t4.licId = t1.licId
left join vPartner t5 on t5.custId = t4.partnerCustId
where t1.status = 4
and t1.undistribamount > 0
and t1.undistribamount = t4.rewardAmount
and t4.stageStatus = 17;

-- Інформація по розподілу для об'єктів права
delete @balansRmid;
with cntReg as
(
	select t1.regid, count(*) as cnt from RegisterItem t1
	join @distrib t2 on t2.regid = t1.regId
	group by t1.regid
)
insert into DistributionItem(regId,regIItemId,distId,amount, status, objId )
output inserted.regId, inserted.regIItemId, inserted.amount into @balansRmid( parentId, id, amount )
select t1.regid, t3.regIItemId, t1.distid, (1. / cntReg.cnt) * (t2.amount-t2.courtFee-t2.partnerCommiss), 1, t3.objId
from @distrib t1
join cntReg on cntReg.regId = t1.regid
join Distribution t2 on t2.distId = t1.distid
join RegisterItem t3 on t3.regId = t1.regid;

-- Балансуємо залишки
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

-- Скидаємо інформацію про нерозподілені суми
update PaidPeriod set
undistribamount = t1.undistribamount - t3.amount,
distribamount = t1.distribamount + t3.amount
from PaidPeriod t1
join RegisterRatedList t2 on t2.periodId = t1.periodId
join (select rmid, sum(amount) as amount from  @distrib group by rmId ) t3 on t3.rmId = t2.rmId

--select t2.* from
--@distrib t1 
--join Distribution t2 on t2.distId = t1.distid;

--select t2.* from
--@distrib t1 
--join DistributionItem t2 on t2.distId = t1.distid;

--select t1.* from PaidPeriod t1
--join RegisterRatedList t2 on t2.periodId = t1.periodId
--join (select distinct rmid from @distrib ) t3 on t3.rmId = t2.rmId

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