use SocWidSubmit
go

drop table if exists RecAckStatus
go

create table RecAckStatus (
	  Code			varchar(2) not null
	, Description	nvarchar(30) not null
)
go

insert RecAckStatus (
	  Code		
	, Description
)
values 
	  ('FA', 'Прийнята')
	, ('PA', 'Частково прийнята')
	, ('RJ', 'Відхилена')
go
