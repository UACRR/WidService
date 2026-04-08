use SocWidSubmitEx
go

create or alter function fnCurDate()
returns date
as
begin
	return getdate()
end
go

use SocWidSubmitEx
go

create or alter function fnCurErrorFileName()
returns nvarchar(256)
as
begin
	return (select ErrorFileName from Submission where Id = dbo.fnCurSubmId())
end
go


use SocWidSubmitEx
go

create or alter function fnCurRespFileName()
returns nvarchar(256)
as
begin
	return (select RespFileName from Submission where Id = dbo.fnCurSubmId())
end
go


use SocWidSubmitEx
go

create or alter function fnCurSubmFileName()
returns nvarchar(256)
as
begin
	return (select SubmFileName from Submission where Id = dbo.fnCurSubmId())
end
go


use SocWidSubmitEx
go

create or alter function fnCurSubmId()
returns int
as
begin
	return (select Id from Submission where EndedAt = dbo.fnMaxDate())
end
go

use SocWidSubmitEx
go

create or alter function fnFullName(
	   @name nvarchar(256)
	,  @fstName varchar(256)
)

returns nvarchar(256)
as
begin
	return left(trim(concat(@name, ' ', @fstName)), 256)
end
go

use SocWidSubmitEx
go

create or alter function fnGetMsRightHolderRoleName
(
	@RhRole int
)
returns nvarchar(max)
as
begin
	return (select concat(codeI, ' - ',  Name) from MediaService..CreativeRoleType where CodeI = @RhRole)
end
go



use SocWidSubmitEx
go

create or alter function fnGetMsRightHolderTypeName
(
	@RhType int
)
returns nvarchar(max)
as
begin
	return (select concat(codeI, ' - ',  Name) from MediaService..RHolderType where CodeI = @RhType)
end
go



use SocWidSubmitEx
go

create or alter function fnGetWidRole
(
	@RhType int, @RhRole int
)
returns varchar(2)
as
begin
	return case 
		when @RhType = 1 then
			case
				when @RhRole = 1 then 'A'
				when @RhRole = 2 then 'C'
				when @RhRole = 5 then 'A'
				when @RhRole = 6 then 'A'
				when @RhRole = 7 then 'C'
				when @RhRole = 10 then 'CA'
				else ''
			end
		when @RhType = 3 and @RhRole in (8, 9) then 'E'
		else ''
	end
end
go

use SocWidSubmitEx
go

create or alter function fnMaxDate()
returns date
as
begin
	return (select datefromparts(9999, 12, 31))
end
go

use SocWidSubmitEx
go

create or alter function fnMinDate()
returns date
as
begin
	return (select datefromparts(1900, 1, 1))
end
go

use SocWidSubmitEx
go

create or alter function fnPrevDate()
returns date
as
begin
	return (select dateadd(day, -1, getdate()))
end
go

use SocWidSubmitEx
go

create or alter function fnPrevSubmId()
returns int
as
begin
	declare @prevSubmMaxDateTime datetime = (select EndedAt from Submission where EndedAt <> dbo.fnMaxDate())
	return (select Id from Submission where EndedAt = @prevSubmMaxDateTime)
end
go

use SocWidSubmitEx
go

create or alter function fnPrevSubmIdEx(
	@curSubmId int
)
returns int
as
begin
	declare @curSubmEndedAt datetime = (select EndedAt from Submission where Id = @curSubmId)
	declare @prevSubmEndedAt datetime = (select max(EndedAt) from Submission where EndedAt < @curSubmEndedAt)
	if( @prevSubmEndedAt is null) return @curSubmId
	declare @prevSubmId int = (select Id from Submission where EndedAt = @prevSubmEndedAt)
	return (select Id from Submission where Id = @prevSubmId)
end
go

use SocWidSubmitEx
go

create or alter function fnPrevSubmWorkId(
	@curSubmWorkId int
)
returns int
as
begin
	declare @curSubmId int = (select SubmissionId from SubmWork where Id = @curSubmWorkId)
	declare @prevSubmId int = (select dbo.fnPrevSubmIdEx(@curSubmId))
	return (
		select t2.Id
		from SubmWork t1
			join SubmWork t2 on t1.ObjId = t2.ObjId
				and t2.SubmissionId = @prevSubmId
		where t1.Id = @curSubmWorkId
			
	)
end
go

use SocWidSubmitEx
go

create or alter function fnSubmFileExists()
returns bit
as
begin
	declare @retVal bit
	if (select SubmFileName from Submission where Id = dbo.fnCurSubmId()) <> ''
		set @retVal = 1
	else
		set @retVal = 0

	return @retVal
end
go

use SocWidSubmitEx
go

create or alter function fnSubmHasReadyWorks()
returns bit
as
begin
	declare @retVal bit
	if exists (select null from vCurSubmWorks where Status = 1)
		set @retVal = 1
	else
		set @retVal = 0

	return @retVal
end
go

use SocWidSubmitEx
go

create or alter function fnSubmWorkStatusFromAck (
	@ackStatus char(2)
)
returns int
as
begin
	return case
		when @ackStatus = 'FA' then 3 -- ACCEPTED
		when @ackStatus = 'PA' then 4 -- ACCEPTED_WARNINGS
		when @ackStatus = 'RJ' then 5 -- REJECTED
		else -1
	end;
end
go

