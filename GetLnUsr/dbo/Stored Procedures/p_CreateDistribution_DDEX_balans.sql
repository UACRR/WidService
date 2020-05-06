
CREATE procedure [dbo].[p_CreateDistribution_DDEX_balans] @regId int
as

BEGIN             --1
/*

exec p_CreateDistribution_DDEX_balans 7431

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
cmCustid	int,
primary key (regIItemId,id)
 )
 */
 create table #delta (
regIItemId	int,
delta		numeric(20,2),
primary key (regIItemId)
)

/*
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
t1.regId = 7431 and
t6.crGroupCode = 2
--t6.crGroupCode = 1
--t6.crGroupCode = @crGroupCode
and amountMech<>0
and  isnull(t2.rateMEC, 100)<>0
order by regIItemId asc,t2.rateMec desc

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
t1.regId = 7431 and
--t6.crGroupCode = 2
t6.crGroupCode = 1
--t6.crGroupCode = @crGroupCode
and amountMech<>0
and  isnull(t2.ratePer, 100)<>0
order by regIItemId asc,t2.ratePer desc


*/
		
		update  t1
		set amount = round((amountXXX * t1.rateXXX/t2.rateMec),2,1)
		from #t t1,(select regiitemid,sum(rateXXX) rateMec from #t 
		group by regiitemid ) t2
		where  t1.regIItemId=t2.regIItemId


insert #delta
select  t2.regiitemid,(t2.amountXXX-t1.amount)  delta 
from (select regIItemId,max(amountXXX) amountXXX from #t 
		group by regIItemId
) t2,(select regiitemid ,sum(amount) amount from  #t group by regiitemid  ) t1
where
t1.regiitemid=t2.regiitemid
and (t2.amountXXX-t1.amount)<>0
order by t2.regiitemid

/*
merge #t as dst
using (select a1.regIItemId,a1.amount,min(id) id ,a1.delta from  #t t1,
		(select t1.regIItemId,max(t2.amount)  amount,max(delta) delta  from #delta t1,#t t2
			where t2.regIItemId =t1.regIItemId
			and abs(delta)=0.01
			group by t1.regIItemId
		) a1
			where a1.regIItemId =t1.regIItemId and
			a1.amount= t1.amount
			group by a1.regIItemId,a1.amount,a1.delta
		) src
		 on ( dst.regiitemid = src.regiitemid and dst.id =src.id)
		 when matched
		 then update set amount =src.amount + src.delta;

delete #delta where abs(delta)=0.01
*/

if ((select count(*) from #delta)<>0)
BEGIN
declare @regiitemid int
declare @delta numeric (20,2)
declare @kop numeric(20,2)=0.01
declare @id int
declare @II int
declare @amount numeric(20,2)
declare @rateXXX numeric(10,2)
declare delta cursor  for select regIItemId,delta from #delta order by regIItemId
open	delta
set @II =  (select count(*) from #delta)
--select @II
fetch delta into @regIItemId,@delta
                                                   
    while @II > 0 
begin
	if @delta>0  
			begin
	_litle_cikl1:
			declare  balans cursor for select regIItemId,id,rateXXX --,amount 
			from #t where regIItemId = @regiitemid
			order by rateXXX desc --For update of amount
			open balans
			fetch   NEXT from balans into @regIItemId,@id,@rateXXX --,@amount
			while (@@fetch_status =0 and @delta > 0)
			begin
				update #t set amount =amount + @kop
--				where current of balans		
				where
				regIItemId = @regiitemid	and
				id  = @id							
				set @delta = @delta - @kop
			fetch   NEXT from balans into @regIItemId,@id,@rateXXX --,@amount
			end
			close balans
			deallocate balans
			if @delta>0 goto _litle_cikl1 
		end
	else
		begin 
		_litle_cikl2:
			declare  balans cursor for select regiitemid,id --,amount 
			from #t where regIItemId = @regiitemid
			and amount>0
			order by amount desc --For update of amount
			open balans
			fetch next  from balans into @regiitemid,@id
			while (@@fetch_status =0 and @delta < 0)
			begin
				update #t set amount =amount - @kop
--				where current of balans	
				where
				regIItemId = @regiitemid	and
				id  = @id							

				set @delta = @delta + @kop
			fetch next  from balans into @regiitemid,@id
			end
			close balans
			deallocate balans
			if @delta<0 goto _litle_cikl2 
		end
		set @II = @II - 1
--		print @regIItemId
		fetch  delta into @regIItemId,@delta
end
close delta
deallocate delta

END
delete #t 
where amount = 0

update #t 
set cmCustid = t2.custid
from #t t1,Community t2
where t1.cmCodeXXX = t2.interCode


END     --1
