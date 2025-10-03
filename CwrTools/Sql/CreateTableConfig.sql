use CWR
go

drop table if exists Config
create table Config (
	  ParamName varchar(64)
	, ParamValue nvarchar(max)
)

insert Config
values 
	  ('FilesRootFolder', 'D:\OlegM\CWR')
	, ('InputQueuePath', 'D:\OlegM\CWR\Надходження')
	, ('OutputQueuePath', 'D:\OlegM\CWR\До відправки')
	, ('InputFilesPath', 'D:\OlegM\CWR\Отримані файли')
	, ('OutputFilesPath', 'D:\OlegM\CWR\Відправлені файли')


go