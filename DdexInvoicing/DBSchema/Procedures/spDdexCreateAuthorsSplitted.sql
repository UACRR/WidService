USE [DDEX]
GO

/****** Object:  StoredProcedure [dbo].[spDdexCreateAuthorsSplitted]    Script Date: 12.09.2022 13:07:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER proc [dbo].[spDdexCreateAuthorsSplitted](@DdexReportId int, @firstBlockId int, @lastBlockId int)
as
begin
declare @BlockId int, @ComposerAuthor nvarchar(2054);  
declare @index int = 1;
  
declare authorsCursor cursor for   
select BlockId, ComposerAuthor from vAuthorsForIdentification 
where DdexReportId = @DdexReportId  and cast(BlockId as int) >= @firstBlockId and cast(BlockId as int) < @lastBlockId
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
GO

