use SocWidSubmitEx
go

create or alter procedure spSubmClose
as
begin

-- Сперш оновлюємо правовласників
	exec spRightHoldersUpdate

-- Не передані або не прийняті твори
	drop table if exists #NotSubmittedWorkIds
	select Id
	into #NotSubmittedWorkIds
	from vCurSubmWorks
	where Status in (1, 5)

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
	declare @newSubmissionId int = (select dbo.fnCurSubmId())

	update t1
	set SubmissionId = @newSubmissionId
	from SubmWork t1
		join #NotSubmittedWorkIds t2 on t1.Id = t2.Id

-- Переносимо з попереднього сеансу активних на поточну дату правовласників

	-- !!! Слід перепослати правовласників сеансу на НОВИХ історичних правовласникіф базуючись на ObjId
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

end
go
