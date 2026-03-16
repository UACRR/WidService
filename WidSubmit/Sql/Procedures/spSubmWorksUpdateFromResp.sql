use SocWidSubmitEx
go

create or alter procedure spSubmWorksUpdateFromResp
as
begin
	update t3
	set
		  t3.Iswc   = t1.Iswc
		, t3.Status = dbo.fnSubmWorkStatusFromAck(t1.Status)
	from RecAck t1
		join RecWiaWiu t2 on t1.RecWiaWiuId = t2.Id
		join SubmWork t3 on t2.SubmWorkId = t3.Id
	where t3.SubmissionId = dbo.fnCurSubmId()

	update t1
	set t1.Wic = t2.Wic
	from SubmWork t1
		join SocWid..WidIswc t2 on t1.Iswc = t2.Iswc
	where t1.SubmissionId = dbo.fnCurSubmId()
		and isnull(t1.Iswc, '') <> ''
		and isnull(t1.Wic, 0) = 0

end
go

-- exec spSubmWorksUpdateFromResp
go