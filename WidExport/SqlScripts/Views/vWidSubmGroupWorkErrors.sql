use SocWidSubmit
go

create or alter view vWidSubmGroupWorkErrors
as
select t1.WidSubmGroupId, t1.ObjId, t2.SubmRecType, t2.RespFileErr, t2.IsFixed, t2.NeedNotFix
	from WidSubmGroupWork t1
		join RespFileErr t2 on t2.SubmRecType = 'WIA' and t1.RecWiaId = t2.SubmRecId
union
select t1.WidSubmGroupId, t1.ObjId, t2.SubmRecType, t2.RespFileErr, t2.IsFixed, t2.NeedNotFix
	from WidSubmGroupWorkName t1
		join RespFileErr t2 on t2.SubmRecType = 'ALT' and t1.RecAltId = t2.SubmRecId
union
select t1.WidSubmGroupId, t1.ObjId, t2.SubmRecType, t2.RespFileErr, t2.IsFixed, t2.NeedNotFix
	from WidSubmGroupWorkPerformer t1
		join RespFileErr t2 on t2.SubmRecType = 'PER' and t1.RecPerId = t2.SubmRecId
union
select t1.WidSubmGroupId, t1.ObjId, t2.SubmRecType, t2.RespFileErr, t2.IsFixed, t2.NeedNotFix
	from WidSubmGroupWorkShare t1
		join RespFileErr t2 on t2.SubmRecType = 'SIP' and t1.RecSipId = t2.SubmRecId
union
select t1.WidSubmGroupId, t1.ObjId, t2.SubmRecType, t2.RespFileErr, t2.IsFixed, t2.NeedNotFix
	from WidSubmGroupWorkShare t1
		join RespFileErr t2 on t2.SubmRecType = 'SSR' and t1.RecSsrPerId = t2.SubmRecId
union
select t1.WidSubmGroupId, t1.ObjId, t2.SubmRecType, t2.RespFileErr, t2.IsFixed, t2.NeedNotFix
	from WidSubmGroupWorkShare t1
		join RespFileErr t2 on t2.SubmRecType = 'SSR' and t1.RecSsrMecId = t2.SubmRecId
union
select t1.WidSubmGroupId, t1.ObjId, t2.SubmRecType, t2.RespFileErr, t2.IsFixed, t2.NeedNotFix
	from WidSubmGroupWorkShare t1
		join RespFileErr t2 on t2.SubmRecType = 'OIP' and t1.RecOipId = t2.SubmRecId
union
select t1.WidSubmGroupId, t1.ObjId, t2.SubmRecType, t2.RespFileErr, t2.IsFixed, t2.NeedNotFix
	from WidSubmGroupWorkShare t1
		join RespFileErr t2 on t2.SubmRecType = 'OSR' and t1.RecOsrPerId = t2.SubmRecId
union
select t1.WidSubmGroupId, t1.ObjId, t2.SubmRecType, t2.RespFileErr, t2.IsFixed, t2.NeedNotFix
	from WidSubmGroupWorkShare t1
		join RespFileErr t2 on t2.SubmRecType = 'OSR' and t1.RecOsrMecId = t2.SubmRecId
go
