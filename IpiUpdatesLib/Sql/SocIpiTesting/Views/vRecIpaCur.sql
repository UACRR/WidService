use SocIpiTesting
go

create or alter view vRecIpaCur
as
select *
from SocIpi..UpdTrans
where TransD < datefromparts(2024, 8, 31)
	and RecType = 'IPA'
-- select * from vRecIpaCur