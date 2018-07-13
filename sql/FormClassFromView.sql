begin
declare @viewName varchar(100) = 'vTsk_vBRLicense'
--select '01 public class ' + @viewName 
--union
--select '02 {' 
--union
select CONCAT(
'public  ', 
case t2.name when 'date' then 'DateTime'
			 when 'money' then 'decimal'
			 when 'bit' then 'bool'
			 when 'numeric' then 'decimal'
			 when 'varchar' then 'string'
			 when 'char' then 'string'
			 else t2.name
	end
, '  ',t1.name, ' {get; set;}' )

from sys.syscolumns t1
join sys.systypes t2 on t2.xtype = t1.xtype
where id = object_id(@viewName)
--union
--select  '04 }'

end