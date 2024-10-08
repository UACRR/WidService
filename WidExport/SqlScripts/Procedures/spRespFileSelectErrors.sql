use SocWidSubmit
go

/*
create or alter procedure spRespFileSelectErrors
	  @respFileId int
	, @objId int
as
begin
*/

declare @respFileId int = 7
declare @objId int = 8065

declare @submFileName varchar(100) = (
	select FileNameRef from RecHdrRsp where RespFileId = @respFileId
)
--print @submFileName

declare @submFileId int = (
	select Id from SubmFile where Name = @submFileName
)
--print @submFileId

declare @submTranSeqNr int = (
	select TransSeqNr from RecWia where SubmFileId = @submFileId and cast(SubmWrkNr as int) = @objId
)
--print @submTranSeqNr

declare @respTranSeqNr int = (
	select TransSeqNr from RecAck where RespFileId = @respFileId and cast(TransSeqNrRef as int) = @submTranSeqNr
)
print @respTranSeqNr

drop table if exists #RecMsg
select *
into #RecMsg
from RecMsg
where RespFileId = @respFileId and TransSeqNr = @respTranSeqNr

select 
	  t1.RecType				as RecType
	, t1.SubmWrkNr				as RefInfo
	, t1.WrkTtl					as DescInfo
	, t2.MsgType				as MsgType
	, t2.MsgLevel				as MsgLevel
	, t2.ErrCondNr				as ErrCondNr
	, t2.MsgTxt					as MsgTxt
	, cast(t1.RecSeqNr as int)	as RecSeqNr
from RecWia t1
	left join #RecMsg t2 on t1.RecSeqNr = t2.RecSeqNrRef
where t1.SubmFileId = @submFileId
	and t1.TransSeqNr = @submTranSeqNr

union
select 
	  t1.RecType				 as RecType
	, t1.IpNameNr				 as RefInfo
	, t1.IpName					 as DescInfo
	, t2.MsgType				 as MsgType
	, t2.MsgLevel				 as MsgLevel
	, t2.ErrCondNr				 as ErrCondNr
	, t2.MsgTxt					 as MsgTxt
	, cast(t1.RecSeqNr as int)	 as RecSeqNr
from RecSip t1
	left join #RecMsg t2 on t1.RecSeqNr = t2.RecSeqNrRef
where t1.SubmFileId = @submFileId
	and t1.TransSeqNr = @submTranSeqNr

union
select 
	  t1.RecType				as RecType
	, t1.IpNameNr				as RefInfo
	, t1.IpName					as DescInfo
	, t2.MsgType				as MsgType
	, t2.MsgLevel				as MsgLevel
	, t2.ErrCondNr				as ErrCondNr
	, t2.MsgTxt					as MsgTxt
	, cast(t1.RecSeqNr as int)	as RecSeqNr
from RecOip t1
	left join #RecMsg t2 on t1.RecSeqNr = t2.RecSeqNrRef
where t1.SubmFileId = @submFileId
	and t1.TransSeqNr = @submTranSeqNr

union
select 
	  t1.RecType				as RecType
	, t1.RightType				as RefInfo
	, t1.Shares					as DescInfo
	, t2.MsgType				as MsgType
	, t2.MsgLevel				as MsgLevel
	, t2.ErrCondNr				as ErrCondNr
	, t2.MsgTxt					as MsgTxt
	, cast(t1.RecSeqNr as int)	as RecSeqNr
from RecSsr t1
	left join #RecMsg t2 on t1.RecSeqNr = t2.RecSeqNrRef
where t1.SubmFileId = @submFileId
	and t1.TransSeqNr = @submTranSeqNr

union
select 
	  t1.RecType				as RecType
	, t1.RightType				as RefInfo
	, t1.Shares					as DescInfo
	, t2.MsgType				as MsgType
	, t2.MsgLevel				as MsgLevel
	, t2.ErrCondNr				as ErrCondNr
	, t2.MsgTxt					as MsgTxt
	, cast(t1.RecSeqNr as int)	as RecSeqNr
from RecOsr t1
	left join #RecMsg t2 on t1.RecSeqNr = t2.RecSeqNrRef
where t1.SubmFileId = @submFileId
	and t1.TransSeqNr = @submTranSeqNr

union
select 
	  t1.RecType				as RecType
	, t1.AltTtl					as RefInfo
	, t1.AltTtl					as DescInfo
	, t2.MsgType				as MsgType
	, t2.MsgLevel				as MsgLevel
	, t2.ErrCondNr				as ErrCondNr
	, t2.MsgTxt					as MsgTxt
	, cast(t1.RecSeqNr as int)	as RecSeqNr
from RecAlt t1
	left join #RecMsg t2 on t1.RecSeqNr = t2.RecSeqNrRef
where t1.SubmFileId = @submFileId
	and t1.TransSeqNr = @submTranSeqNr	

union
select 
	  t1.RecType				as RecType
	, t1.PerfArtistLstName		as RefInfo
	, t1.PerfArtistLstName		as DescInfo
	, t2.MsgType				as MsgType
	, t2.MsgLevel				as MsgLevel
	, t2.ErrCondNr				as ErrCondNr
	, t2.MsgTxt					as MsgTxt
	, cast(t1.RecSeqNr as int)	as RecSeqNr
from RecPer t1
	left join #RecMsg t2 on t1.RecSeqNr = t2.RecSeqNrRef
where t1.SubmFileId = @submFileId
	and t1.TransSeqNr = @submTranSeqNr	

order by RecSeqNr




drop table if exists #RecMsg

/*
end
go
*/

-- exec spSubmFileClear 1
