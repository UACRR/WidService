use SocWidSubmitEx
go

create or alter procedure spSubmWorksTargetCreate
as
begin
	/*
		Ïğîöåäóğà ñòâîğşº â òàáëèöÿõ Z_*** ³íôîğìàö³ş ïğî òâîğè, ÿêèìè âîëîä³şòü
		ïğàâîâëàñíèêè, âêëş÷åí³ â ïîòî÷íèé ñåàíñ ïóáë³êàö³¿
		ÏĞÎÖÅÄÓĞÀ ²ÄÅÌÏÎÒÅÍÒÍÀ - ÍÅ ÇÀËÅÆÈÒÜ Â²Ä ÏÎÏÅĞÅÄÍÜÎÃÎ ÎÏĞÈÖŞ²ÂÀÍÍß ²ÍÔÎĞÌÀÖ²¯
	*/

	-- ØÓÊÀªÌÎ ÏÅĞÅË²Ê ObjId ßÊÈÌÈ ÂÎËÎÄ²ŞÒÜ ÏĞÀÂÎÂËÀÑÍÈÊÈ ÏÎÒÎ×ÍÎÃÎ ÑÅÀÍÑÓ ÏÓÁË²ÊÀÖ²¯
	drop table if exists #ObjIds
	select distinct t3.ObjId
	into #ObjIds
	from vCurSubmRightHolder t1
		join RightHolder t2 on t1.RightHolderId = t2.Id
		join MediaService..CopyRight t3 on t2.CustId = t3.CustId
		join MediaService..MediaTrack t4 on t3.ObjId = t4.ObjId
	
	-- ÑÒÂÎĞŞªÌÎ ÒÂÎĞÈ
	drop table if exists #SubmWork
	select
	    t1.ObjId								as ObjId
      , null									as Wic
	  , left(trim(isnull(t1.Iswc, '')), 11)		as Iswc
	  , t1.Name									as Name
      , dbo.ClrTranslitFromUkrToLat(t1.Name)	as NameForWid
	into #SubmWork
	from MediaService..MediaTrack t1
		join #ObjIds t2 on t1.ObjId = t2.ObjId
	where t1.Name is not null -- ÇÀÏÎÁ²ÆÍÈÊ, àëå òğàïëÿºòüñÿ

	update t1
	set t1.Wic = t2.Wic
	from #SubmWork t1
		join SocWid..WidIswc t2 on t1.Iswc = t2.Iswc
	where t1.Iswc <> ''
	
	-- ÑÒÂÎĞŞªÌÎ ÏĞÎÖÅÍÒÈ
	drop table if exists #SubmWorkShare
	select
	      t3.Id										as RightHolderId
		, t2.ObjId									as ObjId
		, t2.roleCode								as RhRole
		, dbo.fnGetWidRole(t3.RhType, t2.roleCode)  as RoleForWid
		, t2.rate									as ShrPer
		, t2.rateMech								as ShrMec
	into #SubmWorkShare
	from #ObjIds t1
		join MediaService..CopyRight t2 on t1.ObjId = t2.ObjId
		join vCurRightHolder t3 on t2.CustId = t3.CustId
	where getdate() between t2.beginDate and t2.endDate	
	
	-- ÑÒÂÎĞŞªÌÎ ÀËÜÒÅĞÍÀÒÈÂÍ² ÍÀÇÂÈ
	drop table if exists #SubmWorkAltName

	; with MsAltNames as (
		select distinct t1.ObjId, left(t1.Name, 256) as Name, left(dbo.ClrTranslitFromUkrToLat(t1.Name), 256) as NameForWid
		from MediaService..SeekObject t1
			join #ObjIds t2 on t1.ObjId = t2.ObjId
			join #SubmWork t3 on t1.ObjId = t3.ObjId
		where t1.CodeI = 1
			and trim(t1.Name) <> ''
			and trim(t1.Name) <> trim(t3.Name)
	)
	, AltNames as (
		select ObjId, NameForWid, string_agg(Name, '~') as OrigNames
		from MsAltNames
		where trim(NameForWid) <> trim(Name)
		group by ObjId, NameForWid
	)
	select
		  ObjId		  as ObjId
		, OrigNames	  as OrigNames
		, NameForWid  as NameForWid
	into #SubmWorkAltName
	from AltNames

	-- ÑÒÂÎĞŞªÌÎ ÂÈÊÎÍÀÂÖ²Â
	drop table if exists #SubmWorkPerformer

	; with MsPerformers as (
		select distinct t1.ObjId, left(t1.Name, 256) as Name, left(dbo.ClrTranslitFromUkrToLat(t1.Name), 256) as NameForWid
		from MediaService..SeekObject t1
			join #ObjIds t2 on t1.ObjId = t2.ObjId
		where t1.CodeI = 2
			and trim(t1.Name) <> ''
	)
	, Performers as (
		select ObjId, NameForWid, string_agg(Name, '~') as OrigNames
		from MsPerformers
		where trim(NameForWid) <> trim(Name)
		group by ObjId, NameForWid
	)
	select
		  ObjId		  as ObjId
		, OrigNames	  as OrigNames
		, NameForWid  as NameForWid
	into #SubmWorkPerformer
	from Performers

	-- ÏĞÈÁÈĞÀªÌÎ ĞÎÁÎ×² ÄÀÍ²
	exec spZ_SubmWorksDeleteAll

	-- ÏÅĞÅÄÀªÌÎ Â ĞÎÁÎ×² ÒÀÁËÈÖ²
	insert Z_SubmWork (
		   SubmissionId
		,  ObjId
		,  Wic
		,  Iswc
		,  Name
		,  NameForWid
		,  IsChanged
		,  CreatedAt
		,  UpdatedAt
	)
	select
		   0						as SubmissionId
		,  ObjId					as ObjId
		,  Wic						as Wic
		,  Iswc						as Iswc
		,  left(Name, 256)			as Name
		,  left(NameForWid, 256)	as NameForWid
		,  0						as IsChanged
		,  getdate()				as CreatedAt
		,  null						as UpdatedAt
	from #SubmWork

	insert Z_SubmWorkShare (
	    SubmWorkId
      , RightHolderId
      , RhRole
      , RoleForWid
      , ShrPer
      , ShrMec
      , CreatedAt
      , UpdatedAt
	)
	select
	    t1.Id as SubmWorkId
      , t2.RightHolderId as RightHolderId
      , t2.RhRole as RhRole
      , t2.RoleForWid as RoleForWid
      , t2.ShrPer as ShrPer
      , t2.ShrMec as ShrMec
      , getdate() as CreatedAt
      , null as UpdatedAt
	from Z_SubmWork t1
		join #SubmWorkShare t2 on t1.ObjId = t2.ObjId

	insert Z_SubmWorkAltName (
	    SubmWorkId
      , OrigNames
      , NameForWid
      , CreatedAt
      , UpdatedAt
	)
	select
	    t1.Id			as SubmWorkId
      , t2.OrigNames	as OrigNames
      , t2.NameForWid	as NameForWid
      , getdate()		as CreatedAt
      , null			as UpdatedAt
	from Z_SubmWork t1
		join #SubmWorkAltName t2 on t1.ObjId = t2.ObjId

	insert Z_SubmWorkPerformer (
	    SubmWorkId
      , OrigNames
      , NameForWid
      , CreatedAt
      , UpdatedAt
	)
	select
	    t1.Id			as SubmWorkId
      , t2.OrigNames	as OrigNames
      , t2.NameForWid	as NameForWid
      , getdate()		as CreatedAt
      , null			as UpdatedAt
	from Z_SubmWork t1
		join #SubmWorkPerformer t2 on t1.ObjId = t2.ObjId

	-- ÑÒÂÎĞŞªÌÎ ÕÅØ ÄËß ÒÂÎĞ²Â Â ĞÎÁÎ×ÈÕ ÒÀÁËÈÖßÕ
	exec spZ_SubmWorksHashUpdate
end

-- exec spSubmWorksTargetCreate
-- select * from Z_SubmWork