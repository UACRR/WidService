use SocWidSubmit
go

create or alter procedure spRespFileProcess
	@respFileId int
as
begin


--declare @respFileId int = 7;
declare @submFileId int = (
	select Id from SubmFile where Name = (select FileNameRef from RecHdrRsp where RespFileId = @respFileId)
)
print @submFileId

declare @GroupId int =  (select WidSubmGroupId from SubmFile where Id = @submFileId)

update t1
set 
	t1.Status = case t3.Status 
					when 'FA' then 5
					when 'RJ' then 6
					else 7 
				end 
from WidSubmGroupWork t1
	join RecWia t2 on t1.RecWiaId = t2.Id
	join RecAck t3 on cast(t2.TransSeqNr as int) = cast(t3.TransSeqNrRef as int)
where t2.SubmFileId = @submFileId
	and t1.WidSubmGroupId = @GroupId
	and t3.RespFileId = @respFileId


/*
insert  RespFileErr (
		SubmRecType
      , SubmRecId
      , RespFileErr
)
*/
drop table if exists #RespFileErr
select
	  t4.Id		   as RecMsgId
	, 'WIA'        as SubmRecType
	, t2.Id		   as SubmRecId
	, t5.Id		   as RespFileErr
into #RespFileErr

from WidSubmGroupWork t1
	join RecWia t2 on t1.RecWiaId = t2.Id
	join RecAck t3 on cast(t2.TransSeqNr as int) = cast(t3.TransSeqNrRef as int)
	left join RecMsg t4 on cast(t3.TransSeqNr as int) = cast(t4.TransSeqNr as int)
		and cast(t2.RecSeqNr as int) = cast(t4.RecSeqNrRef as int)
	join RespFileErrCode t5 on t4.MsgType = t5.MsgType
		and t4.MsgLevel = t5.MsgLevel
		and t4.ErrCondNr = t5.ErrCondNr
where t2.SubmFileId = @submFileId
	and t1.WidSubmGroupId = @GroupId
	and t3.RespFileId = @respFileId

union
select
	  t4.Id
	, 'SIP'
	, t2.Id
	, t5.Id		   as RespFileErr
from WidSubmGroupWorkShare t1
	join RecSip t2 on t1.RecSipId = t2.Id
	join RecAck t3 on cast(t2.TransSeqNr as int) = cast(t3.TransSeqNrRef as int)
	left join RecMsg t4 on cast(t3.TransSeqNr as int) = cast(t4.TransSeqNr as int)
		and cast(t2.RecSeqNr as int) = cast(t4.RecSeqNrRef as int)
	join RespFileErrCode t5 on t4.MsgType = t5.MsgType
		and t4.MsgLevel = t5.MsgLevel
		and t4.ErrCondNr = t5.ErrCondNr
where t2.SubmFileId = @submFileId
	and t1.WidSubmGroupId = @GroupId
	and t3.RespFileId = @respFileId

union
select
	  t4.Id
	, 'SSR'
	, t2.Id
	, t5.Id		   as RespFileErr
from WidSubmGroupWorkShare t1
	join RecSsr t2 on t1.RecSsrPerId = t2.Id
	join RecAck t3 on cast(t2.TransSeqNr as int) = cast(t3.TransSeqNrRef as int)
	left join RecMsg t4 on cast(t3.TransSeqNr as int) = cast(t4.TransSeqNr as int)
		and cast(t2.RecSeqNr as int) = cast(t4.RecSeqNrRef as int)
	join RespFileErrCode t5 on t4.MsgType = t5.MsgType
		and t4.MsgLevel = t5.MsgLevel
		and t4.ErrCondNr = t5.ErrCondNr
where t2.SubmFileId = @submFileId
	and t1.WidSubmGroupId = @GroupId
	and t3.RespFileId = @respFileId

union
select
	  t4.Id
	, 'SSR'
	, t2.Id
	, t5.Id		   as RespFileErr
from WidSubmGroupWorkShare t1
	join RecSsr t2 on t1.RecSsrMecId = t2.Id
	join RecAck t3 on cast(t2.TransSeqNr as int) = cast(t3.TransSeqNrRef as int)
	left join RecMsg t4 on cast(t3.TransSeqNr as int) = cast(t4.TransSeqNr as int)
		and cast(t2.RecSeqNr as int) = cast(t4.RecSeqNrRef as int)
	join RespFileErrCode t5 on t4.MsgType = t5.MsgType
		and t4.MsgLevel = t5.MsgLevel
		and t4.ErrCondNr = t5.ErrCondNr
where t2.SubmFileId = @submFileId
	and t1.WidSubmGroupId = @GroupId
	and t3.RespFileId = @respFileId

union
select
	  t4.Id
	, 'OIP'
	, t2.Id
	, t5.Id		   as RespFileErr
from WidSubmGroupWorkShare t1
	join RecOip t2 on t1.RecOipId = t2.Id
	join RecAck t3 on cast(t2.TransSeqNr as int) = cast(t3.TransSeqNrRef as int)
	left join RecMsg t4 on cast(t3.TransSeqNr as int) = cast(t4.TransSeqNr as int)
		and cast(t2.RecSeqNr as int) = cast(t4.RecSeqNrRef as int)
	join RespFileErrCode t5 on t4.MsgType = t5.MsgType
		and t4.MsgLevel = t5.MsgLevel
		and t4.ErrCondNr = t5.ErrCondNr
where t2.SubmFileId = @submFileId
	and t1.WidSubmGroupId = @GroupId
	and t3.RespFileId = @respFileId

union
select
	  t4.Id
	, 'OSR'
	, t2.Id
	, t5.Id		   as RespFileErr
