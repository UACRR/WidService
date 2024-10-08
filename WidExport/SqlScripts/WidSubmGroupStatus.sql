use SocWidSubmit
go

drop table if exists WidSubmGroupStatus
go

create table WidSubmGroupStatus (
	  Id			int primary key
	, Code			varchar(20) not null
	, Description	nvarchar(50) not null
)
go

insert WidSubmGroupStatus (
	  Id		
	, Code		
	, Description
)
values 
	  (0, 'Created'  , 'Створений')
	, (1, 'FileCreated', 'Файл створений'	)
	, (2, 'FileSubmitted', 'Файл Переданий'	)
	, (3, 'Responded', 'Відповідь отримана'	)
	, (4, 'Completed', 'Обробка завершена'	)
go

