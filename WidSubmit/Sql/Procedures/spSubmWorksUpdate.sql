use SocWidSubmitEx
go

create or alter procedure spSubmWorksUpdate
as
begin

	/*
		гЛЁМЧ╨ РБНПХ ОНРНВМНЦН ЯЕЮМЯС АЮГСЧВХЯЭ МЮ ОНРНВМХУ ДЮМХУ ЁГ ялюпр
	*/

	-- опхахпю╙лн гюохях ъй╡ бхмхйкх опх ярбнпемм╡ тюикс дкъ осак╡йюж╡╞
	exec spCurSubmFileRecsClear

	-- яоепь нмнбкч╙лн опюбнбкюямхй╡б
	exec spRightHoldersUpdate

	-- оепеоняхкю╙лн опюбнбкюямхй╡б онрнвмнцн яеюмяс мю нярюмм╡у б ╡ярнп╡╞
	update t1
	set t1.RightHolderId = t4.Id
	-- select *
	from SubmRightHolder t1
		join vCurSubmRightHolder t2 on t1.Id = t2.Id
		join RightHolder t3 on t1.RightHolderId = t3.Id
		join vCurRightHolder t4 on t3.CustId = t4.CustId

	-- оепеоняхкю╙лн опнжемрх онрнвмнцн яеюмяс мю нярюмм╡у б ╡ярнп╡╞ опюбнбкюямхй╡б
	update t1
	set t1.RightHolderId = t4.Id
	-- select *
	from SubmWorkShare t1
		join vCurSubmWorks t2 on t1.SubmWorkId = t2.Id
		join RightHolder t3 on t1.RightHolderId = t3.Id
		join vCurRightHolder t4 on t3.CustId = t4.CustId
	
	-- ярбнпч╙лн б пнанвху рюакхжъу онрнвм╡ дюм╡ ╡г ялюпр
	exec spSubmWorksTargetCreate

	-- ярбнпч╙лн уеь дкъ нярюммэн╞ сяо╡ьмн носак╡йнбюмн╞ ╡мтнплюж╡╞ 
	exec spWorksAcceptedHashUpdate

	-- рбнпх оноепедмэнцн яеюмяс, ъй╡ ме гюгмюкх гл╡м
	drop table if exists #UnChangedObjIds
	select t2.ObjId
	into #UnChangedObjIds
	from SubmWorksAcceptedHash t1
		join Z_SubmWorkHash t2 on t1.ObjId = t2.ObjId
	where t1.HashValue = t2.HashValue

	-- бхдюкъ╙лн рбнпх онрнвмнцн яеюмрс ъйху мелю╙ яепед рбнп╡б дкъ онрнвмн╞ оепедюв╡ б пнанвху рюакхжъу
	declare @objIdsToDelete1 as dbo.typeObjIds
	insert @objIdsToDelete1 (ObjId)
	select t1.ObjId
	from SubmWork t1
		left join Z_SubmWork t2 on t1.ObjId = t2.ObjId
	where t1.SubmissionId = dbo.fnCurSubmId()
		and t2.ObjId is null
	exec spCurSubmWorksDelete @objIds = @objIdsToDelete1, @keepWorks = 0
	delete from @objIdsToDelete1

	-- бхдюкъ╙лн рбнпх онрнвмнцн яеюмрс ъй╡ ме гюгмюкх гл╡м
	declare @objIdsToDelete2 as dbo.typeObjIds
	insert @objIdsToDelete2 (ObjId) select ObjId from #UnChangedObjIds
	exec spCurSubmWorksDelete @objIds = @objIdsToDelete2, @keepWorks = 0

	-- рюй яюлн пнахлн дкъ пнанвху рюакхжэ
	exec spZ_SubmWorksDelete @objIds = @objIdsToDelete2, @keepWorks = 0
	delete from @objIdsToDelete2

	-- бхдюкъ╙лн ясосрмч ╡мтнплюж╡ч ╡г рбнп╡б онрнвмнцн яеюмяс ъй╡ гюкхьхкхяэ
	declare @objIdsToDelete3 as dbo.typeObjIds
	insert @objIdsToDelete3 (ObjId) select ObjId from vCurSubmWorks
	exec spCurSubmWorksDelete @objIds = @objIdsToDelete3, @keepWorks = 1
	delete from @objIdsToDelete3

	-- гл╡мч╙лн рбнпх онрнвмнцн яеюмяс
	update t1
	set
		  t1.Wic			= t2.Wic
		, t1.Iswc			= t2.Iswc
		, t1.Name			= t2.Name
		, t1.NameForWid		= t2.NameForWid
