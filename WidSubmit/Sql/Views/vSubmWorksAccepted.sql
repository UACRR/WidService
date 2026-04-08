use SocWidSubmitEx
go

create or alter view vSubmWorksAccepted
as
	-- л╡ярхрэ рбнпх г нярюммэнцн яеюмяс б ъйнлс рб╡п асб опхимърхи б╡д
	with SubmWorksOrdered as (
		select 
			  t1.SubmissionId									as SubmissionId
			, t1.Id												as SubmWorkId
			, t1.ObjId											as ObjId
			, row_number() 
				over (
					  partition by t1.SubmissionId, t1.ObjId
					  order by t2.EndedAt desc
				)												as SeqNr
		from SubmWork t1
			join Submission t2 on t1.SubmissionId = t2.Id
		where t2.EndedAt <> dbo.fnMaxDate()
			and t1.Status = 7
	)
	select t1.*
	from SubmWork t1
		 join SubmWorksOrdered t2 on t1.Id = t2.SubmWorkId
	where t2.SeqNr = 1
go

