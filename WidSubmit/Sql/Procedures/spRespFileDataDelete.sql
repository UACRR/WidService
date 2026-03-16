use SocWidSubmitEx
go

create or alter procedure spRespFileDataDelete
	@skipZTables bit = 0

as
begin
	if @skipZTables = 0
	begin
		truncate table Z_RecAck
		truncate table Z_RecMsg
	end

	delete t1 from RecAck t1 join vCurSubmRecWiaWiu t2 on t1.RecWiaWiuId = t2.Id

	drop table if exists #MsgIds
	select Id into #MsgIds from vCurSubmRecMsg

	delete t1 from MsgMapRecWiaWiu t1 join #MsgIds t2 on t1.RecMsgId = t2.Id
	delete t1 from MsgMapRecSipOip t1 join #MsgIds t2 on t1.RecMsgId = t2.Id
	delete t1 from MsgMapRecSsrOsr t1 join #MsgIds t2 on t1.RecMsgId = t2.Id
	delete t1 from MsgMapRecAlt    t1 join #MsgIds t2 on t1.RecMsgId = t2.Id
	delete t1 from MsgMapRecPer    t1 join #MsgIds t2 on t1.RecMsgId = t2.Id
	delete t1 from RecMsg	       t1 join #MsgIds t2 on t1.Id       = t2.Id

end
go