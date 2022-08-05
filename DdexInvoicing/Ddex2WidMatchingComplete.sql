declare @DdexReportingPeriodId int = 2;
declare @displayartistname varchar(1000);
declare curDisplayArtists cursor for   
select displayartistname 
from [vDdexRecordSuEx] t1
where DdexReportId in (select Id from DdexReport where DdexReportingPeriodId = @DdexReportingPeriodId) and
	not exists(
		select null 
		from Ddex2WidMatch 
		where ddexReportId = t1.ddexreportid 
			and blockid = t1.blockid 
				and salestransactionid = t1.salestransactionid
		)
order by NetRevenue desc
  
open curDisplayArtists  
  
fetch next from curDisplayArtists   
into @displayartistname  
  
while @@fetch_status = 0  
begin  
    exec spDdex2WidMatching 2, @displayartistname
	fetch next from curDisplayArtists   
	into @displayartistname  
end   
close curDisplayArtists;  
deallocate curDisplayArtists;  


--delete from Ddex2WidMatch