CREATE	 procedure [dbo].[Pay_SaldoDay_Court]
as
begin

if ( object_id('tempdb..#PayTurn') is null)

CREATE TABLE #PayTurn(
	TurnId						 int			NOT NULL,
	DateWork				date NOT NULL,
	ND							varchar(25)		NULL,
	NDDate					datetime	NULL,
	AccIdDebet			 int			NULL,
	AccIdCredit			 int			NULL,
	AccDebet				varchar(25)			NULL,
	AccCredit				varchar(25)			NULL,
	Amount					numeric(20, 2	)	NULL,
	AmountCur				numeric(20, 2)	NULL,
	PayNote					varchar(200) 	NULL,
	DateOper				datetime						NOT NULL,
	PayStatus				int					 NULL,
	regId						int,
	distid					int,
	paidid				int null,
	flCourt		tinyint		null,
	custidRh				int		null,
 PRIMARY KEY CLUSTERED (	TurnId ASC,	DateWork ASC)
)

/*
insert #PayTurn( TurnId,DateWork,ND,NDDate,AccIdDebet,AccIdCredit,AccDebet,AccCredit,Amount,
							AmountCur,PayNote,DateOper,PayStatus,regId,distid,paidid ,flCourt)
  select 
							DocPayId,DateWork,ND,NDDate,AccIdDebet,AccIdCredit,AccDebet,AccCredit,Amount,
							AmountCur,PayNote,DateOper,PayStatus,regId,distid,paidid,flCourt
							from DocPreparePaywhere
PayStatus=1			

*/

create table #SaldoDay(
AccID				int,
R030				char(3),
DateBegin		date,
DateEnd		date,
KrdOborot	money,
Deboborot	money,
Rest	money null,
RestBegin money,
KrdOborotCourt	money,
DeboborotCourt	money,
RestCourt	money null,
RestBeginCourt money
)

create table #saldo_turns(
AccID				int,
R030				char(3),
DateBegin		date,
DateEnd			date,
KrdOborot		money,
Deboborot		money,
KrdOborotCourt		money,
DeboborotCourt		money,
Rest				money null,
RestBegin		money,
RestCourt				money null,
RestBeginCourt		money,
 primary key(AccId,DateBegin)
)

create table #saldo_rest(
AccID				int,
DateBegin		date,
RestBegin		money,
RestBeginCourt				money null,
 primary key(AccId,DateBegin)
)

create table #delta(
AccID				int,
DateBegin		date,
delta		money,
deltaCourt	money,
 primary key(AccId,DateBegin)
)






insert  #saldo_turns(
	AccID	,
	DateBegin,
	KrdOborot,
	Deboborot,
	KrdOborotCourt,
	DeboborotCourt,
	R030
	)
select 
max(AccIdDebet) AccID	,max(DateWork) DateWork,0 crdob,sum(Amount) 	debob,0 crdobCourt,sum(AmountCur) debobCourt,  '980'
from 
 #PayTurn group by 	AccIdDebet,DateWork

merge
 #saldo_turns t1
 using  (select max(AccIdCredit) AccID	,max(DateWork) DateWork,sum(Amount) crdob,0	debob,sum(AmountCur) crdobCourt, 0 debobCourt
 from 
 #PayTurn group by 	AccIdCredit,DateWork
) a1
  on 
     (t1.AccID=a1.Accid)

	 when matched
	 then update 
	 set Krdoborot=a1.crdob,
			KrdoborotCourt=a1.crdobCourt
	 when not matched then
	 insert (AccID	,	DateBegin,	KrdOborot,Deboborot,	KrdOborotCourt,DeboborotCourt,	R030)
	 values (a1.AccId,a1.DateWork,a1.crdob,0,crdobCourt,0,'980');




insert #SaldoDay( AccId,DateBegin,DateEnd,R030,Rest,Deboborot, KrdOborot,RestBegin,RestCourt,DeboborotCourt, KrdOborotCourt,RestBeginCourt )  
select distinct
t1.AccId,isnull(t2.DateBegin,t1.DateBegin) DateBegin, t2.DateEnd,t1.R030,
isnull(t2.Rest,0) Rest,isnull(t2.Deboborot,0) Deboborot,isnull(t2.KrdOborot,0) KrdOborot,
isnull(t2.RestBegin,0) RestBegin,
isnull(t2.RestCourt,0) RestCourt,isnull(t2.DeboborotCourt,0) DeboborotCourt,isnull(t2.KrdOborotCourt,0) KrdOborotCourt,
isnull(t2.RestBeginCourt,0) RestBeginCourt
from #saldo_turns t1
left 
join SaldoDay t2 on (t1.AccID=t2.AccId and t1.DateBegin between t2.DateBegin and t2.DateEnd)


