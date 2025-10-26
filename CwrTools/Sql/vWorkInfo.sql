use CWR
go

create or alter view vWorkInfo
as
with Works as (
	select t1.ObjId, isnull(t1.Name, '') as Name, t3.CodeI as CatCode, t3.Name as CatName, isnull(t2.Iswc, '') as Iswc
	from MediaService..ObjectRight t1
		left join MediaService..MediaTrack t2 on t1.ObjId = t2.ObjId
		join MediaService..Category t3 on t1.categoryCode = t3.codeI
),
Shares as (
	select ObjId, sum(PerShr) as PerShr, sum(MecShr) as MecShr
	from vWorkRightHoldersCurrent
	group by ObjId
)
select t1.ObjId, t1.Name, t1.CatCode, t1.Iswc, t2.PerShr, t2.MecShr
from Works t1
	join Shares t2 on t1.ObjId = t2.ObjId
go

-- select * from vWorkInfo where ObjId = 50572
