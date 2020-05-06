create function  [dbo].Month_name  (@month int)
returns  varchar(20)
as
begin
if (@month>12) set @month=1
if (@month<1) set @month=1


return case @month
					when 12 then 'Грудень' 
					when 1 then 'Січень' 
					when 2 then 'Лютий' 
					when 3 then 'Березень' 
					when 4 then 'Квітень' 
					when 5 then 'Травень' 
					when 6 then 'Червень' 
					when 7 then 'Липень' 
					when 8 then 'Серпень' 
					when 9 then 'Вересень' 
					when 10 then 'Жовтень' 
					when 11 then 'Листопад' 
end
end
