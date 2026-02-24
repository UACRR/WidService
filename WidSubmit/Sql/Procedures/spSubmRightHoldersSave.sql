use SocWidSubmitEx
go

create or alter procedure spSubmRightHoldersSave
	@guid uniqueidentifier
as
begin
--truncate table Z_SubmRightHolder
--declare @guid uniqueidentifier = 'D4D436D6-6603-4116-B5C6-2DC7541ED33A'
-- Видалення
	delete t1
	from SubmRightHolder t1
		join vCurSubmRightHolder t2 on t1.Id = t2.Id
		left join Z_SubmRightHolder t3 on t2.RightHolderId = t3.RightHolderId
			and t3.Guid = @guid
	where t3.RightHolderId is null

-- Оновлення
	update t1
	set t1.SubmAsOwn = t3.SubmAsOwn
	from SubmRightHolder t1
		join vCurSubmRightHolder t2 on t1.Id = t2.Id
		left join Z_SubmRightHolder t3 on t2.RightHolderId = t3.RightHolderId
			and t3.Guid = @guid
	where t3.RightHolderId is null

-- Додавання
	insert SubmRightHolder(
		SubmissionId
      , RightHolderId
      , SubmAsOwn
      , CreatedAt
	)
	select
		dbo.fnCurSubmId()
      , t2.RightHolderId
      , t2.SubmAsOwn
      , dbo.fnCurDate()
	from vCurSubmRightHolder t1
		right join Z_SubmRightHolder t2 on t1.RightHolderId = t2.RightHolderId
			and Guid = @guid
	where t1.RightHolderId is null

-- Видалення робочої інформації
	delete Z_SubmRightHolder
	where Guid = @guid

end
go

--select * from Z_SubmRightHolder where RightHolderId =  288337