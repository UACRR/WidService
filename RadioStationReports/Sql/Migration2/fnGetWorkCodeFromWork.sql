use RadioStationReports
go

create or alter function fnGetWorkCodeFromWork
(
	  @foundIn char(1)
	, @objId int
	, @wic int
)
returns varchar(100)
as
begin
	return 
		case 
			when @foundIn = 'M'
				then concat('M', @objId)
			when @foundIn = 'W'
				then concat('W', @wic)
			else ''
		 end			

end
GO

