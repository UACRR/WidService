set nocount on;  
/*
if object_id('spDdexInsertSplittedAuthors') is not null
begin
    drop proc vDdexInsertSplittedAuthors
end
go

alter proc spDdexInsertSplittedAuthors(@DdexReportId int, @BlockId int, @ComposerAuthor nvarchar(2054), @sep varchar(3), @index int output)
as
begin
	declare @startPos int, @endPos int, @authorName varchar(2054);

	set @startPos = 1;
	set @endPos = charindex(@sep, @ComposerAuthor, @startPos);
	while @endPos <> 0
	begin
		set @authorName = substring(@ComposerAuthor, @startPos, @endPos - @startPos);
		insert into DdexAuthorsSplitted values(@DdexReportId, @BlockId, @index, @authorName);
		set @index = @index + 1;
		set @startPos = @endPos + 1;
		set @endPos = charindex(@sep, @ComposerAuthor, @startPos);
		if @endPos = 0
		begin
			set @authorName = substring(@ComposerAuthor, @startPos, len(@ComposerAuthor) - @startPos + 1);
			insert into DdexAuthorsSplitted values(@DdexReportId, @BlockId, @index, @authorName);
			set @index = @index + 1;
		end
	end
end
go
*/

create proc spDdexCreateAuthorsSplitted(@DdexReportId int)
as
begin
declare @BlockId int, @ComposerAuthor nvarchar(2054);  
declare @index int = 1;
  
declare authorsCursor cursor for   
select BlockId, ComposerAuthor from vAuthorsForIdentification
where DdexReportId = @DdexReportId  
order by cast(BlockId as int);  

delete from DdexAuthorsSplitted where DdexReportId = @DdexReportId
  
open authorsCursor  
  
fetch next from authorsCursor   
into @BlockId, @ComposerAuthor
  
while @@fetch_status = 0  
begin  
        if @ComposerAuthor like '%|%'
			exec spDdexInsertSplittedAuthors @DdexReportId, @BlockId, @ComposerAuthor, '|', @index output;
		else if @ComposerAuthor like '%/%'
			exec spDdexInsertSplittedAuthors @DdexReportId, @BlockId, @ComposerAuthor, '/', @index output;
		else if @ComposerAuthor like '%;%'
			exec spDdexInsertSplittedAuthors @DdexReportId, @BlockId, @ComposerAuthor, ';', @index output;
		else if @ComposerAuthor like '%:%'
			exec spDdexInsertSplittedAuthors @DdexReportId, @BlockId, @ComposerAuthor, ':', @index output;
		else
		begin
			insert into DdexAuthorsSplitted values(@DdexReportId, @BlockId, @index, @ComposerAuthor);
			set @index = @index + 1;
		end
		
		fetch next from authorsCursor   
		into @BlockId, @ComposerAuthor
end   
close authorsCursor;  
deallocate authorsCursor;
end  

exec spDdexCreateAuthorsSplitted 1
select * from DdexAuthorsSplitted