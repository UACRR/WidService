alter procedure #tmpApplyAdd (
 @updFileId int
)
as
begin
--declare @updFileId int = 259;

declare @fileName varchar(1000) = (select Name from SocWidUpdates..UpdFiles where Id = @updFileId);
declare @fileTimeStamp datetime = datetimefromparts(
	  convert(int, substring(@fileName, 4, 4))
	, convert(int, substring(@fileName, 8, 2))
	, convert(int, substring(@fileName, 10, 2))
	, convert(int, substring(@fileName, 12, 2))
	, convert(int, substring(@fileName, 14, 2))
	, convert(int, substring(@fileName, 16, 2))
	, convert(int, substring(@fileName, 18, 3))
);
declare @minTimeStamp datetime = datetimefromparts(1900, 1, 1, 0, 0, 0, 0);
declare @maxTimeStamp datetime = datetimefromparts(9999, 12, 31, 0, 0, 0, 0);

drop table if exists #tmpWics;

select Wic
into #tmpWics
from SocWidUpdates..RecSoc t1
	left join SocWid..WidTitle t2 on t1.WicCode = t2.Wic
where 
	t1.UpdFileId = @updFileId and
	t2.Wic is null;

	--select * from #tmpWics

insert SocWid..WidTitle (
	  Wic
	, WrkTtl		
	, LngCode		
	, DurHr		
	, DurMm		
	, DurSs		
	, CprDate		
	, CprNr		
	, RecInd		
	, MwDistrCat	
	, VerType		
	, VerWic		
	, ExcType		
	, ExcWic		
	, CmpType		
	, TxtMusicRel	
	, MusicArr		
	, LyrAdapt		
	, CreDate		
	, CreUid		
	, UpdDate		
	, UpdUid		
	, PdInd		
	, NonDisplay	
)
select
      t1.WicCode
	, t1.WrkTtl		
	, t1.LngCode		
	, convert(int, substring(t1.Dur, 1, 2))	
	, convert(int, substring(t1.Dur, 3, 2))		
	, convert(int, substring(t1.Dur, 5, 2))		
	, case 
		when t1.CprDate = '' or  t1.CprDate = '00000000'  or t1.CprDate = '        ' 
		then null
		else datefromparts(convert(int, substring(t1.CprDate, 1, 4)), convert(int, substring(t1.CprDate, 5, 2)), convert(int, substring(t1.CprDate, 7, 2))) 
	  end
	, t1.CprNr		
	, t1.RecInd		
	, t1.MwDistrCat	
	, t1.VerType		
	, ''		
	, t1.ExcType		
	, ''	
	, t1.CmpType		
	, t1.TxtMusicRel	
	, t1.MusicArr		
	, t1.LyrAdapt		
	, getdate()		
	, 'UACRR'	
	, getdate()		
	, 'UACRR'
	, null	
	, null
from SocWidUpdates..RecSoc t1
	join SocWid..widTitle t2 on t1.WicCode = t2.Wic
	join #tmpWics t3 on t2.Wic = t3.Wic

insert SocWid..WidTitleHist (
	  Wic
	, ValidFrom
	, ValidTo
	, WrkTtl		
	, LngCode		
	, DurHr		
	, DurMm		
	, DurSs		
	, CprDate		
	, CprNr		
	, RecInd		
	, MwDistrCat	
	, VerType		
	, VerWic		
	, ExcType		
	, ExcWic		
	, CmpType		
	, TxtMusicRel	
	, MusicArr		
	, LyrAdapt		
	, CreDate		
	, CreUid		
	, UpdDate		
	, UpdUid		
	, PdInd		
	, NonDisplay	
)
select
      t1.Wic
	, @minTimeStamp
	, @maxTimeStamp
	, WrkTtl		
	, LngCode		
	, DurHr		
	, DurMm		
	, DurSs		
	, CprDate		
	, CprNr		
	, RecInd		
	, MwDistrCat	
	, VerType		
	, VerWic		
	, ExcType		
	, ExcWic		
	, CmpType		
	, TxtMusicRel	
	, MusicArr		
	, LyrAdapt		
	, CreDate		
	, CreUid		
	, UpdDate		
	, UpdUid		
	, PdInd		
	, NonDisplay	
from SocWid..WidTitle t1
	join #tmpWics t2 on t1.Wic = t2.Wic

end
go

drop table if exists #files
select *
into #files
from SocWidUpdates..UpdFiles
--where Id >= 409

declare @fileId int;
while exists (select * from #files)
begin
	set @fileId = (select min(Id) from #files)
	print convert(varchar(100), @fileId)
	exec #tmpApplyAdd @fileId;
	delete #files where Id = @fileId
end