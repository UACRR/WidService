use SocWidSubmitEx
go

create or alter procedure spCreateInitialSubmission
as
begin

-- Виконується лише для порожньої БД
	if exists (select null from Submission) return

-- Submission
	insert Submission (
		  StartedAt
		, EndedAt
		, SubmFileId
		, RespFileId
		, SubmissionStatusId
		, CreatedAt
		, UpdatedAt
	)
	select
		  datefromparts(1900, 1, 1) as StartedAt
		, getdate()					as EndedAt
		, null						as SubmFileId
		, null						as RespFileId
		, 9						as SubmissionStatusID -- finished
		, getdate()					as CreatedAt
		, null						as UpdatedAt

	declare @submId int = scope_identity()
	print @submId

-- Видаляємо дані
	--delete from SubmWorkShare
	--delete from SubmWorkAltName
	--delete from SubmWorkPerformer
	--delete from SubmWork
	--delete from SubmRightHolder
	--delete from RightHolder
-- RightHolder


	insert RightHolder (
		  ValidFrom		
		, ValidTo		
		, CreatedAt		
		, CustId		
		, IpBaseNr		
		, IpNameNr		
		, Name			
		, FstName		
		, NameForWid	
		, FstNameForWid	
		, IsOwn			
		, IsActive		
		, HasIpiAgreePer
		, HasIpiAgreeMec
	)
	select
		  datefromparts(1900, 1, 1)		as ValidFrom		
		, datefromparts(9999, 12, 31)	as ValidTo		
		, getdate()						as CreatedAt		
		, t1.CustId						as CustId		
		, t1.IpBaseNr					as IpBaseNr		
		, t1.IpNameNr					as IpNameNr		
		, t2.Name						as Name			
		, t2.FstName					as FstName		
		, t2.NameForWid					as NameForWid	
		, t2.FstNameForWid				as FstNameForWid	
		, 1								as IsOwn			
		, 1								as IsActive		
		, 1								as HasIpiAgreePer
		, 1								as HasIpiAgreeMec
	from SocWidSubmit..WidSubmGroupParty t1
		join vCustomerNamesForWid t2 on t1.CustId = t2.CustId

-- select * from RightHolder

-- SubmRightHolder
	insert SubmRightHolder (
		  SubmissionId
		, RightHolderId
		, SubmAsOwn
		, CreatedAt
	)
	select
		  @submId	as SubmissionId
		, t2.Id		as RightHolderId
		, 1			as SubmAsOwn
		, getdate() as CreatedAt
--		select * 
	from SocWidSubmit..WidSubmGroupParty t1
		join RightHolder t2 on t1.CustId = t2.CustId
			 and t2.ValidFrom = datefromparts(1900, 1, 1)

--select * from RightHolder

-- SubmWork
	insert SubmWork (
		  SubmissionId
		, ObjId
		, Wic
		, Name
		, NameForWid
		, IsChanged
		, CreatedAt
		, UpdatedAt
	)
	select
		  @submId			as SubmissionId
		, t1.ObjId			as ObjId
		, t2.Wic			as Wic
		, t3.LocalName		as Name
		, t3.WidName		as NameForWid
		, 0					as IsChanged
		, getdate()			as CreatedAt
		, null				as UpdatedAt
	from SocWidSubmit..WidSubmGroupWork t1
		left join SocWidSubmit..ObjIdToWic t2 on t1.ObjId = t2.ObjId
		join SocWidSubmit..WidSubmGroupWorkName t3 on t1.ObjId = t3.ObjId
			and t3.IsMain = 1
	where t1.Status = 10

-- SubmWorkShare
	insert SubmWorkShare (
		  SubmWorkId
		, RightHolderId
		, IpBaseNr
		, IpNameNr
		, ShrPer
		, ShrMec
		, CreatedAt
		, UpdatedAt
	)
	select
		  t2.Id			as SubmWorkId
		, t3.Id			as RightHolderId
		, t1.IpBaseNr	as IpBaseNr
		, t1.IpNameNr	as IpNameNr
		, t1.PerShr		as ShrPer
		, t1.MecShr		as ShrMec
		, getdate()		as CreatedAt
		, null			as UpdatedAt
	from SocWidSubmit..WidSubmGroupWorkShare t1
		join SubmWork t2 on t1.ObjId = t2.ObjId
		join RightHolder t3 on t1.CustId = t3.CustId
			and t3.ValidFrom = datefromparts(1900, 1, 1)

-- SubmWorkAltName
	insert SubmWorkAltName (
		  SubmWorkId
		, Name
		, NameForWid
		, CreatedAt
		, UpdatedAt
	)
	select
		  t2.Id			as SubmWorkId
		, t1.LocalName	as Name
		, t1.WidName	as NameForWid
		, getdate()		as CreatedAt
		, null			as UpdatedAt
	from SocWidSubmit..WidSubmGroupWorkName t1
		join SubmWork t2 on t1.ObjId = t2.ObjId

-- SubmWorkPerformer
	insert SubmWorkPerformer (
		  SubmWorkId
		, Name
		, NameForWid
		, CreatedAt
		, UpdatedAt
	)
	select
		  t2.Id			as SubmWorkId
		, t1.LocalName	as Name
		, t1.WidName	as NameForWid
		, getdate()		as CreatedAt
		, null			as UpdatedAt
	from SocWidSubmit..WidSubmGroupWorkPerformer t1
		join SubmWork t2 on t1.ObjId = t2.ObjId

-- Next Submission
	insert Submission (
		  StartedAt
		, EndedAt
		, SubmFileId
		, RespFileId
		, SubmissionStatusID
		, CreatedAt
		, UpdatedAt
	)
	select
		  dateadd(S, 1, getdate())						as StartedAt
		, cast(datefromparts(9999, 12, 31) as datetime)	as EndedAt
		, null											as SubmFileId
		, null											as RespFileId
		, 0												as SubmissionStatusID -- початковий
		, getdate()										as CreatedAt
		, null											as UpdatedAt

	declare @nextSubmId int = scope_identity()
	print @nextSubmId

	insert SubmRightHolder (
		  SubmissionId
		, RightHolderId
		, SubmAsOwn
		, CreatedAt
	)
	select
		  @nextSubmId as SubmissionId
		, Id		  as RightHolderId
		, SubmAsOwn	  as SubmAsOwn
		, getdate()   as CreatedAt
--		select * 
	from SubmRightHolder
	where SubmissionId = @submId

end
go

-- exec spCreateInitialSubmission