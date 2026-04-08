use SocWidSubmitEx
go

create or alter view vSubmWorkErrors
as
select t1.*, t5.MsgTxt
from SubmWork t1
	join RecWiaWiu t2 on t1.Id = t2.SubmWorkId
	left join MsgMapRecWiaWiu t3 on t2.Id = t3.RecWiaWiuId
	left join RecMsg t4 on t3.RecMsgId = t4.Id
	left join RecMsgType t5 on t4.RecMsgTypeId = t5.Id
go
