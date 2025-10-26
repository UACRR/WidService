use CWR
go

drop table if exists ProblemTypes
create table ProblemTypes
(
	  Code int primary key
	, value nvarchar(64) not null
)

insert ProblemTypes
values
	  (1, 'Не визначена роль правовласника')
	, (2, 'Проценти з Пуб Перевищують 100' )
	, (3, 'Проценти з Мех Перевищують 100' )
	, (4, 'Видавці вказані двічі'		   )
	, (5, 'Автори вказані двічі'		   )
	, (6, 'Невірний код ISW'			   )
	, (7, 'Відсутня назва твору'		   )
