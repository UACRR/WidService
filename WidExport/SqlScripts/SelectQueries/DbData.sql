use SocWidSubmit
go

insert ObjIdToWicSource
values
	  (1, 'RepMSWIC', 'Імпорт творів з WID')
	, (2, 'MediaTrack', 'Створено в локальній базі')
	, (3, 'SubmitExists', 'Існує в WID у відповідності до реакції на публікацію')
	, (4, 'SubmitAdded', 'Результат публікації в WID')
	, (5, 'DciAuto', 'Із звіту DCI автоматично')
	, (6, 'DciManual', 'Із звіту DCI в ручну')
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

insert SubmFileStatus (
	  Id		
	, Code		
	, Description
)
values 
	  (0, 'Created'  , 'Створений')
	, (1, 'Submitted', 'Переданий'	)
	, (2, 'Responded', 'Відповідь отримана'	)
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

insert WidSubmGroupWorkStatus (
	  Id		
	, Code		
	, Description
)
values 
	  (0, 'Unprocessed'	, 'Не оброблено'			)
	, (1, 'InWork'		, 'На розгляді'				)
	, (2, 'Postponed'	, 'Відкладено'				)
	, (3, 'Accepted'	, 'Звтверждено'				)
	, (4, 'Sent'		, 'Надіслано'				)
	, (5, 'Approved'	, 'Прийнято'				)
	, (6, 'Rejected'	, 'Відхилено'				)
	, (7, 'PartApproved', 'Прийнято з зауваженнями'	)
	, (8, 'AlreadyInWid', 'Існує в WID'				)
	, (9, 'ReSent'		, 'Надіслано повторно'		)
	, (10,'Completed'	, 'Передача завершена'		)
go
