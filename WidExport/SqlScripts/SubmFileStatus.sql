use SocWidSubmit
go

drop table if exists SubmFileStatus
go

create table SubmFileStatus (
	  Id			int primary key
	, Code			varchar(20) not null
	, Description	nvarchar(50) not null
)
go

insert SubmFileStatus (
	  Id		
	, Code		
	, Description
)
values 
	  (0, 'Created'  , 'Створений')
	, (1, 'Submitted', 'Переданий'	)
	, (2, 'Responded', 'Відповідь отримана'	)
	, (3, 'Declined',  'Файл відхилений'	)
go

