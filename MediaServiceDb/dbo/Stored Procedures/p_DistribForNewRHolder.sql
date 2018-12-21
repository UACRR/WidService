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
select 2, getdate(), (t4.rest / (100 - isnull( t6.rate, 0 ))) * t1.rate, cast( substring(t3.accNls,4,2) as int ), 0,0, 2, t1.cRightId
from Copyright t1
join @copyRight t2 on t2.cRightId = t1.cRightId
join Account t3 on t3.objId = t1.objId and balsCode = 31
join SaldoDay t4 on t4.accId = t3.accId and dateEnd = '3000-01-01' and rest <> 0
cross join ( select sum(rate) as rate
			from @copyRight t1 join CopyRight t2 on t2.objid = t1.objid 
						and getdate() between t2.beginDate and t2.endDate 
						and t2.cRightId not in (select cRightId from @copyRight )) t6
-- Створити записи в Об'єктах розподілу(DistributionItem) для кожношо рахунку


insert into DistributionItem(distId, objid, amount, status )
select t2.distId, t3.objId, t2.amount, 1
from @distr t1
join Distribution t2 on t2.distId = t1.distid
join CopyRight t3 on t3.cRightId = t2.cRightId;

-- Створити запис нового Правовласника в RegisterCount Для кожного рахунку 
insert into RegisterCount( distId, distItemId, cRType, cRKindCode, rate, custId, objId )
select t3.distId, t3.distItemId, 1, t2.cRKindCode, 100, t4.custId, t4.objId 
from @distr t1
join Distribution t2 on t2.distId = t1.distid
join DistributionItem t3 on t3.distId = t1.distid
join CopyRight t4 on t4.cRightId = t2.cRightId
end