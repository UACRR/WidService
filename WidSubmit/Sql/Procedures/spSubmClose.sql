use SocWidSubmitEx
go

create or alter procedure spSubmClose
as
begin

-- Сперш оновлюємо правовласників
	exec spRightHoldersUpdate

-- Видаляємо із поточного сеансу не готові до передачі твори
	declare @objIds dbo.typeObjIds
	insert @objIds select ObjId from vCurSubmWorks where Status = 0
	exec spCurSubmWorksDelete @objIds = @objIds, @keepWorks = 0

-- Прийняті твори переводимо в статус Завершений
	update SubmWork
	set status = 7
	where SubmissionId = dbo.fnCurSubmId()
		and Status in (3, 4, 6) -- про всяк випадок, на даному етапі такі твори після передачі в СМАРТ отримують статус 6


-- Не передані або не прийняті твори
--	drop table if exists #NotSubmittedWorkIds
--	select Id
--	into #NotSubmittedWorkIds
--	from vCurSubmWorks
--	where Status not in (6, 7) -- 7 - технічно для початкового сеансу, у робочому сеансі потрібний статус 6

-- Правовласники поточного сеансу
	drop table if exists #CurSubmRightHolder
	select t1.*, t2.CustId
	into #CurSubmRightHolder
	from vCurSubmRightHolder t1
		join RightHolder t2 on t1.RightHolderId = t2.Id

-- Завершуємо поточний сеанс
	update Submission
	set
		  EndedAt = getdate()
		, SubmissionStatusId = 7
		, UpdatedAt = getdate()
	where id = dbo.fnCurSubmId()

-- Створюємо новий сеанс
	insert Submission (
		  StartedAt
		, EndedAt
		, SubmFileName
		, RespFileName
		, ErrorFileName
		, SubmissionStatusId
		, CreatedAt
		, UpdatedAt
	)
	values (
		  getdate()			-- StartedAt
		, dbo.fnMaxDate()	-- EndedAt
		, ''				-- SubmFileName
		, ''				-- RespFileName
		, ''				-- ErrorFileName
		, 0					-- SubmissionStatusId
		, getdate()			-- CreatedAt
		, getdate()			-- UpdatedAt
	)

-- Не передані твори переносимо в новий сеанс сеанс
-- Тепер поточним є новий сеанс
-- НЕ ПЕРЕНОСИМО ЩОБ ЗБЕРЕГТИ ІНФОРМАЦІЮ ПРО ПОМИЛКИ ДЛЯ ВИКОРИСТАННЯ В ПОДАЛЬШИХ СЕАНСАХ
--	update t1
--	set SubmissionId = dbo.fnCurSubmId()
--	from SubmWork t1
--		join #NotSubmittedWorkIds t2 on t1.Id = t2.Id
--

-- Переносимо з попереднього сеансу активних на поточну дату правовласників

	-- !!! Слід перепослати правовласників сеансу на НОВИХ історичних правовласників базуючись на ObjId
	-- Твори не перепосилаємо - відбудеться в результаті оновлення творів
	insert SubmRightHolder (
		  SubmissionId
		, RightHolderId
		, SubmAsOwn
		, CreatedAt
	)
	select 
	      dbo.fnCurSubmId() -- SubmissionId
		, t2.Id             -- RightHolderId
		, t1.SubmAsOwn      -- SubmAsOwn
		, getdate()         -- CreatedAt
	from #CurSubmRightHolder t1
		join vCurRightHolder t2 on t1.CustId = t2.CustId
	where t2.IsActive = 1

-- Оновлюємо твори новоствореного сеансу
	exec spSubmWorksUpdate

end
go
