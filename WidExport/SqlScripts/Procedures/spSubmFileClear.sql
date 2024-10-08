use SocWidSubmit
go

create or alter procedure spSubmFileClear
	@submFileId int
as
begin
delete from RecSsr where SubmFileId = @submFileId
delete from RecOsr where SubmFileId = @submFileId
delete from RecSip where SubmFileId = @submFileId
delete from RecOip where SubmFileId = @submFileId
delete from RecAlt where SubmFileId = @submFileId
delete from RecPer where SubmFileId = @submFileId
delete from RecWia where SubmFileId = @submFileId
delete from RecGrh where SubmFileId = @submFileId
delete from RecGrt where SubmFileId = @submFileId
delete from RecHdr where SubmFileId = @submFileId
delete from RecTrl where SubmFileId = @submFileId
end
go

-- exec spSubmFileClear 1
