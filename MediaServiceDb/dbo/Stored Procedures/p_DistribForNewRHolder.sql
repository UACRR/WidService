--create procedure [%QUALIFIER%]%PROC%  @copyRight as CopyRightParam
CREATE procedure dbo.p_DistribForNewRHolder  @copyRight as CopyRightParam READONLY 
as
begin
SET NOCOUNT ON;
declare @distr table ( distid int not null );

-- Створити записи в Розподілу(Distribution) для кожного рахунку
-- type = 2 - Додано правовласника; status = 2 - Розподілено по об'єктам права 
insert into Distribution( status,distribDate,amount, cRKindCode, partnerCommiss, courtFee, distType, cRightId )
output inserted.distId into @distr
select 2, getdate(), t4.rest * t1.rate / (100-isnull(t5.rate,0) ), cast( substring(t3.accNls,4,2) as int ), 0,0, 2, t1.cRightId
from Copyright t1
join @copyRight t2 on t2.cRightId = t1.cRightId
join Account t3 on t3.objId = t1.objId and balsCode = 31
join SaldoDay t4 on t4.accId = t3.accId and dateEnd = '3000-01-01' and rest <> 0
left outer join ( select crl.objId, sum(rate) as rate 
			from CopyRight crl join @copyRight crr on crl.objId = crr.objId and crl.cRightId != crr.cRightId 
			where getdate() between crl.beginDate and endDate
			group by crl.objId
			) t5 on t5.objId = t1.objId;
-- Створити записи в Об'єктах розподілу(DistributionItem) для кожношо рахунку

insert into DistributionItem(distId, objid, amount, status )
select t2.distId, t3.objId, t2.amount, 1
from @distr t1
join Distribution t2 on t2.distId = t1.distid
join CopyRight t3 on t3.cRightId = t2.cRightId;

-- Створити запис нового Правовласника в RegisterCount Для кожного рахунку 
insert into RegisterCount( distId, distItemId, cRType, cRKindCode, rate, custId )
select t3.distId, t3.distItemId, 1, t2.cRKindCode, 100, t4.custId 
from @distr t1
join Distribution t2 on t2.distId = t1.distid
join DistributionItem t3 on t3.distId = t1.distid
join CopyRight t4 on t4.cRightId = t2.cRightId
end