use SocWidSubmit
go

create or alter procedure spRespFileClear
	@respFileId int
as
begin

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
end
go

-- exec spRespFileClear 10
