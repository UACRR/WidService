use CWR
go

create or alter procedure spDropTmpTables
as
begin
	drop table TmpObjIdsFinal
	drop table TmpObjIdsInitial
	drop table TmpObjIdsWrongDupRoles
	drop table TmpObjIdsWrongPublishers
	drop table TmpObjIdsWrongShrMec
	drop table TmpObjIdsWrongShrPer
	drop table TmpWorksAlt
	drop table TmpWorksNwr
	drop table TmpWorksOpu
	drop table TmpWorksOwr
	drop table TmpWorksPer
	drop table TmpWorksSpu
	drop table TmpWorksSwr
end
go

-- exec spDropTmpTables
