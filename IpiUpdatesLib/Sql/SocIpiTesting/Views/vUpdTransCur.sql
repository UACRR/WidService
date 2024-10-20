use SocIpiTesting
go

create or alter view vUpdTransCur
as
select *
from SocIpi..UpdTrans
where TransD < datefromparts(2024, 8, 31)
-- select * from vRecIpaCur