--		, t1.IsChanged		= 1 яРЮРСЯ КХДХЬЮ╨ЛН АЕГ ГЛЁМ
--		, t1.CreatedAt		= t2.CreatedAt
		, t1.UpdatedAt		= getdate()
	from SubmWork t1
		join Z_SubmWork t2 on t1.ObjId = t2.ObjId
	where t1.SubmissionId = dbo.fnCurSubmId()

	-- дндю╙лн дн онрнвмнцн яеюмяс  рбнпх ъйху ме аскн б оноепедм╡у яеюмяюу
	insert SubmWork (
		  SubmissionId
		, ObjId
		, Wic
		, Iswc
		, Name		
		, NameForWid
		, IsChanged
		, Status
		, CreatedAt	
		, UpdatedAt	
	)
	select
		  dbo.fnCurSubmId()		SubmissionId
		, t1.ObjId				ObjId
		, t1.Wic				Wic
		, t1.Iswc				Iswc		
		, t1.Name				Name		
		, t1.NameForWid			NameForWid
		, 0						IsChanged
		, 0						Status
		, t1.CreatedAt			CreatedAt	
		, t1.UpdatedAt			UpdatedAt
	from Z_SubmWork t1
		left join SubmWork t2 on t1.ObjId = t2.ObjId
			and t2.SubmissionId = dbo.fnCurSubmId()
		left join SubmWorksAcceptedHash t3 on t1.ObjId = t3.ObjId
	where t2.ObjId is null
		and t3.ObjId is null

	-- дндю╙лн дн онрнвмнцн яеюмяс рбнпх, ъй╡ гюгмюкх гл╡м б╡дмнямн нярюммэнцн яеюмяс
	insert SubmWork (
		  SubmissionId
		, ObjId
		, Wic
		, Iswc
		, Name		
		, NameForWid
		, IsChanged
		, Status
		, CreatedAt	
		, UpdatedAt	
	)
	select
		  dbo.fnCurSubmId()		SubmissionId
		, t1.ObjId				ObjId
		, t1.Wic				Wic
		, t1.Iswc				Iswc		
		, t1.Name				Name		
		, t1.NameForWid			NameForWid
		, 1						IsChanged
		, 0						Status
		, t1.CreatedAt			CreatedAt	
		, t1.UpdatedAt			UpdatedAt	
	from Z_SubmWork t1
		left join SubmWork t2 on t1.ObjId = t2.ObjId
			and t2.SubmissionId = dbo.fnCurSubmId()
		join Z_SubmWorkHash t3 on t1.ObjId = t3.ObjId
		join SubmWorksAcceptedHash t4 on t1.ObjId = t4.ObjId
			and t3.HashValue <> t4.HashValue
	where t2.ObjId is null

	-- дндю╙лн SubmWorkShare
	insert SubmWorkShare (
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
		t1.Id
      , t3.RightHolderId
      , t3.RhRole
      , t3.RoleForWid
      , t3.ShrPer
      , t3.ShrMec
      , getdate()
      , null
	from SubmWork t1
		join Z_SubmWork t2 on t1.ObjId = t2.ObjId
		join Z_SubmWorkShare t3 on t2.Id = t3.SubmWorkId
	where t1.SubmissionId = dbo.fnCurSubmId()

	-- дндю╙лн SubmWorkAltName
	insert SubmWorkAltName (
	    SubmWorkId
      , OrigNames
      , NameForWid
      , CreatedAt
      , UpdatedAt
	)
	select
		t1.Id
      , t3.OrigNames
      , t3.NameForWid
      , getdate()
      , null
	from SubmWork t1
		join Z_SubmWork t2 on t1.ObjId = t2.ObjId
		join Z_SubmWorkAltName t3 on t2.Id = t3.SubmWorkId
	where t1.SubmissionId = dbo.fnCurSubmId()

	-- дндю╙лн SubmWorkPerformer
	insert SubmWorkPerformer (
	   SubmWorkId
      , OrigNames
      , NameForWid
      , CreatedAt
      , UpdatedAt
	)
	select
		t1.Id
      , t3.OrigNames
      , t3.NameForWid
      , getdate()
      , null
	from SubmWork t1
		join Z_SubmWork t2 on t1.ObjId = t2.ObjId
		join Z_SubmWorkPerformer t3 on t2.Id = t3.SubmWorkId
	where t1.SubmissionId = dbo.fnCurSubmId()
	
	-- опхахпю╙лн пнанв╡ дюм╡
	--exec spZ_SubmWorksDeleteAll

	-- бхйнмс╙лн дндюрйнб╡ д╡╞
	--exec spUpdateObjIdToWicIswcFromMs
	exec spSubmChecklistUpdate
	exec spSubmWorksUpdatePostProc
end

-- exec spSubmWorksUpdate
-- select * from Z_SubmWork