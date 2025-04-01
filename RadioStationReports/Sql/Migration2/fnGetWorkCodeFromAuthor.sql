use RadioStationReports
go

create or alter function fnGetWorkCodeFromAuthor
(
	  @foundIn char(1)
	, @foundCde int
)
returns varchar(100)
as
begin
	return concat(@foundIn, @foundCde)
end
GO

