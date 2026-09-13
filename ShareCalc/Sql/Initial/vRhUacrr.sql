use ShareCalc
go

create or alter view vRhUacrr
as
	select t2.CustId, t1.IpBaseNr, t3.Name
	from AgreeRhUacrr t1
		join MediaService..RightHolder t2 on t1.IpBaseNr = t2.InterCode
		join MediaService..vCustomerNamesFull t3 on t2.CustId = t3.CustId
go
