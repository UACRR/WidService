use SocWidSubmit
go

create or alter view vMapWiaToWork
as
select t1.Id as RecWiaId, t2.Id WidSubmGroupWork
from RecWia t1
	join WidSubmGroupWork t2 on t1.SubmWrkNr = concat('MS', t2.ObjId)
go