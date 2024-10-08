/*
SELECT *
  FROM [SocWidUpdates].[dbo].[RecSoc]
where SubmWrkNr = 'MS886819'

select * from SocWid..WidTitle where wic = 0039649414

select * from SocWid..widIswc where wic = 0039649414

select *
from SocWidSubmit..RecAck t1
	join SocWidUpdates..RecIsw t2 on t1.Iswc = t2.Iswc
where t1.Status <> 'RJ'

select t1.UpdFileId, t1.TransSeqNr, t1.Iswc, t2.Iswc
from SocWidUpdates..RecSoc t1
	join SocWidUpdates..RecIsw t2 on t1.UpdFileId = t2.UpdFileId
		and t1.TransSeqNr = t2.TransSeqNr
where t1.Iswc <> t2.Iswc
order by t1.UpdFileId, t1.TransSeqNr
*/

-- Твори, за які йшлось в апдейтах і які не містять відповідних ISWC в SocWid
drop table if exists #WorksMissingIswc
select distinct cast(t1.WicCode as int) as Wic, t1.Iswc
into #WorksMissingIswc
from SocWidUpdates..RecSoc t1
	left join SocWid..WidIswc t2 on cast(t1.WicCode as int) = t2.Wic and t1.Iswc = t2.Iswc
where cast(t1.WicCode as int) <> 0
	and t1.Iswc <> ''
	and t2.Wic is null

-- Так додамо ж їх
insert SocWid..WidIswc( Wic,  Iswc,  PrefIswc, CreTs,     CreUid,  UpdTs,     UpdUid )
select                  Wic,  Iswc,  Iswc,	   getdate(), 'UACRR', getdate(), 'UACRR'
from #WorksMissingIswc

-- Але PrefIswc треба брати з останніх транзакцій
drop table if exists #LastFileIds
select t1.Wic, max(t2.UpdFileId) as UpdFileId
into #LastFileIds
from #WorksMissingIswc t1
	join SocWidUpdates..RecSoc t2 on t1.Wic = cast(t2.WicCode as int)
group by t1.Wic

-- З ними й поєднаємось для виконання апдейту PrefIswc
update t1
set t1.PrefIswc = t3.Iswc
from SocWid..WidIswc t1
	join #LastFileIds t2 on t1.Wic = t2.Wic
	join SocWidUpdates..RecSoc t3 on t2.UpdFileId = t3.UpdFileId and t2.Wic = cast(t3.WicCode as int)

