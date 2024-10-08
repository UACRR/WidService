select t2.regId, t2.ItemName, t2.authorMusic, t2.authorText, t2.Performer, t2.ObjId
from Register t1
	join RegisterItem t2 on t1.regId = t2.regId
where t1.CustId = 282424 and ItemName = 'Backdraft'
order by t2.ItemName, RegId

select * from AnketaCompany where custId = 4110

select *
from Register
order by custId

; with Items as (
	select t1.custId, t2.ItemName, t2.authorMusic, t2.authorText, t2.Performer, t2.ObjId
	from Register t1
		join RegisterItem t2 on t1.regId = t2.regId
	where t2.ObjId is not null
		and t1.custId not in (281215, 281540, 39556)
)
select t1.*, t2.ObjId
from Items t1
	join Items t2 on 
		t1.custId = t2.custId
		and t1.ItemName = t2.ItemName
		and t1.authorMusic = t2.authorMusic
		and t1.authorText = t2.authorText
		and t1.Performer = t2.Performer
		and t1.ObjId <> t2.ObjId
order by t1.ItemName

; with Items as (
	select distinct t1.custId, t2.ItemName, t2.authorMusic, t2.authorText, t2.Performer
	from Register t1
		join RegisterItem t2 on t1.regId = t2.regId
)
select distinct t2.ItemName, t2.authorMusic, t2.authorText, t2.Performer
from Items t1
	join Items t2 on 
			t1.ItemName = t2.ItemName
		and t1.authorMusic = t2.authorMusic
		and t1.authorText = t2.authorText
		and t1.Performer = t2.Performer
		and t1.custId <> t2.custId
order by t2.ItemName

; with Items as (
	select distinct t1.custId, t2.objId
	from Register t1
		join RegisterItem t2 on t1.regId = t2.regId
	where t1.custId not in (281215, 281540, 39556)
		and objId is not null
)
select distinct t2.ObjId
from Items t1
	join Items t2 on 
			t1.ObjId = t2.ObjId
		and t1.custId <> t2.custId
order by t2.objId

select distinct custId
	from Register t1
		join RegisterItem t2 on t1.regId = t2.regId
	where t1.custId not in (281215, 281540, 39556)
		and objId is not null

select t2.*
from Register t1
	join RegisterItem t2 on t1.regId = t2.regId
where t1.custId not in (281215, 281540, 39556)
	--and objId is null
	and Wic = 0


select t2.*
from SocWid..WidArtist t1
	join SocWid..WidTitle t2 on t1.Wic = t2.Wic
where PerfArtistLstName = 'Bosson'