from WidSubmGroupWorkShare t1
	join RecOsr t2 on t1.RecOsrPerId = t2.Id
	join RecAck t3 on cast(t2.TransSeqNr as int) = cast(t3.TransSeqNrRef as int)
	left join RecMsg t4 on cast(t3.TransSeqNr as int) = cast(t4.TransSeqNr as int)
		and cast(t2.RecSeqNr as int) = cast(t4.RecSeqNrRef as int)
	join RespFileErrCode t5 on t4.MsgType = t5.MsgType
		and t4.MsgLevel = t5.MsgLevel
		and t4.ErrCondNr = t5.ErrCondNr
where t2.SubmFileId = @submFileId
	and t1.WidSubmGroupId = @GroupId
	and t3.RespFileId = @respFileId

union
select
	  t4.Id
	, 'OSR'
	, t2.Id
	, t5.Id		   as RespFileErr
from WidSubmGroupWorkShare t1
	join RecOsr t2 on t1.RecOsrMecId = t2.Id
	join RecAck t3 on cast(t2.TransSeqNr as int) = cast(t3.TransSeqNrRef as int)
	left join RecMsg t4 on cast(t3.TransSeqNr as int) = cast(t4.TransSeqNr as int)
		and cast(t2.RecSeqNr as int) = cast(t4.RecSeqNrRef as int)
	join RespFileErrCode t5 on t4.MsgType = t5.MsgType
		and t4.MsgLevel = t5.MsgLevel
		and t4.ErrCondNr = t5.ErrCondNr
where t2.SubmFileId = @submFileId
	and t1.WidSubmGroupId = @GroupId
	and t3.RespFileId = @respFileId

union
select
	  t4.Id
	, 'ALT'
	, t2.Id
	, t5.Id		   as RespFileErr
from WidSubmGroupWorkName t1
	join RecAlt t2 on t1.RecAltId = t2.Id
	join RecAck t3 on cast(t2.TransSeqNr as int) = cast(t3.TransSeqNrRef as int)
	left join RecMsg t4 on cast(t3.TransSeqNr as int) = cast(t4.TransSeqNr as int)
		and cast(t2.RecSeqNr as int) = cast(t4.RecSeqNrRef as int)
	join RespFileErrCode t5 on t4.MsgType = t5.MsgType
		and t4.MsgLevel = t5.MsgLevel
		and t4.ErrCondNr = t5.ErrCondNr
where t2.SubmFileId = @submFileId
	and t1.WidSubmGroupId = @GroupId
	and t3.RespFileId = @respFileId

union
select
	  t4.Id
	, 'PER'
	, t2.Id
	, t5.Id		   as RespFileErr
from WidSubmGroupWorkPerformer t1
	join RecPer t2 on t1.RecPerId = t2.Id
	join RecAck t3 on cast(t2.TransSeqNr as int) = cast(t3.TransSeqNrRef as int)
	left join RecMsg t4 on cast(t3.TransSeqNr as int) = cast(t4.TransSeqNr as int)
		and cast(t2.RecSeqNr as int) = cast(t4.RecSeqNrRef as int)
	join RespFileErrCode t5 on t4.MsgType = t5.MsgType
		and t4.MsgLevel = t5.MsgLevel
		and t4.ErrCondNr = t5.ErrCondNr
where t2.SubmFileId = @submFileId
	and t1.WidSubmGroupId = @GroupId
	and t3.RespFileId = @respFileId

merge RespFileErr as Tgt
using #RespFileErr	as Src
on Src.SubmRecType = Tgt.SubmRecType
	and Src.SubmRecId = Tgt.SubmRecId
	and Src.RespFileErr = Tgt.RespFileErr
when not matched by Target then
    insert (
		  RecMsgId
		, SubmRecType
		, SubmRecId
		, RespFileErr
		, IsFixed
		, NeedNotFix
	) 
    values (
		  Src.RecMsgId
		, Src.SubmRecType
		, Src.SubmRecId
		, Src.RespFileErr
		, 0
		, 0
	)
when matched then update set
	  Tgt.RecMsgId		= Src.RecMsgId
    , Tgt.SubmRecType	= Src.SubmRecType
    , Tgt.SubmRecId		= Src.SubmRecId
	, Tgt.RespFileErr	= Src.RespFileErr
when not matched by Source then
    delete;

drop table if exists #RespFileErr

drop table if exists #ObjIdToWic
select 
	  t1.ObjId					as ObjId
	, t4.Wic					as Wic
	, trim(isnull(t3.Iswc, '')) as Iswc
into #ObjIdToWic
from WidSubmGroupWork t1
	join RecWia t2 on t1.RecWiaId = t2.Id and t2.SubmFileId = @submFileId
	join RecAck t3 on cast(t2.TransSeqNr as int) = cast(t3.TransSeqNr as int) and t3.RespFileId = @respFileId
	join SocWid..WidIswc t4 on t3.Iswc = t4.Iswc
where trim(isnull(t3.Iswc, '')) <> ''
	and t1.WidSubmGroupId = @GroupId
	and t3.RespFileId = @respFileId

insert ObjIdToWic(ObjId, Wic, Iswc)
select ObjId, Wic, Iswc
from #ObjIdToWic t1
where ObjId not in (
	select ObjId
	from ObjIdToWic t2
	where t1.ObjId = t2.ObjId
)

drop table if exists #ObjIdToWic

-- Позначаємо твори, для яких є ISWC, такими, що не потребують повторної передачі
update t1
set t1.ShouldResubmit = 0
from WidSubmGroupWork t1
where WidSubmGroupId = @GroupId
	and Status in (5, 6, 7) -- responded
	and exists (select null from ObjIdToWic where ObjId = t1.ObjId)

-- Змінюємо статус файлу передачі
update SubmFile set SubmFileStatus = 2 /*responded*/ where Id = @submFileId

end

go

-- exec spRespFileProcess 17


