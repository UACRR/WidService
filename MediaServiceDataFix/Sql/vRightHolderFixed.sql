use MediaSericeDataFix
go

create or alter view vRightHolderFixed
as
	select t2.*, t1.ProblemType
	from RightHolderProblemFixes t1
		join RightHolderFixed t2 on t1.CustId = t2.CustId
go

-- select * from vRightHolderFixed order by ProblemType