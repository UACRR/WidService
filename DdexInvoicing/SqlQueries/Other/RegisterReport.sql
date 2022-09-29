declare @DdexReportId int;
declare @DdexReportingPeriodId int;

declare @year varchar, @quarter varchar, @filetype varchar, @status int, @substatus int

if not exists (select null from DdexReportingPeriod where year = @year and quarter = @quarter)
begin
	insert into DdexReportingPeriod (status, substatus, [year], [quarter]) values (@status, @substatus, @year, @quarter)
    set @DdexReportingPeriodId = SCOPE_IDENTITY();
    insert into DdexReportProcessingData(DdexReportId, DataGroup, DataName, DataValue) 
    values(@DdexReportId, 0, @DdexSourceFolder, @DdexSourceFolderValue);
end
begin
    insert into DdexReport (status, substatus, [year], [quarter], SourceUri, TargetFolder, filetype) values (@status, @substatus, @year, @quarter, '', '', @filetype)
    set @DdexReportId = SCOPE_IDENTITY();
    insert into DdexReportProcessingData(DdexReportId, DataGroup, DataName, DataValue) 
    values(@DdexReportId, 0, @DdexSourceFolder, @DdexSourceFolderValue);
end;

if not exists (select null from DdexReport where year = @year and quarter = @quarter and filetype = @filetype)
begin
    insert into DdexReport (status, substatus, [year], [quarter], SourceUri, TargetFolder, filetype) values (@status, @substatus, @year, @quarter, '', '', @filetype)
    set @DdexReportId = SCOPE_IDENTITY();
    insert into DdexReportProcessingData(DdexReportId, DataGroup, DataName, DataValue) 
    values(@DdexReportId, 0, @DdexSourceFolder, @DdexSourceFolderValue);
end;