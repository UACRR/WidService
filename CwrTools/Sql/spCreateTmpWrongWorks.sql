use CWR
go

create or alter procedure spCreateTmpWrongWorks
as
begin

exec spCreateCopyRightHistoryOutline

-- Твори де не визначена роль правовласника
drop table if exists TmpObjIdsUndefinedRole
	select distinct t1.ObjId
	into TmpObjIdsUndefinedRole
	from TmpObjIdsInitial t1
		join vWorkRightHoldersCurrent t2 on t1.ObjId = t2.ObjId
		left join Z_CopyRightHistoryOutline t3 on t2.CopyRightId = t3.CopyRightId
	where dbo.fnCheckRoleDefined(t2.RightHolderType, t2.RoleCode) = 0
		and (t3.CopyRightRoleNew is null or t3.CopyRightRoleNew = 0)

-- Твори де сума Пуб більше 100%
drop table if exists TmpObjIdsWrongShrPer
	select t1.ObjId, sum(t2.PerShr) as ShrPer
	into TmpObjIdsWrongShrPer
	from TmpObjIdsInitial t1
		join vWorkRightHoldersCurrent t2 on t1.ObjId = t2.ObjId
	group by t1.ObjId
	having sum(t2.PerShr) > 100

-- Твори де сума Мех більше 100%
drop table if exists TmpObjIdsWrongShrPer
	select t1.ObjId, sum(t2.MecShr) as ShrMec
	into TmpObjIdsWrongShrPer
	from TmpObjIdsInitial t1
		join vWorkRightHoldersCurrent t2 on t1.ObjId = t2.ObjId
	group by t1.ObjId
	having sum(t2.MecShr) > 100

-- Твори де правовлисники вказані двічі з однаковою творчою роллю
drop table if exists TmpObjIdsWrongDupRoles
	select t1.ObjId, t2.custId, t2.roleCode, count(*) cnt
	into TmpObjIdsWrongDupRoles
	from TmpObjIdsInitial t1
		join vWorkRightHoldersCurrent t2 on t1.ObjId = t2.ObjId
	group by t1.ObjId, t2.custId, t2.roleCode
	having count(*) > 1

-- Твори де видавці вказані двічі
drop table if exists TmpObjIdsWrongPublishers
	select t1.ObjId, t2.custId, count(*) cnt
	into TmpObjIdsWrongPublishers
	from TmpObjIdsInitial t1
		join vWorkRightHoldersCurrent t2 on t1.ObjId = t2.ObjId
	where t2.RightHolderType = 3
	group by t1.ObjId, t2.custId
	having count(*) > 1

-- Твори де вказані невірні ISWC
drop table if exists TmpObjIdsWrongIswcs
	select t1.ObjId, t2.Iswc
	into TmpObjIdsWrongIswcs
	from TmpObjIdsInitial t1
		join MediaService..MediaTrack t2 on t1.ObjId = t2.ObjId
	where dbo.fnCheckIswc(t2.Iswc) = 0

-- Твори де відсутня назва
drop table if exists TmpObjIdsNoName
	select t1.ObjId
	into TmpObjIdsNoName
	from TmpObjIdsInitial t1
		join MediaService..ObjectRight t2 on t1.ObjId = t2.ObjId
	where trim(isnull(Name, '')) = ''

-- В підсумку
drop table if exists TmpWrongWorks
	create table TmpWrongWorks (
		  ObjId				int
		, UndefRole			bit default(0)
		, WrongPerShr		bit default(0)
		, WrongMecShr		bit default(0)
		, DupRightHolder	bit default(0)
		, DupPublisher		bit default(0)
		, WrongIswc			bit default(0)
		, NoName			bit default(0)
	)

	; with WrongObjIds as (
		      select ObjId from TmpObjIdsUndefinedRole
		union select ObjId from TmpObjIdsWrongShrPer
		union select ObjId from TmpObjIdsWrongShrMec
		union select ObjId from TmpObjIdsWrongDupRoles
		union select ObjId from TmpObjIdsWrongPublishers
		union select ObjId from TmpObjIdsWrongIswcs
		union select ObjId from TmpObjIdsNoName
	)
	insert TmpWrongWorks (ObjId) select ObjId from WrongObjIds

	update t1 set t1.UndefRole		 = 1 from TmpWrongWorks t1 join TmpObjIdsUndefinedRole		t2 on t1.ObjId = t2.ObjId
	update t1 set t1.WrongPerShr	 = 1 from TmpWrongWorks t1 join TmpObjIdsWrongShrPer		t2 on t1.ObjId = t2.ObjId
	update t1 set t1.WrongMecShr	 = 1 from TmpWrongWorks t1 join TmpObjIdsWrongShrMec		t2 on t1.ObjId = t2.ObjId
	update t1 set t1.DupRightHolder  = 1 from TmpWrongWorks t1 join TmpObjIdsWrongDupRoles		t2 on t1.ObjId = t2.ObjId
	update t1 set t1.DupPublisher	 = 1 from TmpWrongWorks t1 join TmpObjIdsWrongPublishers	t2 on t1.ObjId = t2.ObjId
	update t1 set t1.WrongIswc		 = 1 from TmpWrongWorks t1 join TmpObjIdsWrongIswcs			t2 on t1.ObjId = t2.ObjId
	update t1 set t1.NoName		     = 1 from TmpWrongWorks t1 join TmpObjIdsNoName				t2 on t1.ObjId = t2.ObjId

-- ДОДАТКОВО
drop table if exists TmpUndefinedRoleRightHolders
	select distinct t3.CustId, t3.Name
	into TmpUndefinedRoleRightHolders
	from TmpObjIdsInitial t1
		join vWorkRightHoldersCurrent t2 on t1.ObjId = t2.ObjId
		join MediaService ..vCustomerNames t3 on t2.custId = t3.custId
	where dbo.fnCheckRoleDefined(t2.RightHolderType, t2.RoleCode) = 0

end


go

-- exec spCreateTmpWrongWorks
-- select * from TmpWrongWorks where UndefRole = 1