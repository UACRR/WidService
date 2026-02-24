use SocWidSubmit
go

create or alter view vMapMsgToWia
as
select t1.Id as RecMsgId, t2.RecWiaId as RecWiaId
from RecMsg t1
	join vMapMsgToParentWia t2 on t1.Id = t2.RecMsgId
where t1.RecTypeRef in ('WIA', 'WIU')
go

select * from vMapMsgToWia