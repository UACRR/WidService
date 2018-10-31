CREATE procedure [dbo].[pTsk_5_18_TurnAccount] (@dateBegin date = NULL, @dateEnd date = NULL ,@account varchar(20) )
as
BEGIN
set @dateBegin = isnull(@dateBegin, (select convert(date, (convert(char(4),year(getdate()))+'-01-01'))))
set @dateEnd = isnull(@dateEnd, getdate())

if @dateBegin > @dateEnd 
	return

declare @result TABLE(
	turnid				int  not	null,
	dateOper			date,
	Korname			varchar(60) NULL,
	accKorr			int,
	Debet				varchar(20),
	Credit				varchar(20),
	amount				money,
	nD					varchar(10),
	payNote			varchar(120),
	primary key  (turnid)
	)

insert @result(	turnid,	dateOper,	Korname,	accKorr,	Debet,	Credit,	amount	,	nD,	payNote)
select 
		t2.turnid, t2.dateOper,null KorName,
case when (t1.accid= t2.accidCredit ) then t2.accIdDebet
				else  t2.accIdCredit
end accKorr,
case when (t1.accid= t2.accIdDebet ) then NULL
				else t2.accDebet
end dbt,
case when (t1.accid= t2.accidCredit ) then NULL
				else  t2.accCredit
end crdt,
t2.amount,
t2.nD,
t2.paynote
 from Account t1, PayTurn t2
where
t1.accNls=@account	and
(t2.accIdCredit = t1.accId or t2.accIdDebet = t1.accId)
and t2.dateOper between @dateBegin and @dateEnd

update @result
	set Korname =t2.accName
from @result t1,Account t2
where
	t1.accKorr = t2.accId

select * from @result

return

END

--exec  pTsk_5_18_TurnAccount  '20180101','20180802','20000135'