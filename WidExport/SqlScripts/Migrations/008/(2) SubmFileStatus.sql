use SocWidSubmit
go

if not exists (select * from SubmFileStatus where Id = 4)
	insert SubmFileStatus(Id, Code, Description)
	values(4, 'Uploaded', 'Завантажений на ФТП')
go