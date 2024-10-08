USE [SocWidSubmit]
GO
/****** Object:  StoredProcedure [dbo].[spRefreshWicIswc]    Script Date: 17.05.2024 14:08:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER   procedure [dbo].[spRefreshWicIswc]
	@groupId as int
as
begin

declare @submFileId int
	, @submFileName varchar(max) 
select top 1 
	  @submFileId = Id
	, @submFileName = Name
from SubmFile 
where WidSubmGroupId = @groupId
order by Name desc

declare @respFileId int = (select RespFileId from RecHdrRsp where FileNameRef = @submFileName)

if @respFileId is null return

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
	and t1.WidSubmGroupId = @groupId
	and t3.RespFileId = @respFileId

merge ObjIdToWic as Target
		using #ObjIdToWic as Source
		on Source.ObjId = Target.ObjId
		-- For Inserts
		when not matched by Target then
			insert (ObjId, Wic, Iswc) 
			values (Source.ObjId, Source.Wic, Source.Iswc)
 		-- For Updates
		when matched then update set
			  Target.Wic = Source.Wic
			, Target.Iswc = Source.Iswc	
		;

drop table if exists #ObjIdToWic

-- Позначаємо твори, для яких є ISWC, такими, що не потребують повторної передачі
update t1
set t1.ShouldResubmit = 0
from WidSubmGroupWork t1
where WidSubmGroupId = @groupId
	and Status in (5, 6, 7) -- responded
	and exists (select null from ObjIdToWic where ObjId = t1.ObjId)

end

