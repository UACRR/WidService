use SocWidSubmit
go

create or alter procedure spMainFileExchangeSelect
as
begin
	select
		  t1.Id					as SubmFileId
		, t2.Id					as SubmFileGroupId
		, t2.Name				as SubmFileGroupName
		, t1.Name				as SubmFileName
		, isnull(t4.Name, '')   as RespFileName
		, t1.SubmFileStatus		as SubmFileStatus
	from SubmFile t1
		left join WidSubmGroup t2 on t1.WidSubmGroupId = t2.Id
		left join RecHdrRsp t3 on t1.Name = t3.FileNameRef
		left join RespFile t4 on t3.RespFileId = t4.Id
	order by t1.Name
end
go



