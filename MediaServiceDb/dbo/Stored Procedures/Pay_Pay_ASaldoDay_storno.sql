CREATE	 procedure [dbo].[Pay_Pay_ASaldoDay_storno]
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

create table #saldo_turns(
AccID				int,
R030				char(3),
DateBegin		date,
DateEnd			date,
KrdOborot		money,
Deboborot		money,
Rest				money null,
RestBegin		money,
 primary key(AccId,DateBegin)
)

--select * from #saldo_turns 
insert  #saldo_turns(
	AccID	,
	DateBegin,
	KrdOborot,
	Deboborot,
	R030
	)
select 
max(AccIdDebet) AccID	,max(DateWork) DateOper,0 crdob,sum(Amount) 	debob,Max(R030)
from 
 #PayTurn group by 	AccIdDebet,DateWork

merge #saldo_turns dst
USING( 
			select max(AccIdCredit) AccID	,max(DateWork) DateWork,sum(Amount) crdob,0	debob,Max(R030) R030
			from  #PayTurn 
			group by 	AccIdCredit,DateWork
			) src

			on (src.AccId = dst.AccId and
					src.DateWork=dst.dateBegin
					)
		When matched		then
		UPDATE
				set dst.Krdoborot=src.crdob
		when not matched  then
		insert(AccId,R030,DateBegin,DateEnd,Krdoborot,
					DebOborot,Rest,RestBegin)
				values(src.AccId,'980',src.DateWork,Null,src.crdob,
					0,null,null);

/*
select * from #saldo_turns
select t1.* from SaldoDay t1,#saldo_turns t2
where
t1.accId=t2.AccID		and
t1.dateBegin=t2.DateBegin
*/

update t1
set
t1.deboborot=t1.deboborot- t2.Deboborot,
t1.krdOborot=t1.krdOborot-t2.KrdOborot,
t1.rest=t1.rest+t2.KrdOborot-t2.Deboborot
from SaldoDay t1,#saldo_turns t2
where
t1.accId=t2.AccID		and
t1.dateBegin=t2.DateBegin

update t1
set
t1.rest=t1.rest+t2.KrdOborot-t2.Deboborot,
t1.restbegin=t1.restbegin+t2.KrdOborot-t2.Deboborot

from SaldoDay t1,#saldo_turns t2
where
t1.accId=t2.AccID		and
t1.dateBegin>t2.DateBegin


return 0
end