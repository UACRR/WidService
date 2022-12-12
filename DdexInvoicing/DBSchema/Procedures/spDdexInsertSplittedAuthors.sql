USE [DDEX]
GO

/****** Object:  StoredProcedure [dbo].[spDdexInsertSplittedAuthors]    Script Date: 12.09.2022 13:08:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER proc [dbo].[spDdexInsertSplittedAuthors](@DdexReportId int, @BlockId int, @ComposerAuthor nvarchar(2054), @sep varchar(3), @index int output)
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
GO

