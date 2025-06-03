-- T3200219149 - 41335791
-- t3112688098
-- T3200219172
-- t3104121662 - 38789276

select *
from WidIswc
where Iswc in ('T3200219149', 't3112688098', 'T3200219172', 't3104121662')

select *
from WidTitle t1
	join WidArtist t2 on t1.Wic = t2.Wic
	left join WidIswc t3 on t1.Wic = t3.Wic
where t1.WrkTtl like '%BREAK MY SOUL%'
	and t2.PerfArtistLstName like '%beyonce%'