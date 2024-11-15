--select *
update t1
set t1.RadioStationId = t2.Id
from Reports t1
	left join RadioStations t2 on t1.FileName like concat('%', t2.Name, '%')

select t2.Name, t1.FileName, t1.FilePath
from Reports t1
	join RadioStations t2 on t1.RadioStationId = t2.Id
order by t2.Name