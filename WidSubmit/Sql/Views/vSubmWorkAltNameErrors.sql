use SocWidSubmitEx
go

create or alter view vSubmWorkAltNameErrors
as
select
      t1.Id as SubmWorkAltNameId
	, t1.SubmWorkId as SubmWorkId
	, t1.OrigNames as OrigNames    
	, t1.NameForWid as NameForWid  
	, t5.MsgTxt
--select *
from SubmWorkAltName t1
	join RecAlt t2 on t1.Id = t2.SubmWorkAltNameId
	left join MsgMapRecAlt t3 on t2.Id = t3.RecAltId
	left join RecMsg t4 on t3.RecMsgId = t4.Id
	left join RecMsgType t5 on t4.RecMsgTypeId = t5.Id
go

