use SocWidSubmitEx
go

create or alter view vSubmWorkPerformerErrors
as
select
      t1.Id as SubmWorkPerformerId
	, t1.SubmWorkId as SubmWorkId
	, t1.OrigNames as OrigNames    
	, t1.NameForWid as NameForWid  
	, t5.MsgTxt
--select *
from SubmWorkPerformer t1
	join RecPer t2 on t1.Id = t2.SubmWorkPerformerId
	left join MsgMapRecPer t3 on t2.Id = t3.RecPerId
	left join RecMsg t4 on t3.RecMsgId = t4.Id
	left join RecMsgType t5 on t4.RecMsgTypeId = t5.Id
go