merge #saldoDay as dst
Using  (select AccId,R030,DateBegin,DateEnd,Krdoborot,DebOborot,isnull(Rest,0) Rest,isnull(RestBegin,0) RestBegin  
					,KrdoborotCourt,DebOborotCourt,isnull(RestCourt,0) RestCourt,isnull(RestBeginCourt,0) RestBeginCourt  
					from #saldo_turns) src
					on (dst.AccId=src.AccId and dst.DateBegin=src.DateBegin)
					when matched
					then
					update set
					dst.krdoborot=src.krdoborot+dst.krdoborot,
					dst.deboborot=src.deboborot+dst.deboborot,
					dst.krdoborotCourt=src.krdoborotCourt+dst.krdoborotCourt,
					dst.deboborotCourt=src.deboborotCourt+dst.deboborotCourt

					when not matched
					then
					insert(AccId,R030,DateBegin,DateEnd,Krdoborot,DebOborot,Rest,RestBegin,
								KrdoborotCourt,DebOborotCourt,RestCourt,RestBeginCourt)
					values(src.AccId,src.R030,src.DateBegin,src.DateEnd,src.Krdoborot,
					src.DebOborot,src.Rest,src.RestBegin,src.KrdoborotCourt,src.DebOborotCourt,src.RestCourt,src.RestBeginCourt); 

insert #saldo_turns(
	AccID	,
	DateBegin,
	KrdOborot,
	Deboborot,
	KrdOborotCourt,
	DeboborotCourt,
	R030
)
select  a1.AccID,a1.DateBegin,a1.KrdOborot,a1.Deboborot,a1.KrdOborotCourt,a1.DeboborotCourt,a1.R030
from #SaldoDay a1 where not exists( select 1 from #saldo_turns t2
		where
		a1.AccId=t2.AccID	and
		a1.DateBegin=t2.DateBegin
		)




