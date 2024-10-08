use SocWidSubmit
go

if not exists (select null from SubmFileStatus where Id = 3)
	insert SubmFileStatus values (3, 'Declined',  'Файл відхилений')