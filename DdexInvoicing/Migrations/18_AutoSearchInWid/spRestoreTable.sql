use AutoSearch
go

create or alter procedure spRestoreTable
	@tableName varchar(100)
as
begin
	
	if object_id(@tableName) is null
	begin
		declare @sql1 nvarchar(1000) = 'select * into @tableName from Back_@tableName'
		set @sql1 = replace(@sql1, '@tableName', @tableName)
		exec sp_executesql @sql1
	end

	if object_id(@tableName) is not null
	begin
		declare @sql2 nvarchar(1000) = 'drop table if exists Back_@tableName'
		set @sql2 = replace(@sql2, '@tableName', @tableName)
		exec sp_executesql @sql2	
	end
	
end

/*
select * into Back_ExtraTargetWorksWid from ExtraTargetWorksWid
drop table ExtraTargetWorksWid
exec spRestoreTable 'ExtraTargetWorksWid'
select * from ExtraTargetWorksWid
*/

