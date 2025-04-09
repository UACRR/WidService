select * 
from Reports t1
	left join MediaService..Register t2 on t1.FileName = t2.FileName
where t2.RegId is null
order by t1.CreatedAt

drop table if exists #Candidates
select distinct t1.ReportId, t2.RegId
into #Candidates
from ReportLines t1
	join MediaService..RegisterItem t2 on 
			t1.LineNr	 = t2.regIItemId
		and t1.Name		 = t2.ItemName
		and t2.Performer = t2.Performer
select distinct ReportId from #Candidates order by ReportId

--select * from Reports where Id = 1101

--select * from MediaService..Register where CustId = 286473
/*
	--_FORMAT_zvit Тернопіль 1 кв. 2024 (Байрактар).xlsx
	ReportId = 28
	CustId = 286473
	select * from MediaService..Register where CustId = 286473
	select * from MediaService..RegisterItem where RegId = 6002
	select * from ReportLines where ReportId = 28

	3815, 6002, 6003

	select *
	from ReportLines t1
		left join MediaService..RegisterItem t2 on 
				t1.LineNr	 = t2.regIItemId
			and t1.Name		 = t2.ItemName
			and t1.Performer = t2.Performer
	where ReportId = 28 and RegId = 3815
*/

; with SelectedReportLines as (select * from ReportLines where ReportId = 28)
, SelectedRegisterItem as (select * from MediaService..RegisterItem where RegId = 6003)
select *
from SelectedReportLines t1
	full join SelectedRegisterItem t2 on 
			t1.LineNr	 = t2.regIItemId
		and t1.Name		 = t2.ItemName
where t1.ReportId is null or t2.regId is null
