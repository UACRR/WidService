use MediaService
go

delete from SeekObject where ObjId is null
delete from SeekObject where Name is null
delete from SeekObject where trim(Name) = ''
update SeekObject set Name = trim(Name) where trim(Name) <> Name

declare @str varchar(255)

declare @i int
set @str = ''
set @i = 0
while @i <= 31
begin
set @str = @str + '|' + char(@i)
set @i = @i + 1
end

--select @str

SELECT * from SeekObject
WHERE Name LIKE '%[^' + @str + ']%' escape '|'

'ÂÎËÈÍÑÜÊÈÉ ÍÀÐÎÄÍÈÉ ÕÎÐ'

select * 
from SeekObject
where trim(Name) <> Name

select codeI, ObjId, Name, count(*), max(objId)
from SeekObject
where codeI = 1
group by codeI, ObjId, Name
having count(*) > 1
order by count(*) desc

select count(*)
from ObjectRight t1
	left join SeekObject t2 on t1.Name = t2.Name
		and t2.codeI = 1
where t2.Name is not null