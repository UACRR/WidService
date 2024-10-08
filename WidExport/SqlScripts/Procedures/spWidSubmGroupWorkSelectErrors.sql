use SocWidSubmit
go

create or alter procedure spWidSubmGroupWorkSelectErrors
	  @GroupId int
	, @objId int
as
begin

declare @SubmFileName varchar(max) = (select max(name) from SubmFile where WidSubmGroupId = @GroupId)
declare @SubmFileId int = (select id from SubmFile where Name = @SubmFileName)
declare @RespFileId int = (select RespFileId from RecHdrRsp where FileNameRef = @SubmFileName)

if @RespFileId is null
begin
	return
end

; with Res as (
select 
	  t2.RecType as ItemType
	, t2.Id as SourceId
	, t2.WrkTtl as Name
	, t3.RespFileErr as ErrorCode
	, t4.MsgTxt as ErrorText
	, t2.TransSeqNr as TransSeqNr
	, t2.RecSeqNr as RecSeqNr
from WidSubmGroupWork t1
	join RecWia t2 on t1.RecWiaId = t2.Id
	join RespFileErr t3 on t2.Id = t3.SubmRecId
	left join RespFileErrCode t4 on t3.RespFileErr = t4.Id
	join RecMsg t5 on t3.RecMsgId = t5.Id
where t1.WidSubmGroupId = @GroupId
	and t1.ObjId = @objId
	and t2.SubmFileId = @SubmFileId
	and t5.RespFileId = @RespFileId

union
select
	  t3.RecType as ItemType
	, t3.Id as SourceId
	, concat(
			trim(concat(t3.IpName, ' ', t3.IpFstName))
			, ', '
			, case 
				when t3.IpRole = 'C' then 'композитор'
				when t3.IpRole = 'CA' then 'композитор/автор тексту'
				when t3.IpRole = 'A' then 'автор тексту'
				when t3.IpRole = 'E' then 'видавець'
				else 'невідома роль'
			  end
	  )												as Name
	, t4.RespFileErr as ErrorCode
	, t5.MsgTxt as ErrorText
	, t3.TransSeqNr as TransSeqNr
	, t3.RecSeqNr as RecSeqNr
from WidSubmGroupWork t1
	join WidSubmGroupWorkShare t2 on t1.ObjId = t2.ObjId
	join RecSip t3 on t2.RecSipId = t3.Id
	join RespFileErr t4 on t3.Id = t4.SubmRecId
	left join RespFileErrCode t5 on t4.RespFileErr = t5.Id
	join RecMsg t6 on t4.RecMsgId = t6.Id
where t1.WidSubmGroupId = @GroupId
	and t1.ObjId = @objId
	and t3.SubmFileId = @SubmFileId
	and t6.RespFileId = @RespFileId

union
select
	  concat(t3.RecType, t3.RightType) as ItemType
	, t3.Id as SourceId
	, t3.Shares as Name
	, t4.RespFileErr as ErrorCode
	, t5.MsgTxt as ErrorText
	, t3.TransSeqNr as TransSeqNr
	, t3.RecSeqNr as RecSeqNr
from WidSubmGroupWork t1
	join WidSubmGroupWorkShare t2 on t1.ObjId = t2.ObjId
	join RecSsr t3 on t2.RecSsrPerId = t3.Id
	join RespFileErr t4 on t3.Id = t4.SubmRecId
	left join RespFileErrCode t5 on t4.RespFileErr = t5.Id
	join RecMsg t6 on t4.RecMsgId = t6.Id
where t1.WidSubmGroupId = @GroupId
	and t1.ObjId = @objId
	and t3.SubmFileId = @SubmFileId
	and t6.RespFileId = @RespFileId

union
select
	  concat(t3.RecType, t3.RightType) as ItemType
	, t3.Id as SourceId
	, t3.Shares as Name
	, t4.RespFileErr as ErrorCode
	, t5.MsgTxt as ErrorText
	, t3.TransSeqNr as TransSeqNr
	, t3.RecSeqNr as RecSeqNr
from WidSubmGroupWork t1
	join WidSubmGroupWorkShare t2 on t1.ObjId = t2.ObjId
	join RecSsr t3 on t2.RecSsrMecId = t3.Id
	join RespFileErr t4 on t3.Id = t4.SubmRecId
	left join RespFileErrCode t5 on t4.RespFileErr = t5.Id
	join RecMsg t6 on t4.RecMsgId = t6.Id
where t1.WidSubmGroupId = @GroupId
	and t1.ObjId = @objId
	and t3.SubmFileId = @SubmFileId
	and t6.RespFileId = @RespFileId

union
select
	  t3.RecType as ItemType
	, t3.Id as SourceId
	, concat(
			trim(concat(t3.IpName, ' ', t3.IpFstName))
			, ', '
			, case 
				when t3.IpRole = 'C' then 'композитор'
				when t3.IpRole = 'CA' then 'композитор/автор тексту'
				when t3.IpRole = 'A' then 'автор тексту'
				when t3.IpRole = 'E' then 'видавець'
				else 'невідома роль'
			  end
	  )												as Name
	, t4.RespFileErr as ErrorCode
	, t5.MsgTxt as ErrorText
	, t3.TransSeqNr as TransSeqNr
	, t3.RecSeqNr as RecSeqNr
from WidSubmGroupWork t1
	join WidSubmGroupWorkShare t2 on t1.ObjId = t2.ObjId
	join RecOip t3 on t2.RecOipId = t3.Id
	join RespFileErr t4 on t3.Id = t4.SubmRecId
	left join RespFileErrCode t5 on t4.RespFileErr = t5.Id
	join RecMsg t6 on t4.RecMsgId = t6.Id
where t1.WidSubmGroupId = @GroupId
	and t1.ObjId = @objId
	and t3.SubmFileId = @SubmFileId
	and t6.RespFileId = @RespFileId

union
select
	  concat(t3.RecType, t3.RightType) as ItemType
	, t3.Id as SourceId
	, t3.Shares as Name
	, t4.RespFileErr as ErrorCode
	, t5.MsgTxt as ErrorText
	, t3.TransSeqNr as TransSeqNr
	, t3.RecSeqNr as RecSeqNr
from WidSubmGroupWork t1
	join WidSubmGroupWorkShare t2 on t1.ObjId = t2.ObjId
	join RecOsr t3 on t2.RecOsrPerId = t3.Id
	join RespFileErr t4 on t3.Id = t4.SubmRecId
	left join RespFileErrCode t5 on t4.RespFileErr = t5.Id
	join RecMsg t6 on t4.RecMsgId = t6.Id
where t1.WidSubmGroupId = @GroupId
	and t1.ObjId = @objId
	and t3.SubmFileId = @SubmFileId
	and t6.RespFileId = @RespFileId

union
select
	  concat(t3.RecType, t3.RightType) as ItemType
	, t3.Id as SourceId
	, t3.Shares as Name
	, t4.RespFileErr as ErrorCode
	, t5.MsgTxt as ErrorText
	, t3.TransSeqNr as TransSeqNr
	, t3.RecSeqNr as RecSeqNr
from WidSubmGroupWork t1
	join WidSubmGroupWorkShare t2 on t1.ObjId = t2.ObjId
	join RecOsr t3 on t2.RecOsrMecId = t3.Id
	join RespFileErr t4 on t3.Id = t4.SubmRecId
	left join RespFileErrCode t5 on t4.RespFileErr = t5.Id
	join RecMsg t6 on t4.RecMsgId = t6.Id
where t1.WidSubmGroupId = @GroupId
	and t1.ObjId = @objId
	and t3.SubmFileId = @SubmFileId
	and t6.RespFileId = @RespFileId

union
select
	  t3.RecType as ItemType
	, t3.Id as SourceId
	, t3.AltTtl as Name
	, t4.RespFileErr as ErrorCode
	, t5.MsgTxt as ErrorText
	, t3.TransSeqNr as TransSeqNr
	, t3.RecSeqNr as RecSeqNr
from WidSubmGroupWork t1
	join WidSubmGroupWorkName t2 on t1.ObjId = t2.ObjId
	join RecAlt t3 on t2.RecAltId = t3.Id
	join RespFileErr t4 on t3.Id = t4.SubmRecId
	left join RespFileErrCode t5 on t4.RespFileErr = t5.Id
	join RecMsg t6 on t4.RecMsgId = t6.Id
where t1.WidSubmGroupId = @GroupId
	and t1.ObjId = @objId
	and t3.SubmFileId = @SubmFileId
	and t6.RespFileId = @RespFileId

union
select
	  t3.RecType as ItemType
	, t3.Id as SourceId
	, trim(concat(t3.PerfArtistFstName, ' ', t3.PerfArtistLstName)) as Name
	, t4.RespFileErr as ErrorCode
	, t5.MsgTxt as ErrorText
	, t3.TransSeqNr as TransSeqNr
	, t3.RecSeqNr as RecSeqNr
from WidSubmGroupWork t1
	join WidSubmGroupWorkPerformer t2 on t1.ObjId = t2.ObjId
	join RecPer t3 on t2.RecPerId = t3.Id
	join RespFileErr t4 on t3.Id = t4.SubmRecId
	left join RespFileErrCode t5 on t4.RespFileErr = t5.Id
	join RecMsg t6 on t4.RecMsgId = t6.Id
where t1.WidSubmGroupId = @GroupId
	and t1.ObjId = @objId
	and t3.SubmFileId = @SubmFileId
	and t6.RespFileId = @RespFileId
)


select *
from Res
order by cast(TransSeqNr as int), cast(RecSeqNr as int)
--where t1.Id = @WidSubmGroupWorkId

end
go

-- exec spWidSubmGroupWorkSelectErrors 3, 875083
