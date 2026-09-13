use SocIpiEx
go

create or alter procedure spUpdate
as
declare @from char(8) = (select Name from LastProcessedUpdateFile)
if @from is null
begin
	exec spUpdateAll
end
else
begin
	exec spUpdateChanged
end
go

-- exec spUpdate

