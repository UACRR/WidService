use RadioStationReports
go

create or alter procedure spCorrectCodesInWorks
as
begin

-- брпювем╡ с ялюпр оняхкюммъ мю рб╡п ╡г ялюпр
delete t1
--select *
from MediaService..RepMSWIC t1
	left join MediaService..ObjectRight t2 on t1.ObjId = t2.ObjId
where t2.ObjId is null

-- брпювем╡ с ялюпр оняхкюммъ мю рб╡п ╡г б╡д
delete t1
--select *
from MediaService..RepMSWIC t1
	left join SocWid..WidTitle t2 on t1.Wic = t2.Wic
where t2.Wic is null

-- гаюцювс╙лн оепедюмхлх мюлх б б╡д
drop table if exists #InWid
select distinct substring(SocWorkCde, 3, len(SocWorkCde) - 2) as ObjId, Wic
into #InWid
from SocWid..WidSubmission
where SocCde = 140
	and SocWorkCde like 'MS%'

-- дндю╙лн б╡дясрм╡
insert MediaService..RepMSWIC(ObjId, Wic, DateCreate)
select t1.ObjId, t1.Wic, getdate()
from #InWid t1
	left join MediaService..RepMSWIC t2 on t1.ObjId = t2.ObjId
where t2.ObjId is null

-- бхопюбкъ╙лн меб╡пм╡
update t2
set t2.Wic = t1.Wic
--select *
from #InWid t1
	left join MediaService..RepMSWIC t2 on t1.ObjId = t2.ObjId
where t1.Wic <> t2.Wic

-- гб╡рх пюд╡н - яйхдю╙лн б мск оняхкюммъ мю рб╡п б╡д ъйе ме опнохяюме б ялюпр
update t1
set t1.Wic = null
--select *
from RadioStationReports..Works t1
	left join MediaService..RepMSWIC t2 on t1.ObjId = t2.ObjId
where t1.ObjId is not null
	and t2.ObjId is null

-- гб╡рх пюд╡н - яйхдю╙лн б мск меб╡пме оняхкюммъ мю рб╡п ялюпр
update t1
set t1.ObjId = null
--select *
from RadioStationReports..Works t1
	left join MediaService..ObjectRight t2 on t1.ObjId = t2.ObjId
where t1.ObjId is not null
	and t2.ObjId is null

-- гб╡рх пюд╡н - яйхдю╙лн б мск меб╡пме оняхкюммъ мю рб╡п б╡д гю йнднл WIC
update t1
set t1.Wic = null
--select *
from RadioStationReports..Works t1
	left join SocWid..WidTitle t2 on t1.Wic = t2.Wic
where t1.Wic is not null
	and t2.Wic is null

-- гб╡рх пюд╡н - яйхдю╙лн б мск меб╡пме оняхкюммъ мю рб╡п б╡д гю йнднл ISWC

update Works
set Iswc = null
where trim(Iswc) = ''

update t1
set t1.Iswc = null
--select *
from RadioStationReports..Works t1
	left join SocWid..WidIswc t2 on t1.Iswc = t2.Iswc
where t1.Iswc is not null
	and t2.Iswc is null

-- гб╡рх пюд╡н - б╡дмнбкч╙лн йнд б╡д ╡г ялюпр
update t1
set t1.Wic = t2.Wic
--select *
from RadioStationReports..Works t1
	join MediaService..RepMSWIC t2 on t1.ObjId = t2.ObjId
where t1.ObjId is not null
	 --and t1.Wic <> t2.Wic

update t1
set t1.ObjId = t2.ObjId
--select *
from RadioStationReports..Works t1
	join MediaService..RepMSWIC t2 on t1.ObjId = t2.ObjId
where t1.Wic is not null
	 and t1.ObjId <> t2.ObjID

end

go

-- exec spCorrectCodesInWorks