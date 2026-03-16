use SocWidSubmitEx
go

create or alter function fnCurSubmFileName()
returns nvarchar(256)
as
begin
	return (select SubmFileName from Submission where Id = dbo.fnCurSubmId())
end
go

-- select dbo.fnCurSubmFileName()

D:\UACRR\WID_Service\SubmissionWorkFiles\OutFiles\WID2026031110241823300140.021 -- created
                                                  WID2026031110241823300140.021 -- in db
												  WID2023030609244604300140.021