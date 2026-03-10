use SocWidSubmitEx
go

exec spCreateInitialSubmission
-- select * from SubmWork where SubmissionId <> 1

exec spRightHoldersUpdate
-- select * from SubmWork where SubmissionId <> 1

exec spSubmWorksUpdate
-- select * from SubmWork where SubmissionId <> 1 order by ObjId
