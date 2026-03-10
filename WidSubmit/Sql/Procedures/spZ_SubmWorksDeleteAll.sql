use SocWidSubmitEx
go

create or alter procedure spZ_SubmWorksDeleteAll
as
begin
	delete from Z_SubmWorkHash
	delete from Z_SubmWorkShare
	delete from Z_SubmWorkAltName
	delete from Z_SubmWorkPerformer
	delete from Z_SubmWork
end
go
