use SocWidSubmit
go

if not exists (select * from WidSubmGroupWorkStatus where Id = 11)
	insert WidSubmGroupWorkStatus(Id, Code, Description)
	values(11, 'Uploaded', 'Завантажений на ФТП')
go