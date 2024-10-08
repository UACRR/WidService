use SocWidSubmit
go

drop table if exists RecMsgType
go

create table RecMsgType (
	  Code			varchar(2) not null
	, Description	nvarchar(30) not null
)
go

insert RecMsgType (
	  Code		
	, Description
)
values 
	  ('F', 'Поле відхилене')
	, ('R', 'Запис відхилений')
	, ('T', 'Транзакція відхилена')
	, ('G', 'Група відхилена')
	, ('E', 'Файл відхилений')
go