update t2
set 
t2.Deboborot=t1.deboborot,
t2.KrdOborot=t1.KrdOborot,
t2.DeboborotCourt=t1.deboborotCourt,
t2.KrdOborotCourt=t1.KrdOborotCourt
from
#saldo_turns t2,#SaldoDay t1
where
t1.AccID=t2.AccID		and
t1.DateBegin=t2.DateBegin

 
insert  #saldo_rest(AccID	,DateBegin	,RestBegin)
select  a1.AccId,a2.DateBegin,a2.RestBegin from 
		(select AccId ,min (DateBegin) DateBegin from #SaldoDay group by AccId) a1,
				#SaldoDay a2
				where 
				a2.AccID=a1.AccID	and
				a2.DateBegin=a1.DateBegin

update t2
set t2.RestBegin=t1.RestBegin
from #SaldoDay t2,#saldo_rest t1
where t2.AccID=t1.AccId


merge #saldo_turns as dst
using (select a1.AccId,a1.dateBegin,isnull(sum(a2.KrdOborot),0) Krdoborot,isnull(sum(a2.DebOborot),0) Deboborot  ,
					isnull(sum(a2.KrdOborotCourt),0) KrdoborotCourt,isnull(sum(a2.DebOborotCourt),0) DeboborotCourt  
			from #saldo_turns a1 left join #saldo_turns a2 on (a1.accid=a2.accid and a1.datebegin>=a2.datebegin)
			group by a1.AccId,a1.DateBegin) src
		on (dst.AccId=src.AccId and dst.DateBegin=src.DateBegin)
		when matched
			then
			update set
			Rest=isnull(dst.Rest,0)-src.KrdOborot+src.DebOborot,
			RestCourt=isnull(dst.RestCourt,0)-src.KrdOborotCourt+src.DebOborotCourt;


update t2
set t2.rest=t2.restbegin+t1.rest,
		t2.restCourt=t2.restbeginCourt+t1.restCourt
from #SaldoDay t2,#saldo_turns t1
where
t2.AccID=t1.AccID	and
t2.DateBegin=t1.DateBegin

update t2
set t2.RestBegin=t2.Rest+t2.KrdOborot-t2.Deboborot,
		t2.RestBeginCourt=t2.RestCourt+t2.KrdOborotCourt-t2.DeboborotCourt
from #SaldoDay t2


/*
merge #saldoday as dst
using (select a1.AccId,a1.dateBegin,isnull(sum(a2.KrdOborot),0) Krdoborot,
			isnull(sum(a2.DebOborot),0) Deboborot  
			from #saldoday a1 left join #saldoday a2 on (a1.accid=a2.accid and a1.datebegin>=a2.datebegin)
			group by a1.AccId,a1.DateBegin) src
		on (dst.AccId=src.AccId and dst.DateBegin=src.DateBegin)
		when matched
			then
			update set
			Rest=isnull(dst.RestBegin,0)-src.KrdOborot+src.DebOborot;
*/



Merge  #saldoday as dst
Using (select t1.AccId,t1.DateBegin,min(t2.DateBegin) DateEnd from #saldoday t1,
			 #saldo_turns t2
			where 
					t2.AccId=t1.AccId	and
					t2.DateBegin>t1.DateBegin
					group by t1.AccId,t1.DateBegin
					) src
				on (
						dst.AccId=src.AccId	and
						dst.DateBegin=src.DateBegin
						)
		When MATCHED then
		update 
			set DateEnd=dateadd(day,-1,src.DateEnd);

Merge  #saldoday as dst
Using (select t1.AccId,t1.DateBegin,min(t2.DateBegin) DateEnd from #saldoday t1,
			 Saldoday t2
			where 
					t2.AccId=t1.AccId	and
					t2.DateBegin>t1.DateBegin
					group by t1.AccId,t1.DateBegin
					) src
				on (
						dst.AccId=src.AccId	and
						dst.DateBegin=src.DateBegin and
						dst.DateEnd is null
						)
		When MATCHED then
		update 
			set DateEnd=dateadd(day,-1,src.DateEnd);

		update #saldoday
			set DateEnd='90000101'
			where DateEnd is null


Merge SaldoDay as dst
Using (select AccId,R030,DateBegin,DateEnd,Krdoborot,Deboborot,Rest,RestBegin  ,
				KrdoborotCourt,DeboborotCourt,RestCourt,RestBeginCourt  
			 from #saldoday) src
			 on (dst.AccId=src.AccId and
					dst.DateBegin=src.DateBegin
					)
					when matched
						then update
								set  dst.DateEnd=src.DateEnd,
										dst.Krdoborot=src.Krdoborot,
										dst.Deboborot=src.Deboborot,
										dst.Rest=src.Rest,
										dst.RestBegin=src.RestBegin,
										
										dst.KrdoborotCourt=src.KrdoborotCourt,
										dst.DeboborotCourt=src.DeboborotCourt,
										dst.RestCourt=src.RestCourt,
										dst.RestBeginCourt=src.RestBeginCourt
					when not matched
--						then insert(AccId,R030,DateBegin,DateEnd,Krdoborot,Deboborot,Rest,RestBegin)
						then insert( accId,dateBegin,dateEnd,r030,rest,restCourt,deboborot,krdOborot,
						deboborotCourt,krdOborotCourt,restBegin,restBeginCourt)
						values(src.AccId,src.DateBegin,src.DateEnd,src.R030,src.Rest,src.RestCourt,src.Deboborot,src.Krdoborot,
						src.deboborotCourt,src.krdoborotCourt,	src.RestBegin,	src.RestBeginCourt);
--						values(src.AccId,src.R030,src.DateBegin,src.DateEnd,src.Krdoborot,	src.Deboborot,src.Rest,RestBegin);


insert #delta(accid,datebegin,delta,deltaCourt)
select a1.accid,a1.datebegin,(t2.deboborot-t2.krdoborot) delta ,(t2.deboborotCourt-t2.krdoborotCourt) deltaCourt   from 
(select accid,max(datebegin) datebegin from #saldo_turns
group by accid) a1,#saldo_turns t2
where 
a1.accid=t2.accid	and
a1.datebegin=t2.datebegin

update saldoday
set 
rest=rest+delta,
restbegin=restbegin+delta ,
restCourt=restCourt+deltaCourt,
restBeginCourt=restBeginCourt+deltaCourt 
from 
#delta t1,saldoday t2
where t1.accid=t2.accid
and t2.datebegin>t1.datebegin


return 0
end