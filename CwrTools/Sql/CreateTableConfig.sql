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
	, ('InputQueuePath', 'D:\OlegM\CWR\InputQueue')
	, ('OutputQueuePath', 'D:\OlegM\CWR\OutputQueue')
	, ('InputFilesPath', 'D:\OlegM\CWR\InputFiles')
	, ('OutputFilesPath', 'D:\OlegM\CWR\OutputFiles')


go