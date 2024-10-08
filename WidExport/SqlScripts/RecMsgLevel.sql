use SocWidSubmit
go

drop table if exists RecMsgLevel
go

create table RecMsgLevel (
	  Code			varchar(2) not null
	, Description	nvarchar(30) not null
)
go

insert RecMsgLevel (
	  Code		
	, Description
)
values 
	  ('F', 'Поле')
	, ('R', 'Запис')
	, ('T', 'Транзакція')
	, ('G', 'Група')
	, ('E', 'Файл')
go
