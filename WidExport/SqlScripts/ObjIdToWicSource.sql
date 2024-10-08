use SocWidSubmit
go

drop table if exists ObjIdToWicSource
go

create table ObjIdToWicSource (
	  Id int primary key not null
	, Code varchar(20) not null
	, Description nvarchar(100) not null
)

insert ObjIdToWicSource
values
	  (1, 'RepMSWIC', 'Імпорт творів з WID')
	, (2, 'MediaTrack', 'Створено в локальній базі')
	, (3, 'SubmitExists', 'Існує в WID у відповідності до реакції на публікацію')
	, (4, 'SubmitAdded', 'Результат публікації в WID')
	, (5, 'DciAuto', 'Із звіту DCI автоматично')
	, (6, 'DciManual', 'Із звіту DCI в ручну')
go



