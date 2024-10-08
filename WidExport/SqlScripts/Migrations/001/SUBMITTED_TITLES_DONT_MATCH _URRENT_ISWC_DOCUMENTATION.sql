declare @ErrId int = 23

select *
from RespFileErr t1
	join RecWia t2 on t1.SubmRecId = t2.Id
where RespFileErr = @ErrId