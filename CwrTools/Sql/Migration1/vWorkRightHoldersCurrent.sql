use CWR
go

create or alter view vWorkRightHoldersCurrent
as
select
	   t1.cRightId					as [CopyRightId]
	 , t1.ObjId						as [ObjId]
	 , t1.roleCode					as [RoleCode]
	 , t1.CustId					as [CustId]
	 , t2.rHolderType				as [RightHolderType]
	 , isnull(t2.interCode, '')		as [IpBaseNr]
	 , isnull(t2.IPIBase, '')		as [IpNameNr]
	 , isnull(t1.rate, 0.00)		as [PerShr]
	 , isnull(t1.rateMech, 0.00)	as [MecShr]
	 , cast(1 as bit)				as [IsOwn]
	 , t2.aroundWord				as [AroundWord]
from MediaService..CopyRight t1
	join vRightHoldersOwnActive t2 on t1.CustId = t2.CustId
where dbo.fnIsDateInInterval(getdate(), t1.beginDate, t1.endDate) = 1
union
select
	   t1.cRightId					as [CopyRightId]
	 , t1.ObjId						as [ObjId]
	 , t1.roleCode					as [RoleCode]
	 , t1.CustId					as [CustId]
	 , t2.rHolderType				as [RightHolderType]
	 , isnull(t2.interCode, '')		as [IpBaseNr]
	 , isnull(t2.IPIBase, '')		as [IpNameNr]
	 , isnull(t1.rate, 0.00)		as [PerShr]
	 , isnull(t1.rateMech, 0.00)	as [MecShr]
	 , cast(0 as bit)				as [IsOwn]
	 , t2.aroundWord				as [AroundWord]
from MediaService..CopyRight t1
	join vRightHoldersForeign t2 on t1.CustId = t2.CustId
where dbo.fnIsDateInInterval(getdate(), t1.beginDate, t1.endDate) = 1
go

-- select * from vWorkRightHoldersCurrent where CustId = 39689 and dbo.fnCheckRoleDefined([RightHolderType], [RoleCode]) = 1
