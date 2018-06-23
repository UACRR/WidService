select concat( '"', name, '",' )
from sys.sysobjects
where Type='U'
and name not like '[_][_]%'
order by name

