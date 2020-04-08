begin
declare @viewName varchar(100) = 'vtsk_3_R_04'
select CONCAT(
'public  ', 
case t2.name when 'date' then 'DateTime'
			 when 'datetime' then 'DateTime'
			 when 'money' then 'decimal'
			 when 'smallint' then 'short'
			 when 'bit' then 'bool'
			 when 'numeric' then 'decimal'
			 when 'varchar' then 'string'
			 when 'char' then 'string'
			 when 'nvarchar' then 'string'
			 else t2.name
	end

, case when t1.isnullable = 1 and t2.name not in ( 'varchar', 'char' ) then '?  ' else '  ' end, Upper(Substring(t1.name,1,1)), SUBSTRING( t1.name, 2, LEN( t1.name )), ' {get; set;}' )

from sys.syscolumns t1
join sys.systypes t2 on t2.xtype = t1.xtype
where id = object_id(@viewName)
end