select objId, trim(value) 
from ObjectRight
	cross apply string_split(author, ',')
order by trim(value) 


select * from string_split('a, b, c', ',')
