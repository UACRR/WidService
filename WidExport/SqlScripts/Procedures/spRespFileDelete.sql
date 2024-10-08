use SocWidSubmit
go

create or alter procedure spRespFileDelete
	@respFileId int
as
begin

-- SubmFileStatus
declare @SubmFileStatusCurrent	 int = 0 -- Поточний
declare @SubmFileStatusSubmitted int = 1 --	Переданий
declare @SubmFileStatusResponded int = 2 --	Відповідь отримана

update t1
set t1.SubmFileStatus = @SubmFileStatusSubmitted
from SubmFile t1
	join RecHdrRsp t2 on t1.Name = t2.FileNameRef
where t2.RespFileId = @respFileId

delete t1
from RespFileErr t1 
	join RecMsg t2 on t1.RecMsgId = t2.Id
where t2.RespFileId = @respFileId

delete from RecMsg where RespFileId = @respFileId
delete from RecAck where RespFileId = @respFileId
delete from RecGrhRsp where RespFileId = @respFileId
delete from RecGrtRsp where RespFileId = @respFileId
delete from RecHdrRsp where RespFileId = @respFileId
delete from RecTrlRsp where RespFileId = @respFileId

delete from RespFile where Id = @respFileId

end
go

-- exec spRespFileDelete 16
