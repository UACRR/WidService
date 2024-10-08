drop index if exists WidSubmGroupWork_WidSubmGroupId 
on WidSubmGroupWork
create nonclustered index WidSubmGroupWork_WidSubmGroupId 
on WidSubmGroupWork(WidSubmGroupId)
go

drop index if exists WidSubmGroupWork_ObjId 
on WidSubmGroupWork
create nonclustered index WidSubmGroupWork_ObjId 
on WidSubmGroupWork(ObjId)
go

drop index if exists WidSubmGroupWorkCheckList_WidSubmGroupId 
on WidSubmGroupWorkCheckList
create nonclustered index WidSubmGroupWorkCheckList_WidSubmGroupId 
on WidSubmGroupWorkCheckList(WidSubmGroupId)
go

drop index if exists WidSubmGroupWorkCheckList_ObjId 
on WidSubmGroupWorkCheckList
create nonclustered index WidSubmGroupWorkCheckList_ObjId 
on WidSubmGroupWorkCheckList(ObjId)
go

/*
drop index if exists WidSubmGroupWorkHash_WidSubmGroupId 
on WidSubmGroupWork
create nonclustered index WidSubmGroupWorkHash_WidSubmGroupId 
on WidSubmGroupWorkHash(WidSubmGroupId)
go
*/

drop index if exists WidSubmGroupWorkHash_ObjId 
on WidSubmGroupWorkHash
create nonclustered index WidSubmGroupWorkHash_ObjId 
on WidSubmGroupWorkHash(ObjId)
go

drop index if exists WidSubmGroupWorkName_WidSubmGroupId 
on WidSubmGroupWorkName
create nonclustered index WidSubmGroupWorkName_WidSubmGroupId 
on WidSubmGroupWorkName(WidSubmGroupId)
go

drop index if exists WidSubmGroupWorkName_ObjId 
on WidSubmGroupWorkName
create nonclustered index WidSubmGroupWorkName_ObjId 
on WidSubmGroupWorkName(ObjId)
go

drop index if exists WidSubmGroupWorkPerformer_WidSubmGroupId 
on WidSubmGroupWorkPerformer
create nonclustered index WidSubmGroupWorkPerformer_WidSubmGroupId 
on WidSubmGroupWorkPerformer(WidSubmGroupId)
go

drop index if exists WidSubmGroupWorkPerformer_ObjId 
on WidSubmGroupWorkPerformer
create nonclustered index WidSubmGroupWorkPerformer_ObjId 
on WidSubmGroupWorkPerformer(ObjId)
go

drop index if exists WidSubmGroupWorkShare_WidSubmGroupId 
on WidSubmGroupWorkShare
create nonclustered index WidSubmGroupWorkShare_WidSubmGroupId 
on WidSubmGroupWorkShare(WidSubmGroupId)
go

drop index if exists WidSubmGroupWorkShare_ObjId 
on WidSubmGroupWorkShare
create nonclustered index WidSubmGroupWorkShare_ObjId 
on WidSubmGroupWorkShare(ObjId)
go

drop index if exists ObjIdToWic_ObjId 
on ObjIdToWic
create nonclustered index ObjIdToWic_ObjId 
on ObjIdToWic(ObjId)
go