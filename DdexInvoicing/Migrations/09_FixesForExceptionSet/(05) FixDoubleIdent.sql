use DDEX
go

; with MwIds as (
		  select 26433991	as MwId
	union select 26907948
	union select 26536812
	union select 26536851
	union select 26407480
	union select 26447148
	union select 27045684
	union select 27207984
)
update t2
set t2.ObjId = null
from MwIds t1
	join IdentMw t2 on t1.MwId = t2.Id
	
