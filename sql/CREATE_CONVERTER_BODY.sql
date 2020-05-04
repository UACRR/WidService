
CREATE TABLE #propTable
(
	property VARCHAR(50),
)

declare @viewName varchar(100) = 'vtsk_1_MasterListBR_wpf'

INSERT INTO #propTable (property)
select CONCAT(Upper(Substring(t1.name,1,1)), SUBSTRING( t1.name, 2, LEN( t1.name ))) as cname
from sys.syscolumns t1
join sys.systypes t2 on t2.xtype = t1.xtype
where id = object_id(@viewName)


-- конвертатор

declare @className varchar(50) = 'ClientBRListModel'
select 
concat(property,' = DTC.CastInt(DTH.GetObject(obj, nameof(', @className, '.', property, '))),')
from #propTable

-- грохнуть
DROP TABLE #propTable


