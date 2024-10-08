use SocWidSubmit
go

drop table if exists WidSubmGroupWorkStatus
go

create table WidSubmGroupWorkStatus (
	  Id			int primary key
	, Code			varchar(20) not null
	, Description	nvarchar(50) not null
)
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
